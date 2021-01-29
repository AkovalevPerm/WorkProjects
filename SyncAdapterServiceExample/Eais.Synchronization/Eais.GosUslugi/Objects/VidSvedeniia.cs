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
    /// VidSvedeniia.
    /// </summary>
    // *** Start programmer edit section *** (VidSvedeniia CustomAttributes)
    [Serializable]
    [Primary(true)]
    // *** End programmer edit section *** (VidSvedeniia CustomAttributes)
    [AutoAltered()]
    [AccessType(ICSSoft.STORMNET.AccessType.@this)]
    [View("AuditView", new string[] {
            "Name as \'Name\'",
            "Namespace as \'Namespace\'"})]
    [AssociatedDetailViewAttribute("AuditView", "VariantOkazaniia", "AuditView", true, "", "Variant okazaniia", true, new string[] {
            ""})]
    [View("VidSvedeniiaE", new string[] {
            "Name as \'Наименование\'",
            "Namespace as \'Namespace URI\'"})]
    [AssociatedDetailViewAttribute("VidSvedeniiaE", "VariantOkazaniia", "VariantOkazaniiaD", true, "", "Вариант оказания услуги", true, new string[] {
            ""})]
    [View("VidSvedeniiaL", new string[] {
            "Name as \'Наименование\'",
            "Namespace as \'NamespaceURI\'"})]
    public class VidSvedeniia : ICSSoft.STORMNET.DataObject, IDataObjectWithAuditFields
    {
        
        private string fName;
        
        private string fNamespace;
        
        private System.Nullable<System.DateTime> fCreateTime;
        
        private string fCreator;
        
        private System.Nullable<System.DateTime> fEditTime;
        
        private string fEditor;
        
        private Iis.Eais.GosUslugi.DetailArrayOfVariantOkazaniia fVariantOkazaniia;
        
        // *** Start programmer edit section *** (VidSvedeniia CustomMembers)

        // *** End programmer edit section *** (VidSvedeniia CustomMembers)

        
        /// <summary>
        /// Name.
        /// </summary>
        // *** Start programmer edit section *** (VidSvedeniia.Name CustomAttributes)

        // *** End programmer edit section *** (VidSvedeniia.Name CustomAttributes)
        [StrLen(1000)]
        [NotNull()]
        public virtual string Name
        {
            get
            {
                // *** Start programmer edit section *** (VidSvedeniia.Name Get start)

                // *** End programmer edit section *** (VidSvedeniia.Name Get start)
                string result = this.fName;
                // *** Start programmer edit section *** (VidSvedeniia.Name Get end)

                // *** End programmer edit section *** (VidSvedeniia.Name Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (VidSvedeniia.Name Set start)

                // *** End programmer edit section *** (VidSvedeniia.Name Set start)
                this.fName = value;
                // *** Start programmer edit section *** (VidSvedeniia.Name Set end)

                // *** End programmer edit section *** (VidSvedeniia.Name Set end)
            }
        }
        
        /// <summary>
        /// Namespace.
        /// </summary>
        // *** Start programmer edit section *** (VidSvedeniia.Namespace CustomAttributes)

        // *** End programmer edit section *** (VidSvedeniia.Namespace CustomAttributes)
        [StrLen(255)]
        [NotNull()]
        public virtual string Namespace
        {
            get
            {
                // *** Start programmer edit section *** (VidSvedeniia.Namespace Get start)

                // *** End programmer edit section *** (VidSvedeniia.Namespace Get start)
                string result = this.fNamespace;
                // *** Start programmer edit section *** (VidSvedeniia.Namespace Get end)

                // *** End programmer edit section *** (VidSvedeniia.Namespace Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (VidSvedeniia.Namespace Set start)

                // *** End programmer edit section *** (VidSvedeniia.Namespace Set start)
                this.fNamespace = value;
                // *** Start programmer edit section *** (VidSvedeniia.Namespace Set end)

                // *** End programmer edit section *** (VidSvedeniia.Namespace Set end)
            }
        }
        
        /// <summary>
        /// Время создания объекта.
        /// </summary>
        // *** Start programmer edit section *** (VidSvedeniia.CreateTime CustomAttributes)

        // *** End programmer edit section *** (VidSvedeniia.CreateTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> CreateTime
        {
            get
            {
                // *** Start programmer edit section *** (VidSvedeniia.CreateTime Get start)

                // *** End programmer edit section *** (VidSvedeniia.CreateTime Get start)
                System.Nullable<System.DateTime> result = this.fCreateTime;
                // *** Start programmer edit section *** (VidSvedeniia.CreateTime Get end)

                // *** End programmer edit section *** (VidSvedeniia.CreateTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (VidSvedeniia.CreateTime Set start)

                // *** End programmer edit section *** (VidSvedeniia.CreateTime Set start)
                this.fCreateTime = value;
                // *** Start programmer edit section *** (VidSvedeniia.CreateTime Set end)

                // *** End programmer edit section *** (VidSvedeniia.CreateTime Set end)
            }
        }
        
        /// <summary>
        /// Создатель объекта.
        /// </summary>
        // *** Start programmer edit section *** (VidSvedeniia.Creator CustomAttributes)

        // *** End programmer edit section *** (VidSvedeniia.Creator CustomAttributes)
        [StrLen(255)]
        public virtual string Creator
        {
            get
            {
                // *** Start programmer edit section *** (VidSvedeniia.Creator Get start)

                // *** End programmer edit section *** (VidSvedeniia.Creator Get start)
                string result = this.fCreator;
                // *** Start programmer edit section *** (VidSvedeniia.Creator Get end)

                // *** End programmer edit section *** (VidSvedeniia.Creator Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (VidSvedeniia.Creator Set start)

                // *** End programmer edit section *** (VidSvedeniia.Creator Set start)
                this.fCreator = value;
                // *** Start programmer edit section *** (VidSvedeniia.Creator Set end)

                // *** End programmer edit section *** (VidSvedeniia.Creator Set end)
            }
        }
        
        /// <summary>
        /// Время последнего редактирования объекта.
        /// </summary>
        // *** Start programmer edit section *** (VidSvedeniia.EditTime CustomAttributes)

        // *** End programmer edit section *** (VidSvedeniia.EditTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> EditTime
        {
            get
            {
                // *** Start programmer edit section *** (VidSvedeniia.EditTime Get start)

                // *** End programmer edit section *** (VidSvedeniia.EditTime Get start)
                System.Nullable<System.DateTime> result = this.fEditTime;
                // *** Start programmer edit section *** (VidSvedeniia.EditTime Get end)

                // *** End programmer edit section *** (VidSvedeniia.EditTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (VidSvedeniia.EditTime Set start)

                // *** End programmer edit section *** (VidSvedeniia.EditTime Set start)
                this.fEditTime = value;
                // *** Start programmer edit section *** (VidSvedeniia.EditTime Set end)

                // *** End programmer edit section *** (VidSvedeniia.EditTime Set end)
            }
        }
        
        /// <summary>
        /// Последний редактор объекта.
        /// </summary>
        // *** Start programmer edit section *** (VidSvedeniia.Editor CustomAttributes)

        // *** End programmer edit section *** (VidSvedeniia.Editor CustomAttributes)
        [StrLen(255)]
        public virtual string Editor
        {
            get
            {
                // *** Start programmer edit section *** (VidSvedeniia.Editor Get start)

                // *** End programmer edit section *** (VidSvedeniia.Editor Get start)
                string result = this.fEditor;
                // *** Start programmer edit section *** (VidSvedeniia.Editor Get end)

                // *** End programmer edit section *** (VidSvedeniia.Editor Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (VidSvedeniia.Editor Set start)

                // *** End programmer edit section *** (VidSvedeniia.Editor Set start)
                this.fEditor = value;
                // *** Start programmer edit section *** (VidSvedeniia.Editor Set end)

                // *** End programmer edit section *** (VidSvedeniia.Editor Set end)
            }
        }
        
        /// <summary>
        /// VidSvedeniia.
        /// </summary>
        // *** Start programmer edit section *** (VidSvedeniia.VariantOkazaniia CustomAttributes)

        // *** End programmer edit section *** (VidSvedeniia.VariantOkazaniia CustomAttributes)
        public virtual Iis.Eais.GosUslugi.DetailArrayOfVariantOkazaniia VariantOkazaniia
        {
            get
            {
                // *** Start programmer edit section *** (VidSvedeniia.VariantOkazaniia Get start)

                // *** End programmer edit section *** (VidSvedeniia.VariantOkazaniia Get start)
                if ((this.fVariantOkazaniia == null))
                {
                    this.fVariantOkazaniia = new Iis.Eais.GosUslugi.DetailArrayOfVariantOkazaniia(this);
                }
                Iis.Eais.GosUslugi.DetailArrayOfVariantOkazaniia result = this.fVariantOkazaniia;
                // *** Start programmer edit section *** (VidSvedeniia.VariantOkazaniia Get end)

                // *** End programmer edit section *** (VidSvedeniia.VariantOkazaniia Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (VidSvedeniia.VariantOkazaniia Set start)

                // *** End programmer edit section *** (VidSvedeniia.VariantOkazaniia Set start)
                this.fVariantOkazaniia = value;
                // *** Start programmer edit section *** (VidSvedeniia.VariantOkazaniia Set end)

                // *** End programmer edit section *** (VidSvedeniia.VariantOkazaniia Set end)
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
                    return ICSSoft.STORMNET.Information.GetView("AuditView", typeof(Iis.Eais.GosUslugi.VidSvedeniia));
                }
            }
            
            /// <summary>
            /// "VidSvedeniiaE" view.
            /// </summary>
            public static ICSSoft.STORMNET.View VidSvedeniiaE
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("VidSvedeniiaE", typeof(Iis.Eais.GosUslugi.VidSvedeniia));
                }
            }
            
            /// <summary>
            /// "VidSvedeniiaL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View VidSvedeniiaL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("VidSvedeniiaL", typeof(Iis.Eais.GosUslugi.VidSvedeniia));
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