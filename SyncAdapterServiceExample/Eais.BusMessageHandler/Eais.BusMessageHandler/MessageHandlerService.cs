namespace BusMessageHandler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Configuration;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using IIS.University.Tools;
    using MessageHandlers;
    using Synchronization.Objects;
    using Synchronization.Utils;

    public class MessageHandlerService
    {
        private const string MessageHeader = "BusMessageHandlerService: ";

        protected IDataService DataService = DataServiceFactory.SyncDataService;

        public void Process()
        {
            var lcs = LoadingCustomizationStruct.GetSimpleStruct(
                typeof(SyncLogItem),
                SyncLogItem.Views.SyncLogItemE);
            lcs.LimitFunction = FunctionBuilder.BuildEquals<SyncLogItem>(i => i.Status, tSyncStatus.Invalid);

            if (DataService.GetObjectsCount(lcs) > 0)
            {
                LogService.LogWarn(
                    $"{MessageHeader}Обнаружено входящее сообщение, обработанное с ошибкой. Дальнейшее продолжение обработки невозможно! Исправьте сообщение и вручную обновите его статус.");
                return;
            }

            lcs.LimitFunction =
                FunctionBuilder.BuildAnd(
                    FunctionBuilder.BuildEquals<SyncLogItem>(i => i.Status, tSyncStatus.Prepared),
                    FunctionBuilder.BuildEquals<SyncLogItem>(i => i.Direction, tSyncDirection.In));
            lcs.AddColumnSort(new ColumnsSortDef(Information.ExtractPropertyName<SyncLogItem>(i => i.Created),
                SortOrder.Asc));
            var preparedLogItems = DataService.LoadObjects(lcs).Cast<SyncLogItem>().ToArray();
            if (preparedLogItems.Any())
            {
                var itemCount = preparedLogItems.Length;
                LogService.LogInfo($"{MessageHeader}Обнаружено {itemCount} готовых к обработке сообщений.");
                var syncLogitemForUpdate = new List<SyncLogItem>();
                var errorMessage = "";
                SyncLogItem logItem = null;
                for (var i = 0; i < itemCount; i++)
                {
                    logItem = preparedLogItems[i];
                    LogService.LogInfo(
                        $"{MessageHeader}Начата обработка {i+1}го сообщения (pk - {logItem.__PrimaryKey}) типа {logItem.Description}.");

                    var className = Settings.GetMessageHandlerTypeName(logItem.Description);
                    if (!string.IsNullOrEmpty(className))
                    {
                        var handlerType = Type.GetType(className);
                        if (handlerType != null)
                        {
                            if (Activator.CreateInstance(handlerType) is IMessageHandler handler)
                            {
                                try
                                {
                                    handler.HandleMessage(logItem);
                                }
                                catch (Exception ex)
                                {
                                    errorMessage =
                                        $"Произошла ошибка во время обработки сообщения типа: {logItem.Description}.{Environment.NewLine}{ex.Message}{Environment.NewLine}{ex.InnerException?.Message ?? ""}.";
                                    break;
                                }

                                logItem.Status = tSyncStatus.Success;
                                syncLogitemForUpdate.Add(logItem);
                                LogService.LogInfo(
                                    $"{MessageHeader} Cообщение (pk - {logItem.__PrimaryKey}) типа {logItem.Description} успешно обработано.");
                            }
                            else
                            {
                                errorMessage =
                                    $"Ошибка при попытке получить экземпляр обработчика для сообщения типа {logItem.Description}.";
                                break;
                            }
                        }
                        else
                        {
                            errorMessage =
                                $"Не удалось получить тип обработчика для сообщения типа {logItem.Description}. Проверьте настройки конфигурационного файла.";
                            break;
                        }
                    }
                    else
                    {
                        errorMessage =
                            $"Не удалось найти обработчик для сообщения типа {logItem.Description}. Проверьте настройки конфигурационного файла.";
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    if (logItem != null)
                    {
                        logItem.Status = tSyncStatus.Invalid;
                        syncLogitemForUpdate.Add(logItem);
                        LogService.LogError($"{MessageHeader}Возникла ошибка при обработке входящего сообщения (pk - {logItem.__PrimaryKey}) {errorMessage}.");
                    }
                }

                var objToUpdate = syncLogitemForUpdate.Cast<DataObject>().ToArray();
                try
                {
                    DataService.UpdateObjects(ref objToUpdate);
                }
                catch (Exception ex)
                {
                    //TODO предусмотреть механизм автоматического выключения обработчика при этой ошибке.
                    var errorMsg = string.Join(";", syncLogitemForUpdate.Select(x => $"SincLogItem.PK - {x.__PrimaryKey}, new status -{x.Status}"));
                    LogService.LogError(
                        $"{MessageHeader}Произошла ошибка во время обновления статусов сообщений - {errorMsg}! Возможна повторная обработка сообщений! Необходимо срочно остановить обработчик и проставить статусы вручную!", ex);
                }
            }
        }
    }
}