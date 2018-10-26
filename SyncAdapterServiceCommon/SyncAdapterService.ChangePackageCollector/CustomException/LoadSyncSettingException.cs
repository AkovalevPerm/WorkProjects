namespace SyncAdapterService.ChangePackageCollector.CustomException
{
    using System;
    using IIS.Synchronizer;
    using IIS.Synchronizer.Mappers;

    public class LoadSyncSettingException: Exception
    {
        public LoadSyncSettingException(Guid? syncEntityPK,  SyncSetting setting, Type type, IPropertyMapper mapper, string exMessage) 
            : base(GetErrorText(syncEntityPK, setting, type, mapper, exMessage)){}

        private static string GetErrorText(Guid? syncEntityPK, SyncSetting setting, Type type, IPropertyMapper mapper, string exMessage)
        {
            var text = "Ошибка: не удалось";
            if (setting == null)
            {
                text = $"{text} загрузить настройки SyncSettings для SyncDOEntity.PK = {syncEntityPK}.";
            }
            else if (type == null)
            {
                text = $"{text} получить тип из настройки SyncSettings.PK - {setting.__PrimaryKey}.";
            }
            else if (mapper == null)
            {
                text = $"{text} получить маппер из настройки SyncSettings.PK - {setting.__PrimaryKey}.";
            }

            return $"{text}{Environment.NewLine}{exMessage}";
        }

        public LoadSyncSettingException(string syncType, SyncSetting setting, Type type, IPropertyMapper mapper, string exMessage)
           : base(GetErrorText(syncType, setting, type, mapper, exMessage)) { }

        private static string GetErrorText(string syncType, SyncSetting setting, Type type, IPropertyMapper mapper, string exMessage)
        {
            var text = "Ошибка: не удалось";
            if (setting == null)
            {
                text = $"{text} загрузить настройки SyncSettings для входящего типа = {syncType}.";
            }
            else if (type == null)
            {
                text = $"{text} получить исходящий тип из настройки SyncSettings.PK - {setting.__PrimaryKey}.";
            }
            else if (mapper == null)
            {
                text = $"{text} получить маппер из настройки SyncSettings.PK - {setting.__PrimaryKey}.";
            }

            return $"{text}{Environment.NewLine}{exMessage}";
        }
    }
}