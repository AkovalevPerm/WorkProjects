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
    /// НазначениеВыплаты.
    /// </summary>
    // *** Start programmer edit section *** (NaznachenieVyplaty CustomAttributes)
    [Primary(true)]
    [Serializable]
    // *** End programmer edit section *** (NaznachenieVyplaty CustomAttributes)
    [AutoAltered()]
    [AccessType(ICSSoft.STORMNET.AccessType.@this)]
    [View("AuditView", new string[] {
            "Podtverzhdeno as \'Подтверждено\'",
            "Nositel as \'Носитель\'",
            "Lgota as \'Льгота\'",
            "Izhdivenetc as \'Иждивенец\'"})]
    [AssociatedDetailViewAttribute("AuditView", "Izmeneniia", "AuditView", true, "", "Изменения", true, new string[] {
            ""})]
    [View("NaznachenieVyplatyE", new string[] {
            "Nositel as \'Носитель льготы\'",
            "Nositel.Familiia",
            "Nositel.Imia",
            "Nositel.Otchestvo",
            "Nositel.DataRozhdeniia",
            "Nositel.FullNameDate",
            "Izhdivenetc as \'Иждивенец\'",
            "Izhdivenetc.Familiia",
            "Izhdivenetc.Imia",
            "Izhdivenetc.Otchestvo",
            "Izhdivenetc.DataRozhdeniia",
            "Izhdivenetc.FullNameDate",
            "Lgota as \'Вид выплат\'",
            "Podtverzhdeno as \'Подтверждено\'"}, Hidden = new string[] {
            "Nositel.Familiia",
            "Nositel.Imia",
            "Nositel.Otchestvo",
            "Nositel.DataRozhdeniia",
            "Nositel.FullNameDate",
            "Izhdivenetc.Familiia",
            "Izhdivenetc.Imia",
            "Izhdivenetc.Otchestvo",
            "Izhdivenetc.DataRozhdeniia",
            "Izhdivenetc.FullNameDate"})]
    [AssociatedDetailViewAttribute("NaznachenieVyplatyE", "Izmeneniia", "IzmenenieNaznachVyplL", true, "", "Назначенные суммы", true, new string[] {
            ""})]
    [View("NaznachenieVyplatyL", new string[] {
            "Nositel.Familiia as \'Фамилия\'",
            "Nositel.Imia as \'Имя\'",
            "Nositel.Otchestvo as \'Отчество\'",
            "Nositel.DataRozhdeniia as \'Дата рождения\'",
            "Podtverzhdeno as \'Подтверждено\'",
            "Izhdivenetc.Familiia as \'Фамилия (Иждивенец)\'",
            "Izhdivenetc.Imia as \'Имя (Иждивенец)\'",
            "Izhdivenetc.Otchestvo as \'Отчество (Иждивенец)\'",
            "Izhdivenetc.DataRozhdeniia as \'Дата рождения (Иждивенец)\'"})]
    public class NaznachenieVyplaty : ICSSoft.STORMNET.DataObject, IDataObjectWithAuditFields, ISync
    {

        private Iis.Eais.Leechnost.tLogicheskii fPodtverzhdeno = Iis.Eais.Leechnost.tLogicheskii.Net;

        private System.Nullable<System.DateTime> fCreateTime;

        private string fCreator;

        private System.Nullable<System.DateTime> fEditTime;

        private string fEditor;

        private Iis.Eais.Leechnost.Leechnost fNositel;

        private Iis.Eais.Leechnost.Lgota fLgota;

        private Iis.Eais.Leechnost.Leechnost fIzhdivenetc;

        private Iis.Eais.Leechnost.DetailArrayOfIzmenenieNaznachVypl fIzmeneniia;

        // *** Start programmer edit section *** (NaznachenieVyplaty CustomMembers)

        // *** End programmer edit section *** (NaznachenieVyplaty CustomMembers)


        /// <summary>
        /// Podtverzhdeno.
        /// </summary>
        // *** Start programmer edit section *** (NaznachenieVyplaty.Podtverzhdeno CustomAttributes)

        // *** End programmer edit section *** (NaznachenieVyplaty.Podtverzhdeno CustomAttributes)
        [NotNull()]
        public virtual Iis.Eais.Leechnost.tLogicheskii Podtverzhdeno
        {
            get
            {
                // *** Start programmer edit section *** (NaznachenieVyplaty.Podtverzhdeno Get start)

                // *** End programmer edit section *** (NaznachenieVyplaty.Podtverzhdeno Get start)
                Iis.Eais.Leechnost.tLogicheskii result = this.fPodtverzhdeno;
                // *** Start programmer edit section *** (NaznachenieVyplaty.Podtverzhdeno Get end)

                // *** End programmer edit section *** (NaznachenieVyplaty.Podtverzhdeno Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (NaznachenieVyplaty.Podtverzhdeno Set start)

                // *** End programmer edit section *** (NaznachenieVyplaty.Podtverzhdeno Set start)
                this.fPodtverzhdeno = value;
                // *** Start programmer edit section *** (NaznachenieVyplaty.Podtverzhdeno Set end)

                // *** End programmer edit section *** (NaznachenieVyplaty.Podtverzhdeno Set end)
            }
        }

        /// <summary>
        /// Время создания объекта.
        /// </summary>
        // *** Start programmer edit section *** (NaznachenieVyplaty.CreateTime CustomAttributes)

        // *** End programmer edit section *** (NaznachenieVyplaty.CreateTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> CreateTime
        {
            get
            {
                // *** Start programmer edit section *** (NaznachenieVyplaty.CreateTime Get start)

                // *** End programmer edit section *** (NaznachenieVyplaty.CreateTime Get start)
                System.Nullable<System.DateTime> result = this.fCreateTime;
                // *** Start programmer edit section *** (NaznachenieVyplaty.CreateTime Get end)

                // *** End programmer edit section *** (NaznachenieVyplaty.CreateTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (NaznachenieVyplaty.CreateTime Set start)

                // *** End programmer edit section *** (NaznachenieVyplaty.CreateTime Set start)
                this.fCreateTime = value;
                // *** Start programmer edit section *** (NaznachenieVyplaty.CreateTime Set end)

                // *** End programmer edit section *** (NaznachenieVyplaty.CreateTime Set end)
            }
        }

        /// <summary>
        /// Создатель объекта.
        /// </summary>
        // *** Start programmer edit section *** (NaznachenieVyplaty.Creator CustomAttributes)

        // *** End programmer edit section *** (NaznachenieVyplaty.Creator CustomAttributes)
        [StrLen(255)]
        public virtual string Creator
        {
            get
            {
                // *** Start programmer edit section *** (NaznachenieVyplaty.Creator Get start)

                // *** End programmer edit section *** (NaznachenieVyplaty.Creator Get start)
                string result = this.fCreator;
                // *** Start programmer edit section *** (NaznachenieVyplaty.Creator Get end)

                // *** End programmer edit section *** (NaznachenieVyplaty.Creator Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (NaznachenieVyplaty.Creator Set start)

                // *** End programmer edit section *** (NaznachenieVyplaty.Creator Set start)
                this.fCreator = value;
                // *** Start programmer edit section *** (NaznachenieVyplaty.Creator Set end)

                // *** End programmer edit section *** (NaznachenieVyplaty.Creator Set end)
            }
        }

        /// <summary>
        /// Время последнего редактирования объекта.
        /// </summary>
        // *** Start programmer edit section *** (NaznachenieVyplaty.EditTime CustomAttributes)

        // *** End programmer edit section *** (NaznachenieVyplaty.EditTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> EditTime
        {
            get
            {
                // *** Start programmer edit section *** (NaznachenieVyplaty.EditTime Get start)

                // *** End programmer edit section *** (NaznachenieVyplaty.EditTime Get start)
                System.Nullable<System.DateTime> result = this.fEditTime;
                // *** Start programmer edit section *** (NaznachenieVyplaty.EditTime Get end)

                // *** End programmer edit section *** (NaznachenieVyplaty.EditTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (NaznachenieVyplaty.EditTime Set start)

                // *** End programmer edit section *** (NaznachenieVyplaty.EditTime Set start)
                this.fEditTime = value;
                // *** Start programmer edit section *** (NaznachenieVyplaty.EditTime Set end)

                // *** End programmer edit section *** (NaznachenieVyplaty.EditTime Set end)
            }
        }

        /// <summary>
        /// Последний редактор объекта.
        /// </summary>
        // *** Start programmer edit section *** (NaznachenieVyplaty.Editor CustomAttributes)

        // *** End programmer edit section *** (NaznachenieVyplaty.Editor CustomAttributes)
        [StrLen(255)]
        public virtual string Editor
        {
            get
            {
                // *** Start programmer edit section *** (NaznachenieVyplaty.Editor Get start)

                // *** End programmer edit section *** (NaznachenieVyplaty.Editor Get start)
                string result = this.fEditor;
                // *** Start programmer edit section *** (NaznachenieVyplaty.Editor Get end)

                // *** End programmer edit section *** (NaznachenieVyplaty.Editor Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (NaznachenieVyplaty.Editor Set start)

                // *** End programmer edit section *** (NaznachenieVyplaty.Editor Set start)
                this.fEditor = value;
                // *** Start programmer edit section *** (NaznachenieVyplaty.Editor Set end)

                // *** End programmer edit section *** (NaznachenieVyplaty.Editor Set end)
            }
        }

        /// <summary>
        /// НазначениеВыплаты.
        /// </summary>
        // *** Start programmer edit section *** (NaznachenieVyplaty.Nositel CustomAttributes)

        // *** End programmer edit section *** (NaznachenieVyplaty.Nositel CustomAttributes)
        [PropertyStorage(new string[] {
                "Nositel"})]
        [NotNull()]
        public virtual Iis.Eais.Leechnost.Leechnost Nositel
        {
            get
            {
                // *** Start programmer edit section *** (NaznachenieVyplaty.Nositel Get start)

                // *** End programmer edit section *** (NaznachenieVyplaty.Nositel Get start)
                Iis.Eais.Leechnost.Leechnost result = this.fNositel;
                // *** Start programmer edit section *** (NaznachenieVyplaty.Nositel Get end)

                // *** End programmer edit section *** (NaznachenieVyplaty.Nositel Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (NaznachenieVyplaty.Nositel Set start)

                // *** End programmer edit section *** (NaznachenieVyplaty.Nositel Set start)
                this.fNositel = value;
                // *** Start programmer edit section *** (NaznachenieVyplaty.Nositel Set end)

                // *** End programmer edit section *** (NaznachenieVyplaty.Nositel Set end)
            }
        }

        /// <summary>
        /// НазначениеВыплаты.
        /// </summary>
        // *** Start programmer edit section *** (NaznachenieVyplaty.Lgota CustomAttributes)

        // *** End programmer edit section *** (NaznachenieVyplaty.Lgota CustomAttributes)
        [PropertyStorage(new string[] {
                "Lgota"})]
        [NotNull()]
        public virtual Iis.Eais.Leechnost.Lgota Lgota
        {
            get
            {
                // *** Start programmer edit section *** (NaznachenieVyplaty.Lgota Get start)

                // *** End programmer edit section *** (NaznachenieVyplaty.Lgota Get start)
                Iis.Eais.Leechnost.Lgota result = this.fLgota;
                // *** Start programmer edit section *** (NaznachenieVyplaty.Lgota Get end)

                // *** End programmer edit section *** (NaznachenieVyplaty.Lgota Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (NaznachenieVyplaty.Lgota Set start)

                // *** End programmer edit section *** (NaznachenieVyplaty.Lgota Set start)
                this.fLgota = value;
                // *** Start programmer edit section *** (NaznachenieVyplaty.Lgota Set end)

                // *** End programmer edit section *** (NaznachenieVyplaty.Lgota Set end)
            }
        }

        /// <summary>
        /// НазначениеВыплаты.
        /// </summary>
        // *** Start programmer edit section *** (NaznachenieVyplaty.Izhdivenetc CustomAttributes)

        // *** End programmer edit section *** (NaznachenieVyplaty.Izhdivenetc CustomAttributes)
        [PropertyStorage(new string[] {
                "Izhdivenetc"})]
        public virtual Iis.Eais.Leechnost.Leechnost Izhdivenetc
        {
            get
            {
                // *** Start programmer edit section *** (NaznachenieVyplaty.Izhdivenetc Get start)

                // *** End programmer edit section *** (NaznachenieVyplaty.Izhdivenetc Get start)
                Iis.Eais.Leechnost.Leechnost result = this.fIzhdivenetc;
                // *** Start programmer edit section *** (NaznachenieVyplaty.Izhdivenetc Get end)

                // *** End programmer edit section *** (NaznachenieVyplaty.Izhdivenetc Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (NaznachenieVyplaty.Izhdivenetc Set start)

                // *** End programmer edit section *** (NaznachenieVyplaty.Izhdivenetc Set start)
                this.fIzhdivenetc = value;
                // *** Start programmer edit section *** (NaznachenieVyplaty.Izhdivenetc Set end)

                // *** End programmer edit section *** (NaznachenieVyplaty.Izhdivenetc Set end)
            }
        }

        /// <summary>
        /// НазначениеВыплаты.
        /// </summary>
        // *** Start programmer edit section *** (NaznachenieVyplaty.Izmeneniia CustomAttributes)

        // *** End programmer edit section *** (NaznachenieVyplaty.Izmeneniia CustomAttributes)
        public virtual Iis.Eais.Leechnost.DetailArrayOfIzmenenieNaznachVypl Izmeneniia
        {
            get
            {
                // *** Start programmer edit section *** (NaznachenieVyplaty.Izmeneniia Get start)

                // *** End programmer edit section *** (NaznachenieVyplaty.Izmeneniia Get start)
                if ((this.fIzmeneniia == null))
                {
                    this.fIzmeneniia = new Iis.Eais.Leechnost.DetailArrayOfIzmenenieNaznachVypl(this);
                }
                Iis.Eais.Leechnost.DetailArrayOfIzmenenieNaznachVypl result = this.fIzmeneniia;
                // *** Start programmer edit section *** (NaznachenieVyplaty.Izmeneniia Get end)

                // *** End programmer edit section *** (NaznachenieVyplaty.Izmeneniia Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (NaznachenieVyplaty.Izmeneniia Set start)

                // *** End programmer edit section *** (NaznachenieVyplaty.Izmeneniia Set start)
                this.fIzmeneniia = value;
                // *** Start programmer edit section *** (NaznachenieVyplaty.Izmeneniia Set end)

                // *** End programmer edit section *** (NaznachenieVyplaty.Izmeneniia Set end)
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
                    return ICSSoft.STORMNET.Information.GetView("AuditView", typeof(Iis.Eais.Leechnost.NaznachenieVyplaty));
                }
            }

            /// <summary>
            /// "NaznachenieVyplatyE" view.
            /// </summary>
            public static ICSSoft.STORMNET.View NaznachenieVyplatyE
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("NaznachenieVyplatyE", typeof(Iis.Eais.Leechnost.NaznachenieVyplaty));
                }
            }

            /// <summary>
            /// "NaznachenieVyplatyL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View NaznachenieVyplatyL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("NaznachenieVyplatyL", typeof(Iis.Eais.Leechnost.NaznachenieVyplaty));
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
}
