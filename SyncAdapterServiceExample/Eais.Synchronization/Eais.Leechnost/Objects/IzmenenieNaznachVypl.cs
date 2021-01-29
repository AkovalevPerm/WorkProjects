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
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business.Audit;


    // *** Start programmer edit section *** (Using statements)
    using Iis.Eais.Common;
    using IIS.Synchronizer;

    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// ИзменениеНазначВыпл.
    /// </summary>
    // *** Start programmer edit section *** (IzmenenieNaznachVypl CustomAttributes)
    [Primary(true)]
    [Serializable]
    // *** End programmer edit section *** (IzmenenieNaznachVypl CustomAttributes)
    [AutoAltered()]
    [AccessType(ICSSoft.STORMNET.AccessType.@this)]
    [View("AuditView", new string[] {
            "DataNaznacheniia as \'Дата назначения\'",
            "DataOtmeny as \'Дата отмены\'",
            "TipVypl as \'Тип выплаты\'",
            "PeriodPredost as \'Период предоставления\'",
            "Summa as \'Сумма\'",
            "Primechanie as \'Примечание\'",
            "Naznachenie as \'Назначение\'",
            "OrganSZ as \'Орган СЗ\'",
            "Poluchatel as \'Получатель\'",
            "LgKatLeechnosti as \'Льготная категория личности\'"})]
    [View("IzmenenieNaznachVyplL", new string[] {
            "DataNaznacheniia as \'Дата назначения\'",
            "DataOtmeny as \'Дата отмены\'",
            "Summa as \'Сумма\'",
            "LgKatLeechnosti as \'Льготная категория\'",
            "LgKatLeechnosti.LgotKat",
            "LgKatLeechnosti.DataNaznacheniia",
            "LgKatLeechnosti.DataOtmeny",
            "TipVypl as \'Тип выплаты\'",
            "PeriodPredost as \'Периодичность предоставления\'",
            "Primechanie as \'Примечание\'",
            "OrganSZ as \'Орган СЗ\'",
            "Poluchatel as \'Получатель\'",
            "Poluchatel.Familiia",
            "Poluchatel.Imia",
            "Poluchatel.Otchestvo",
            "Poluchatel.DataRozhdeniia",
            "Poluchatel.FullNameDate"}, Hidden = new string[] {
            "LgKatLeechnosti.LgotKat",
            "LgKatLeechnosti.DataNaznacheniia",
            "LgKatLeechnosti.DataOtmeny",
            "Poluchatel.Familiia",
            "Poluchatel.Imia",
            "Poluchatel.Otchestvo",
            "Poluchatel.DataRozhdeniia",
            "Poluchatel.FullNameDate"})]
    public class IzmenenieNaznachVypl : ICSSoft.STORMNET.DataObject, IDataObjectWithAuditFields, ISync
    {

        private ICSSoft.STORMNET.UserDataTypes.NullableDateTime fDataNaznacheniia;

        private ICSSoft.STORMNET.UserDataTypes.NullableDateTime fDataOtmeny;

        private Iis.Eais.Leechnost.tTipVyplaty fTipVypl;

        private Iis.Eais.Leechnost.tTipPerioda fPeriodPredost;

        private ICSSoft.STORMNET.UserDataTypes.NullableDecimal fSumma;

        private string fPrimechanie;

        private System.Nullable<System.DateTime> fCreateTime;

        private string fCreator;

        private System.Nullable<System.DateTime> fEditTime;

        private string fEditor;

        private Iis.Eais.Leechnost.OrganSZ fOrganSZ;

        private Iis.Eais.Leechnost.Leechnost fPoluchatel;

        private Iis.Eais.Leechnost.LgKatLeechnosti fLgKatLeechnosti;

        private Iis.Eais.Leechnost.NaznachenieVyplaty fNaznachenie;

        // *** Start programmer edit section *** (IzmenenieNaznachVypl CustomMembers)

        // *** End programmer edit section *** (IzmenenieNaznachVypl CustomMembers)


        /// <summary>
        /// DataNaznacheniia.
        /// </summary>
        // *** Start programmer edit section *** (IzmenenieNaznachVypl.DataNaznacheniia CustomAttributes)

        // *** End programmer edit section *** (IzmenenieNaznachVypl.DataNaznacheniia CustomAttributes)
        [NotNull()]
        public virtual ICSSoft.STORMNET.UserDataTypes.NullableDateTime DataNaznacheniia
        {
            get
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.DataNaznacheniia Get start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.DataNaznacheniia Get start)
                ICSSoft.STORMNET.UserDataTypes.NullableDateTime result = this.fDataNaznacheniia;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.DataNaznacheniia Get end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.DataNaznacheniia Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.DataNaznacheniia Set start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.DataNaznacheniia Set start)
                this.fDataNaznacheniia = value;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.DataNaznacheniia Set end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.DataNaznacheniia Set end)
            }
        }

        /// <summary>
        /// DataOtmeny.
        /// </summary>
        // *** Start programmer edit section *** (IzmenenieNaznachVypl.DataOtmeny CustomAttributes)

        // *** End programmer edit section *** (IzmenenieNaznachVypl.DataOtmeny CustomAttributes)
        public virtual ICSSoft.STORMNET.UserDataTypes.NullableDateTime DataOtmeny
        {
            get
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.DataOtmeny Get start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.DataOtmeny Get start)
                ICSSoft.STORMNET.UserDataTypes.NullableDateTime result = this.fDataOtmeny;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.DataOtmeny Get end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.DataOtmeny Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.DataOtmeny Set start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.DataOtmeny Set start)
                this.fDataOtmeny = value;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.DataOtmeny Set end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.DataOtmeny Set end)
            }
        }

        /// <summary>
        /// TipVypl.
        /// </summary>
        // *** Start programmer edit section *** (IzmenenieNaznachVypl.TipVypl CustomAttributes)

        // *** End programmer edit section *** (IzmenenieNaznachVypl.TipVypl CustomAttributes)
        [NotNull()]
        public virtual Iis.Eais.Leechnost.tTipVyplaty TipVypl
        {
            get
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.TipVypl Get start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.TipVypl Get start)
                Iis.Eais.Leechnost.tTipVyplaty result = this.fTipVypl;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.TipVypl Get end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.TipVypl Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.TipVypl Set start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.TipVypl Set start)
                this.fTipVypl = value;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.TipVypl Set end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.TipVypl Set end)
            }
        }

        /// <summary>
        /// PeriodPredost.
        /// </summary>
        // *** Start programmer edit section *** (IzmenenieNaznachVypl.PeriodPredost CustomAttributes)

        // *** End programmer edit section *** (IzmenenieNaznachVypl.PeriodPredost CustomAttributes)
        public virtual Iis.Eais.Leechnost.tTipPerioda PeriodPredost
        {
            get
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.PeriodPredost Get start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.PeriodPredost Get start)
                Iis.Eais.Leechnost.tTipPerioda result = this.fPeriodPredost;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.PeriodPredost Get end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.PeriodPredost Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.PeriodPredost Set start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.PeriodPredost Set start)
                this.fPeriodPredost = value;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.PeriodPredost Set end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.PeriodPredost Set end)
            }
        }

        /// <summary>
        /// Summa.
        /// </summary>
        // *** Start programmer edit section *** (IzmenenieNaznachVypl.Summa CustomAttributes)

        // *** End programmer edit section *** (IzmenenieNaznachVypl.Summa CustomAttributes)
        [NotNull()]
        public virtual ICSSoft.STORMNET.UserDataTypes.NullableDecimal Summa
        {
            get
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.Summa Get start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.Summa Get start)
                ICSSoft.STORMNET.UserDataTypes.NullableDecimal result = this.fSumma;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.Summa Get end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.Summa Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.Summa Set start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.Summa Set start)
                this.fSumma = value;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.Summa Set end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.Summa Set end)
            }
        }

        /// <summary>
        /// Primechanie.
        /// </summary>
        // *** Start programmer edit section *** (IzmenenieNaznachVypl.Primechanie CustomAttributes)

        // *** End programmer edit section *** (IzmenenieNaznachVypl.Primechanie CustomAttributes)
        public virtual string Primechanie
        {
            get
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.Primechanie Get start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.Primechanie Get start)
                string result = this.fPrimechanie;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.Primechanie Get end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.Primechanie Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.Primechanie Set start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.Primechanie Set start)
                this.fPrimechanie = value;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.Primechanie Set end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.Primechanie Set end)
            }
        }

        /// <summary>
        /// Время создания объекта.
        /// </summary>
        // *** Start programmer edit section *** (IzmenenieNaznachVypl.CreateTime CustomAttributes)

        // *** End programmer edit section *** (IzmenenieNaznachVypl.CreateTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> CreateTime
        {
            get
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.CreateTime Get start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.CreateTime Get start)
                System.Nullable<System.DateTime> result = this.fCreateTime;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.CreateTime Get end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.CreateTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.CreateTime Set start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.CreateTime Set start)
                this.fCreateTime = value;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.CreateTime Set end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.CreateTime Set end)
            }
        }

        /// <summary>
        /// Создатель объекта.
        /// </summary>
        // *** Start programmer edit section *** (IzmenenieNaznachVypl.Creator CustomAttributes)

        // *** End programmer edit section *** (IzmenenieNaznachVypl.Creator CustomAttributes)
        [StrLen(255)]
        public virtual string Creator
        {
            get
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.Creator Get start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.Creator Get start)
                string result = this.fCreator;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.Creator Get end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.Creator Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.Creator Set start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.Creator Set start)
                this.fCreator = value;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.Creator Set end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.Creator Set end)
            }
        }

        /// <summary>
        /// Время последнего редактирования объекта.
        /// </summary>
        // *** Start programmer edit section *** (IzmenenieNaznachVypl.EditTime CustomAttributes)

        // *** End programmer edit section *** (IzmenenieNaznachVypl.EditTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> EditTime
        {
            get
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.EditTime Get start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.EditTime Get start)
                System.Nullable<System.DateTime> result = this.fEditTime;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.EditTime Get end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.EditTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.EditTime Set start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.EditTime Set start)
                this.fEditTime = value;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.EditTime Set end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.EditTime Set end)
            }
        }

        /// <summary>
        /// Последний редактор объекта.
        /// </summary>
        // *** Start programmer edit section *** (IzmenenieNaznachVypl.Editor CustomAttributes)

        // *** End programmer edit section *** (IzmenenieNaznachVypl.Editor CustomAttributes)
        [StrLen(255)]
        public virtual string Editor
        {
            get
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.Editor Get start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.Editor Get start)
                string result = this.fEditor;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.Editor Get end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.Editor Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.Editor Set start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.Editor Set start)
                this.fEditor = value;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.Editor Set end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.Editor Set end)
            }
        }

        /// <summary>
        /// ИзменениеНазначВыпл.
        /// </summary>
        // *** Start programmer edit section *** (IzmenenieNaznachVypl.OrganSZ CustomAttributes)

        // *** End programmer edit section *** (IzmenenieNaznachVypl.OrganSZ CustomAttributes)
        [PropertyStorage(new string[] {
                "OrganSZ"})]
        [NotNull()]
        public virtual Iis.Eais.Leechnost.OrganSZ OrganSZ
        {
            get
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.OrganSZ Get start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.OrganSZ Get start)
                Iis.Eais.Leechnost.OrganSZ result = this.fOrganSZ;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.OrganSZ Get end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.OrganSZ Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.OrganSZ Set start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.OrganSZ Set start)
                this.fOrganSZ = value;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.OrganSZ Set end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.OrganSZ Set end)
            }
        }

        /// <summary>
        /// ИзменениеНазначВыпл.
        /// </summary>
        // *** Start programmer edit section *** (IzmenenieNaznachVypl.Poluchatel CustomAttributes)

        // *** End programmer edit section *** (IzmenenieNaznachVypl.Poluchatel CustomAttributes)
        [PropertyStorage(new string[] {
                "Poluchatel"})]
        [NotNull()]
        public virtual Iis.Eais.Leechnost.Leechnost Poluchatel
        {
            get
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.Poluchatel Get start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.Poluchatel Get start)
                Iis.Eais.Leechnost.Leechnost result = this.fPoluchatel;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.Poluchatel Get end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.Poluchatel Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.Poluchatel Set start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.Poluchatel Set start)
                this.fPoluchatel = value;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.Poluchatel Set end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.Poluchatel Set end)
            }
        }

        /// <summary>
        /// ИзменениеНазначВыпл.
        /// </summary>
        // *** Start programmer edit section *** (IzmenenieNaznachVypl.LgKatLeechnosti CustomAttributes)

        // *** End programmer edit section *** (IzmenenieNaznachVypl.LgKatLeechnosti CustomAttributes)
        [PropertyStorage(new string[] {
                "LgKatLeechnosti"})]
        [NotNull()]
        public virtual Iis.Eais.Leechnost.LgKatLeechnosti LgKatLeechnosti
        {
            get
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.LgKatLeechnosti Get start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.LgKatLeechnosti Get start)
                Iis.Eais.Leechnost.LgKatLeechnosti result = this.fLgKatLeechnosti;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.LgKatLeechnosti Get end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.LgKatLeechnosti Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.LgKatLeechnosti Set start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.LgKatLeechnosti Set start)
                this.fLgKatLeechnosti = value;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.LgKatLeechnosti Set end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.LgKatLeechnosti Set end)
            }
        }

        /// <summary>
        /// мастеровая ссылка на шапку Iis.Eais.Leechnost.NaznachenieVyplaty.
        /// </summary>
        // *** Start programmer edit section *** (IzmenenieNaznachVypl.Naznachenie CustomAttributes)

        // *** End programmer edit section *** (IzmenenieNaznachVypl.Naznachenie CustomAttributes)
        [Agregator()]
        [NotNull()]
        [PropertyStorage(new string[] {
                "Naznachenie"})]
        public virtual Iis.Eais.Leechnost.NaznachenieVyplaty Naznachenie
        {
            get
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.Naznachenie Get start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.Naznachenie Get start)
                Iis.Eais.Leechnost.NaznachenieVyplaty result = this.fNaznachenie;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.Naznachenie Get end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.Naznachenie Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.Naznachenie Set start)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.Naznachenie Set start)
                this.fNaznachenie = value;
                // *** Start programmer edit section *** (IzmenenieNaznachVypl.Naznachenie Set end)

                // *** End programmer edit section *** (IzmenenieNaznachVypl.Naznachenie Set end)
            }
        }

        /// <summary>
        /// Class views container.
        /// </summary>
        public class Views
        {

            /// <summary>
            /// "AuditView" view.
            /// </summary>
            public static ICSSoft.STORMNET.View AuditView
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("AuditView", typeof(Iis.Eais.Leechnost.IzmenenieNaznachVypl));
                }
            }

            /// <summary>
            /// "IzmenenieNaznachVyplL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View IzmenenieNaznachVyplL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("IzmenenieNaznachVyplL", typeof(Iis.Eais.Leechnost.IzmenenieNaznachVypl));
                }
            }
        }

        /// <summary>
        /// Audit class settings.
        /// </summary>
        public class AuditSettings
        {

            /// <summary>
            /// Включён ли аудит для класса.
            /// </summary>
            public static bool AuditEnabled = true;

            /// <summary>
            /// Использовать имя представления для аудита по умолчанию.
            /// </summary>
            public static bool UseDefaultView = false;

            /// <summary>
            /// Включён ли аудит операции чтения.
            /// </summary>
            public static bool SelectAudit = false;

            /// <summary>
            /// Имя представления для аудирования операции чтения.
            /// </summary>
            public static string SelectAuditViewName = "AuditView";

            /// <summary>
            /// Включён ли аудит операции создания.
            /// </summary>
            public static bool InsertAudit = true;

            /// <summary>
            /// Имя представления для аудирования операции создания.
            /// </summary>
            public static string InsertAuditViewName = "AuditView";

            /// <summary>
            /// Включён ли аудит операции изменения.
            /// </summary>
            public static bool UpdateAudit = true;

            /// <summary>
            /// Имя представления для аудирования операции изменения.
            /// </summary>
            public static string UpdateAuditViewName = "AuditView";

            /// <summary>
            /// Включён ли аудит операции удаления.
            /// </summary>
            public static bool DeleteAudit = true;

            /// <summary>
            /// Имя представления для аудирования операции удаления.
            /// </summary>
            public static string DeleteAuditViewName = "AuditView";

            /// <summary>
            /// Путь к форме просмотра результатов аудита.
            /// </summary>
            public static string FormUrl = "";

            /// <summary>
            /// Режим записи данных аудита (синхронный или асинхронный).
            /// </summary>
            public static ICSSoft.STORMNET.Business.Audit.Objects.tWriteMode WriteMode = ICSSoft.STORMNET.Business.Audit.Objects.tWriteMode.Synchronous;

            /// <summary>
            /// Максимальная длина сохраняемого значения поля (если 0, то строка обрезаться не будет).
            /// </summary>
            public static int PrunningLength = 0;

            /// <summary>
            /// Показывать ли пользователям в изменениях первичные ключи.
            /// </summary>
            public static bool ShowPrimaryKey = false;

            /// <summary>
            /// Сохранять ли старое значение.
            /// </summary>
            public static bool KeepOldValue = true;

            /// <summary>
            /// Сжимать ли сохраняемые значения.
            /// </summary>
            public static bool Compress = false;

            /// <summary>
            /// Сохранять ли все значения атрибутов, а не только изменяемые.
            /// </summary>
            public static bool KeepAllValues = false;
        }
    }

    /// <summary>
    /// Detail array of IzmenenieNaznachVypl.
    /// </summary>
    // *** Start programmer edit section *** (DetailArrayDetailArrayOfIzmenenieNaznachVypl CustomAttributes)
    [Serializable]
    // *** End programmer edit section *** (DetailArrayDetailArrayOfIzmenenieNaznachVypl CustomAttributes)
    public class DetailArrayOfIzmenenieNaznachVypl : ICSSoft.STORMNET.DetailArray
    {

        // *** Start programmer edit section *** (Iis.Eais.Leechnost.DetailArrayOfIzmenenieNaznachVypl members)

        // *** End programmer edit section *** (Iis.Eais.Leechnost.DetailArrayOfIzmenenieNaznachVypl members)


        /// <summary>
        /// Construct detail array.
        /// </summary>
        /// <summary>
        /// Returns object with type IzmenenieNaznachVypl by index.
        /// </summary>
        /// <summary>
        /// Adds object with type IzmenenieNaznachVypl.
        /// </summary>
        public DetailArrayOfIzmenenieNaznachVypl(Iis.Eais.Leechnost.NaznachenieVyplaty fNaznachenieVyplaty) :
                base(typeof(IzmenenieNaznachVypl), ((ICSSoft.STORMNET.DataObject)(fNaznachenieVyplaty)))
        {
        }

        public Iis.Eais.Leechnost.IzmenenieNaznachVypl this[int index]
        {
            get
            {
                return ((Iis.Eais.Leechnost.IzmenenieNaznachVypl)(this.ItemByIndex(index)));
            }
        }

        public virtual void Add(Iis.Eais.Leechnost.IzmenenieNaznachVypl dataobject)
        {
            this.AddObject(((ICSSoft.STORMNET.DataObject)(dataobject)));
        }
    }
}