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
    using ICSSoft.STORMNET;


    // *** Start programmer edit section *** (Using statements)

    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// T СпособОплаты.
    /// </summary>
    // *** Start programmer edit section *** (tSposobOplaty CustomAttributes)

    // *** End programmer edit section *** (tSposobOplaty CustomAttributes)
    public enum tSposobOplaty
    {

        /// <summary>
        /// 
        /// </summary>
        // *** Start programmer edit section *** (tSposobOplaty.Pusto CustomAttributes)

        // *** End programmer edit section *** (tSposobOplaty.Pusto CustomAttributes)
        [Caption("")]
        Pusto,

        /// <summary>
        /// 
        /// </summary>
        // *** Start programmer edit section *** (tSposobOplaty.BankPerevod CustomAttributes)

        // *** End programmer edit section *** (tSposobOplaty.BankPerevod CustomAttributes)
        [Caption("на счет в сбербанк")]
        BankPerevod,

        /// <summary>
        /// 
        /// </summary>
        // *** Start programmer edit section *** (tSposobOplaty.PochtVedomostSDost CustomAttributes)

        // *** End programmer edit section *** (tSposobOplaty.PochtVedomostSDost CustomAttributes)
        [Caption("ведом. для предпр. связи с доставкой")]
        PochtVedomostSDost,

        /// <summary>
        /// 
        /// </summary>
        // *** Start programmer edit section *** (tSposobOplaty.PochtVedomostBezDost CustomAttributes)

        // *** End programmer edit section *** (tSposobOplaty.PochtVedomostBezDost CustomAttributes)
        [Caption("ведом. для предпр. связи без доставки")]
        PochtVedomostBezDost,

        /// <summary>
        /// 
        /// </summary>
        // *** Start programmer edit section *** (tSposobOplaty.PochtPerevod CustomAttributes)

        // *** End programmer edit section *** (tSposobOplaty.PochtPerevod CustomAttributes)
        [Caption("переводом через предпр. связи")]
        PochtPerevod,

        /// <summary>
        /// 
        /// </summary>
        // *** Start programmer edit section *** (tSposobOplaty.PochtPoruchenie CustomAttributes)

        // *** End programmer edit section *** (tSposobOplaty.PochtPoruchenie CustomAttributes)
        [Caption("разовым поруч. через предпр. связи")]
        PochtPoruchenie,

        /// <summary>
        /// 
        /// </summary>
        // *** Start programmer edit section *** (tSposobOplaty.Nalichnymi CustomAttributes)

        // *** End programmer edit section *** (tSposobOplaty.Nalichnymi CustomAttributes)
        [Caption("ведомостью через кассу органа СЗН")]
        Nalichnymi,

        /// <summary>
        /// 
        /// </summary>
        // *** Start programmer edit section *** (tSposobOplaty.AlterBankPerevod CustomAttributes)

        // *** End programmer edit section *** (tSposobOplaty.AlterBankPerevod CustomAttributes)
        [Caption("на счет в альтерн. банк")]
        AlterBankPerevod,

        /// <summary>
        /// 
        /// </summary>
        // *** Start programmer edit section *** (tSposobOplaty.AlterPochtVedSDost CustomAttributes)

        // *** End programmer edit section *** (tSposobOplaty.AlterPochtVedSDost CustomAttributes)
        [Caption("ведом. для альтерн. предпр. с доставкой")]
        AlterPochtVedSDost,

        /// <summary>
        /// 
        /// </summary>
        // *** Start programmer edit section *** (tSposobOplaty.AlterPochtVedBezDost CustomAttributes)

        // *** End programmer edit section *** (tSposobOplaty.AlterPochtVedBezDost CustomAttributes)
        [Caption("ведом. для альтерн. предпр. без доставки")]
        AlterPochtVedBezDost,

        /// <summary>
        /// 
        /// </summary>
        // *** Start programmer edit section *** (tSposobOplaty.AlterPochtPoruchenie CustomAttributes)

        // *** End programmer edit section *** (tSposobOplaty.AlterPochtPoruchenie CustomAttributes)
        [Caption("раз. поруч. через альтерн. предпр. связи")]
        AlterPochtPoruchenie,

        /// <summary>
        /// 
        /// </summary>
        // *** Start programmer edit section *** (tSposobOplaty.PerevodNaSchetOrg CustomAttributes)

        // *** End programmer edit section *** (tSposobOplaty.PerevodNaSchetOrg CustomAttributes)
        [Caption("перечисление на счет организации")]
        PerevodNaSchetOrg,
    }
}