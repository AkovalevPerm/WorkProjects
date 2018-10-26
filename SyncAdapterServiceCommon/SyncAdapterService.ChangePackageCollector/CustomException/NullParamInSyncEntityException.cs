namespace SyncAdapterService.ChangePackageCollector.CustomException
{
    using System;
    using IIS.Synchronizer;
    using IIS.University.Tools;

    public class NullParamInSyncEntityException:Exception
    {
        public NullParamInSyncEntityException(SyncDOEntity syncEntity) : base(GetErrorText(syncEntity)){}

        private static string GetErrorText(SyncDOEntity syncEntity)
        {
            var text = $"Ошибка: обнаружена запись SyncDOEntity({PKHelper.GetGuidByObject(syncEntity)})";
            if (syncEntity.ObjectPrimaryKey == null)
            {
                text = $"{text} с пустым ключом на изменившийся объкт.";
            }
            else if (!syncEntity.Date.HasValue)
            {
                text = $"{text} с пустой датой изменения.";
            }
            else if (!syncEntity.AuditChangePK.HasValue)
            {
                text = $"{text} с пустым ключом на соответствующую запись изменения аудита.";
            }

            return text;
        }
    }
}