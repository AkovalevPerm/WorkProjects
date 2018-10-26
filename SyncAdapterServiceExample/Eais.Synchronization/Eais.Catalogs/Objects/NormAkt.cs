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
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business.Audit;


    // *** Start programmer edit section *** (Using statements)
    using Iis.Eais.Common;

    using IIS.Synchronizer;
    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// НормАкт.
    /// </summary>
    // *** Start programmer edit section *** (NormAkt CustomAttributes)
    [Primary(true)]
    [Serializable]
    // *** End programmer edit section *** (NormAkt CustomAttributes)
    [BusinessServer("Iis.Eais.Catalogs.CatalogsBS, Eais.Catalogs.BusinessServers", ICSSoft.STORMNET.Business.DataServiceObjectEvents.OnAllEvents)]
    [AutoAltered()]
    [AccessType(ICSSoft.STORMNET.AccessType.@this)]
    [View("AuditView", new string[] {
            "Nomer as \'Номер\'",
            "DataPodpisaniia as \'Дата подписания\'",
            "Naimenovanie as \'Наименование\'",
            "KodOtchFedKaznach as \'Код отчетности Федерального казначейства\'",
            "Tip as \'Тип\'",
            "Izdatel as \'Издатель\'",
            "Oldid as \'Ид\'"})]
    [AssociatedDetailViewAttribute("AuditView", "Stati", "AuditView", true, "", "Статья", true, new string[] {
            ""})]
    [View("NormAktE", new string[] {
            "Nomer as \'Номер\'",
            "DataPodpisaniia as \'Дата подписания\'",
            "Naimenovanie as \'Наименование\'",
            "KodOtchFedKaznach as \'Код отчетности Федерального казначейства\'",
            "Tip as \'Тип нормативного акта\'",
            "Tip.Naimenovanie as \'\'",
            "Izdatel as \'Орган издатель\'",
            "Izdatel.Naimenovanie as \'\'",
            "Oldid as \'Ид\'"})]
    [AssociatedDetailViewAttribute("NormAktE", "Stati", "StatiaAktaL", true, "", "Статьи акта", true, new string[] {
            ""})]
    [View("NormAktL", new string[] {
            "Naimenovanie as \'Наименование\'",
            "Nomer as \'Номер\'",
            "DataPodpisaniia as \'Дата подписания\'",
            "Tip.Naimenovanie as \'Тип нормативного акта\'",
            "Izdatel.Naimenovanie as \'Орган издатель\'",
            "KodOtchFedKaznach as \'Код отчетности ФК\'",
            "CreateTime as \'Время создания объекта\'",
            "Creator as \'Создатель объекта\'",
            "EditTime as \'Время последнего редактирования\'",
            "Editor as \'Последний редактор объекта\'",
            "Oldid as \'Ид\'"}, Hidden = new string[] {
            "CreateTime",
            "Creator",
            "EditTime",
            "Editor"})]
    public class NormAkt : ICSSoft.STORMNET.DataObject, IDataObjectWithAuditFields, ISync
    {

        private string fNaimenovanie;

        private string fNomer;

        private System.DateTime? fDataPodpisaniia;

        private string fKodOtchFedKaznach;

        private System.Nullable<System.DateTime> fCreateTime;

        private string fCreator;

        private System.Nullable<System.DateTime> fEditTime;

        private string fEditor;

        private int fOldid;

        private Iis.Eais.Catalogs.TipNormAkta fTip;

        private Iis.Eais.Catalogs.UrovenVlasti fIzdatel;

        private Iis.Eais.Catalogs.DetailArrayOfStatiaAkta fStati;

        // *** Start programmer edit section *** (NormAkt CustomMembers)

        // *** End programmer edit section *** (NormAkt CustomMembers)


        /// <summary>
        /// Naimenovanie.
        /// </summary>
        // *** Start programmer edit section *** (NormAkt.Naimenovanie CustomAttributes)

        // *** End programmer edit section *** (NormAkt.Naimenovanie CustomAttributes)
        [NotNull()]
        public virtual string Naimenovanie
        {
            get
            {
                // *** Start programmer edit section *** (NormAkt.Naimenovanie Get start)

                // *** End programmer edit section *** (NormAkt.Naimenovanie Get start)
                string result = this.fNaimenovanie;
                // *** Start programmer edit section *** (NormAkt.Naimenovanie Get end)

                // *** End programmer edit section *** (NormAkt.Naimenovanie Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (NormAkt.Naimenovanie Set start)

                // *** End programmer edit section *** (NormAkt.Naimenovanie Set start)
                this.fNaimenovanie = value;
                // *** Start programmer edit section *** (NormAkt.Naimenovanie Set end)

                // *** End programmer edit section *** (NormAkt.Naimenovanie Set end)
            }
        }

        /// <summary>
        /// Nomer.
        /// </summary>
        // *** Start programmer edit section *** (NormAkt.Nomer CustomAttributes)

        // *** End programmer edit section *** (NormAkt.Nomer CustomAttributes)
        public virtual string Nomer
        {
            get
            {
                // *** Start programmer edit section *** (NormAkt.Nomer Get start)

                // *** End programmer edit section *** (NormAkt.Nomer Get start)
                string result = this.fNomer;
                // *** Start programmer edit section *** (NormAkt.Nomer Get end)

                // *** End programmer edit section *** (NormAkt.Nomer Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (NormAkt.Nomer Set start)

                // *** End programmer edit section *** (NormAkt.Nomer Set start)
                this.fNomer = value;
                // *** Start programmer edit section *** (NormAkt.Nomer Set end)

                // *** End programmer edit section *** (NormAkt.Nomer Set end)
            }
        }

        /// <summary>
        /// DataPodpisaniia.
        /// </summary>
        // *** Start programmer edit section *** (NormAkt.DataPodpisaniia CustomAttributes)

        // *** End programmer edit section *** (NormAkt.DataPodpisaniia CustomAttributes)
        public virtual System.DateTime? DataPodpisaniia
        {
            get
            {
                // *** Start programmer edit section *** (NormAkt.DataPodpisaniia Get start)

                // *** End programmer edit section *** (NormAkt.DataPodpisaniia Get start)
                System.DateTime? result = this.fDataPodpisaniia;
                // *** Start programmer edit section *** (NormAkt.DataPodpisaniia Get end)

                // *** End programmer edit section *** (NormAkt.DataPodpisaniia Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (NormAkt.DataPodpisaniia Set start)

                // *** End programmer edit section *** (NormAkt.DataPodpisaniia Set start)
                this.fDataPodpisaniia = value;
                // *** Start programmer edit section *** (NormAkt.DataPodpisaniia Set end)

                // *** End programmer edit section *** (NormAkt.DataPodpisaniia Set end)
            }
        }

        /// <summary>
        /// KodOtchFedKaznach.
        /// </summary>
        // *** Start programmer edit section *** (NormAkt.KodOtchFedKaznach CustomAttributes)

        // *** End programmer edit section *** (NormAkt.KodOtchFedKaznach CustomAttributes)
        public virtual string KodOtchFedKaznach
        {
            get
            {
                // *** Start programmer edit section *** (NormAkt.KodOtchFedKaznach Get start)

                // *** End programmer edit section *** (NormAkt.KodOtchFedKaznach Get start)
                string result = this.fKodOtchFedKaznach;
                // *** Start programmer edit section *** (NormAkt.KodOtchFedKaznach Get end)

                // *** End programmer edit section *** (NormAkt.KodOtchFedKaznach Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (NormAkt.KodOtchFedKaznach Set start)

                // *** End programmer edit section *** (NormAkt.KodOtchFedKaznach Set start)
                this.fKodOtchFedKaznach = value;
                // *** Start programmer edit section *** (NormAkt.KodOtchFedKaznach Set end)

                // *** End programmer edit section *** (NormAkt.KodOtchFedKaznach Set end)
            }
        }

        /// <summary>
        /// Время создания объекта.
        /// </summary>
        // *** Start programmer edit section *** (NormAkt.CreateTime CustomAttributes)

        // *** End programmer edit section *** (NormAkt.CreateTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> CreateTime
        {
            get
            {
                // *** Start programmer edit section *** (NormAkt.CreateTime Get start)

                // *** End programmer edit section *** (NormAkt.CreateTime Get start)
                System.Nullable<System.DateTime> result = this.fCreateTime;
                // *** Start programmer edit section *** (NormAkt.CreateTime Get end)

                // *** End programmer edit section *** (NormAkt.CreateTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (NormAkt.CreateTime Set start)

                // *** End programmer edit section *** (NormAkt.CreateTime Set start)
                this.fCreateTime = value;
                // *** Start programmer edit section *** (NormAkt.CreateTime Set end)

                // *** End programmer edit section *** (NormAkt.CreateTime Set end)
            }
        }

        /// <summary>
        /// Создатель объекта.
        /// </summary>
        // *** Start programmer edit section *** (NormAkt.Creator CustomAttributes)

        // *** End programmer edit section *** (NormAkt.Creator CustomAttributes)
        [StrLen(255)]
        public virtual string Creator
        {
            get
            {
                // *** Start programmer edit section *** (NormAkt.Creator Get start)

                // *** End programmer edit section *** (NormAkt.Creator Get start)
                string result = this.fCreator;
                // *** Start programmer edit section *** (NormAkt.Creator Get end)

                // *** End programmer edit section *** (NormAkt.Creator Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (NormAkt.Creator Set start)

                // *** End programmer edit section *** (NormAkt.Creator Set start)
                this.fCreator = value;
                // *** Start programmer edit section *** (NormAkt.Creator Set end)

                // *** End programmer edit section *** (NormAkt.Creator Set end)
            }
        }

        /// <summary>
        /// Время последнего редактирования объекта.
        /// </summary>
        // *** Start programmer edit section *** (NormAkt.EditTime CustomAttributes)

        // *** End programmer edit section *** (NormAkt.EditTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> EditTime
        {
            get
            {
                // *** Start programmer edit section *** (NormAkt.EditTime Get start)

                // *** End programmer edit section *** (NormAkt.EditTime Get start)
                System.Nullable<System.DateTime> result = this.fEditTime;
                // *** Start programmer edit section *** (NormAkt.EditTime Get end)

                // *** End programmer edit section *** (NormAkt.EditTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (NormAkt.EditTime Set start)

                // *** End programmer edit section *** (NormAkt.EditTime Set start)
                this.fEditTime = value;
                // *** Start programmer edit section *** (NormAkt.EditTime Set end)

                // *** End programmer edit section *** (NormAkt.EditTime Set end)
            }
        }

        /// <summary>
        /// Последний редактор объекта.
        /// </summary>
        // *** Start programmer edit section *** (NormAkt.Editor CustomAttributes)

        // *** End programmer edit section *** (NormAkt.Editor CustomAttributes)
        [StrLen(255)]
        public virtual string Editor
        {
            get
            {
                // *** Start programmer edit section *** (NormAkt.Editor Get start)

                // *** End programmer edit section *** (NormAkt.Editor Get start)
                string result = this.fEditor;
                // *** Start programmer edit section *** (NormAkt.Editor Get end)

                // *** End programmer edit section *** (NormAkt.Editor Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (NormAkt.Editor Set start)

                // *** End programmer edit section *** (NormAkt.Editor Set start)
                this.fEditor = value;
                // *** Start programmer edit section *** (NormAkt.Editor Set end)

                // *** End programmer edit section *** (NormAkt.Editor Set end)
            }
        }

        /// <summary>
        /// Oldid.
        /// </summary>
        // *** Start programmer edit section *** (NormAkt.Oldid CustomAttributes)

        // *** End programmer edit section *** (NormAkt.Oldid CustomAttributes)
        public virtual int Oldid
        {
            get
            {
                // *** Start programmer edit section *** (NormAkt.Oldid Get start)

                // *** End programmer edit section *** (NormAkt.Oldid Get start)
                int result = this.fOldid;
                // *** Start programmer edit section *** (NormAkt.Oldid Get end)

                // *** End programmer edit section *** (NormAkt.Oldid Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (NormAkt.Oldid Set start)

                // *** End programmer edit section *** (NormAkt.Oldid Set start)
                this.fOldid = value;
                // *** Start programmer edit section *** (NormAkt.Oldid Set end)

                // *** End programmer edit section *** (NormAkt.Oldid Set end)
            }
        }

        /// <summary>
        /// НормАкт.
        /// </summary>
        // *** Start programmer edit section *** (NormAkt.Tip CustomAttributes)

        // *** End programmer edit section *** (NormAkt.Tip CustomAttributes)
        [PropertyStorage(new string[] {
                "Tip"})]
        [NotNull()]
        public virtual Iis.Eais.Catalogs.TipNormAkta Tip
        {
            get
            {
                // *** Start programmer edit section *** (NormAkt.Tip Get start)

                // *** End programmer edit section *** (NormAkt.Tip Get start)
                Iis.Eais.Catalogs.TipNormAkta result = this.fTip;
                // *** Start programmer edit section *** (NormAkt.Tip Get end)

                // *** End programmer edit section *** (NormAkt.Tip Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (NormAkt.Tip Set start)

                // *** End programmer edit section *** (NormAkt.Tip Set start)
                this.fTip = value;
                // *** Start programmer edit section *** (NormAkt.Tip Set end)

                // *** End programmer edit section *** (NormAkt.Tip Set end)
            }
        }

        /// <summary>
        /// НормАкт.
        /// </summary>
        // *** Start programmer edit section *** (NormAkt.Izdatel CustomAttributes)

        // *** End programmer edit section *** (NormAkt.Izdatel CustomAttributes)
        [PropertyStorage(new string[] {
                "Izdatel"})]
        [NotNull()]
        public virtual Iis.Eais.Catalogs.UrovenVlasti Izdatel
        {
            get
            {
                // *** Start programmer edit section *** (NormAkt.Izdatel Get start)

                // *** End programmer edit section *** (NormAkt.Izdatel Get start)
                Iis.Eais.Catalogs.UrovenVlasti result = this.fIzdatel;
                // *** Start programmer edit section *** (NormAkt.Izdatel Get end)

                // *** End programmer edit section *** (NormAkt.Izdatel Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (NormAkt.Izdatel Set start)

                // *** End programmer edit section *** (NormAkt.Izdatel Set start)
                this.fIzdatel = value;
                // *** Start programmer edit section *** (NormAkt.Izdatel Set end)

                // *** End programmer edit section *** (NormAkt.Izdatel Set end)
            }
        }

        /// <summary>
        /// НормАкт.
        /// </summary>
        // *** Start programmer edit section *** (NormAkt.Stati CustomAttributes)

        // *** End programmer edit section *** (NormAkt.Stati CustomAttributes)
        public virtual Iis.Eais.Catalogs.DetailArrayOfStatiaAkta Stati
        {
            get
            {
                // *** Start programmer edit section *** (NormAkt.Stati Get start)

                // *** End programmer edit section *** (NormAkt.Stati Get start)
                if ((this.fStati == null))
                {
                    this.fStati = new Iis.Eais.Catalogs.DetailArrayOfStatiaAkta(this);
                }
                Iis.Eais.Catalogs.DetailArrayOfStatiaAkta result = this.fStati;
                // *** Start programmer edit section *** (NormAkt.Stati Get end)

                // *** End programmer edit section *** (NormAkt.Stati Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (NormAkt.Stati Set start)

                // *** End programmer edit section *** (NormAkt.Stati Set start)
                this.fStati = value;
                // *** Start programmer edit section *** (NormAkt.Stati Set end)

                // *** End programmer edit section *** (NormAkt.Stati Set end)
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
                    return ICSSoft.STORMNET.Information.GetView("AuditView", typeof(Iis.Eais.Catalogs.NormAkt));
                }
            }

            /// <summary>
            /// "NormAktE" view.
            /// </summary>
            public static ICSSoft.STORMNET.View NormAktE
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("NormAktE", typeof(Iis.Eais.Catalogs.NormAkt));
                }
            }

            /// <summary>
            /// "NormAktL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View NormAktL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("NormAktL", typeof(Iis.Eais.Catalogs.NormAkt));
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
