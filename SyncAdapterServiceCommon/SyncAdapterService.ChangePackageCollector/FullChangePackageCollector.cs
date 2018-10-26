namespace SyncAdapterService.ChangePackageCollector
{
    using System;
    using System.Collections.Generic;
    using ICSSoft.STORMNET;
    using Utils;

    public class FullChangePackageCollector : DefaultChangePackageCollector
    {
        public override DataObject GetDataObjectBySyncEntity(
            Guid appObjPK,
            Type appObjType,
            ObjectStatus changedObjStatus,
            DateTime changedDate)
        {
            var appObject = Helper.CreateDataObject(appObjType, appObjPK);
            if (changedObjStatus != ObjectStatus.Deleted)
            {
                //Откатываем вычитанный изменённый объект, к состоянию на дату изменения.
                AuditTools.GetObjForDate(changedDate, ref appObject, true, true);
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