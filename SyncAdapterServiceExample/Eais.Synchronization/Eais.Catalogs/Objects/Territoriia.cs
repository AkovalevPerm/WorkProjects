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
    /// Территория.
    /// </summary>
    // *** Start programmer edit section *** (Territoriia CustomAttributes)
    [Primary(true)]
    [Serializable]
    // *** End programmer edit section *** (Territoriia CustomAttributes)
    [BusinessServer("Iis.Eais.Catalogs.TerritoriiaBS, Eais.Catalogs.BusinessServers", ICSSoft.STORMNET.Business.DataServiceObjectEvents.OnAllEvents)]
    [AutoAltered()]
    [AccessType(ICSSoft.STORMNET.AccessType.@this)]
    [View("AuditView", new string[] {
            "KodCLADR as \'Kod CLADR\'",
            "KodOKATO as \'Kod OKATO\'",
            "VidObekta as \'Vid obekta\'",
            "PochtIndeks as \'Pocht indeks\'",
            "Naimenovanie as \'Naimenovanie\'",
            "KodSZ as \'Kod SZ\'",
            "GorRaion as \'Gor raion\'",
            "KodRegionaPF as \'Kod regiona PF\'",
            "KodOKTMO as \'Kod OKTMO\'",
            "KodOPFR as \'Kod OPFR\'",
            "KodFIAS as \'Kod FIAS\'",
            "OrganSZ as \'Organ SZ\'",
            "OrganSZ.Telefon as \'Telefon\'",
            "Ierarhiia as \'Ierarhiia\'",
            "Ierarhiia.KodCLADR as \'Kod CLADR\'",
            "Oldid as \'Ид\'"})]
    [View("TerritoriiaE", new string[] {
            "Naimenovanie as \'Наименование\'",
            "KodOKATO as \'Код ОКАТО\'",
            "VidObekta as \'Вид объекта\'",
            "KodSZ as \'Код СЗ\'",
            "KodCLADR as \'Код КЛАДР\'",
            "PochtIndeks as \'Почт. индекс\'",
            "GorRaion as \'Р-н города\'",
            "KodRegionaPF as \'Код региона ПФ\'",
            "KodOKTMO as \'Код ОКТМО\'",
            "KodOPFR as \'Код ОПФР\'",
            "KodFIAS as \'Код ФИАС\'",
            "Ierarhiia as \'Иерархия\' on \'-Вышестоящая территория\'",
            "Ierarhiia.Naimenovanie as \'Наименование\' on \'-Вышестоящая территория\'",
            "Ierarhiia.KodOKATO as \'Код ОКАТО\' on \'-Вышестоящая территория\'",
            "OrganSZ as \'Орган СЗ\'",
            "OrganSZ.Naimenovanie as \'Наименование\'",
            "Oldid as \'Ид\'"})]
    [View("TerritoriiaL", new string[] {
            "Naimenovanie as \'Наименование\'",
            "KodCLADR as \'Код КЛАДР\'",
            "KodOKATO as \'Код ОКАТО\'",
            "VidObekta as \'Вид объекта\'",
            "PochtIndeks as \'Почт. индекс\'",
            "KodSZ as \'Код СЗ\'",
            "GorRaion as \'Р-н города\'",
            "Ierarhiia",
            "Ierarhiia.Naimenovanie as \'Наименование выш.\'",
            "Ierarhiia.KodFIAS",
            "Ierarhiia.KodOKATO as \'Код ОКАТО выш.\'",
            "OrganSZ",
            "OrganSZ.Kod as \'Код органа СЗ\'",
            "OrganSZ.Naimenovanie as \'Наименование органа СЗ\'",
            "KodRegionaPF as \'Код региона ПФ\'",
            "KodOPFR as \'Код ОПФР\'",
            "KodOKTMO as \'Код ОКТМО\'",
            "KodFIAS as \'Код ФИАС\'",
            "NaimenovanieAndVid",
            "Oldid as \'Ид\'",
            "NaimDlyaZaprosa"}, Hidden = new string[] {
            "Ierarhiia",
            "Ierarhiia.KodFIAS",
            "OrganSZ",
            "NaimenovanieAndVid",
            "NaimDlyaZaprosa"})]
    [View("TerritoriiaTransformation", new string[] {
            "VidObekta",
            "Naimenovanie",
            "Ierarhiia",
            "Ierarhiia.KodFIAS"})]
    public class Territoriia : ICSSoft.STORMNET.DataObject, IDataObjectWithAuditFields, ISync
    {

        private string fKodCLADR;

        private string fKodOKATO;

        private string fVidObekta;

        private string fPochtIndeks;

        private string fNaimenovanie;

        private string fKodSZ;

        private Iis.Eais.Catalogs.tLogicheskii fGorRaion = Iis.Eais.Catalogs.tLogicheskii.Net;

        private string fKodRegionaPF;

        private string fKodOKTMO;

        private string fKodOPFR;

        private string fKodFIAS;

        private System.Nullable<System.DateTime> fCreateTime;

        private string fCreator;

        private System.Nullable<System.DateTime> fEditTime;

        private string fEditor;

        private int fOldid;

        private Iis.Eais.Catalogs.OrganSZ fOrganSZ;

        private Iis.Eais.Catalogs.Territoriia fIerarhiia;

        // *** Start programmer edit section *** (Territoriia CustomMembers)

        // *** End programmer edit section *** (Territoriia CustomMembers)


        /// <summary>
        /// KodCLADR.
        /// </summary>
        // *** Start programmer edit section *** (Territoriia.KodCLADR CustomAttributes)

        // *** End programmer edit section *** (Territoriia.KodCLADR CustomAttributes)
        public virtual string KodCLADR
        {
            get
            {
                // *** Start programmer edit section *** (Territoriia.KodCLADR Get start)

                // *** End programmer edit section *** (Territoriia.KodCLADR Get start)
                string result = this.fKodCLADR;
                // *** Start programmer edit section *** (Territoriia.KodCLADR Get end)

                // *** End programmer edit section *** (Territoriia.KodCLADR Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Territoriia.KodCLADR Set start)

                // *** End programmer edit section *** (Territoriia.KodCLADR Set start)
                this.fKodCLADR = value;
                // *** Start programmer edit section *** (Territoriia.KodCLADR Set end)

                // *** End programmer edit section *** (Territoriia.KodCLADR Set end)
            }
        }

        /// <summary>
        /// KodOKATO.
        /// </summary>
        // *** Start programmer edit section *** (Territoriia.KodOKATO CustomAttributes)

        // *** End programmer edit section *** (Territoriia.KodOKATO CustomAttributes)
        public virtual string KodOKATO
        {
            get
            {
                // *** Start programmer edit section *** (Territoriia.KodOKATO Get start)

                // *** End programmer edit section *** (Territoriia.KodOKATO Get start)
                string result = this.fKodOKATO;
                // *** Start programmer edit section *** (Territoriia.KodOKATO Get end)

                // *** End programmer edit section *** (Territoriia.KodOKATO Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Territoriia.KodOKATO Set start)

                // *** End programmer edit section *** (Territoriia.KodOKATO Set start)
                this.fKodOKATO = value;
                // *** Start programmer edit section *** (Territoriia.KodOKATO Set end)

                // *** End programmer edit section *** (Territoriia.KodOKATO Set end)
            }
        }

        /// <summary>
        /// VidObekta.
        /// </summary>
        // *** Start programmer edit section *** (Territoriia.VidObekta CustomAttributes)

        // *** End programmer edit section *** (Territoriia.VidObekta CustomAttributes)
        public virtual string VidObekta
        {
            get
            {
                // *** Start programmer edit section *** (Territoriia.VidObekta Get start)

                // *** End programmer edit section *** (Territoriia.VidObekta Get start)
                string result = this.fVidObekta;
                // *** Start programmer edit section *** (Territoriia.VidObekta Get end)

                // *** End programmer edit section *** (Territoriia.VidObekta Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Territoriia.VidObekta Set start)

                // *** End programmer edit section *** (Territoriia.VidObekta Set start)
                this.fVidObekta = value;
                // *** Start programmer edit section *** (Territoriia.VidObekta Set end)

                // *** End programmer edit section *** (Territoriia.VidObekta Set end)
            }
        }

        /// <summary>
        /// PochtIndeks.
        /// </summary>
        // *** Start programmer edit section *** (Territoriia.PochtIndeks CustomAttributes)

        // *** End programmer edit section *** (Territoriia.PochtIndeks CustomAttributes)
        public virtual string PochtIndeks
        {
            get
            {
                // *** Start programmer edit section *** (Territoriia.PochtIndeks Get start)

                // *** End programmer edit section *** (Territoriia.PochtIndeks Get start)
                string result = this.fPochtIndeks;
                // *** Start programmer edit section *** (Territoriia.PochtIndeks Get end)

                // *** End programmer edit section *** (Territoriia.PochtIndeks Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Territoriia.PochtIndeks Set start)

                // *** End programmer edit section *** (Territoriia.PochtIndeks Set start)
                this.fPochtIndeks = value;
                // *** Start programmer edit section *** (Territoriia.PochtIndeks Set end)

                // *** End programmer edit section *** (Territoriia.PochtIndeks Set end)
            }
        }

        /// <summary>
        /// Naimenovanie.
        /// </summary>
        // *** Start programmer edit section *** (Territoriia.Naimenovanie CustomAttributes)

        // *** End programmer edit section *** (Territoriia.Naimenovanie CustomAttributes)
        [NotNull()]
        public virtual string Naimenovanie
        {
            get
            {
                // *** Start programmer edit section *** (Territoriia.Naimenovanie Get start)

                // *** End programmer edit section *** (Territoriia.Naimenovanie Get start)
                string result = this.fNaimenovanie;
                // *** Start programmer edit section *** (Territoriia.Naimenovanie Get end)

                // *** End programmer edit section *** (Territoriia.Naimenovanie Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Territoriia.Naimenovanie Set start)

                // *** End programmer edit section *** (Territoriia.Naimenovanie Set start)
                this.fNaimenovanie = value;
                // *** Start programmer edit section *** (Territoriia.Naimenovanie Set end)

                // *** End programmer edit section *** (Territoriia.Naimenovanie Set end)
            }
        }

        /// <summary>
        /// KodSZ.
        /// </summary>
        // *** Start programmer edit section *** (Territoriia.KodSZ CustomAttributes)

        // *** End programmer edit section *** (Territoriia.KodSZ CustomAttributes)
        public virtual string KodSZ
        {
            get
            {
                // *** Start programmer edit section *** (Territoriia.KodSZ Get start)

                // *** End programmer edit section *** (Territoriia.KodSZ Get start)
                string result = this.fKodSZ;
                // *** Start programmer edit section *** (Territoriia.KodSZ Get end)

                // *** End programmer edit section *** (Territoriia.KodSZ Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Territoriia.KodSZ Set start)

                // *** End programmer edit section *** (Territoriia.KodSZ Set start)
                this.fKodSZ = value;
                // *** Start programmer edit section *** (Territoriia.KodSZ Set end)

                // *** End programmer edit section *** (Territoriia.KodSZ Set end)
            }
        }

        /// <summary>
        /// GorRaion.
        /// </summary>
        // *** Start programmer edit section *** (Territoriia.GorRaion CustomAttributes)

        // *** End programmer edit section *** (Territoriia.GorRaion CustomAttributes)
        [NotNull()]
        public virtual Iis.Eais.Catalogs.tLogicheskii GorRaion
        {
            get
            {
                // *** Start programmer edit section *** (Territoriia.GorRaion Get start)

                // *** End programmer edit section *** (Territoriia.GorRaion Get start)
                Iis.Eais.Catalogs.tLogicheskii result = this.fGorRaion;
                // *** Start programmer edit section *** (Territoriia.GorRaion Get end)

                // *** End programmer edit section *** (Territoriia.GorRaion Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Territoriia.GorRaion Set start)

                // *** End programmer edit section *** (Territoriia.GorRaion Set start)
                this.fGorRaion = value;
                // *** Start programmer edit section *** (Territoriia.GorRaion Set end)

                // *** End programmer edit section *** (Territoriia.GorRaion Set end)
            }
        }

        /// <summary>
        /// KodRegionaPF.
        /// </summary>
        // *** Start programmer edit section *** (Territoriia.KodRegionaPF CustomAttributes)

        // *** End programmer edit section *** (Territoriia.KodRegionaPF CustomAttributes)
        public virtual string KodRegionaPF
        {
            get
            {
                // *** Start programmer edit section *** (Territoriia.KodRegionaPF Get start)

                // *** End programmer edit section *** (Territoriia.KodRegionaPF Get start)
                string result = this.fKodRegionaPF;
                // *** Start programmer edit section *** (Territoriia.KodRegionaPF Get end)

                // *** End programmer edit section *** (Territoriia.KodRegionaPF Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Territoriia.KodRegionaPF Set start)

                // *** End programmer edit section *** (Territoriia.KodRegionaPF Set start)
                this.fKodRegionaPF = value;
                // *** Start programmer edit section *** (Territoriia.KodRegionaPF Set end)

                // *** End programmer edit section *** (Territoriia.KodRegionaPF Set end)
            }
        }

        /// <summary>
        /// KodOKTMO.
        /// </summary>
        // *** Start programmer edit section *** (Territoriia.KodOKTMO CustomAttributes)

        // *** End programmer edit section *** (Territoriia.KodOKTMO CustomAttributes)
        public virtual string KodOKTMO
        {
            get
            {
                // *** Start programmer edit section *** (Territoriia.KodOKTMO Get start)

                // *** End programmer edit section *** (Territoriia.KodOKTMO Get start)
                string result = this.fKodOKTMO;
                // *** Start programmer edit section *** (Territoriia.KodOKTMO Get end)

                // *** End programmer edit section *** (Territoriia.KodOKTMO Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Territoriia.KodOKTMO Set start)

                // *** End programmer edit section *** (Territoriia.KodOKTMO Set start)
                this.fKodOKTMO = value;
                // *** Start programmer edit section *** (Territoriia.KodOKTMO Set end)

                // *** End programmer edit section *** (Territoriia.KodOKTMO Set end)
            }
        }

        /// <summary>
        /// KodOPFR.
        /// </summary>
        // *** Start programmer edit section *** (Territoriia.KodOPFR CustomAttributes)

        // *** End programmer edit section *** (Territoriia.KodOPFR CustomAttributes)
        public virtual string KodOPFR
        {
            get
            {
                // *** Start programmer edit section *** (Territoriia.KodOPFR Get start)

                // *** End programmer edit section *** (Territoriia.KodOPFR Get start)
                string result = this.fKodOPFR;
                // *** Start programmer edit section *** (Territoriia.KodOPFR Get end)

                // *** End programmer edit section *** (Territoriia.KodOPFR Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Territoriia.KodOPFR Set start)

                // *** End programmer edit section *** (Territoriia.KodOPFR Set start)
                this.fKodOPFR = value;
                // *** Start programmer edit section *** (Territoriia.KodOPFR Set end)

                // *** End programmer edit section *** (Territoriia.KodOPFR Set end)
            }
        }

        /// <summary>
        /// KodFIAS.
        /// </summary>
        // *** Start programmer edit section *** (Territoriia.KodFIAS CustomAttributes)

        // *** End programmer edit section *** (Territoriia.KodFIAS CustomAttributes)
        public virtual string KodFIAS
        {
            get
            {
                // *** Start programmer edit section *** (Territoriia.KodFIAS Get start)

                // *** End programmer edit section *** (Territoriia.KodFIAS Get start)
                string result = this.fKodFIAS;
                // *** Start programmer edit section *** (Territoriia.KodFIAS Get end)

                // *** End programmer edit section *** (Territoriia.KodFIAS Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Territoriia.KodFIAS Set start)

                // *** End programmer edit section *** (Territoriia.KodFIAS Set start)
                this.fKodFIAS = value;
                // *** Start programmer edit section *** (Territoriia.KodFIAS Set end)

                // *** End programmer edit section *** (Territoriia.KodFIAS Set end)
            }
        }

        /// <summary>
        /// Время создания объекта.
        /// </summary>
        // *** Start programmer edit section *** (Territoriia.CreateTime CustomAttributes)

        // *** End programmer edit section *** (Territoriia.CreateTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> CreateTime
        {
            get
            {
                // *** Start programmer edit section *** (Territoriia.CreateTime Get start)

                // *** End programmer edit section *** (Territoriia.CreateTime Get start)
                System.Nullable<System.DateTime> result = this.fCreateTime;
                // *** Start programmer edit section *** (Territoriia.CreateTime Get end)

                // *** End programmer edit section *** (Territoriia.CreateTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Territoriia.CreateTime Set start)

                // *** End programmer edit section *** (Territoriia.CreateTime Set start)
                this.fCreateTime = value;
                // *** Start programmer edit section *** (Territoriia.CreateTime Set end)

                // *** End programmer edit section *** (Territoriia.CreateTime Set end)
            }
        }

        /// <summary>
        /// Создатель объекта.
        /// </summary>
        // *** Start programmer edit section *** (Territoriia.Creator CustomAttributes)

        // *** End programmer edit section *** (Territoriia.Creator CustomAttributes)
        [StrLen(255)]
        public virtual string Creator
        {
            get
            {
                // *** Start programmer edit section *** (Territoriia.Creator Get start)

                // *** End programmer edit section *** (Territoriia.Creator Get start)
                string result = this.fCreator;
                // *** Start programmer edit section *** (Territoriia.Creator Get end)

                // *** End programmer edit section *** (Territoriia.Creator Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Territoriia.Creator Set start)

                // *** End programmer edit section *** (Territoriia.Creator Set start)
                this.fCreator = value;
                // *** Start programmer edit section *** (Territoriia.Creator Set end)

                // *** End programmer edit section *** (Territoriia.Creator Set end)
            }
        }

        /// <summary>
        /// Время последнего редактирования объекта.
        /// </summary>
        // *** Start programmer edit section *** (Territoriia.EditTime CustomAttributes)

        // *** End programmer edit section *** (Territoriia.EditTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> EditTime
        {
            get
            {
                // *** Start programmer edit section *** (Territoriia.EditTime Get start)

                // *** End programmer edit section *** (Territoriia.EditTime Get start)
                System.Nullable<System.DateTime> result = this.fEditTime;
                // *** Start programmer edit section *** (Territoriia.EditTime Get end)

                // *** End programmer edit section *** (Territoriia.EditTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Territoriia.EditTime Set start)

                // *** End programmer edit section *** (Territoriia.EditTime Set start)
                this.fEditTime = value;
                // *** Start programmer edit section *** (Territoriia.EditTime Set end)

                // *** End programmer edit section *** (Territoriia.EditTime Set end)
            }
        }

        /// <summary>
        /// Последний редактор объекта.
        /// </summary>
        // *** Start programmer edit section *** (Territoriia.Editor CustomAttributes)

        // *** End programmer edit section *** (Territoriia.Editor CustomAttributes)
        [StrLen(255)]
        public virtual string Editor
        {
            get
            {
                // *** Start programmer edit section *** (Territoriia.Editor Get start)

                // *** End programmer edit section *** (Territoriia.Editor Get start)
                string result = this.fEditor;
                // *** Start programmer edit section *** (Territoriia.Editor Get end)

                // *** End programmer edit section *** (Territoriia.Editor Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Territoriia.Editor Set start)

                // *** End programmer edit section *** (Territoriia.Editor Set start)
                this.fEditor = value;
                // *** Start programmer edit section *** (Territoriia.Editor Set end)

                // *** End programmer edit section *** (Territoriia.Editor Set end)
            }
        }

        /// <summary>
        /// NaimenovanieAndVid.
        /// </summary>
        // *** Start programmer edit section *** (Territoriia.NaimenovanieAndVid CustomAttributes)

        // *** End programmer edit section *** (Territoriia.NaimenovanieAndVid CustomAttributes)
        [ICSSoft.STORMNET.NotStored()]
        [DataServiceExpression(typeof(ICSSoft.STORMNET.Business.SQLDataService), "btrim(@Naimenovanie@ || \' \' || COALESCE(@VidObekta@, \'\'))\r\n")]
        public virtual string NaimenovanieAndVid
        {
            get
            {
                // *** Start programmer edit section *** (Territoriia.NaimenovanieAndVid Get)
                return $"{this.Naimenovanie} {this.VidObekta}";
                // *** End programmer edit section *** (Territoriia.NaimenovanieAndVid Get)
            }
            set
            {
                // *** Start programmer edit section *** (Territoriia.NaimenovanieAndVid Set)

                // *** End programmer edit section *** (Territoriia.NaimenovanieAndVid Set)
            }
        }

        /// <summary>
        /// Oldid.
        /// </summary>
        // *** Start programmer edit section *** (Territoriia.Oldid CustomAttributes)

        // *** End programmer edit section *** (Territoriia.Oldid CustomAttributes)
        public virtual int Oldid
        {
            get
            {
                // *** Start programmer edit section *** (Territoriia.Oldid Get start)

                // *** End programmer edit section *** (Territoriia.Oldid Get start)
                int result = this.fOldid;
                // *** Start programmer edit section *** (Territoriia.Oldid Get end)

                // *** End programmer edit section *** (Territoriia.Oldid Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Territoriia.Oldid Set start)

                // *** End programmer edit section *** (Territoriia.Oldid Set start)
                this.fOldid = value;
                // *** Start programmer edit section *** (Territoriia.Oldid Set end)

                // *** End programmer edit section *** (Territoriia.Oldid Set end)
            }
        }

        /// <summary>
        /// NaimDlyaZaprosa.
        /// </summary>
        // *** Start programmer edit section *** (Territoriia.NaimDlyaZaprosa CustomAttributes)
        private string cashedNaimDlyaZaprosa = null;
        // *** End programmer edit section *** (Territoriia.NaimDlyaZaprosa CustomAttributes)
        [ICSSoft.STORMNET.NotStored()]
        [DataServiceExpression(typeof(ICSSoft.STORMNET.Business.SQLDataService), "btrim(COALESCE(@VidObekta@, \'\') || \' \' || @Naimenovanie@ || \' \' || COALESCE(@Iera" +
            "rhiia.Naimenovanie@, \'\'))")]
        public virtual string NaimDlyaZaprosa
        {
            get
            {
                // *** Start programmer edit section *** (Territoriia.NaimDlyaZaprosa Get)
                if (this.cashedNaimDlyaZaprosa == null)
                {
                    string[] str = { this.VidObekta, this.Naimenovanie, this.Ierarhiia?.Naimenovanie };
                    this.cashedNaimDlyaZaprosa = String.Join(" ", str);
                }
                return this.cashedNaimDlyaZaprosa;
                // *** End programmer edit section *** (Territoriia.NaimDlyaZaprosa Get)
            }
            set
            {
                // *** Start programmer edit section *** (Territoriia.NaimDlyaZaprosa Set)
                if (value != null)
                {
                    this.cashedNaimDlyaZaprosa = value;
                }
                // *** End programmer edit section *** (Territoriia.NaimDlyaZaprosa Set)
            }
        }

        /// <summary>
        /// Территория.
        /// </summary>
        // *** Start programmer edit section *** (Territoriia.OrganSZ CustomAttributes)

        // *** End programmer edit section *** (Territoriia.OrganSZ CustomAttributes)
        [PropertyStorage(new string[] {
                "OrganSZ"})]
        public virtual Iis.Eais.Catalogs.OrganSZ OrganSZ
        {
            get
            {
                // *** Start programmer edit section *** (Territoriia.OrganSZ Get start)

                // *** End programmer edit section *** (Territoriia.OrganSZ Get start)
                Iis.Eais.Catalogs.OrganSZ result = this.fOrganSZ;
                // *** Start programmer edit section *** (Territoriia.OrganSZ Get end)

                // *** End programmer edit section *** (Territoriia.OrganSZ Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Territoriia.OrganSZ Set start)

                // *** End programmer edit section *** (Territoriia.OrganSZ Set start)
                this.fOrganSZ = value;
                // *** Start programmer edit section *** (Territoriia.OrganSZ Set end)

                // *** End programmer edit section *** (Territoriia.OrganSZ Set end)
            }
        }

        /// <summary>
        /// Территория.
        /// </summary>
        // *** Start programmer edit section *** (Territoriia.Ierarhiia CustomAttributes)

        // *** End programmer edit section *** (Territoriia.Ierarhiia CustomAttributes)
        [PropertyStorage(new string[] {
                "Ierarhiia"})]
        public virtual Iis.Eais.Catalogs.Territoriia Ierarhiia
        {
            get
            {
                // *** Start programmer edit section *** (Territoriia.Ierarhiia Get start)

                // *** End programmer edit section *** (Territoriia.Ierarhiia Get start)
                Iis.Eais.Catalogs.Territoriia result = this.fIerarhiia;
                // *** Start programmer edit section *** (Territoriia.Ierarhiia Get end)

                // *** End programmer edit section *** (Territoriia.Ierarhiia Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Territoriia.Ierarhiia Set start)

                // *** End programmer edit section *** (Territoriia.Ierarhiia Set start)
                this.fIerarhiia = value;
                // *** Start programmer edit section *** (Territoriia.Ierarhiia Set end)

                // *** End programmer edit section *** (Territoriia.Ierarhiia Set end)
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
                    return ICSSoft.STORMNET.Information.GetView("AuditView", typeof(Iis.Eais.Catalogs.Territoriia));
                }
            }

            /// <summary>
            /// "TerritoriiaE" view.
            /// </summary>
            public static ICSSoft.STORMNET.View TerritoriiaE
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("TerritoriiaE", typeof(Iis.Eais.Catalogs.Territoriia));
                }
            }

            /// <summary>
            /// "TerritoriiaL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View TerritoriiaL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("TerritoriiaL", typeof(Iis.Eais.Catalogs.Territoriia));
                }
            }

            /// <summary>
            /// "TerritoriiaTransformation" view.
            /// </summary>
            public static ICSSoft.STORMNET.View TerritoriiaTransformation
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("TerritoriiaTransformation", typeof(Iis.Eais.Catalogs.Territoriia));
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