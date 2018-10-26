namespace ChangePackageCollector
{
    using System;
    using System.Collections.Generic;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using Synchronization.Common;
    using Synchronization.Utils;

    public class FullChangePackageCollector : DefaultChangePackageCollector
    {
        public FullChangePackageCollector(IDataService appDS, IDataService syncDS):base(appDS, syncDS){}

        public override DataObject GetDataObjectBySyncEntity(
            Guid appObjPK,
            Type appObjType,
            ObjectStatus changedObjStatus,
            Guid auditChangePK)
        {
            var appObject = Helper.CreateDataObject(appObjType, appObjPK);
            if (changedObjStatus != ObjectStatus.Deleted)
            {
                //  Получаем дату операции изменения аудита связанную с SyncEntity.
                var auditDate = AuditTools.GetAuditEntityOperationTimeByPK(auditChangePK);
                //  Откатываем вычитанный изменённый объект, к состоянию на дату изменения.
                if (auditDate != null)
                {
                    AuditTools.GetObjForDate(auditDate.Value, ref appObject, Context.OnlySelfRollbackFromAudit, true);
                }
                else
                {
                    throw new Exception($"Ошибка - не удалось определить дату операции изменения аудита(AuditEntity:{auditChangePK})");
                }
            }

            //Если объект удалён, то создаём его экземпляр для передачи в сообщении ключа этого объекта.
            return appObject;
        }

        public override List<string> GetChangedFieldBySyncEntity(ObjectStatus changedObjStatus, Guid auditChangePK)
        {
            var result = changedObjStatus != ObjectStatus.Deleted
                         ? AuditTools.GetChangeFieldFromAuditEntityByPK(auditChangePK)
                         : null;

            return result;
        }
    }
}