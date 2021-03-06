﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Iis.Eais.GosUslugi
{
    using System;
    using System.Xml;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business.Audit;
    using ICSSoft.STORMNET.Business.Audit.Objects;
    
    
    // *** Start programmer edit section *** (Using statements)
    using Iis.Eais.Common;
    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// Личность.
    /// </summary>
    // *** Start programmer edit section *** (Leechnost CustomAttributes)
    [Serializable]
    [Primary(true)]
    // *** End programmer edit section *** (Leechnost CustomAttributes)
    [BusinessServer("Iis.Eais.GosUslugi.LeechnostBS, Eais.GosUslugi.BusinessServers", ICSSoft.STORMNET.Business.DataServiceObjectEvents.OnAllEvents)]
    [AutoAltered()]
    [AccessType(ICSSoft.STORMNET.AccessType.@this)]
    [View("AuditView", new string[0])]
    [View("LeechnostE", new string[0])]
    [View("LeechnostL", new string[0])]
    public class Leechnost : ICSSoft.STORMNET.DataObject, IDataObjectWithAuditFields
    {
        
        private System.Nullable<System.DateTime> fCreateTime;
        
        private string fCreator;
        
        private System.Nullable<System.DateTime> fEditTime;
        
        private string fEditor;
        
        // *** Start programmer edit section *** (Leechnost CustomMembers)

        // *** End programmer edit section *** (Leechnost CustomMembers)

        
        /// <summary>
        /// Время создания объекта.
        /// </summary>
        // *** Start programmer edit section *** (Leechnost.CreateTime CustomAttributes)

        // *** End programmer edit section *** (Leechnost.CreateTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> CreateTime
        {
            get
            {
                // *** Start programmer edit section *** (Leechnost.CreateTime Get start)

                // *** End programmer edit section *** (Leechnost.CreateTime Get start)
                System.Nullable<System.DateTime> result = this.fCreateTime;
                // *** Start programmer edit section *** (Leechnost.CreateTime Get end)

                // *** End programmer edit section *** (Leechnost.CreateTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Leechnost.CreateTime Set start)

                // *** End programmer edit section *** (Leechnost.CreateTime Set start)
                this.fCreateTime = value;
                // *** Start programmer edit section *** (Leechnost.CreateTime Set end)

                // *** End programmer edit section *** (Leechnost.CreateTime Set end)
            }
        }
        
        /// <summary>
        /// Создатель объекта.
        /// </summary>
        // *** Start programmer edit section *** (Leechnost.Creator CustomAttributes)

        // *** End programmer edit section *** (Leechnost.Creator CustomAttributes)
        [StrLen(255)]
        public virtual string Creator
        {
            get
            {
                // *** Start programmer edit section *** (Leechnost.Creator Get start)

                // *** End programmer edit section *** (Leechnost.Creator Get start)
                string result = this.fCreator;
                // *** Start programmer edit section *** (Leechnost.Creator Get end)

                // *** End programmer edit section *** (Leechnost.Creator Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Leechnost.Creator Set start)

                // *** End programmer edit section *** (Leechnost.Creator Set start)
                this.fCreator = value;
                // *** Start programmer edit section *** (Leechnost.Creator Set end)

                // *** End programmer edit section *** (Leechnost.Creator Set end)
            }
        }
        
        /// <summary>
        /// Время последнего редактирования объекта.
        /// </summary>
        // *** Start programmer edit section *** (Leechnost.EditTime CustomAttributes)

        // *** End programmer edit section *** (Leechnost.EditTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> EditTime
        {
            get
            {
                // *** Start programmer edit section *** (Leechnost.EditTime Get start)

                // *** End programmer edit section *** (Leechnost.EditTime Get start)
                System.Nullable<System.DateTime> result = this.fEditTime;
                // *** Start programmer edit section *** (Leechnost.EditTime Get end)

                // *** End programmer edit section *** (Leechnost.EditTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Leechnost.EditTime Set start)

                // *** End programmer edit section *** (Leechnost.EditTime Set start)
                this.fEditTime = value;
                // *** Start programmer edit section *** (Leechnost.EditTime Set end)

                // *** End programmer edit section *** (Leechnost.EditTime Set end)
            }
        }
        
        /// <summary>
        /// Последний редактор объекта.
        /// </summary>
        // *** Start programmer edit section *** (Leechnost.Editor CustomAttributes)

        // *** End programmer edit section *** (Leechnost.Editor CustomAttributes)
        [StrLen(255)]
        public virtual string Editor
        {
            get
            {
                // *** Start programmer edit section *** (Leechnost.Editor Get start)

                // *** End programmer edit section *** (Leechnost.Editor Get start)
                string result = this.fEditor;
                // *** Start programmer edit section *** (Leechnost.Editor Get end)

                // *** End programmer edit section *** (Leechnost.Editor Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Leechnost.Editor Set start)

                // *** End programmer edit section *** (Leechnost.Editor Set start)
                this.fEditor = value;
                // *** Start programmer edit section *** (Leechnost.Editor Set end)

                // *** End programmer edit section *** (Leechnost.Editor Set end)
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
                    return ICSSoft.STORMNET.Information.GetView("AuditView", typeof(Iis.Eais.GosUslugi.Leechnost));
                }
            }
            
            /// <summary>
            /// "LeechnostE" view.
            /// </summary>
            public static ICSSoft.STORMNET.View LeechnostE
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("LeechnostE", typeof(Iis.Eais.GosUslugi.Leechnost));
                }
            }
            
            /// <summary>
            /// "LeechnostL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View LeechnostL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("LeechnostL", typeof(Iis.Eais.GosUslugi.Leechnost));
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
