﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Iis.Eais.Leechnost
{
    using System;
    using System.Xml;


    // *** Start programmer edit section *** (Using statements)
    using System.Collections.Generic;
    using Iis.Eais.Common.Errors;
    using Iis.Eais.Leechnost.Helpers;
    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// UdostDokumentBS.
    /// </summary>
    // *** Start programmer edit section *** (UdostDokumentBS CustomAttributes)

    // *** End programmer edit section *** (UdostDokumentBS CustomAttributes)
    [ICSSoft.STORMNET.AccessType(ICSSoft.STORMNET.AccessType.none)]
    public class UdostDokumentBS : Iis.Eais.Common.CommonBS
    {

        // *** Start programmer edit section *** (UdostDokumentBS CustomMembers)
        public override List<IError> CanDelete(Type type, Guid objectId)
        {
            List<IError> errors = new List<IError>();

            // Проверка связанных объектов по списку
            errors.AddRange(CheckRelationsBeforDelete(objectId, RelationsToCheckBeforeDelete.UdostDokument));

            return errors;
        }
        // *** End programmer edit section *** (UdostDokumentBS CustomMembers)


        // *** Start programmer edit section *** (OnUpdateUdostDokument CustomAttributes)

        // *** End programmer edit section *** (OnUpdateUdostDokument CustomAttributes)
        public virtual ICSSoft.STORMNET.DataObject[] OnUpdateUdostDokument(Iis.Eais.Leechnost.UdostDokument UpdatedObject)
        {
            // *** Start programmer edit section *** (OnUpdateUdostDokument)

            return new ICSSoft.STORMNET.DataObject[0];
            // *** End programmer edit section *** (OnUpdateUdostDokument)
        }
    }
}