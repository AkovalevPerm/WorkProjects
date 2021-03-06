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
    using ICSSoft.STORMNET.FunctionalLanguage.SQLWhere;
    using ICSSoft.STORMNET.FunctionalLanguage;
    using System.Collections.Generic;
    using Iis.Eais.Common.Errors;
    using IIS.University.Tools;

    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// Период.
    /// </summary>
    // *** Start programmer edit section *** (Period CustomAttributes)
    [Serializable]
    [Primary(false)]
    // *** End programmer edit section *** (Period CustomAttributes)
    [BusinessServer("Iis.Eais.Leechnost.PeriodBS, Eais.Leechnost.BusinessServers", ICSSoft.STORMNET.Business.DataServiceObjectEvents.OnAllEvents)]
    [AutoAltered()]
    [AccessType(ICSSoft.STORMNET.AccessType.@this)]
    [View("AuditView", new string[] {
            "Ierarhiia as \'Иерархия\'"})]
    [View("PeriodL", new string[] {
            "Ierarhiia"})]
    public class Period : ICSSoft.STORMNET.DataObject, IDataObjectWithAuditFields
    {

        private System.Nullable<System.DateTime> fCreateTime;

        private string fCreator;

        private System.Nullable<System.DateTime> fEditTime;

        private string fEditor;

        private Iis.Eais.Leechnost.Period fIerarhiia;

        // *** Start programmer edit section *** (Period CustomMembers)
        /// <summary>
        /// Загрузить вложенные периоды.
        /// </summary>
        /// <param name="pВложенныеПериоды"></param>
        public void LoadВложенныеПериоды(System.Collections.ArrayList pВложенныеПериоды)
        {
            IDataService ds = DataServiceProvider.DataService;

            LoadingCustomizationStruct lcs = new LoadingCustomizationStruct(null);
            lcs.View = Information.GetView("PeriodL", typeof(Period));
            lcs.LoadingTypes = new Type[] { typeof(Period) };
            SQLWhereLanguageDef langdef = SQLWhereLanguageDef.LanguageDef;
            ICSSoft.STORMNET.FunctionalLanguage.Function lf = langdef.GetFunction(langdef.funcEQ,
                new VariableDef(langdef.NumericType, "Ierarhiia"), this.__PrimaryKey);

            lcs.LimitFunction = lf;

            ICSSoft.STORMNET.DataObject[] tmpПериоды = ds.LoadObjects(lcs);
            foreach (Period dobject in tmpПериоды)
            {
                pВложенныеПериоды.Add(dobject);
                ((Period)dobject).LoadВложенныеПериоды(pВложенныеПериоды);
            }
        }

        /// <summary>
        /// Удалить период с типом год
        /// </summary>
        public void DeleteГод()
        {
            if (this.Ierarhiia == null) //это год (в представление тип не загружается)
            {
                System.Collections.ArrayList ArrList = new System.Collections.ArrayList();
                this.LoadВложенныеПериоды(ArrList);
                DataObject[] dObjects = new DataObject[ArrList.Count];
                List<IError> errors = new List<IError>();
                for (int i = 0; i < ArrList.Count; i++)
                {
                    Period period;
                    period = (Period)ArrList[i];
                    period.SetStatus(ObjectStatus.Deleted);
                    dObjects[ArrList.Count - 1 - i] = period; //удалять в обратном порядке (начиная с месяцев)


                    var faktLgotLcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(FaktLgot), FaktLgot.Views.FaktLgotE);
                    faktLgotLcs.LimitFunction = FunctionBuilder.BuildEquals<FaktLgot>(p => p.Period, period.__PrimaryKey);

                    if (DataServiceProvider.DataService.GetObjectsCount(faktLgotLcs) > 0)
                    {
                        errors.Add(new ForeignKeyConstraintError(typeof(FaktLgot), "\"Факт получения льготы\""));
                    };
                }

                if (errors.Count > 0)
                {
                    throw new SummaryUserException(errors);
                }
                else
                {
                    this.SetStatus(ObjectStatus.Deleted);
                    DataServiceProvider.DataService.UpdateObjects(ref dObjects);
                }
            }
            else
                throw new Exception("Нельзя удалить период, не являющийся годом");
        }

        // *** End programmer edit section *** (Period CustomMembers)


        /// <summary>
        /// Время создания объекта.
        /// </summary>
        // *** Start programmer edit section *** (Period.CreateTime CustomAttributes)

        // *** End programmer edit section *** (Period.CreateTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> CreateTime
        {
            get
            {
                // *** Start programmer edit section *** (Period.CreateTime Get start)

                // *** End programmer edit section *** (Period.CreateTime Get start)
                System.Nullable<System.DateTime> result = this.fCreateTime;
                // *** Start programmer edit section *** (Period.CreateTime Get end)

                // *** End programmer edit section *** (Period.CreateTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Period.CreateTime Set start)

                // *** End programmer edit section *** (Period.CreateTime Set start)
                this.fCreateTime = value;
                // *** Start programmer edit section *** (Period.CreateTime Set end)

                // *** End programmer edit section *** (Period.CreateTime Set end)
            }
        }

        /// <summary>
        /// Создатель объекта.
        /// </summary>
        // *** Start programmer edit section *** (Period.Creator CustomAttributes)

        // *** End programmer edit section *** (Period.Creator CustomAttributes)
        [StrLen(255)]
        public virtual string Creator
        {
            get
            {
                // *** Start programmer edit section *** (Period.Creator Get start)

                // *** End programmer edit section *** (Period.Creator Get start)
                string result = this.fCreator;
                // *** Start programmer edit section *** (Period.Creator Get end)

                // *** End programmer edit section *** (Period.Creator Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Period.Creator Set start)

                // *** End programmer edit section *** (Period.Creator Set start)
                this.fCreator = value;
                // *** Start programmer edit section *** (Period.Creator Set end)

                // *** End programmer edit section *** (Period.Creator Set end)
            }
        }

        /// <summary>
        /// Время последнего редактирования объекта.
        /// </summary>
        // *** Start programmer edit section *** (Period.EditTime CustomAttributes)

        // *** End programmer edit section *** (Period.EditTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> EditTime
        {
            get
            {
                // *** Start programmer edit section *** (Period.EditTime Get start)

                // *** End programmer edit section *** (Period.EditTime Get start)
                System.Nullable<System.DateTime> result = this.fEditTime;
                // *** Start programmer edit section *** (Period.EditTime Get end)

                // *** End programmer edit section *** (Period.EditTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Period.EditTime Set start)

                // *** End programmer edit section *** (Period.EditTime Set start)
                this.fEditTime = value;
                // *** Start programmer edit section *** (Period.EditTime Set end)

                // *** End programmer edit section *** (Period.EditTime Set end)
            }
        }

        /// <summary>
        /// Последний редактор объекта.
        /// </summary>
        // *** Start programmer edit section *** (Period.Editor CustomAttributes)

        // *** End programmer edit section *** (Period.Editor CustomAttributes)
        [StrLen(255)]
        public virtual string Editor
        {
            get
            {
                // *** Start programmer edit section *** (Period.Editor Get start)

                // *** End programmer edit section *** (Period.Editor Get start)
                string result = this.fEditor;
                // *** Start programmer edit section *** (Period.Editor Get end)

                // *** End programmer edit section *** (Period.Editor Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Period.Editor Set start)

                // *** End programmer edit section *** (Period.Editor Set start)
                this.fEditor = value;
                // *** Start programmer edit section *** (Period.Editor Set end)

                // *** End programmer edit section *** (Period.Editor Set end)
            }
        }

        /// <summary>
        /// Период.
        /// </summary>
        // *** Start programmer edit section *** (Period.Ierarhiia CustomAttributes)

        // *** End programmer edit section *** (Period.Ierarhiia CustomAttributes)
        [PropertyStorage(new string[] {
                "Ierarhiia"})]
        public virtual Iis.Eais.Leechnost.Period Ierarhiia
        {
            get
            {
                // *** Start programmer edit section *** (Period.Ierarhiia Get start)

                // *** End programmer edit section *** (Period.Ierarhiia Get start)
                Iis.Eais.Leechnost.Period result = this.fIerarhiia;
                // *** Start programmer edit section *** (Period.Ierarhiia Get end)

                // *** End programmer edit section *** (Period.Ierarhiia Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Period.Ierarhiia Set start)

                // *** End programmer edit section *** (Period.Ierarhiia Set start)
                this.fIerarhiia = value;
                // *** Start programmer edit section *** (Period.Ierarhiia Set end)

                // *** End programmer edit section *** (Period.Ierarhiia Set end)
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
                    return ICSSoft.STORMNET.Information.GetView("AuditView", typeof(Iis.Eais.Leechnost.Period));
                }
            }

            /// <summary>
            /// "PeriodL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View PeriodL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("PeriodL", typeof(Iis.Eais.Leechnost.Period));
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
