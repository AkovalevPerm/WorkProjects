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
    /// СтатьяАкта.
    /// </summary>
    // *** Start programmer edit section *** (StatiaAkta CustomAttributes)
    [Primary(true)]
    [Serializable]
    // *** End programmer edit section *** (StatiaAkta CustomAttributes)
    [BusinessServer("Iis.Eais.Catalogs.StatiaAktaBS, Eais.Catalogs.BusinessServers", ICSSoft.STORMNET.Business.DataServiceObjectEvents.OnAllEvents)]
    [AutoAltered()]
    [AccessType(ICSSoft.STORMNET.AccessType.@this)]
    [View("AuditView", new string[] {
            "Nomer as \'Номер\'",
            "Kommentarii as \'Комментарий\'",
            "Lgota as \'Наименование льготы\'",
            "Kod as \'Код льготы\'",
            "Akt as \'Акт\'",
            "Oldid as \'Ид\'"})]
    [View("StatiaAktaE", new string[] {
            "Nomer as \'Номер\'",
            "Kommentarii as \'Комментарий\'",
            "Lgota as \'Наименование льготы\'",
            "Kod as \'Код льготы\'",
            "Oldid as \'Ид\'"})]
    [View("StatiaAktaL", new string[] {
            "Nomer as \'Номер\'",
            "Kommentarii as \'Комментарий\'",
            "Akt.Tip.Naimenovanie as \'Тип акта\'",
            "Akt.Naimenovanie as \'Нормативный акт\'",
            "Akt.Izdatel.Naimenovanie as \'Орган издатель\'",
            "Lgota as \'Льгота\'",
            "Kod as \'Код льготы\'",
            "Akt.KodOtchFedKaznach as \'Код отчетности ФК\'",
            "CreateTime as \'Время создания объекта\'",
            "Creator as \'Создатель объекта\'",
            "EditTime as \'Время последнего редактирования\'",
            "Editor as \'Последний редактор объекта\'",
            "Akt",
            "Oldid as \'Ид\'"}, Hidden = new string[] {
            "CreateTime",
            "Creator",
            "EditTime",
            "Editor",
            "Akt"})]
    public class StatiaAkta : ICSSoft.STORMNET.DataObject, IDataObjectWithAuditFields, ISync
    {

        private string fNomer;

        private string fKommentarii;

        private string fLgota;

        private string fKod;

        private System.Nullable<System.DateTime> fCreateTime;

        private string fCreator;

        private System.Nullable<System.DateTime> fEditTime;

        private string fEditor;

        private int fOldid;

        private Iis.Eais.Catalogs.NormAkt fAkt;

        // *** Start programmer edit section *** (StatiaAkta CustomMembers)

        // *** End programmer edit section *** (StatiaAkta CustomMembers)


        /// <summary>
        /// Nomer.
        /// </summary>
        // *** Start programmer edit section *** (StatiaAkta.Nomer CustomAttributes)

        // *** End programmer edit section *** (StatiaAkta.Nomer CustomAttributes)
        [NotNull()]
        public virtual string Nomer
        {
            get
            {
                // *** Start programmer edit section *** (StatiaAkta.Nomer Get start)

                // *** End programmer edit section *** (StatiaAkta.Nomer Get start)
                string result = this.fNomer;
                // *** Start programmer edit section *** (StatiaAkta.Nomer Get end)

                // *** End programmer edit section *** (StatiaAkta.Nomer Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (StatiaAkta.Nomer Set start)

                // *** End programmer edit section *** (StatiaAkta.Nomer Set start)
                this.fNomer = value;
                // *** Start programmer edit section *** (StatiaAkta.Nomer Set end)

                // *** End programmer edit section *** (StatiaAkta.Nomer Set end)
            }
        }

        /// <summary>
        /// Kommentarii.
        /// </summary>
        // *** Start programmer edit section *** (StatiaAkta.Kommentarii CustomAttributes)

        // *** End programmer edit section *** (StatiaAkta.Kommentarii CustomAttributes)
        public virtual string Kommentarii
        {
            get
            {
                // *** Start programmer edit section *** (StatiaAkta.Kommentarii Get start)

                // *** End programmer edit section *** (StatiaAkta.Kommentarii Get start)
                string result = this.fKommentarii;
                // *** Start programmer edit section *** (StatiaAkta.Kommentarii Get end)

                // *** End programmer edit section *** (StatiaAkta.Kommentarii Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (StatiaAkta.Kommentarii Set start)

                // *** End programmer edit section *** (StatiaAkta.Kommentarii Set start)
                this.fKommentarii = value;
                // *** Start programmer edit section *** (StatiaAkta.Kommentarii Set end)

                // *** End programmer edit section *** (StatiaAkta.Kommentarii Set end)
            }
        }

        /// <summary>
        /// Lgota.
        /// </summary>
        // *** Start programmer edit section *** (StatiaAkta.Lgota CustomAttributes)

        // *** End programmer edit section *** (StatiaAkta.Lgota CustomAttributes)
        public virtual string Lgota
        {
            get
            {
                // *** Start programmer edit section *** (StatiaAkta.Lgota Get start)

                // *** End programmer edit section *** (StatiaAkta.Lgota Get start)
                string result = this.fLgota;
                // *** Start programmer edit section *** (StatiaAkta.Lgota Get end)

                // *** End programmer edit section *** (StatiaAkta.Lgota Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (StatiaAkta.Lgota Set start)

                // *** End programmer edit section *** (StatiaAkta.Lgota Set start)
                this.fLgota = value;
                // *** Start programmer edit section *** (StatiaAkta.Lgota Set end)

                // *** End programmer edit section *** (StatiaAkta.Lgota Set end)
            }
        }

        /// <summary>
        /// Kod.
        /// </summary>
        // *** Start programmer edit section *** (StatiaAkta.Kod CustomAttributes)

        // *** End programmer edit section *** (StatiaAkta.Kod CustomAttributes)
        public virtual string Kod
        {
            get
            {
                // *** Start programmer edit section *** (StatiaAkta.Kod Get start)

                // *** End programmer edit section *** (StatiaAkta.Kod Get start)
                string result = this.fKod;
                // *** Start programmer edit section *** (StatiaAkta.Kod Get end)

                // *** End programmer edit section *** (StatiaAkta.Kod Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (StatiaAkta.Kod Set start)

                // *** End programmer edit section *** (StatiaAkta.Kod Set start)
                this.fKod = value;
                // *** Start programmer edit section *** (StatiaAkta.Kod Set end)

                // *** End programmer edit section *** (StatiaAkta.Kod Set end)
            }
        }

        /// <summary>
        /// Время создания объекта.
        /// </summary>
        // *** Start programmer edit section *** (StatiaAkta.CreateTime CustomAttributes)

        // *** End programmer edit section *** (StatiaAkta.CreateTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> CreateTime
        {
            get
            {
                // *** Start programmer edit section *** (StatiaAkta.CreateTime Get start)

                // *** End programmer edit section *** (StatiaAkta.CreateTime Get start)
                System.Nullable<System.DateTime> result = this.fCreateTime;
                // *** Start programmer edit section *** (StatiaAkta.CreateTime Get end)

                // *** End programmer edit section *** (StatiaAkta.CreateTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (StatiaAkta.CreateTime Set start)

                // *** End programmer edit section *** (StatiaAkta.CreateTime Set start)
                this.fCreateTime = value;
                // *** Start programmer edit section *** (StatiaAkta.CreateTime Set end)

                // *** End programmer edit section *** (StatiaAkta.CreateTime Set end)
            }
        }

        /// <summary>
        /// Создатель объекта.
        /// </summary>
        // *** Start programmer edit section *** (StatiaAkta.Creator CustomAttributes)

        // *** End programmer edit section *** (StatiaAkta.Creator CustomAttributes)
        [StrLen(255)]
        public virtual string Creator
        {
            get
            {
                // *** Start programmer edit section *** (StatiaAkta.Creator Get start)

                // *** End programmer edit section *** (StatiaAkta.Creator Get start)
                string result = this.fCreator;
                // *** Start programmer edit section *** (StatiaAkta.Creator Get end)

                // *** End programmer edit section *** (StatiaAkta.Creator Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (StatiaAkta.Creator Set start)

                // *** End programmer edit section *** (StatiaAkta.Creator Set start)
                this.fCreator = value;
                // *** Start programmer edit section *** (StatiaAkta.Creator Set end)

                // *** End programmer edit section *** (StatiaAkta.Creator Set end)
            }
        }

        /// <summary>
        /// Время последнего редактирования объекта.
        /// </summary>
        // *** Start programmer edit section *** (StatiaAkta.EditTime CustomAttributes)

        // *** End programmer edit section *** (StatiaAkta.EditTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> EditTime
        {
            get
            {
                // *** Start programmer edit section *** (StatiaAkta.EditTime Get start)

                // *** End programmer edit section *** (StatiaAkta.EditTime Get start)
                System.Nullable<System.DateTime> result = this.fEditTime;
                // *** Start programmer edit section *** (StatiaAkta.EditTime Get end)

                // *** End programmer edit section *** (StatiaAkta.EditTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (StatiaAkta.EditTime Set start)

                // *** End programmer edit section *** (StatiaAkta.EditTime Set start)
                this.fEditTime = value;
                // *** Start programmer edit section *** (StatiaAkta.EditTime Set end)

                // *** End programmer edit section *** (StatiaAkta.EditTime Set end)
            }
        }

        /// <summary>
        /// Последний редактор объекта.
        /// </summary>
        // *** Start programmer edit section *** (StatiaAkta.Editor CustomAttributes)

        // *** End programmer edit section *** (StatiaAkta.Editor CustomAttributes)
        [StrLen(255)]
        public virtual string Editor
        {
            get
            {
                // *** Start programmer edit section *** (StatiaAkta.Editor Get start)

                // *** End programmer edit section *** (StatiaAkta.Editor Get start)
                string result = this.fEditor;
                // *** Start programmer edit section *** (StatiaAkta.Editor Get end)

                // *** End programmer edit section *** (StatiaAkta.Editor Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (StatiaAkta.Editor Set start)

                // *** End programmer edit section *** (StatiaAkta.Editor Set start)
                this.fEditor = value;
                // *** Start programmer edit section *** (StatiaAkta.Editor Set end)

                // *** End programmer edit section *** (StatiaAkta.Editor Set end)
            }
        }

        /// <summary>
        /// Oldid.
        /// </summary>
        // *** Start programmer edit section *** (StatiaAkta.Oldid CustomAttributes)

        // *** End programmer edit section *** (StatiaAkta.Oldid CustomAttributes)
        public virtual int Oldid
        {
            get
            {
                // *** Start programmer edit section *** (StatiaAkta.Oldid Get start)

                // *** End programmer edit section *** (StatiaAkta.Oldid Get start)
                int result = this.fOldid;
                // *** Start programmer edit section *** (StatiaAkta.Oldid Get end)

                // *** End programmer edit section *** (StatiaAkta.Oldid Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (StatiaAkta.Oldid Set start)

                // *** End programmer edit section *** (StatiaAkta.Oldid Set start)
                this.fOldid = value;
                // *** Start programmer edit section *** (StatiaAkta.Oldid Set end)

                // *** End programmer edit section *** (StatiaAkta.Oldid Set end)
            }
        }

        /// <summary>
        /// мастеровая ссылка на шапку Iis.Eais.Catalogs.NormAkt.
        /// </summary>
        // *** Start programmer edit section *** (StatiaAkta.Akt CustomAttributes)

        // *** End programmer edit section *** (StatiaAkta.Akt CustomAttributes)
        [Agregator()]
        [NotNull()]
        [PropertyStorage(new string[] {
                "Akt"})]
        public virtual Iis.Eais.Catalogs.NormAkt Akt
        {
            get
            {
                // *** Start programmer edit section *** (StatiaAkta.Akt Get start)

                // *** End programmer edit section *** (StatiaAkta.Akt Get start)
                Iis.Eais.Catalogs.NormAkt result = this.fAkt;
                // *** Start programmer edit section *** (StatiaAkta.Akt Get end)

                // *** End programmer edit section *** (StatiaAkta.Akt Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (StatiaAkta.Akt Set start)

                // *** End programmer edit section *** (StatiaAkta.Akt Set start)
                this.fAkt = value;
                // *** Start programmer edit section *** (StatiaAkta.Akt Set end)

                // *** End programmer edit section *** (StatiaAkta.Akt Set end)
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
                    return ICSSoft.STORMNET.Information.GetView("AuditView", typeof(Iis.Eais.Catalogs.StatiaAkta));
                }
            }

            /// <summary>
            /// "StatiaAktaE" view.
            /// </summary>
            public static ICSSoft.STORMNET.View StatiaAktaE
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("StatiaAktaE", typeof(Iis.Eais.Catalogs.StatiaAkta));
                }
            }

            /// <summary>
            /// "StatiaAktaL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View StatiaAktaL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("StatiaAktaL", typeof(Iis.Eais.Catalogs.StatiaAkta));
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
    /// Detail array of StatiaAkta.
    /// </summary>
    // *** Start programmer edit section *** (DetailArrayDetailArrayOfStatiaAkta CustomAttributes)
    [Serializable]
    // *** End programmer edit section *** (DetailArrayDetailArrayOfStatiaAkta CustomAttributes)
    public class DetailArrayOfStatiaAkta : ICSSoft.STORMNET.DetailArray
    {

        // *** Start programmer edit section *** (Iis.Eais.Catalogs.DetailArrayOfStatiaAkta members)

        // *** End programmer edit section *** (Iis.Eais.Catalogs.DetailArrayOfStatiaAkta members)


        /// <summary>
        /// Construct detail array.
        /// </summary>
        /// <summary>
        /// Returns object with type StatiaAkta by index.
        /// </summary>
        /// <summary>
        /// Adds object with type StatiaAkta.
        /// </summary>
        public DetailArrayOfStatiaAkta(Iis.Eais.Catalogs.NormAkt fNormAkt) :
                base(typeof(StatiaAkta), ((ICSSoft.STORMNET.DataObject)(fNormAkt)))
        {
        }

        public Iis.Eais.Catalogs.StatiaAkta this[int index]
        {
            get
            {
                return ((Iis.Eais.Catalogs.StatiaAkta)(this.ItemByIndex(index)));
            }
        }

        public virtual void Add(Iis.Eais.Catalogs.StatiaAkta dataobject)
        {
            this.AddObject(((ICSSoft.STORMNET.DataObject)(dataobject)));
        }
    }
}