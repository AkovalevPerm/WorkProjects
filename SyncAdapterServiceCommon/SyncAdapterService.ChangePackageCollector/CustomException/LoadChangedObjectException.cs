namespace SyncAdapterService.ChangePackageCollector.CustomException
{
    using System;

    public class LoadChangedObjectException: Exception
    {
        public LoadChangedObjectException(string typeName, Guid? objPK, string exMessage) 
            : base($"Ошибка: не удалось вычитать изменившийся объект (Type = {typeName}, PK = {objPK}) из бд!{Environment.NewLine}{exMessage}"){}
    }
}