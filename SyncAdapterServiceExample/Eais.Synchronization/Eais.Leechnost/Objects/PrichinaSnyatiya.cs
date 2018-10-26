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
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business.Audit;


    // *** Start programmer edit section *** (Using statements)
    using Iis.Eais.Common;
    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// Причина снятия с учета.
    /// </summary>
    // *** Start programmer edit section *** (PrichinaSnyatiya CustomAttributes)
    [Primary(false)]
    [Serializable]
    // *** End programmer edit section *** (PrichinaSnyatiya CustomAttributes)
    [BusinessServer("Iis.Eais.Leechnost.PrichinaSnyatiyaBS, Eais.Leechnost.BusinessServers", ICSSoft.STORMNET.Business.DataServiceObjectEvents.OnAllEvents)]
    [AutoAltered()]
    [Caption("Причина снятия с учета")]
    [AccessType(ICSSoft.STORMNET.AccessType.@this)]
    [View("AuditView", new string[] {
            "CreateTime",
            "Creator",
            "EditTime",
            "Editor"})]
    [View("PrichinaSnyatiyaE", new string[0])]
    [View("PrichinaSnyatiyaL", new string[0])]
    public class PrichinaSnyatiya : ICSSoft.STORMNET.DataObject, IDataObjectWithAuditFields
    {

        private System.Nullable<System.DateTime> fCreateTime;

        private string fCreator;

        private System.Nullable<System.DateTime> fEditTime;

        private string fEditor;

        // *** Start programmer edit section *** (PrichinaSnyatiya CustomMembers)

        // *** End programmer edit section *** (PrichinaSnyatiya CustomMembers)


        /// <summary>
        /// Время создания объекта.
        /// </summary>
        // *** Start programmer edit section *** (PrichinaSnyatiya.CreateTime CustomAttributes)

        // *** End programmer edit section *** (PrichinaSnyatiya.CreateTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> CreateTime
        {
            get
            {
                // *** Start programmer edit section *** (PrichinaSnyatiya.CreateTime Get start)

                // *** End programmer edit section *** (PrichinaSnyatiya.CreateTime Get start)
                System.Nullable<System.DateTime> result = this.fCreateTime;
                // *** Start programmer edit section *** (PrichinaSnyatiya.CreateTime Get end)

                // *** End programmer edit section *** (PrichinaSnyatiya.CreateTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (PrichinaSnyatiya.CreateTime Set start)

                // *** End programmer edit section *** (PrichinaSnyatiya.CreateTime Set start)
                this.fCreateTime = value;
                // *** Start programmer edit section *** (PrichinaSnyatiya.CreateTime Set end)

                // *** End programmer edit section *** (PrichinaSnyatiya.CreateTime Set end)
            }
        }

        /// <summary>
        /// Создатель объекта.
        /// </summary>
        // *** Start programmer edit section *** (PrichinaSnyatiya.Creator CustomAttributes)

        // *** End programmer edit section *** (PrichinaSnyatiya.Creator CustomAttributes)
        [StrLen(255)]
        public virtual string Creator
        {
            get
            {
                // *** Start programmer edit section *** (PrichinaSnyatiya.Creator Get start)

                // *** End programmer edit section *** (PrichinaSnyatiya.Creator Get start)
                string result = this.fCreator;
                // *** Start programmer edit section *** (PrichinaSnyatiya.Creator Get end)

                // *** End programmer edit section *** (PrichinaSnyatiya.Creator Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (PrichinaSnyatiya.Creator Set start)

                // *** End programmer edit section *** (PrichinaSnyatiya.Creator Set start)
                this.fCreator = value;
                // *** Start programmer edit section *** (PrichinaSnyatiya.Creator Set end)

                // *** End programmer edit section *** (PrichinaSnyatiya.Creator Set end)
            }
        }

        /// <summary>
        /// Время последнего редактирования объекта.
        /// </summary>
        // *** Start programmer edit section *** (PrichinaSnyatiya.EditTime CustomAttributes)

        // *** End programmer edit section *** (PrichinaSnyatiya.EditTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> EditTime
        {
            get
            {
                // *** Start programmer edit section *** (PrichinaSnyatiya.EditTime Get start)

                // *** End programmer edit section *** (PrichinaSnyatiya.EditTime Get start)
                System.Nullable<System.DateTime> result = this.fEditTime;
                // *** Start programmer edit section *** (PrichinaSnyatiya.EditTime Get end)

                // *** End programmer edit section *** (PrichinaSnyatiya.EditTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (PrichinaSnyatiya.EditTime Set start)

                // *** End programmer edit section *** (PrichinaSnyatiya.EditTime Set start)
                this.fEditTime = value;
                // *** Start programmer edit section *** (PrichinaSnyatiya.EditTime Set end)

                // *** End programmer edit section *** (PrichinaSnyatiya.EditTime Set end)
            }
        }

        /// <summary>
        /// Последний редактор объекта.
        /// </summary>
        // *** Start programmer edit section *** (PrichinaSnyatiya.Editor CustomAttributes)

        // *** End programmer edit section *** (PrichinaSnyatiya.Editor CustomAttributes)
        [StrLen(255)]
        public virtual string Editor
        {
            get
            {
                // *** Start programmer edit section *** (PrichinaSnyatiya.Editor Get start)

                // *** End programmer edit section *** (PrichinaSnyatiya.Editor Get start)
                string result = this.fEditor;
                // *** Start programmer edit section *** (PrichinaSnyatiya.Editor Get end)

                // *** End programmer edit section *** (PrichinaSnyatiya.Editor Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (PrichinaSnyatiya.Editor Set start)

                // *** End programmer edit section *** (PrichinaSnyatiya.Editor Set start)
                this.fEditor = value;
                // *** Start programmer edit section *** (PrichinaSnyatiya.Editor Set end)

                // *** End programmer edit section *** (PrichinaSnyatiya.Editor Set end)
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
                    return ICSSoft.STORMNET.Information.GetView("AuditView", typeof(Iis.Eais.Leechnost.PrichinaSnyatiya));
                }
            }

            /// <summary>
            /// "PrichinaSnyatiyaE" view.
            /// </summary>
            public static ICSSoft.STORMNET.View PrichinaSnyatiyaE
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("PrichinaSnyatiyaE", typeof(Iis.Eais.Leechnost.PrichinaSnyatiya));
                }
            }

            /// <summary>
            /// "PrichinaSnyatiyaL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View PrichinaSnyatiyaL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("PrichinaSnyatiyaL", typeof(Iis.Eais.Leechnost.PrichinaSnyatiya));
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
            public static bool SelectAudit = true;

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
