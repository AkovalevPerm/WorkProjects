﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Iis.Eais.Synchronization
{
    using System;
    using System.Xml;
    using ICSSoft.STORMNET;
    
    
    // *** Start programmer edit section *** (Using statements)

    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// T sync status.
    /// </summary>
    // *** Start programmer edit section *** (tSyncStatus CustomAttributes)

    // *** End programmer edit section *** (tSyncStatus CustomAttributes)
    public enum tSyncStatus
    {
        
        /// <summary>
        /// 
        /// </summary>
        // *** Start programmer edit section *** (tSyncStatus.Prepared CustomAttributes)

        // *** End programmer edit section *** (tSyncStatus.Prepared CustomAttributes)
        [Caption("Готов к обработке")]
        Prepared,
        
        /// <summary>
        /// 
        /// </summary>
        // *** Start programmer edit section *** (tSyncStatus.Success CustomAttributes)

        // *** End programmer edit section *** (tSyncStatus.Success CustomAttributes)
        [Caption("Обработан успешно")]
        Success,
        
        /// <summary>
        /// 
        /// </summary>
        // *** Start programmer edit section *** (tSyncStatus.Invalid CustomAttributes)

        // *** End programmer edit section *** (tSyncStatus.Invalid CustomAttributes)
        [Caption("При обработке возникла ошибка")]
        Invalid,
    }
}
