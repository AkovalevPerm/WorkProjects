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
    /// Проживание.
    /// </summary>
    // *** Start programmer edit section *** (Prozhivanie CustomAttributes)
    [Primary(true)]
    [Serializable]
    // *** End programmer edit section *** (Prozhivanie CustomAttributes)
    [BusinessServer("Iis.Eais.Catalogs.CatalogsBS, Eais.Catalogs.BusinessServers", ICSSoft.STORMNET.Business.DataServiceObjectEvents.OnAllEvents)]
    [AutoAltered()]
    [Caption("Проживание")]
    [AccessType(ICSSoft.STORMNET.AccessType.@this)]
    [View("AuditView", new string[] {
            "Kvartira as \'Kvartira\'",
            "Ploshchad as \'Ploshchad\'",
            "KolKomnat as \'Kol komnat\'",
            "NomerStroeniia as \'Nomer stroeniia\'",
            "Iznos as \'Iznos\'",
            "NomerDoma as \'Nomer doma\'",
            "Telefon as \'Telefon\'",
            "PochtIndeks as \'Pocht indeks\'",
            "KolProzhiv as \'Kol prozhiv\'",
            "IspolzovatIndeksPriPoiske as \'Ispolzovat indeks pri poiske\'",
            "ProchHarakteristiki as \'Proch harakteristiki\'",
            "AdresStrokoi as \'Adres strokoi\'",
            "Ulitca as \'Ulitca\'",
            "Ulitca.PochtIndeks as \'Pocht indeks\'",
            "Stroenie as \'Stroenie\'",
            "Stroenie.PochtIndeks as \'Pocht indeks\'",
            "Territoriia as \'Territoriia\'",
            "Territoriia.KodCLADR as \'Kod CLADR\'"})]
    [View("ProzhivanieE", new string[] {
            "Ulitca as \'Улица\'",
            "Ulitca.VidObekta as \'Вид\'",
            "Ulitca.Naimenovanie as \'Улица\'",
            "NomerDoma as \'№ дома\'",
            "NomerStroeniia as \'№ строения\'",
            "Kvartira as \'Квартира\'",
            "Telefon as \'Телефон\'",
            "KolKomnat as \'Кол-во комнат\'",
            "Iznos as \'Износ\'",
            "Stroenie as \'Строение\'",
            "Stroenie.PochtIndeks as \'Почтовый индекс\'",
            "Stroenie.Raion.Ierarhiia.Naimenovanie as \'Территория\'",
            "Stroenie.Raion.Naimenovanie as \'Территория\'",
            "Stroenie.Ulitca.VidObekta",
            "Stroenie.Ulitca.Naimenovanie as \'Улица\'",
            "Stroenie.Nomer as \'№ дома\'",
            "Stroenie.DopStroenie",
            "PochtIndeks as \'Почт. индекс\'",
            "Territoriia as \'Территория\'",
            "Territoriia.Naimenovanie as \'Территория\'",
            "Territoriia.VidObekta",
            "Territoriia.GorRaion",
            "Territoriia.NaimenovanieAndVid",
            "Ulitca.NaimenovanieAndVid",
            "AdresStrokoi",
            "ProchHarakteristiki as \'Прочие характеристики помещения\'",
            "Stroenie.StroenieStrokoi as \'Строение\'"}, Hidden = new string[] {
            "Ulitca",
            "Stroenie",
            "Stroenie.PochtIndeks",
            "Stroenie.Raion.Ierarhiia.Naimenovanie",
            "Stroenie.Raion.Naimenovanie",
            "Stroenie.Ulitca.VidObekta",
            "Stroenie.Ulitca.Naimenovanie",
            "Stroenie.Nomer",
            "Stroenie.DopStroenie",
            "Territoriia.VidObekta",
            "Territoriia.GorRaion",
            "AdresStrokoi"})]
    [View("ProzhivanieL", new string[] {
            "Kvartira as \'Квартира\'",
            "KolKomnat as \'Кол-во комнат\'",
            "NomerStroeniia as \'№ строения\'",
            "Iznos as \'Износ\'",
            "NomerDoma as \'№ дома\'",
            "Telefon as \'Телефон\'",
            "PochtIndeks as \'Почтовый индекс\'",
            "Territoriia.Naimenovanie as \'Территория\'",
            "Ulitca.Naimenovanie as \'Улица\'",
            "Ulitca.VidObekta as \'Вид улицы\'",
            "ProchHarakteristiki as \'Проч. хар-ки жилья\'",
            "Stroenie.PochtIndeks as \'Почтовый индекс (строение)\'",
            "Stroenie.Raion.Naimenovanie as \'Территория (строение)\'",
            "Stroenie.Ulitca.Naimenovanie as \'Улица (строение)\'",
            "Stroenie.Ulitca.VidObekta as \'Вид улицы (строение)\'",
            "Stroenie.Nomer as \'№ дома (строение)\'",
            "Stroenie.DopStroenie as \'№ строения (строение)\'",
            "AdresStrokoi"}, Hidden = new string[] {
            "AdresStrokoi"})]
    public class Prozhivanie : ICSSoft.STORMNET.DataObject, IDataObjectWithAuditFields, ISync
    {

        private string fKvartira;

        private uint fPloshchad;

        private System.Nullable<int> fKolKomnat;

        private string fNomerStroeniia;

        private System.Nullable<int> fIznos;

        private System.Nullable<int> fNomerDoma;

        private string fTelefon;

        private string fPochtIndeks;

        private uint fKolProzhiv;

        private string fProchHarakteristiki;

        private System.Nullable<System.DateTime> fCreateTime;

        private string fCreator;

        private System.Nullable<System.DateTime> fEditTime;

        private string fEditor;

        private Iis.Eais.Catalogs.Ulitca fUlitca;

        private Iis.Eais.Catalogs.Stroenie fStroenie;

        private Iis.Eais.Catalogs.Territoriia fTerritoriia;

        // *** Start programmer edit section *** (Prozhivanie CustomMembers)

        // *** End programmer edit section *** (Prozhivanie CustomMembers)


        /// <summary>
        /// Kvartira.
        /// </summary>
        // *** Start programmer edit section *** (Prozhivanie.Kvartira CustomAttributes)

        // *** End programmer edit section *** (Prozhivanie.Kvartira CustomAttributes)
        public virtual string Kvartira
        {
            get
            {
                // *** Start programmer edit section *** (Prozhivanie.Kvartira Get start)

                // *** End programmer edit section *** (Prozhivanie.Kvartira Get start)
                string result = this.fKvartira;
                // *** Start programmer edit section *** (Prozhivanie.Kvartira Get end)

                // *** End programmer edit section *** (Prozhivanie.Kvartira Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Prozhivanie.Kvartira Set start)

                // *** End programmer edit section *** (Prozhivanie.Kvartira Set start)
                this.fKvartira = value;
                // *** Start programmer edit section *** (Prozhivanie.Kvartira Set end)

                // *** End programmer edit section *** (Prozhivanie.Kvartira Set end)
            }
        }

        /// <summary>
        /// Ploshchad.
        /// </summary>
        // *** Start programmer edit section *** (Prozhivanie.Ploshchad CustomAttributes)

        // *** End programmer edit section *** (Prozhivanie.Ploshchad CustomAttributes)
        public virtual uint Ploshchad
        {
            get
            {
                // *** Start programmer edit section *** (Prozhivanie.Ploshchad Get start)

                // *** End programmer edit section *** (Prozhivanie.Ploshchad Get start)
                uint result = this.fPloshchad;
                // *** Start programmer edit section *** (Prozhivanie.Ploshchad Get end)

                // *** End programmer edit section *** (Prozhivanie.Ploshchad Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Prozhivanie.Ploshchad Set start)

                // *** End programmer edit section *** (Prozhivanie.Ploshchad Set start)
                this.fPloshchad = value;
                // *** Start programmer edit section *** (Prozhivanie.Ploshchad Set end)

                // *** End programmer edit section *** (Prozhivanie.Ploshchad Set end)
            }
        }

        /// <summary>
        /// KolKomnat.
        /// </summary>
        // *** Start programmer edit section *** (Prozhivanie.KolKomnat CustomAttributes)

        // *** End programmer edit section *** (Prozhivanie.KolKomnat CustomAttributes)
        public virtual System.Nullable<int> KolKomnat
        {
            get
            {
                // *** Start programmer edit section *** (Prozhivanie.KolKomnat Get start)

                // *** End programmer edit section *** (Prozhivanie.KolKomnat Get start)
                System.Nullable<int> result = this.fKolKomnat;
                // *** Start programmer edit section *** (Prozhivanie.KolKomnat Get end)

                // *** End programmer edit section *** (Prozhivanie.KolKomnat Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Prozhivanie.KolKomnat Set start)

                // *** End programmer edit section *** (Prozhivanie.KolKomnat Set start)
                this.fKolKomnat = value;
                // *** Start programmer edit section *** (Prozhivanie.KolKomnat Set end)

                // *** End programmer edit section *** (Prozhivanie.KolKomnat Set end)
            }
        }

        /// <summary>
        /// NomerStroeniia.
        /// </summary>
        // *** Start programmer edit section *** (Prozhivanie.NomerStroeniia CustomAttributes)

        // *** End programmer edit section *** (Prozhivanie.NomerStroeniia CustomAttributes)
        public virtual string NomerStroeniia
        {
            get
            {
                // *** Start programmer edit section *** (Prozhivanie.NomerStroeniia Get start)

                // *** End programmer edit section *** (Prozhivanie.NomerStroeniia Get start)
                string result = this.fNomerStroeniia;
                // *** Start programmer edit section *** (Prozhivanie.NomerStroeniia Get end)

                // *** End programmer edit section *** (Prozhivanie.NomerStroeniia Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Prozhivanie.NomerStroeniia Set start)

                // *** End programmer edit section *** (Prozhivanie.NomerStroeniia Set start)
                this.fNomerStroeniia = value;
                // *** Start programmer edit section *** (Prozhivanie.NomerStroeniia Set end)

                // *** End programmer edit section *** (Prozhivanie.NomerStroeniia Set end)
            }
        }

        /// <summary>
        /// Iznos.
        /// </summary>
        // *** Start programmer edit section *** (Prozhivanie.Iznos CustomAttributes)

        // *** End programmer edit section *** (Prozhivanie.Iznos CustomAttributes)
        public virtual System.Nullable<int> Iznos
        {
            get
            {
                // *** Start programmer edit section *** (Prozhivanie.Iznos Get start)

                // *** End programmer edit section *** (Prozhivanie.Iznos Get start)
                System.Nullable<int> result = this.fIznos;
                // *** Start programmer edit section *** (Prozhivanie.Iznos Get end)

                // *** End programmer edit section *** (Prozhivanie.Iznos Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Prozhivanie.Iznos Set start)

                // *** End programmer edit section *** (Prozhivanie.Iznos Set start)
                this.fIznos = value;
                // *** Start programmer edit section *** (Prozhivanie.Iznos Set end)

                // *** End programmer edit section *** (Prozhivanie.Iznos Set end)
            }
        }

        /// <summary>
        /// NomerDoma.
        /// </summary>
        // *** Start programmer edit section *** (Prozhivanie.NomerDoma CustomAttributes)

        // *** End programmer edit section *** (Prozhivanie.NomerDoma CustomAttributes)
        public virtual System.Nullable<int> NomerDoma
        {
            get
            {
                // *** Start programmer edit section *** (Prozhivanie.NomerDoma Get start)

                // *** End programmer edit section *** (Prozhivanie.NomerDoma Get start)
                System.Nullable<int> result = this.fNomerDoma;
                // *** Start programmer edit section *** (Prozhivanie.NomerDoma Get end)

                // *** End programmer edit section *** (Prozhivanie.NomerDoma Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Prozhivanie.NomerDoma Set start)

                // *** End programmer edit section *** (Prozhivanie.NomerDoma Set start)
                this.fNomerDoma = value;
                // *** Start programmer edit section *** (Prozhivanie.NomerDoma Set end)

                // *** End programmer edit section *** (Prozhivanie.NomerDoma Set end)
            }
        }

        /// <summary>
        /// Telefon.
        /// </summary>
        // *** Start programmer edit section *** (Prozhivanie.Telefon CustomAttributes)

        // *** End programmer edit section *** (Prozhivanie.Telefon CustomAttributes)
        public virtual string Telefon
        {
            get
            {
                // *** Start programmer edit section *** (Prozhivanie.Telefon Get start)

                // *** End programmer edit section *** (Prozhivanie.Telefon Get start)
                string result = this.fTelefon;
                // *** Start programmer edit section *** (Prozhivanie.Telefon Get end)

                // *** End programmer edit section *** (Prozhivanie.Telefon Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Prozhivanie.Telefon Set start)

                // *** End programmer edit section *** (Prozhivanie.Telefon Set start)
                this.fTelefon = value;
                // *** Start programmer edit section *** (Prozhivanie.Telefon Set end)

                // *** End programmer edit section *** (Prozhivanie.Telefon Set end)
            }
        }

        /// <summary>
        /// PochtIndeks.
        /// </summary>
        // *** Start programmer edit section *** (Prozhivanie.PochtIndeks CustomAttributes)

        // *** End programmer edit section *** (Prozhivanie.PochtIndeks CustomAttributes)
        public virtual string PochtIndeks
        {
            get
            {
                // *** Start programmer edit section *** (Prozhivanie.PochtIndeks Get start)

                // *** End programmer edit section *** (Prozhivanie.PochtIndeks Get start)
                string result = this.fPochtIndeks;
                // *** Start programmer edit section *** (Prozhivanie.PochtIndeks Get end)

                // *** End programmer edit section *** (Prozhivanie.PochtIndeks Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Prozhivanie.PochtIndeks Set start)

                // *** End programmer edit section *** (Prozhivanie.PochtIndeks Set start)
                this.fPochtIndeks = value;
                // *** Start programmer edit section *** (Prozhivanie.PochtIndeks Set end)

                // *** End programmer edit section *** (Prozhivanie.PochtIndeks Set end)
            }
        }

        /// <summary>
        /// KolProzhiv.
        /// </summary>
        // *** Start programmer edit section *** (Prozhivanie.KolProzhiv CustomAttributes)

        // *** End programmer edit section *** (Prozhivanie.KolProzhiv CustomAttributes)
        public virtual uint KolProzhiv
        {
            get
            {
                // *** Start programmer edit section *** (Prozhivanie.KolProzhiv Get start)

                // *** End programmer edit section *** (Prozhivanie.KolProzhiv Get start)
                uint result = this.fKolProzhiv;
                // *** Start programmer edit section *** (Prozhivanie.KolProzhiv Get end)

                // *** End programmer edit section *** (Prozhivanie.KolProzhiv Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Prozhivanie.KolProzhiv Set start)

                // *** End programmer edit section *** (Prozhivanie.KolProzhiv Set start)
                this.fKolProzhiv = value;
                // *** Start programmer edit section *** (Prozhivanie.KolProzhiv Set end)

                // *** End programmer edit section *** (Prozhivanie.KolProzhiv Set end)
            }
        }

        /// <summary>
        /// IspolzovatIndeksPriPoiske.
        /// </summary>
        // *** Start programmer edit section *** (Prozhivanie.IspolzovatIndeksPriPoiske CustomAttributes)

        // *** End programmer edit section *** (Prozhivanie.IspolzovatIndeksPriPoiske CustomAttributes)
        [ICSSoft.STORMNET.NotStored()]
        public virtual bool IspolzovatIndeksPriPoiske
        {
            get
            {
                // *** Start programmer edit section *** (Prozhivanie.IspolzovatIndeksPriPoiske Get)
                return false;
                // *** End programmer edit section *** (Prozhivanie.IspolzovatIndeksPriPoiske Get)
            }
            set
            {
                // *** Start programmer edit section *** (Prozhivanie.IspolzovatIndeksPriPoiske Set)

                // *** End programmer edit section *** (Prozhivanie.IspolzovatIndeksPriPoiske Set)
            }
        }

        /// <summary>
        /// ProchHarakteristiki.
        /// </summary>
        // *** Start programmer edit section *** (Prozhivanie.ProchHarakteristiki CustomAttributes)

        // *** End programmer edit section *** (Prozhivanie.ProchHarakteristiki CustomAttributes)
        public virtual string ProchHarakteristiki
        {
            get
            {
                // *** Start programmer edit section *** (Prozhivanie.ProchHarakteristiki Get start)

                // *** End programmer edit section *** (Prozhivanie.ProchHarakteristiki Get start)
                string result = this.fProchHarakteristiki;
                // *** Start programmer edit section *** (Prozhivanie.ProchHarakteristiki Get end)

                // *** End programmer edit section *** (Prozhivanie.ProchHarakteristiki Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Prozhivanie.ProchHarakteristiki Set start)

                // *** End programmer edit section *** (Prozhivanie.ProchHarakteristiki Set start)
                this.fProchHarakteristiki = value;
                // *** Start programmer edit section *** (Prozhivanie.ProchHarakteristiki Set end)

                // *** End programmer edit section *** (Prozhivanie.ProchHarakteristiki Set end)
            }
        }

        /// <summary>
        /// Получить адрес строкой.
        /// </summary>
        // *** Start programmer edit section *** (Prozhivanie.AdresStrokoi CustomAttributes)
        private string ПолучитьАдресСтрокой(Prozhivanie адрес)
        {
            if (адрес == null || адрес.GetStatus() == ObjectStatus.Created) return "";
            string адр = "";
            if (!адрес.CheckLoadedProperty("Territoriia") || !адрес.CheckLoadedProperty("Ulitca")
                || !адрес.CheckLoadedProperty("PochtIndeks") || !адрес.CheckLoadedProperty("NomerDoma")
                || !адрес.CheckLoadedProperty("NomerStroeniia") || !адрес.CheckLoadedProperty("Kvartira"))
                DataServiceProvider.DataService.LoadObject(адрес);
            Territoriia тер = адрес.Territoriia;
            if (!тер.CheckLoadedProperty("Ierarhiia") || !тер.CheckLoadedProperty("GorRaion") || !тер.CheckLoadedProperty("VidObekta")
                        || !тер.CheckLoadedProperty("Naimenovanie"))
                DataServiceProvider.DataService.LoadObject(тер);

            System.Collections.ArrayList arl = new System.Collections.ArrayList();
            while (тер.Ierarhiia != null)
            {
                if (тер.GorRaion != tLogicheskii.Da)
                    arl.Add(тер);
                тер = тер.Ierarhiia;
                if (!тер.CheckLoadedProperty("Ierarhiia") || !тер.CheckLoadedProperty("GorRaion") || !тер.CheckLoadedProperty("VidObekta")
                        || !тер.CheckLoadedProperty("Naimenovanie"))
                    DataServiceProvider.DataService.LoadObject(тер);
            }
            arl.Add(тер);
            Array ar = arl.ToArray();
            for (int i = ar.Length - 1; i >= 0; i--)
            {
                тер = (Territoriia)ar.GetValue(i);
                if (ar.Length == 1)
                    адр = тер.Naimenovanie + (тер.VidObekta == null ? "" : " " + тер.VidObekta.ToLower()) + "., " + адрес.PochtIndeks;
                else
                {
                    if (i == 0)
                        адр = (адр == "" ? "" : адр + ", ") + адрес.PochtIndeks + ", " + (тер.VidObekta == null ? "" : тер.VidObekta.ToLower() + ". ") + тер.Naimenovanie;
                    else
                        if (тер.Naimenovanie == "Россия")
                        адр = "";
                    else
                        адр = (адр == "" ? "" : адр + ", ") + тер.Naimenovanie + (тер.VidObekta == null ? "" : " " + тер.VidObekta.ToLower());

                }
            }
            if (адрес.Ulitca != null)
            {
                Ulitca ул = адрес.Ulitca;
                if (!ул.CheckLoadedProperty("VidObekta") || !ул.CheckLoadedProperty("Naimenovanie"))
                    DataServiceProvider.DataService.LoadObject(ул);
                var видУлицы = ул.VidObekta.ToLower();
                List<string> видыУлицНеСтавитьТочку = new List<string> { "пр-кт", "проезд", "переулок", "городок", "заезд", "проулок", "тракт" };
                видУлицы = (видыУлицНеСтавитьТочку.IndexOf(видУлицы) < 0 ? видУлицы + ". " : видУлицы + " ");
                адр = адр + ", " + (ул.VidObekta == null ? "" : видУлицы) + ул.Naimenovanie;
            }
            адр = адр + (адрес.NomerDoma == 0 ? "" : ", д. " + адрес.NomerDoma.ToString());
            адр = адр + (адрес.NomerStroeniia == null ? "" : "/" + адрес.NomerStroeniia);
            адр = адр + (адрес.Kvartira == null ? "" : ", кв. " + адрес.Kvartira);
            return адр;
        }

        private string m_АдресСтрокой;
        // *** End programmer edit section *** (Prozhivanie.AdresStrokoi CustomAttributes)
        [ICSSoft.STORMNET.NotStored()]
        public virtual string AdresStrokoi
        {
            get
            {
                // *** Start programmer edit section *** (Prozhivanie.AdresStrokoi Get)
                if (m_АдресСтрокой == null)
                {
                    m_АдресСтрокой = ПолучитьАдресСтрокой(this);
                }
                return m_АдресСтрокой;
                // *** End programmer edit section *** (Prozhivanie.AdresStrokoi Get)
            }
            set
            {
                // *** Start programmer edit section *** (Prozhivanie.AdresStrokoi Set)
                m_АдресСтрокой = value;
                // *** End programmer edit section *** (Prozhivanie.AdresStrokoi Set)
            }
        }

        /// <summary>
        /// Время создания объекта.
        /// </summary>
        // *** Start programmer edit section *** (Prozhivanie.CreateTime CustomAttributes)

        // *** End programmer edit section *** (Prozhivanie.CreateTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> CreateTime
        {
            get
            {
                // *** Start programmer edit section *** (Prozhivanie.CreateTime Get start)

                // *** End programmer edit section *** (Prozhivanie.CreateTime Get start)
                System.Nullable<System.DateTime> result = this.fCreateTime;
                // *** Start programmer edit section *** (Prozhivanie.CreateTime Get end)

                // *** End programmer edit section *** (Prozhivanie.CreateTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Prozhivanie.CreateTime Set start)

                // *** End programmer edit section *** (Prozhivanie.CreateTime Set start)
                this.fCreateTime = value;
                // *** Start programmer edit section *** (Prozhivanie.CreateTime Set end)

                // *** End programmer edit section *** (Prozhivanie.CreateTime Set end)
            }
        }

        /// <summary>
        /// Создатель объекта.
        /// </summary>
        // *** Start programmer edit section *** (Prozhivanie.Creator CustomAttributes)

        // *** End programmer edit section *** (Prozhivanie.Creator CustomAttributes)
        [StrLen(255)]
        public virtual string Creator
        {
            get
            {
                // *** Start programmer edit section *** (Prozhivanie.Creator Get start)

                // *** End programmer edit section *** (Prozhivanie.Creator Get start)
                string result = this.fCreator;
                // *** Start programmer edit section *** (Prozhivanie.Creator Get end)

                // *** End programmer edit section *** (Prozhivanie.Creator Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Prozhivanie.Creator Set start)

                // *** End programmer edit section *** (Prozhivanie.Creator Set start)
                this.fCreator = value;
                // *** Start programmer edit section *** (Prozhivanie.Creator Set end)

                // *** End programmer edit section *** (Prozhivanie.Creator Set end)
            }
        }

        /// <summary>
        /// Время последнего редактирования объекта.
        /// </summary>
        // *** Start programmer edit section *** (Prozhivanie.EditTime CustomAttributes)

        // *** End programmer edit section *** (Prozhivanie.EditTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> EditTime
        {
            get
            {
                // *** Start programmer edit section *** (Prozhivanie.EditTime Get start)

                // *** End programmer edit section *** (Prozhivanie.EditTime Get start)
                System.Nullable<System.DateTime> result = this.fEditTime;
                // *** Start programmer edit section *** (Prozhivanie.EditTime Get end)

                // *** End programmer edit section *** (Prozhivanie.EditTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Prozhivanie.EditTime Set start)

                // *** End programmer edit section *** (Prozhivanie.EditTime Set start)
                this.fEditTime = value;
                // *** Start programmer edit section *** (Prozhivanie.EditTime Set end)

                // *** End programmer edit section *** (Prozhivanie.EditTime Set end)
            }
        }

        /// <summary>
        /// Последний редактор объекта.
        /// </summary>
        // *** Start programmer edit section *** (Prozhivanie.Editor CustomAttributes)

        // *** End programmer edit section *** (Prozhivanie.Editor CustomAttributes)
        [StrLen(255)]
        public virtual string Editor
        {
            get
            {
                // *** Start programmer edit section *** (Prozhivanie.Editor Get start)

                // *** End programmer edit section *** (Prozhivanie.Editor Get start)
                string result = this.fEditor;
                // *** Start programmer edit section *** (Prozhivanie.Editor Get end)

                // *** End programmer edit section *** (Prozhivanie.Editor Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Prozhivanie.Editor Set start)

                // *** End programmer edit section *** (Prozhivanie.Editor Set start)
                this.fEditor = value;
                // *** Start programmer edit section *** (Prozhivanie.Editor Set end)

                // *** End programmer edit section *** (Prozhivanie.Editor Set end)
            }
        }

        /// <summary>
        /// Проживание.
        /// </summary>
        // *** Start programmer edit section *** (Prozhivanie.Ulitca CustomAttributes)

        // *** End programmer edit section *** (Prozhivanie.Ulitca CustomAttributes)
        [PropertyStorage(new string[] {
                "Ulitca"})]
        public virtual Iis.Eais.Catalogs.Ulitca Ulitca
        {
            get
            {
                // *** Start programmer edit section *** (Prozhivanie.Ulitca Get start)

                // *** End programmer edit section *** (Prozhivanie.Ulitca Get start)
                Iis.Eais.Catalogs.Ulitca result = this.fUlitca;
                // *** Start programmer edit section *** (Prozhivanie.Ulitca Get end)

                // *** End programmer edit section *** (Prozhivanie.Ulitca Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Prozhivanie.Ulitca Set start)

                // *** End programmer edit section *** (Prozhivanie.Ulitca Set start)
                this.fUlitca = value;
                // *** Start programmer edit section *** (Prozhivanie.Ulitca Set end)

                // *** End programmer edit section *** (Prozhivanie.Ulitca Set end)
            }
        }

        /// <summary>
        /// Проживание.
        /// </summary>
        // *** Start programmer edit section *** (Prozhivanie.Stroenie CustomAttributes)

        // *** End programmer edit section *** (Prozhivanie.Stroenie CustomAttributes)
        [PropertyStorage(new string[] {
                "Stroenie"})]
        public virtual Iis.Eais.Catalogs.Stroenie Stroenie
        {
            get
            {
                // *** Start programmer edit section *** (Prozhivanie.Stroenie Get start)

                // *** End programmer edit section *** (Prozhivanie.Stroenie Get start)
                Iis.Eais.Catalogs.Stroenie result = this.fStroenie;
                // *** Start programmer edit section *** (Prozhivanie.Stroenie Get end)

                // *** End programmer edit section *** (Prozhivanie.Stroenie Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Prozhivanie.Stroenie Set start)

                // *** End programmer edit section *** (Prozhivanie.Stroenie Set start)
                this.fStroenie = value;
                // *** Start programmer edit section *** (Prozhivanie.Stroenie Set end)

                // *** End programmer edit section *** (Prozhivanie.Stroenie Set end)
            }
        }

        /// <summary>
        /// Проживание.
        /// </summary>
        // *** Start programmer edit section *** (Prozhivanie.Territoriia CustomAttributes)

        // *** End programmer edit section *** (Prozhivanie.Territoriia CustomAttributes)
        [PropertyStorage(new string[] {
                "Territoriia"})]
        [NotNull()]
        public virtual Iis.Eais.Catalogs.Territoriia Territoriia
        {
            get
            {
                // *** Start programmer edit section *** (Prozhivanie.Territoriia Get start)

                // *** End programmer edit section *** (Prozhivanie.Territoriia Get start)
                Iis.Eais.Catalogs.Territoriia result = this.fTerritoriia;
                // *** Start programmer edit section *** (Prozhivanie.Territoriia Get end)

                // *** End programmer edit section *** (Prozhivanie.Territoriia Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Prozhivanie.Territoriia Set start)

                // *** End programmer edit section *** (Prozhivanie.Territoriia Set start)
                this.fTerritoriia = value;
                // *** Start programmer edit section *** (Prozhivanie.Territoriia Set end)

                // *** End programmer edit section *** (Prozhivanie.Territoriia Set end)
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
                    return ICSSoft.STORMNET.Information.GetView("AuditView", typeof(Iis.Eais.Catalogs.Prozhivanie));
                }
            }

            /// <summary>
            /// "ProzhivanieE" view.
            /// </summary>
            public static ICSSoft.STORMNET.View ProzhivanieE
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("ProzhivanieE", typeof(Iis.Eais.Catalogs.Prozhivanie));
                }
            }

            /// <summary>
            /// "ProzhivanieL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View ProzhivanieL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("ProzhivanieL", typeof(Iis.Eais.Catalogs.Prozhivanie));
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
