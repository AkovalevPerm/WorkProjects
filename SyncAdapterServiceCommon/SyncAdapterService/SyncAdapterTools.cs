namespace SyncAdapterService
{
    using SyncAdapterService.Objects;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using IIS.University.Tools;
    using XMLMessageModel.Interface;
    using SyncAdapterService.Utils;
    using XMLMessageModel.Attribute;
    using System.Runtime.Serialization;
    using XMLDataModel.Attribute;
    using XMLDataModel.Interface;
    using Microsoft.Practices.ObjectBuilder2;

    public static class SyncAdapterTools
    {
        public static SyncLogItem GetLastSendMessage<TMessage>(bool throwException = false)
            where TMessage : ICommonMessage

        {
            SyncLogItem result = null;
            var typeName = GetDataContractNameForMessage<TMessage>();
            if (!string.IsNullOrEmpty(typeName))
            {
                var lcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(SyncLogItem),
                    SyncLogItem.Views.SyncLogItemE);
                lcs.LimitFunction = FunctionBuilder.BuildAnd(
                    FunctionBuilder.BuildEquals<SyncLogItem>(x => x.Description, typeName),
                    FunctionBuilder.BuildEquals<SyncLogItem>(x => x.Direction, tSyncDirection.Out),
                    FunctionBuilder.BuildIsNotNull<SyncLogItem>(x => x.ChangesTo),
                    FunctionBuilder.BuildIsNotNull<SyncLogItem>(x => x.ChangesFrom));
                lcs.ReturnTop = 1;
                lcs.ColumnsSort = new[] {new ColumnsSortDef(nameof(SyncLogItem.Created), SortOrder.Desc)};
                try
                {
                    result = DataServiceFactory.SyncDataService.LoadObjects(lcs).Cast<SyncLogItem>().FirstOrDefault();
                }
                catch (Exception ex)
                {
                    if (throwException)
                    {
                        throw;
                    }

                    LogService.LogError(
                        $"Ошибка при попытке получить последнее sync-сообщение типа {typeof(TMessage).Name}. Ошибка вычитки сообщения из БД - {ex.Message}");
                }
            }
            else
            {
                LogService.LogError(
                    $"Ошибка при попытке получить последнее sync-сообщение типа {typeof(TMessage).Name}. Для сообщения не задан DataContractAttribute с заполенным значением Name");
            }

            return result;
        }

        public static string GetDataContractNameForMessage(Type type, bool throwException = true)
        {
            var result = "";
            try
            {
                result = type.GetCustomAttribute<DataContractAttribute>()?.Name ?? "";
            }
            catch (Exception ex)
            {
                var errorText =
                    $"Произошла ошибка при попытке получить DataContract.Name для сообщения типа {type.Name}";
                if (throwException)
                {
                    throw new Exception($"{errorText}{ex.Message}");;
                }

                LogService.LogError(errorText, ex);
            }

            return result;
        }

        public static string GetDataContractNameForMessage<TMessage>(bool throwException = true)
            where TMessage : ICommonMessage
        {
            return GetDataContractNameForMessage(typeof(TMessage), throwException);
        }

        public static bool GetSendChangedFieldAttributeForMessage<TMessage>()
            where TMessage : ICommonMessage
        {
            return typeof(TMessage).GetCustomAttribute<SendChangedField>()?.Enable ?? false;
        }

        public static int GetPackageSizeForMessage<TMessage>()
            where TMessage : ICommonMessage
        {
            var msgType = typeof(TMessage);
            int result = Context.DefaultPackageSize;
            try
            {
                result = msgType.GetCustomAttribute<PackageSize>()?.Size ?? result;
            }
            catch (Exception ex)
            {
                var errorText = $"Произошла ошибка при попытке получить размер пакета (атрибут PackageSize) для сообщения типа {msgType.Name}. Размер пакета будет установлен в {result}.";
                LogService.LogWarn(errorText, ex);
            }

            if (result == 0)
            {
                result = 100;
            }

            return result;
        }

        public static List<Type> GetSupportTypeForChangedItem<TItem>(bool throwException = true)
            where TItem : IChangedItem
        {
            var itemType = typeof(TItem);
            var result = new List<Type>();
            try
            {
                itemType.GetProperties().ForEach(x=>
                {
                    var supType = x.GetCustomAttribute<XMLDataFieldType>()?.Type;
                    if (supType != null)
                    {
                        result.Add(supType);
                    }
                });
            }
            catch (Exception ex)
            {
                var errorText =
                    $"Произошла ошибка при попытке получить список поддерживаемых типов (атрибут SupportType) для ChangedItem типа {itemType.Name}.";
                if (throwException)
                {
                    throw new Exception($"{errorText}{ex.Message}");;
                }

                LogService.LogError(errorText, ex);
            }

            return result;
        }
    }
}