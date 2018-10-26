namespace BusSender
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;

    using IIS.University.Tools;
    using Synchronization.Objects;
    using Synchronization.Utils;

    public class BusSender
    {
        private const string MessageErrorHeader = "BusSenderService: ";
        private static readonly IDataService ds = DataServiceProvider.DataService;

        private static void Main(string[] args)
        {
            if (!ErrorMessages())
            {
                var lcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(SyncLogItem),
                    SyncLogItem.Views.SyncLogItemE);
                lcs.LimitFunction = FunctionBuilder.BuildAnd(
                    FunctionBuilder.BuildEquals<SyncLogItem>(x => x.Status, tSyncStatus.Prepared),
                    FunctionBuilder.BuildEquals<SyncLogItem>(x => x.Direction, tSyncDirection.Out));

                List<SyncLogItem> synclogitems = null;
                try
                {
                    synclogitems = ds.LoadObjects(lcs).Cast<SyncLogItem>().OrderBy(x => x.Created).ToList();
                }
                catch (Exception ex)
                {
                    LogService.LogError($"{MessageErrorHeader}Произошла ошибка при попытке вычитать SyncLogItem из БД!{Environment.NewLine}{ex}");
                }

                

                if (synclogitems != null && synclogitems.Count > 0)
                {
                    var sliForUpdate = new List<SyncLogItem>();
                    foreach (var synclogitem in synclogitems)
                    {
                        try
                        {
                            // Проверка валидация по XSD-схеме полученного xml.
                            if (Context.EnableXSDValidation)
                            {
                                var pathToXSD = Path.Combine($"{Context.XSDSchemasPath}{synclogitem.Description}.xsd");
                                if (File.Exists(pathToXSD))
                                {
                                    XMLTools.CheckXMLtoXSD(synclogitem.DataSet, pathToXSD);
                                }
                                else
                                {
                                    LogService.LogWarn(
                                        $"BusSenderService: При отправке сообщений включена проверка валидности сообщения XSD-схеме, но XSD-схема для сообщения типа {synclogitem.Description} не найдена!{Environment.NewLine} Путь для ожидаемой XSD-схемы - {pathToXSD}");
                                }
                            }

                            // Отправка сообщения.
                            SBSenderHelper.SendMessageToESB(synclogitem.Description, synclogitem.DataSet);
                            synclogitem.Status = synclogitem.RequestInfo != null
                                ? tSyncStatus.RespWaiting
                                : tSyncStatus.Success;
                            LogService.LogInfo($"{MessageErrorHeader} Успешно отправлен в шину SyncLogItem: pk - {synclogitem.__PrimaryKey}. Время отправки - {DateTime.Now:dd.MM.yyyy HH:mm:ss}.");
                            sliForUpdate.Add(synclogitem);
                        }
                        catch(Exception ex)
                        {
                            LogService.Log.Error($"{MessageErrorHeader}Возникла ошибка при попытке отправить в шину SyncLogItem: pk - {synclogitem.__PrimaryKey}, дата создания - {synclogitem.CreateTime?.ToString("dd.MM.yyyy HH:mm:ss") ?? ""}, статус - {synclogitem.Status}. Время отправки - {DateTime.Now:dd.MM.yyyy HH:mm:ss}{Environment.NewLine}{ex}.");
                            var time = ConfigurationManager.AppSettings["Time"];
                            if (synclogitem.Created!= null && DateTime.Now.Subtract(synclogitem.Created.Value).TotalSeconds > int.Parse(time))
                            {
                                synclogitem.Status = tSyncStatus.Invalid;
                                sliForUpdate.Add(synclogitem);
                            }

                            break;
                        }
                    }

                    try
                    {
                        var objForUpdate = sliForUpdate.Cast<DataObject>().ToArray();
                        ds.UpdateObjects(ref objForUpdate);
                    }
                    catch (Exception ex)
                    {
                        var errorUpdateMessage = string.Join(",", sliForUpdate.Select(x => $"pk:{x.__PrimaryKey} - статус:{x.Status}"));
                        LogService.LogError($"{MessageErrorHeader}Произошла ошибка при попытке обновить статусы сообщений!{Environment.NewLine}{ex}{Environment.NewLine}{errorUpdateMessage}");

                    }
                }
            }
        }

        public static bool ErrorMessages()
        {
            var lcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(SyncLogItem), SyncLogItem.Views.SyncLogItemE);
            lcs.LimitFunction = FunctionBuilder.BuildAnd(
                FunctionBuilder.BuildEquals<SyncLogItem>(x => x.Status, tSyncStatus.Invalid),
                FunctionBuilder.BuildEquals<SyncLogItem>(x => x.Direction, tSyncDirection.Out));

            var failedItems = 10;
            try
            {
                failedItems = ds.GetObjectsCount(lcs);
            }
            catch (Exception ex)
            {
                LogService.LogError($"{MessageErrorHeader}Произошла ошибка при попытке подсчитать количество ошибочных сообщений!{Environment.NewLine}{ex}");
            }

            return failedItems > 0;
        }
    }
}