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
    /// RodstvOtn.
    /// </summary>
    // *** Start programmer edit section *** (RodstvOtn CustomAttributes)
    [Primary(true)]
    [Serializable]
    // *** End programmer edit section *** (RodstvOtn CustomAttributes)
    [BusinessServer("Iis.Eais.Catalogs.CatalogsBS, Eais.Catalogs.BusinessServers", ICSSoft.STORMNET.Business.DataServiceObjectEvents.OnAllEvents)]
    [AutoAltered()]
    [AccessType(ICSSoft.STORMNET.AccessType.@this)]
    [View("AuditView", new string[] {
            "Naimenovanie as \'Наименование\'",
            "Pol as \'Пол\'",
            "Oldid as \'Ид\'"})]
    [View("RodstvOtnE", new string[] {
            "Naimenovanie as \'Наименование\'",
            "Pol as \'Пол\'",
            "Oldid as \'Ид\'"})]
    [View("RodstvOtnL", new string[] {
            "Naimenovanie as \'Наименование\'",
            "Pol as \'Пол\'",
            "CreateTime as \'Время создания\'",
            "Creator as \'Создатель\'",
            "EditTime as \'Время редактирования\'",
            "Editor as \'Редактор\'",
            "Oldid as \'Ид\'"}, Hidden = new string[] {
            "CreateTime",
            "Creator",
            "EditTime",
            "Editor"})]
    public class RodstvOtn : ICSSoft.STORMNET.DataObject, IDataObjectWithAuditFields, ISync
    {

        private string fNaimenovanie;

        private Iis.Eais.Catalogs.tPol fPol;

        private System.Nullable<System.DateTime> fCreateTime;

        private string fCreator;

        private System.Nullable<System.DateTime> fEditTime;

        private string fEditor;

        private int fOldid;

        // *** Start programmer edit section *** (RodstvOtn CustomMembers)

        // *** End programmer edit section *** (RodstvOtn CustomMembers)


        /// <summary>
        /// Naimenovanie.
        /// </summary>
        // *** Start programmer edit section *** (RodstvOtn.Naimenovanie CustomAttributes)

        // *** End programmer edit section *** (RodstvOtn.Naimenovanie CustomAttributes)
        [StrLen(25)]
        [NotNull()]
        public virtual string Naimenovanie
        {
            get
            {
                // *** Start programmer edit section *** (RodstvOtn.Naimenovanie Get start)

                // *** End programmer edit section *** (RodstvOtn.Naimenovanie Get start)
                string result = this.fNaimenovanie;
                // *** Start programmer edit section *** (RodstvOtn.Naimenovanie Get end)

                // *** End programmer edit section *** (RodstvOtn.Naimenovanie Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (RodstvOtn.Naimenovanie Set start)

                // *** End programmer edit section *** (RodstvOtn.Naimenovanie Set start)
                this.fNaimenovanie = value;
                // *** Start programmer edit section *** (RodstvOtn.Naimenovanie Set end)

                // *** End programmer edit section *** (RodstvOtn.Naimenovanie Set end)
            }
        }

        /// <summary>
        /// Pol.
        /// </summary>
        // *** Start programmer edit section *** (RodstvOtn.Pol CustomAttributes)

        // *** End programmer edit section *** (RodstvOtn.Pol CustomAttributes)
        [NotNull()]
        public virtual Iis.Eais.Catalogs.tPol Pol
        {
            get
            {
                // *** Start programmer edit section *** (RodstvOtn.Pol Get start)

                // *** End programmer edit section *** (RodstvOtn.Pol Get start)
                Iis.Eais.Catalogs.tPol result = this.fPol;
                // *** Start programmer edit section *** (RodstvOtn.Pol Get end)

                // *** End programmer edit section *** (RodstvOtn.Pol Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (RodstvOtn.Pol Set start)

                // *** End programmer edit section *** (RodstvOtn.Pol Set start)
                this.fPol = value;
                // *** Start programmer edit section *** (RodstvOtn.Pol Set end)

                // *** End programmer edit section *** (RodstvOtn.Pol Set end)
            }
        }

        /// <summary>
        /// Время создания объекта.
        /// </summary>
        // *** Start programmer edit section *** (RodstvOtn.CreateTime CustomAttributes)

        // *** End programmer edit section *** (RodstvOtn.CreateTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> CreateTime
        {
            get
            {
                // *** Start programmer edit section *** (RodstvOtn.CreateTime Get start)

                // *** End programmer edit section *** (RodstvOtn.CreateTime Get start)
                System.Nullable<System.DateTime> result = this.fCreateTime;
                // *** Start programmer edit section *** (RodstvOtn.CreateTime Get end)

                // *** End programmer edit section *** (RodstvOtn.CreateTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (RodstvOtn.CreateTime Set start)

                // *** End programmer edit section *** (RodstvOtn.CreateTime Set start)
                this.fCreateTime = value;
                // *** Start programmer edit section *** (RodstvOtn.CreateTime Set end)

                // *** End programmer edit section *** (RodstvOtn.CreateTime Set end)
            }
        }

        /// <summary>
        /// Создатель объекта.
        /// </summary>
        // *** Start programmer edit section *** (RodstvOtn.Creator CustomAttributes)

        // *** End programmer edit section *** (RodstvOtn.Creator CustomAttributes)
        [StrLen(255)]
        public virtual string Creator
        {
            get
            {
                // *** Start programmer edit section *** (RodstvOtn.Creator Get start)

                // *** End programmer edit section *** (RodstvOtn.Creator Get start)
                string result = this.fCreator;
                // *** Start programmer edit section *** (RodstvOtn.Creator Get end)

                // *** End programmer edit section *** (RodstvOtn.Creator Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (RodstvOtn.Creator Set start)

                // *** End programmer edit section *** (RodstvOtn.Creator Set start)
                this.fCreator = value;
                // *** Start programmer edit section *** (RodstvOtn.Creator Set end)

                // *** End programmer edit section *** (RodstvOtn.Creator Set end)
            }
        }

        /// <summary>
        /// Время последнего редактирования объекта.
        /// </summary>
        // *** Start programmer edit section *** (RodstvOtn.EditTime CustomAttributes)

        // *** End programmer edit section *** (RodstvOtn.EditTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> EditTime
        {
            get
            {
                // *** Start programmer edit section *** (RodstvOtn.EditTime Get start)

                // *** End programmer edit section *** (RodstvOtn.EditTime Get start)
                System.Nullable<System.DateTime> result = this.fEditTime;
                // *** Start programmer edit section *** (RodstvOtn.EditTime Get end)

                // *** End programmer edit section *** (RodstvOtn.EditTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (RodstvOtn.EditTime Set start)

                // *** End programmer edit section *** (RodstvOtn.EditTime Set start)
                this.fEditTime = value;
                // *** Start programmer edit section *** (RodstvOtn.EditTime Set end)

                // *** End programmer edit section *** (RodstvOtn.EditTime Set end)
            }
        }

        /// <summary>
        /// Последний редактор объекта.
        /// </summary>
        // *** Start programmer edit section *** (RodstvOtn.Editor CustomAttributes)

        // *** End programmer edit section *** (RodstvOtn.Editor CustomAttributes)
        [StrLen(255)]
        public virtual string Editor
        {
            get
            {
                // *** Start programmer edit section *** (RodstvOtn.Editor Get start)

                // *** End programmer edit section *** (RodstvOtn.Editor Get start)
                string result = this.fEditor;
                // *** Start programmer edit section *** (RodstvOtn.Editor Get end)

                // *** End programmer edit section *** (RodstvOtn.Editor Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (RodstvOtn.Editor Set start)

                // *** End programmer edit section *** (RodstvOtn.Editor Set start)
                this.fEditor = value;
                // *** Start programmer edit section *** (RodstvOtn.Editor Set end)

                // *** End programmer edit section *** (RodstvOtn.Editor Set end)
            }
        }

        /// <summary>
        /// Oldid.
        /// </summary>
        // *** Start programmer edit section *** (RodstvOtn.Oldid CustomAttributes)

        // *** End programmer edit section *** (RodstvOtn.Oldid CustomAttributes)
        public virtual int Oldid
        {
            get
            {
                // *** Start programmer edit section *** (RodstvOtn.Oldid Get start)

                // *** End programmer edit section *** (RodstvOtn.Oldid Get start)
                int result = this.fOldid;
                // *** Start programmer edit section *** (RodstvOtn.Oldid Get end)

                // *** End programmer edit section *** (RodstvOtn.Oldid Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (RodstvOtn.Oldid Set start)

                // *** End programmer edit section *** (RodstvOtn.Oldid Set start)
                this.fOldid = value;
                // *** Start programmer edit section *** (RodstvOtn.Oldid Set end)

                // *** End programmer edit section *** (RodstvOtn.Oldid Set end)
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
                    return ICSSoft.STORMNET.Information.GetView("AuditView", typeof(Iis.Eais.Catalogs.RodstvOtn));
                }
            }

            /// <summary>
            /// "RodstvOtnE" view.
            /// </summary>
            public static ICSSoft.STORMNET.View RodstvOtnE
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("RodstvOtnE", typeof(Iis.Eais.Catalogs.RodstvOtn));
                }
            }

            /// <summary>
            /// "RodstvOtnL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View RodstvOtnL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("RodstvOtnL", typeof(Iis.Eais.Catalogs.RodstvOtn));
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
