﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Iis.Eais.GosUslugi
{
    using System;


    // *** Start programmer edit section *** (Using statements)
    using System.Collections.Generic;
    using Iis.Eais.Common.Errors;
    using Iis.Eais.GosUslugi.Helpers;
    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// LeechnostBS.
    /// </summary>
    // *** Start programmer edit section *** (LeechnostBS CustomAttributes)

    // *** End programmer edit section *** (LeechnostBS CustomAttributes)
    [ICSSoft.STORMNET.AccessType(ICSSoft.STORMNET.AccessType.none)]
    public class LeechnostBS : Iis.Eais.Common.CommonBS
    {

        // *** Start programmer edit section *** (LeechnostBS CustomMembers)
        public override List<IError> CanDelete(Type type, Guid objectId)
        {
            List<IError> errors = new List<IError>();

            // Проверка связанных объектов по списку
            errors.AddRange(CheckRelationsBeforDelete(objectId, RelationsToCheckBeforeDelete.Leechnost));

            return errors;
        }
        // *** End programmer edit section *** (LeechnostBS CustomMembers)


        // *** Start programmer edit section *** (OnUpdateLeechnost CustomAttributes)

        // *** End programmer edit section *** (OnUpdateLeechnost CustomAttributes)
        public virtual ICSSoft.STORMNET.DataObject[] OnUpdateLeechnost(Iis.Eais.GosUslugi.Leechnost UpdatedObject)
        {
            // *** Start programmer edit section *** (OnUpdateLeechnost)
            return new ICSSoft.STORMNET.DataObject[0];
            // *** End programmer edit section *** (OnUpdateLeechnost)
        }
    }
}
