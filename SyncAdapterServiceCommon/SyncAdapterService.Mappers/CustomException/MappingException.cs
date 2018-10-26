namespace SyncAdapterService.Mappers.CustomException
{
    using System;
    using ICSSoft.STORMNET;

    public class MappingException : Exception
    {
        public MappingException(DataObject appObject, string exMessage) 
            : base($"Ошибка: не удалось преобразовать объект (Type = {appObject.GetType().AssemblyQualifiedName}, PK = {appObject.__PrimaryKey})!{Environment.NewLine}{exMessage}"){}
    }
}