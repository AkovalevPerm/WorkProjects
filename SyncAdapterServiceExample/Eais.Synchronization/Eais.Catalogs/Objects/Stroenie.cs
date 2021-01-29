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

    using System.Collections.Generic;

    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// Строение.
    /// </summary>
    // *** Start programmer edit section *** (Stroenie CustomAttributes)
    [Primary(true)]
    [Serializable]
    // *** End programmer edit section *** (Stroenie CustomAttributes)
    [BusinessServer("Iis.Eais.Catalogs.StroenieBS, Eais.Catalogs.BusinessServers", ICSSoft.STORMNET.Business.DataServiceObjectEvents.OnAllEvents)]
    [AutoAltered()]
    [Caption("Строение")]
    [AccessType(ICSSoft.STORMNET.AccessType.@this)]
    [View("AuditView", new string[] {
            "Nomer as \'Nomer\'",
            "PochtIndeks as \'Pocht indeks\'",
            "DopStroenie as \'Dop stroenie\'",
            "VidStroeniia as \'Vid stroeniia\'",
            "KodFIAS as \'Kod FIAS\'",
            "KodPodtverzhd as \'Kod podtverzhd\'",
            "Raion as \'Raion\'",
            "Raion.KodCLADR as \'Kod CLADR\'",
            "Ulitca as \'Ulitca\'",
            "Ulitca.PochtIndeks as \'Pocht indeks\'"})]
    [View("StroenieE", new string[] {
            "Raion as \'Населенный пункт\'",
            "Raion.Naimenovanie as \'Наименование\'",
            "Ulitca as \'Улица\'",
            "Ulitca.Naimenovanie as \'Наименование\'",
            "Nomer as \'Номер дома\'",
            "DopStroenie as \'Строение\'",
            "PochtIndeks as \'Почтовый индекс\'",
            "KodPodtverzhd as \'Код подтверждения\'",
            "KodFIAS as \'Код ФИАС\'",
            "VidStroeniia as \'Вид строения\'",
            "Ulitca.KodFIAS"}, Hidden = new string[] {
            "Ulitca.KodFIAS"})]
    [View("StroenieL", new string[] {
            "Raion",
            "Raion.Naimenovanie as \'Населенный пункт\'",
            "Ulitca",
            "Ulitca.Naimenovanie as \'Улица\'",
            "Nomer as \'Номер дома\'",
            "DopStroenie as \'Строение\'",
            "PochtIndeks as \'Почтовый индекс\'",
            "KodFIAS as \'Код ФИАС\'",
            "KodPodtverzhd as \'Код подтверждения\'",
            "VidStroeniia as \'Вид строения\'",
            "StroenieStrokoi"}, Hidden = new string[] {
            "Raion",
            "Ulitca",
            "KodPodtverzhd",
            "VidStroeniia",
            "StroenieStrokoi"})]
    [View("StroenieTransformation", new string[] {
            "Nomer",
            "DopStroenie",
            "Ulitca",
            "Ulitca.KodFIAS"})]
    public class Stroenie : ICSSoft.STORMNET.DataObject, IDataObjectWithAuditFields, ISync
    {

        private uint fNomer;

        private string fPochtIndeks;

        private string fDopStroenie;

        private Iis.Eais.Catalogs.tVidStroeniia fVidStroeniia;

        private string fKodFIAS;

        private uint fKodPodtverzhd;

        private System.Nullable<System.DateTime> fCreateTime;

        private string fCreator;

        private System.Nullable<System.DateTime> fEditTime;

        private string fEditor;

        private Iis.Eais.Catalogs.Territoriia fRaion;

        private Iis.Eais.Catalogs.Ulitca fUlitca;

        // *** Start programmer edit section *** (Stroenie CustomMembers)

        // *** End programmer edit section *** (Stroenie CustomMembers)


        /// <summary>
        /// Nomer.
        /// </summary>
        // *** Start programmer edit section *** (Stroenie.Nomer CustomAttributes)

        // *** End programmer edit section *** (Stroenie.Nomer CustomAttributes)
        [NotNull()]
        public virtual uint Nomer
        {
            get
            {
                // *** Start programmer edit section *** (Stroenie.Nomer Get start)

                // *** End programmer edit section *** (Stroenie.Nomer Get start)
                uint result = this.fNomer;
                // *** Start programmer edit section *** (Stroenie.Nomer Get end)

                // *** End programmer edit section *** (Stroenie.Nomer Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Stroenie.Nomer Set start)

                // *** End programmer edit section *** (Stroenie.Nomer Set start)
                this.fNomer = value;
                // *** Start programmer edit section *** (Stroenie.Nomer Set end)

                // *** End programmer edit section *** (Stroenie.Nomer Set end)
            }
        }

        /// <summary>
        /// PochtIndeks.
        /// </summary>
        // *** Start programmer edit section *** (Stroenie.PochtIndeks CustomAttributes)

        // *** End programmer edit section *** (Stroenie.PochtIndeks CustomAttributes)
        [NotNull()]
        public virtual string PochtIndeks
        {
            get
            {
                // *** Start programmer edit section *** (Stroenie.PochtIndeks Get start)

                // *** End programmer edit section *** (Stroenie.PochtIndeks Get start)
                string result = this.fPochtIndeks;
                // *** Start programmer edit section *** (Stroenie.PochtIndeks Get end)

                // *** End programmer edit section *** (Stroenie.PochtIndeks Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Stroenie.PochtIndeks Set start)

                // *** End programmer edit section *** (Stroenie.PochtIndeks Set start)
                this.fPochtIndeks = value;
                // *** Start programmer edit section *** (Stroenie.PochtIndeks Set end)

                // *** End programmer edit section *** (Stroenie.PochtIndeks Set end)
            }
        }

        /// <summary>
        /// DopStroenie.
        /// </summary>
        // *** Start programmer edit section *** (Stroenie.DopStroenie CustomAttributes)

        // *** End programmer edit section *** (Stroenie.DopStroenie CustomAttributes)
        public virtual string DopStroenie
        {
            get
            {
                // *** Start programmer edit section *** (Stroenie.DopStroenie Get start)

                // *** End programmer edit section *** (Stroenie.DopStroenie Get start)
                string result = this.fDopStroenie;
                // *** Start programmer edit section *** (Stroenie.DopStroenie Get end)

                // *** End programmer edit section *** (Stroenie.DopStroenie Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Stroenie.DopStroenie Set start)

                // *** End programmer edit section *** (Stroenie.DopStroenie Set start)
                this.fDopStroenie = value;
                // *** Start programmer edit section *** (Stroenie.DopStroenie Set end)

                // *** End programmer edit section *** (Stroenie.DopStroenie Set end)
            }
        }

        /// <summary>
        /// VidStroeniia.
        /// </summary>
        // *** Start programmer edit section *** (Stroenie.VidStroeniia CustomAttributes)

        // *** End programmer edit section *** (Stroenie.VidStroeniia CustomAttributes)
        public virtual Iis.Eais.Catalogs.tVidStroeniia VidStroeniia
        {
            get
            {
                // *** Start programmer edit section *** (Stroenie.VidStroeniia Get start)

                // *** End programmer edit section *** (Stroenie.VidStroeniia Get start)
                Iis.Eais.Catalogs.tVidStroeniia result = this.fVidStroeniia;
                // *** Start programmer edit section *** (Stroenie.VidStroeniia Get end)

                // *** End programmer edit section *** (Stroenie.VidStroeniia Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Stroenie.VidStroeniia Set start)

                // *** End programmer edit section *** (Stroenie.VidStroeniia Set start)
                this.fVidStroeniia = value;
                // *** Start programmer edit section *** (Stroenie.VidStroeniia Set end)

                // *** End programmer edit section *** (Stroenie.VidStroeniia Set end)
            }
        }

        /// <summary>
        /// KodFIAS.
        /// </summary>
        // *** Start programmer edit section *** (Stroenie.KodFIAS CustomAttributes)

        // *** End programmer edit section *** (Stroenie.KodFIAS CustomAttributes)
        public virtual string KodFIAS
        {
            get
            {
                // *** Start programmer edit section *** (Stroenie.KodFIAS Get start)

                // *** End programmer edit section *** (Stroenie.KodFIAS Get start)
                string result = this.fKodFIAS;
                // *** Start programmer edit section *** (Stroenie.KodFIAS Get end)

                // *** End programmer edit section *** (Stroenie.KodFIAS Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Stroenie.KodFIAS Set start)

                // *** End programmer edit section *** (Stroenie.KodFIAS Set start)
                this.fKodFIAS = value;
                // *** Start programmer edit section *** (Stroenie.KodFIAS Set end)

                // *** End programmer edit section *** (Stroenie.KodFIAS Set end)
            }
        }

        /// <summary>
        /// KodPodtverzhd.
        /// </summary>
        // *** Start programmer edit section *** (Stroenie.KodPodtverzhd CustomAttributes)

        // *** End programmer edit section *** (Stroenie.KodPodtverzhd CustomAttributes)
        public virtual uint KodPodtverzhd
        {
            get
            {
                // *** Start programmer edit section *** (Stroenie.KodPodtverzhd Get start)

                // *** End programmer edit section *** (Stroenie.KodPodtverzhd Get start)
                uint result = this.fKodPodtverzhd;
                // *** Start programmer edit section *** (Stroenie.KodPodtverzhd Get end)

                // *** End programmer edit section *** (Stroenie.KodPodtverzhd Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Stroenie.KodPodtverzhd Set start)

                // *** End programmer edit section *** (Stroenie.KodPodtverzhd Set start)
                this.fKodPodtverzhd = value;
                // *** Start programmer edit section *** (Stroenie.KodPodtverzhd Set end)

                // *** End programmer edit section *** (Stroenie.KodPodtverzhd Set end)
            }
        }

        /// <summary>
        /// Время создания объекта.
        /// </summary>
        // *** Start programmer edit section *** (Stroenie.CreateTime CustomAttributes)

        // *** End programmer edit section *** (Stroenie.CreateTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> CreateTime
        {
            get
            {
                // *** Start programmer edit section *** (Stroenie.CreateTime Get start)

                // *** End programmer edit section *** (Stroenie.CreateTime Get start)
                System.Nullable<System.DateTime> result = this.fCreateTime;
                // *** Start programmer edit section *** (Stroenie.CreateTime Get end)

                // *** End programmer edit section *** (Stroenie.CreateTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Stroenie.CreateTime Set start)

                // *** End programmer edit section *** (Stroenie.CreateTime Set start)
                this.fCreateTime = value;
                // *** Start programmer edit section *** (Stroenie.CreateTime Set end)

                // *** End programmer edit section *** (Stroenie.CreateTime Set end)
            }
        }

        /// <summary>
        /// Создатель объекта.
        /// </summary>
        // *** Start programmer edit section *** (Stroenie.Creator CustomAttributes)

        // *** End programmer edit section *** (Stroenie.Creator CustomAttributes)
        [StrLen(255)]
        public virtual string Creator
        {
            get
            {
                // *** Start programmer edit section *** (Stroenie.Creator Get start)

                // *** End programmer edit section *** (Stroenie.Creator Get start)
                string result = this.fCreator;
                // *** Start programmer edit section *** (Stroenie.Creator Get end)

                // *** End programmer edit section *** (Stroenie.Creator Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Stroenie.Creator Set start)

                // *** End programmer edit section *** (Stroenie.Creator Set start)
                this.fCreator = value;
                // *** Start programmer edit section *** (Stroenie.Creator Set end)

                // *** End programmer edit section *** (Stroenie.Creator Set end)
            }
        }

        /// <summary>
        /// Время последнего редактирования объекта.
        /// </summary>
        // *** Start programmer edit section *** (Stroenie.EditTime CustomAttributes)

        // *** End programmer edit section *** (Stroenie.EditTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> EditTime
        {
            get
            {
                // *** Start programmer edit section *** (Stroenie.EditTime Get start)

                // *** End programmer edit section *** (Stroenie.EditTime Get start)
                System.Nullable<System.DateTime> result = this.fEditTime;
                // *** Start programmer edit section *** (Stroenie.EditTime Get end)

                // *** End programmer edit section *** (Stroenie.EditTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Stroenie.EditTime Set start)

                // *** End programmer edit section *** (Stroenie.EditTime Set start)
                this.fEditTime = value;
                // *** Start programmer edit section *** (Stroenie.EditTime Set end)

                // *** End programmer edit section *** (Stroenie.EditTime Set end)
            }
        }

        /// <summary>
        /// Последний редактор объекта.
        /// </summary>
        // *** Start programmer edit section *** (Stroenie.Editor CustomAttributes)

        // *** End programmer edit section *** (Stroenie.Editor CustomAttributes)
        [StrLen(255)]
        public virtual string Editor
        {
            get
            {
                // *** Start programmer edit section *** (Stroenie.Editor Get start)

                // *** End programmer edit section *** (Stroenie.Editor Get start)
                string result = this.fEditor;
                // *** Start programmer edit section *** (Stroenie.Editor Get end)

                // *** End programmer edit section *** (Stroenie.Editor Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Stroenie.Editor Set start)

                // *** End programmer edit section *** (Stroenie.Editor Set start)
                this.fEditor = value;
                // *** Start programmer edit section *** (Stroenie.Editor Set end)

                // *** End programmer edit section *** (Stroenie.Editor Set end)
            }
        }

        /// <summary>
        /// Адрес Строения строкой.
        /// </summary>
        // *** Start programmer edit section *** (Stroenie.StroenieStrokoi CustomAttributes)
        private string ПолучитьСтроениеСтрокой(Stroenie stroenie)
        {
            Territoriia тер = stroenie.Raion;
            Ulitca ул = stroenie.Ulitca;
            if (!stroenie.CheckLoadedProperty("PochtIndeks") || !stroenie.CheckLoadedProperty("Raion")
                || !stroenie.CheckLoadedProperty("Ulitca") || !stroenie.CheckLoadedProperty("Nomer")
                || !stroenie.CheckLoadedProperty("DopStroenie") || !ул.CheckLoadedProperty("Naimenovanie")
                || !ул.CheckLoadedProperty("VidObekta") || !тер.CheckLoadedProperty("Naimenovanie"))
                DataServiceProvider.DataService.LoadObject(Stroenie.Views.StroenieE, stroenie);

            List<string> strings = new List<string>();
            strings.Add(stroenie.PochtIndeks);

            тер = stroenie.Raion;
            string terr = String.IsNullOrEmpty(тер.VidObekta) ? "" : тер.VidObekta + ". ";
            terr = String.IsNullOrEmpty(тер.Naimenovanie) ? "" : terr + тер.Naimenovanie;
            strings.Add(terr);

            if (stroenie.Ulitca != null)
            {
                ул = stroenie.Ulitca;
                string ulitca = String.IsNullOrEmpty(ул.VidObekta) ? "" : ул.VidObekta + ". ";
                ulitca = String.IsNullOrEmpty(ул.Naimenovanie) ? "" : ulitca + ул.Naimenovanie;
                strings.Add(ulitca);
            }

            strings.Add(stroenie.Nomer.ToString());
            strings.Add(stroenie.DopStroenie);
            strings.RemoveAll(x => String.IsNullOrEmpty(x));

            return String.Join(", ", strings.ToArray());
        }

        private string m_СтроениеСтрокой;
        // *** End programmer edit section *** (Stroenie.StroenieStrokoi CustomAttributes)
        [ICSSoft.STORMNET.NotStored()]
        public virtual string StroenieStrokoi
        {
            get
            {
                // *** Start programmer edit section *** (Stroenie.StroenieStrokoi Get)
                if (m_СтроениеСтрокой == null)
                {
                    m_СтроениеСтрокой = ПолучитьСтроениеСтрокой(this);
                }
                return m_СтроениеСтрокой;
                // *** End programmer edit section *** (Stroenie.StroenieStrokoi Get)
            }
            set
            {
                // *** Start programmer edit section *** (Stroenie.StroenieStrokoi Set)
                m_СтроениеСтрокой = value;
                // *** End programmer edit section *** (Stroenie.StroenieStrokoi Set)
            }
        }

        /// <summary>
        /// Строение.
        /// </summary>
        // *** Start programmer edit section *** (Stroenie.Raion CustomAttributes)

        // *** End programmer edit section *** (Stroenie.Raion CustomAttributes)
        [PropertyStorage(new string[] {
                "Raion"})]
        [NotNull()]
        public virtual Iis.Eais.Catalogs.Territoriia Raion
        {
            get
            {
                // *** Start programmer edit section *** (Stroenie.Raion Get start)

                // *** End programmer edit section *** (Stroenie.Raion Get start)
                Iis.Eais.Catalogs.Territoriia result = this.fRaion;
                // *** Start programmer edit section *** (Stroenie.Raion Get end)

                // *** End programmer edit section *** (Stroenie.Raion Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Stroenie.Raion Set start)

                // *** End programmer edit section *** (Stroenie.Raion Set start)
                this.fRaion = value;
                // *** Start programmer edit section *** (Stroenie.Raion Set end)

                // *** End programmer edit section *** (Stroenie.Raion Set end)
            }
        }

        /// <summary>
        /// Строение.
        /// </summary>
        // *** Start programmer edit section *** (Stroenie.Ulitca CustomAttributes)

        // *** End programmer edit section *** (Stroenie.Ulitca CustomAttributes)
        [PropertyStorage(new string[] {
                "Ulitca"})]
        public virtual Iis.Eais.Catalogs.Ulitca Ulitca
        {
            get
            {
                // *** Start programmer edit section *** (Stroenie.Ulitca Get start)

                // *** End programmer edit section *** (Stroenie.Ulitca Get start)
                Iis.Eais.Catalogs.Ulitca result = this.fUlitca;
                // *** Start programmer edit section *** (Stroenie.Ulitca Get end)

                // *** End programmer edit section *** (Stroenie.Ulitca Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Stroenie.Ulitca Set start)

                // *** End programmer edit section *** (Stroenie.Ulitca Set start)
                this.fUlitca = value;
                // *** Start programmer edit section *** (Stroenie.Ulitca Set end)

                // *** End programmer edit section *** (Stroenie.Ulitca Set end)
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
                    return ICSSoft.STORMNET.Information.GetView("AuditView", typeof(Iis.Eais.Catalogs.Stroenie));
                }
            }

            /// <summary>
            /// "StroenieE" view.
            /// </summary>
            public static ICSSoft.STORMNET.View StroenieE
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("StroenieE", typeof(Iis.Eais.Catalogs.Stroenie));
                }
            }

            /// <summary>
            /// "StroenieL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View StroenieL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("StroenieL", typeof(Iis.Eais.Catalogs.Stroenie));
                }
            }

            /// <summary>
            /// "StroenieTransformation" view.
            /// </summary>
            public static ICSSoft.STORMNET.View StroenieTransformation
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("StroenieTransformation", typeof(Iis.Eais.Catalogs.Stroenie));
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