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
    /// TipNormAktaBS.
    /// </summary>
    // *** Start programmer edit section *** (TipNormAktaBS CustomAttributes)

    // *** End programmer edit section *** (TipNormAktaBS CustomAttributes)
    [ICSSoft.STORMNET.AccessType(ICSSoft.STORMNET.AccessType.none)]
    public class TipNormAktaBS : Iis.Eais.Common.CommonBS
    {

        // *** Start programmer edit section *** (TipNormAktaBS CustomMembers)
        public override List<IError> CanDelete(Type type, Guid objectId)
        {
            List<IError> errors = new List<IError>();

            // Проверка связанных объектов по списку
            errors.AddRange(CheckRelationsBeforDelete(objectId, RelationsToCheckBeforeDelete.TipNormAkta));

            return errors;
        }
        // *** End programmer edit section *** (TipNormAktaBS CustomMembers)


        // *** Start programmer edit section *** (OnUpdateTipNormAkta CustomAttributes)

        // *** End programmer edit section *** (OnUpdateTipNormAkta CustomAttributes)
        public virtual ICSSoft.STORMNET.DataObject[] OnUpdateTipNormAkta(Iis.Eais.Catalogs.TipNormAkta UpdatedObject)
        {
            // *** Start programmer edit section *** (OnUpdateTipNormAkta)
            UpdatedObject.Oldid = new CatalogsBS().MakeIdIfEmpty(UpdatedObject);

            return new ICSSoft.STORMNET.DataObject[0];
            // *** End programmer edit section *** (OnUpdateTipNormAkta)
        }
    }
}