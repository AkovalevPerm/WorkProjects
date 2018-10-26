namespace ChangePackageCollector.CustomException
{
    using System;
    using IIS.Synchronizer;

    public class LoadSyncSettingException: Exception
    {
        public LoadSyncSettingException(Guid? syncEntityPK,  SyncSetting setting, Type type, string exMessage) 
            : base(GetErrorText(syncEntityPK, setting, type, exMessage)){}

        private static string GetErrorText(Guid? syncEntityPK, SyncSetting setting, Type type, string exMessage)
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

            return $"{text}{Environment.NewLine}{exMessage}";
        }
    }
}