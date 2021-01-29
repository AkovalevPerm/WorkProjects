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
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business.Audit;
    using ICSSoft.STORMNET.Business.Audit.Objects;
    
    
    // *** Start programmer edit section *** (Using statements)
    using Iis.Eais.Common;
    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// WorkflowStepResult.
    /// </summary>
    // *** Start programmer edit section *** (WorkflowStepResult CustomAttributes)
    [Serializable]
    [Primary(true)]
    // *** End programmer edit section *** (WorkflowStepResult CustomAttributes)
    [AutoAltered()]
    [AccessType(ICSSoft.STORMNET.AccessType.@this)]
    [View("AuditView", new string[] {
            "Name as \'Name\'",
            "Comment as \'Comment\'",
            "EngineResult as \'EngineResult\'",
            "Status as \'Status\'",
            "Status.StatusEAIS"}, Hidden=new string[] {
            "Status.StatusEAIS"})]
    [MasterViewDefineAttribute("AuditView", "Status", ICSSoft.STORMNET.LookupTypeEnum.Standard, "", "StatusEAIS")]
    [View("WorkflowStepResultE", new string[] {
            "Name as \'Наименование\'",
            "Comment as \'Комментарий\'",
            "EngineResult as \'Результат для процесса\'",
            "Status as \'Статус\'",
            "Status.StatusEAIS"}, Hidden=new string[] {
            "Status.StatusEAIS"})]
    [MasterViewDefineAttribute("WorkflowStepResultE", "Status", ICSSoft.STORMNET.LookupTypeEnum.Standard, "", "StatusEAIS")]
    [View("WorkflowStepResultL", new string[] {
            "Name as \'Наименование\'",
            "Comment as \'Комментарий\'",
            "EngineResult as \'Результат для процесса\'",
            "Status",
            "Status.StatusEAIS as \'Статус\'"}, Hidden=new string[] {
            "Status"})]
    public class WorkflowStepResult : ICSSoft.STORMNET.DataObject, IDataObjectWithAuditFields
    {
        
        private string fName;
        
        private string fComment;
        
        private string fEngineResult;
        
        private System.Nullable<System.DateTime> fCreateTime;
        
        private string fCreator;
        
        private System.Nullable<System.DateTime> fEditTime;
        
        private string fEditor;
        
        private Iis.Eais.GosUslugi.StatusZaprosa fStatus;
        
        // *** Start programmer edit section *** (WorkflowStepResult CustomMembers)

        // *** End programmer edit section *** (WorkflowStepResult CustomMembers)

        
        /// <summary>
        /// Name.
        /// </summary>
        // *** Start programmer edit section *** (WorkflowStepResult.Name CustomAttributes)

        // *** End programmer edit section *** (WorkflowStepResult.Name CustomAttributes)
        [StrLen(100)]
        [NotNull()]
        public virtual string Name
        {
            get
            {
                // *** Start programmer edit section *** (WorkflowStepResult.Name Get start)

                // *** End programmer edit section *** (WorkflowStepResult.Name Get start)
                string result = this.fName;
                // *** Start programmer edit section *** (WorkflowStepResult.Name Get end)

                // *** End programmer edit section *** (WorkflowStepResult.Name Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (WorkflowStepResult.Name Set start)

                // *** End programmer edit section *** (WorkflowStepResult.Name Set start)
                this.fName = value;
                // *** Start programmer edit section *** (WorkflowStepResult.Name Set end)

                // *** End programmer edit section *** (WorkflowStepResult.Name Set end)
            }
        }
        
        /// <summary>
        /// Comment.
        /// </summary>
        // *** Start programmer edit section *** (WorkflowStepResult.Comment CustomAttributes)

        // *** End programmer edit section *** (WorkflowStepResult.Comment CustomAttributes)
        [StrLen(1000)]
        public virtual string Comment
        {
            get
            {
                // *** Start programmer edit section *** (WorkflowStepResult.Comment Get start)

                // *** End programmer edit section *** (WorkflowStepResult.Comment Get start)
                string result = this.fComment;
                // *** Start programmer edit section *** (WorkflowStepResult.Comment Get end)

                // *** End programmer edit section *** (WorkflowStepResult.Comment Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (WorkflowStepResult.Comment Set start)

                // *** End programmer edit section *** (WorkflowStepResult.Comment Set start)
                this.fComment = value;
                // *** Start programmer edit section *** (WorkflowStepResult.Comment Set end)

                // *** End programmer edit section *** (WorkflowStepResult.Comment Set end)
            }
        }
        
        /// <summary>
        /// EngineResult.
        /// </summary>
        // *** Start programmer edit section *** (WorkflowStepResult.EngineResult CustomAttributes)

        // *** End programmer edit section *** (WorkflowStepResult.EngineResult CustomAttributes)
        [StrLen(100)]
        public virtual string EngineResult
        {
            get
            {
                // *** Start programmer edit section *** (WorkflowStepResult.EngineResult Get start)

                // *** End programmer edit section *** (WorkflowStepResult.EngineResult Get start)
                string result = this.fEngineResult;
                // *** Start programmer edit section *** (WorkflowStepResult.EngineResult Get end)

                // *** End programmer edit section *** (WorkflowStepResult.EngineResult Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (WorkflowStepResult.EngineResult Set start)

                // *** End programmer edit section *** (WorkflowStepResult.EngineResult Set start)
                this.fEngineResult = value;
                // *** Start programmer edit section *** (WorkflowStepResult.EngineResult Set end)

                // *** End programmer edit section *** (WorkflowStepResult.EngineResult Set end)
            }
        }
        
        /// <summary>
        /// Время создания объекта.
        /// </summary>
        // *** Start programmer edit section *** (WorkflowStepResult.CreateTime CustomAttributes)

        // *** End programmer edit section *** (WorkflowStepResult.CreateTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> CreateTime
        {
            get
            {
                // *** Start programmer edit section *** (WorkflowStepResult.CreateTime Get start)

                // *** End programmer edit section *** (WorkflowStepResult.CreateTime Get start)
                System.Nullable<System.DateTime> result = this.fCreateTime;
                // *** Start programmer edit section *** (WorkflowStepResult.CreateTime Get end)

                // *** End programmer edit section *** (WorkflowStepResult.CreateTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (WorkflowStepResult.CreateTime Set start)

                // *** End programmer edit section *** (WorkflowStepResult.CreateTime Set start)
                this.fCreateTime = value;
                // *** Start programmer edit section *** (WorkflowStepResult.CreateTime Set end)

                // *** End programmer edit section *** (WorkflowStepResult.CreateTime Set end)
            }
        }
        
        /// <summary>
        /// Создатель объекта.
        /// </summary>
        // *** Start programmer edit section *** (WorkflowStepResult.Creator CustomAttributes)

        // *** End programmer edit section *** (WorkflowStepResult.Creator CustomAttributes)
        [StrLen(255)]
        public virtual string Creator
        {
            get
            {
                // *** Start programmer edit section *** (WorkflowStepResult.Creator Get start)

                // *** End programmer edit section *** (WorkflowStepResult.Creator Get start)
                string result = this.fCreator;
                // *** Start programmer edit section *** (WorkflowStepResult.Creator Get end)

                // *** End programmer edit section *** (WorkflowStepResult.Creator Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (WorkflowStepResult.Creator Set start)

                // *** End programmer edit section *** (WorkflowStepResult.Creator Set start)
                this.fCreator = value;
                // *** Start programmer edit section *** (WorkflowStepResult.Creator Set end)

                // *** End programmer edit section *** (WorkflowStepResult.Creator Set end)
            }
        }
        
        /// <summary>
        /// Время последнего редактирования объекта.
        /// </summary>
        // *** Start programmer edit section *** (WorkflowStepResult.EditTime CustomAttributes)

        // *** End programmer edit section *** (WorkflowStepResult.EditTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> EditTime
        {
            get
            {
                // *** Start programmer edit section *** (WorkflowStepResult.EditTime Get start)

                // *** End programmer edit section *** (WorkflowStepResult.EditTime Get start)
                System.Nullable<System.DateTime> result = this.fEditTime;
                // *** Start programmer edit section *** (WorkflowStepResult.EditTime Get end)

                // *** End programmer edit section *** (WorkflowStepResult.EditTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (WorkflowStepResult.EditTime Set start)

                // *** End programmer edit section *** (WorkflowStepResult.EditTime Set start)
                this.fEditTime = value;
                // *** Start programmer edit section *** (WorkflowStepResult.EditTime Set end)

                // *** End programmer edit section *** (WorkflowStepResult.EditTime Set end)
            }
        }
        
        /// <summary>
        /// Последний редактор объекта.
        /// </summary>
        // *** Start programmer edit section *** (WorkflowStepResult.Editor CustomAttributes)

        // *** End programmer edit section *** (WorkflowStepResult.Editor CustomAttributes)
        [StrLen(255)]
        public virtual string Editor
        {
            get
            {
                // *** Start programmer edit section *** (WorkflowStepResult.Editor Get start)

                // *** End programmer edit section *** (WorkflowStepResult.Editor Get start)
                string result = this.fEditor;
                // *** Start programmer edit section *** (WorkflowStepResult.Editor Get end)

                // *** End programmer edit section *** (WorkflowStepResult.Editor Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (WorkflowStepResult.Editor Set start)

                // *** End programmer edit section *** (WorkflowStepResult.Editor Set start)
                this.fEditor = value;
                // *** Start programmer edit section *** (WorkflowStepResult.Editor Set end)

                // *** End programmer edit section *** (WorkflowStepResult.Editor Set end)
            }
        }
        
        /// <summary>
        /// WorkflowStepResult.
        /// </summary>
        // *** Start programmer edit section *** (WorkflowStepResult.Status CustomAttributes)

        // *** End programmer edit section *** (WorkflowStepResult.Status CustomAttributes)
        [PropertyStorage(new string[] {
                "Status"})]
        public virtual Iis.Eais.GosUslugi.StatusZaprosa Status
        {
            get
            {
                // *** Start programmer edit section *** (WorkflowStepResult.Status Get start)

                // *** End programmer edit section *** (WorkflowStepResult.Status Get start)
                Iis.Eais.GosUslugi.StatusZaprosa result = this.fStatus;
                // *** Start programmer edit section *** (WorkflowStepResult.Status Get end)

                // *** End programmer edit section *** (WorkflowStepResult.Status Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (WorkflowStepResult.Status Set start)

                // *** End programmer edit section *** (WorkflowStepResult.Status Set start)
                this.fStatus = value;
                // *** Start programmer edit section *** (WorkflowStepResult.Status Set end)

                // *** End programmer edit section *** (WorkflowStepResult.Status Set end)
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
                    return ICSSoft.STORMNET.Information.GetView("AuditView", typeof(Iis.Eais.GosUslugi.WorkflowStepResult));
                }
            }
            
            /// <summary>
            /// "WorkflowStepResultE" view.
            /// </summary>
            public static ICSSoft.STORMNET.View WorkflowStepResultE
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("WorkflowStepResultE", typeof(Iis.Eais.GosUslugi.WorkflowStepResult));
                }
            }
            
            /// <summary>
            /// "WorkflowStepResultL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View WorkflowStepResultL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("WorkflowStepResultL", typeof(Iis.Eais.GosUslugi.WorkflowStepResult));
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