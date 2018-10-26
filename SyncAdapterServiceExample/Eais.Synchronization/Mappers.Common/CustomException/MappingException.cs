namespace Mappers.Common.CustomException
{
    using System;
    using System.Reflection;
    using ICSSoft.STORMNET;
    using IIS.Synchronizer;
    using IIS.Synchronizer.Mappers;

    public class MappingException : Exception
    {
        public MappingException(DataObject appObject, SyncSetting setting, IPropertyMapper mapper, string exMessage) 
            : base(GetErrorText(appObject, setting, mapper, exMessage)){}
    
        private static string GetErrorText(DataObject appObject, SyncSetting setting, IPropertyMapper mapper, string exMessage)
        {
            var text = $"Ошибка: не удалось преобразовать объект (Type = {appObject.GetType().AssemblyQualifiedName}, PK = {appObject.__PrimaryKey})!";
            if(!(appObject is ISync suncObj))
            {
                text = $"{text} Объект указанного типа не реализует {nameof(ISync)} интерфейс.";
            }
            else if (setting == null)
            {
                text = $"{text} Ошибка при загрузке настроек SyncSettings.";
            }
            else if (mapper == null)
            {
                text = $"{text} Не удалось получить маппер из настройки SyncSettings.PK - {setting.__PrimaryKey}.";
            }

            return $"{text}{Environment.NewLine}{exMessage}";
        }
        }
}