﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Iis.Eais.Catalogs
{
    using System;


    // *** Start programmer edit section *** (Using statements)
    using System.Collections.Generic;
    using Iis.Eais.Common.Errors;
    using Iis.Eais.Catalogs.Helpers;
    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// TipLgotyBS.
    /// </summary>
    // *** Start programmer edit section *** (TipLgotyBS CustomAttributes)

    // *** End programmer edit section *** (TipLgotyBS CustomAttributes)
    [ICSSoft.STORMNET.AccessType(ICSSoft.STORMNET.AccessType.none)]
    public class TipLgotyBS : Iis.Eais.Common.CommonBS
    {

        // *** Start programmer edit section *** (TipLgotyBS CustomMembers)
        public override List<IError> CanDelete(Type type, Guid objectId)
        {
            List<IError> errors = new List<IError>();

            // Проверка связанных объектов по списку
            errors.AddRange(CheckRelationsBeforDelete(objectId, RelationsToCheckBeforeDelete.TipLgoty));

            return errors;
        }
        // *** End programmer edit section *** (TipLgotyBS CustomMembers)


        // *** Start programmer edit section *** (OnUpdateTipLgoty CustomAttributes)

        // *** End programmer edit section *** (OnUpdateTipLgoty CustomAttributes)
        public virtual ICSSoft.STORMNET.DataObject[] OnUpdateTipLgoty(Iis.Eais.Catalogs.TipLgoty UpdatedObject)
        {
            // *** Start programmer edit section *** (OnUpdateTipLgoty)
            UpdatedObject.Oldid = new CatalogsBS().MakeIdIfEmpty(UpdatedObject);

            return new ICSSoft.STORMNET.DataObject[0];
            // *** End programmer edit section *** (OnUpdateTipLgoty)
        }
    }
}
