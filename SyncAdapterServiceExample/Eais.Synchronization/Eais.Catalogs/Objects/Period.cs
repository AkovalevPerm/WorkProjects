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
    using ICSSoft.STORMNET.FunctionalLanguage.SQLWhere;
    using ICSSoft.STORMNET.FunctionalLanguage;

    using Iis.Eais.Common;

    using IIS.Synchronizer;
    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// Период.
    /// </summary>
    // *** Start programmer edit section *** (Period CustomAttributes)
    [Primary(true)]
    [Serializable]
    // *** End programmer edit section *** (Period CustomAttributes)
    [BusinessServer("Iis.Eais.Catalogs.PeriodBS, Eais.Catalogs.BusinessServers", ICSSoft.STORMNET.Business.DataServiceObjectEvents.OnAllEvents)]
    [AutoAltered()]
    [AccessType(ICSSoft.STORMNET.AccessType.@this)]
    [View("AuditView", new string[] {
            "Naimenovanie as \'Наименование\'",
            "DataNachala as \'Дата начала\'",
            "DataKontca as \'Дата конца\'",
            "Tip as \'Тип\'",
            "Znachenie as \'Значение\'",
            "Ierarhiia as \'Иерархия\'",
            "Oldid as \'Ид\'"})]
    [View("PeriodE", new string[] {
            "Znachenie as \'Значение\'",
            "Oldid as \'Ид\'"})]
    [View("PeriodL", new string[] {
            "Naimenovanie as \'Наименование\'",
            "DataNachala as \'Начало периода\'",
            "DataKontca as \'Конец периода\'",
            "Ierarhiia",
            "Oldid as \'Ид\'"}, Hidden = new string[] {
            "Ierarhiia"})]
    public class Period : ICSSoft.STORMNET.DataObject, IDataObjectWithAuditFields, ISync
    {

        private string fNaimenovanie;

        private System.DateTime? fDataNachala;

        private System.DateTime? fDataKontca;

        private Iis.Eais.Catalogs.tTipPerioda fTip;

        private uint fZnachenie;

        private System.Nullable<System.DateTime> fCreateTime;

        private string fCreator;

        private System.Nullable<System.DateTime> fEditTime;

        private string fEditor;

        private int fOldid;

        private Iis.Eais.Catalogs.Period fIerarhiia;

        // *** Start programmer edit section *** (Period CustomMembers)

        // *** End programmer edit section *** (Period CustomMembers)


        /// <summary>
        /// Naimenovanie.
        /// </summary>
        // *** Start programmer edit section *** (Period.Naimenovanie CustomAttributes)

        // *** End programmer edit section *** (Period.Naimenovanie CustomAttributes)
        [NotNull()]
        public virtual string Naimenovanie
        {
            get
            {
                // *** Start programmer edit section *** (Period.Naimenovanie Get start)

                // *** End programmer edit section *** (Period.Naimenovanie Get start)
                string result = this.fNaimenovanie;
                // *** Start programmer edit section *** (Period.Naimenovanie Get end)

                // *** End programmer edit section *** (Period.Naimenovanie Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Period.Naimenovanie Set start)

                // *** End programmer edit section *** (Period.Naimenovanie Set start)
                this.fNaimenovanie = value;
                // *** Start programmer edit section *** (Period.Naimenovanie Set end)

                // *** End programmer edit section *** (Period.Naimenovanie Set end)
            }
        }

        /// <summary>
        /// DataNachala.
        /// </summary>
        // *** Start programmer edit section *** (Period.DataNachala CustomAttributes)

        // *** End programmer edit section *** (Period.DataNachala CustomAttributes)
        [NotNull()]
        public virtual System.DateTime? DataNachala
        {
            get
            {
                // *** Start programmer edit section *** (Period.DataNachala Get start)

                // *** End programmer edit section *** (Period.DataNachala Get start)
                System.DateTime? result = this.fDataNachala;
                // *** Start programmer edit section *** (Period.DataNachala Get end)

                // *** End programmer edit section *** (Period.DataNachala Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Period.DataNachala Set start)

                // *** End programmer edit section *** (Period.DataNachala Set start)
                this.fDataNachala = value;
                // *** Start programmer edit section *** (Period.DataNachala Set end)

                // *** End programmer edit section *** (Period.DataNachala Set end)
            }
        }

        /// <summary>
        /// DataKontca.
        /// </summary>
        // *** Start programmer edit section *** (Period.DataKontca CustomAttributes)

        // *** End programmer edit section *** (Period.DataKontca CustomAttributes)
        [NotNull()]
        public virtual System.DateTime? DataKontca
        {
            get
            {
                // *** Start programmer edit section *** (Period.DataKontca Get start)

                // *** End programmer edit section *** (Period.DataKontca Get start)
                System.DateTime? result = this.fDataKontca;
                // *** Start programmer edit section *** (Period.DataKontca Get end)

                // *** End programmer edit section *** (Period.DataKontca Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Period.DataKontca Set start)

                // *** End programmer edit section *** (Period.DataKontca Set start)
                this.fDataKontca = value;
                // *** Start programmer edit section *** (Period.DataKontca Set end)

                // *** End programmer edit section *** (Period.DataKontca Set end)
            }
        }

        /// <summary>
        /// Tip.
        /// </summary>
        // *** Start programmer edit section *** (Period.Tip CustomAttributes)

        // *** End programmer edit section *** (Period.Tip CustomAttributes)
        [NotNull()]
        public virtual Iis.Eais.Catalogs.tTipPerioda Tip
        {
            get
            {
                // *** Start programmer edit section *** (Period.Tip Get start)

                // *** End programmer edit section *** (Period.Tip Get start)
                Iis.Eais.Catalogs.tTipPerioda result = this.fTip;
                // *** Start programmer edit section *** (Period.Tip Get end)

                // *** End programmer edit section *** (Period.Tip Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Period.Tip Set start)

                // *** End programmer edit section *** (Period.Tip Set start)
                this.fTip = value;
                // *** Start programmer edit section *** (Period.Tip Set end)

                // *** End programmer edit section *** (Period.Tip Set end)
            }
        }

        /// <summary>
        /// Znachenie.
        /// </summary>
        // *** Start programmer edit section *** (Period.Znachenie CustomAttributes)

        // *** End programmer edit section *** (Period.Znachenie CustomAttributes)
        [NotNull()]
        public virtual uint Znachenie
        {
            get
            {
                // *** Start programmer edit section *** (Period.Znachenie Get start)

                // *** End programmer edit section *** (Period.Znachenie Get start)
                uint result = this.fZnachenie;
                // *** Start programmer edit section *** (Period.Znachenie Get end)

                // *** End programmer edit section *** (Period.Znachenie Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Period.Znachenie Set start)

                // *** End programmer edit section *** (Period.Znachenie Set start)
                this.fZnachenie = value;
                // *** Start programmer edit section *** (Period.Znachenie Set end)

                // *** End programmer edit section *** (Period.Znachenie Set end)
            }
        }

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
        /// Oldid.
        /// </summary>
        // *** Start programmer edit section *** (Period.Oldid CustomAttributes)

        // *** End programmer edit section *** (Period.Oldid CustomAttributes)
        public virtual int Oldid
        {
            get
            {
                // *** Start programmer edit section *** (Period.Oldid Get start)

                // *** End programmer edit section *** (Period.Oldid Get start)
                int result = this.fOldid;
                // *** Start programmer edit section *** (Period.Oldid Get end)

                // *** End programmer edit section *** (Period.Oldid Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Period.Oldid Set start)

                // *** End programmer edit section *** (Period.Oldid Set start)
                this.fOldid = value;
                // *** Start programmer edit section *** (Period.Oldid Set end)

                // *** End programmer edit section *** (Period.Oldid Set end)
            }
        }

        /// <summary>
        /// Период.
        /// </summary>
        // *** Start programmer edit section *** (Period.Ierarhiia CustomAttributes)

        // *** End programmer edit section *** (Period.Ierarhiia CustomAttributes)
        [PropertyStorage(new string[] {
                "Ierarhiia"})]
        public virtual Iis.Eais.Catalogs.Period Ierarhiia
        {
            get
            {
                // *** Start programmer edit section *** (Period.Ierarhiia Get start)

                // *** End programmer edit section *** (Period.Ierarhiia Get start)
                Iis.Eais.Catalogs.Period result = this.fIerarhiia;
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
        /// Загрузить вложенные периоды.
        /// </summary>
        // *** Start programmer edit section *** (Period.LoadВложенныеПериоды System.Collections.ArrayList CustomAttributes)

        // *** End programmer edit section *** (Period.LoadВложенныеПериоды System.Collections.ArrayList CustomAttributes)
        [ICSSoft.STORMNET.AccessType(ICSSoft.STORMNET.AccessType.none)]
        public virtual void LoadВложенныеПериоды(System.Collections.ArrayList pВложенныеПериоды)
        {
            // *** Start programmer edit section *** (Period.LoadВложенныеПериоды System.Collections.ArrayList method implementation)
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
            // *** End programmer edit section *** (Period.LoadВложенныеПериоды System.Collections.ArrayList method implementation)
        }

        /// <summary>
        /// Удалить период с типом год.
        /// </summary>
        // *** Start programmer edit section *** (Period.DeleteГод CustomAttributes)

        // *** End programmer edit section *** (Period.DeleteГод CustomAttributes)
        [ICSSoft.STORMNET.AccessType(ICSSoft.STORMNET.AccessType.none)]
        public virtual void DeleteГод()
        {
            // *** Start programmer edit section *** (Period.DeleteГод method implementation)
            if (this.Ierarhiia == null) //это год (в представление тип не загружается)
            {
                System.Collections.ArrayList ArrList = new System.Collections.ArrayList();
                this.LoadВложенныеПериоды(ArrList);
                DataObject[] dObjects = new DataObject[ArrList.Count];
                for (int i = 0; i < ArrList.Count; i++)
                {
                    Period period;
                    period = (Period)ArrList[i];
                    period.SetStatus(ObjectStatus.Deleted);
                    dObjects[ArrList.Count - 1 - i] = period; //удалять в обратном порядке (начиная с месяцев)
                }
                this.SetStatus(ObjectStatus.Deleted);
                dObjects[ArrList.Count] = this;
                DataServiceProvider.DataService.UpdateObjects(ref dObjects);

            }
            else
                throw new Exception("Нельзя удалить период, не являющийся годом");
            // *** End programmer edit section *** (Period.DeleteГод method implementation)
        }

        /// <summary>
        /// Процедура создает вложенные периоды первого уровня (месяцы для квартала, кварталы для полугодия, полугодия для года).
        /// </summary>
        // *** Start programmer edit section *** (Period.CreateIncludedPeriods System.Collections.ArrayList CustomAttributes)

        // *** End programmer edit section *** (Period.CreateIncludedPeriods System.Collections.ArrayList CustomAttributes)
        [ICSSoft.STORMNET.AccessType(ICSSoft.STORMNET.AccessType.none)]
        public virtual void CreateIncludedPeriods(System.Collections.ArrayList pВложенныеПериоды)
        {
            // *** Start programmer edit section *** (Period.CreateIncludedPeriods System.Collections.ArrayList method implementation)
            int month = 0;
            int year = this.DataNachala.Value.Year;

            switch (this.Tip)
            {
                case tTipPerioda.God:
                    //создаем полугодия
                    for (int i = 1; i <= 2; i++)
                    {
                        Period vПериод = new Period();
                        vПериод.Znachenie = (uint)i;
                        vПериод.Ierarhiia = this;
                        vПериод.Tip = tTipPerioda.Polugodie;
                        vПериод.Naimenovanie = vПериод.Znachenie + "-е полугодие " + year + " года"; ;

                        month = (i - 1) * 6 + 1;
                        DateTime StartTime = new DateTime(year, month, 1);
                        vПериод.DataNachala = StartTime;
                        int LastMonthInPeriod = month + 5;
                        DateTime EndTime = new DateTime(year, LastMonthInPeriod, DateTime.DaysInMonth(year, LastMonthInPeriod));
                        vПериод.DataKontca = EndTime;

                        pВложенныеПериоды.Add(vПериод);
                    }
                    break;

                case tTipPerioda.Polugodie:
                    //создаем кварталы
                    for (int i = 1; i <= 2; i++)
                    {
                        Period vПериод = new Period();
                        vПериод.Znachenie = (uint)((this.Znachenie - 1) * 2 + i);
                        vПериод.Ierarhiia = this;
                        vПериод.Tip = tTipPerioda.Kvartal;
                        vПериод.Naimenovanie = vПериод.Znachenie + "-й квартал " + year + " года";

                        month = (int)(vПериод.Znachenie - 1) * 3 + 1;
                        DateTime StartTime = new DateTime(year, month, 1);
                        vПериод.DataNachala = StartTime;
                        int LastMonthInPeriod = month + 2;
                        DateTime EndTime = new DateTime(year, LastMonthInPeriod, DateTime.DaysInMonth(year, LastMonthInPeriod));
                        vПериод.DataKontca = EndTime;

                        pВложенныеПериоды.Add(vПериод);
                    }
                    break;

                case tTipPerioda.Kvartal:
                    //создаем месяцы
                    for (int i = 1; i <= 3; i++)
                    {
                        Period vПериод = new Period();
                        vПериод.Znachenie = (uint)((this.Znachenie - 1) * 3 + i);
                        vПериод.Ierarhiia = this;
                        vПериод.Tip = tTipPerioda.Mesiatc;

                        month = (int)vПериод.Znachenie;
                        DateTime StartTime = new DateTime(year, month, 1);
                        vПериод.DataNachala = StartTime;
                        DateTime EndTime = new DateTime(year, month, DateTime.DaysInMonth(year, month));
                        vПериод.DataKontca = EndTime;

                        vПериод.Naimenovanie = StartTime.ToString("MMMM") + " " + year + " года";

                        pВложенныеПериоды.Add(vПериод);
                    }
                    break;

                case tTipPerioda.Mesiatc: //ICSSoft.Соцзащита.ТипыДанных.tТипПериода.Месяц:
                    //сюда никогда не попадем
                    break;
            }
            // *** End programmer edit section *** (Period.CreateIncludedPeriods System.Collections.ArrayList method implementation)
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
                    return ICSSoft.STORMNET.Information.GetView("AuditView", typeof(Iis.Eais.Catalogs.Period));
                }
            }

            /// <summary>
            /// "PeriodE" view.
            /// </summary>
            public static ICSSoft.STORMNET.View PeriodE
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("PeriodE", typeof(Iis.Eais.Catalogs.Period));
                }
            }

            /// <summary>
            /// "PeriodL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View PeriodL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("PeriodL", typeof(Iis.Eais.Catalogs.Period));
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
