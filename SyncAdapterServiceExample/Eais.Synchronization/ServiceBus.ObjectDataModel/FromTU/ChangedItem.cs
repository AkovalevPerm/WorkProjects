namespace ServiceBus.ObjectDataModel.FromTU
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Common;
    using Common.Attribute;
    using Common.Interfaces;
    using Iis.Eais.Catalogs;
    using Iis.Eais.GosUslugi;
    using Iis.Eais.Leechnost;
    using Prozhivanie = Iis.Eais.Leechnost.Prozhivanie;

    [DataContract(Name = "Item", Namespace = "")]
    public class ChangedItem : IChangedItem
    {
        /// <summary>
        ///     Личность
        /// </summary>
        [XMLDataFieldType(typeof(Iis.Eais.GosUslugi.Leechnost))]
        [DataMember(Name = "beneficiary", EmitDefaultValue = false, Order = 4)]
        public Beneficiary Beneficiary { get; set; }

        /// <summary>
        ///     Перемещение
        /// </summary>
        [XMLDataFieldType(typeof(Peremeshchenie))]
        [DataMember(Name = "movement", EmitDefaultValue = false, Order = 5)]
        public Movement Movement { get; set; }

        /// <summary>
        ///     Удостоверяющий документ
        /// </summary>
        [XMLDataFieldType(typeof(UdostDokument))]
        [DataMember(Name = "document", EmitDefaultValue = false, Order = 6)]
        public Document Document { get; set; }

        /// <summary>
        ///     Удостоверяющий документ
        /// </summary>
        [XMLDataFieldType(typeof(IzmenenieFIO))]
        [DataMember(Name = "changeName", EmitDefaultValue = false, Order = 7)]
        public ChangeName ChangeName { get; set; }

        /// <summary>
        ///     Льготная категория личности
        /// </summary>
        [XMLDataFieldType(typeof(LgKatLeechnosti))]
        [DataMember(Name = "beneficiaryPreferentialCategory", EmitDefaultValue = false, Order = 8)]
        public BeneficiaryPreferentialCategory BeneficiaryPreferentialCategory { get; set; }

        /// <summary>
        ///     Инвалидность
        /// </summary>
        [XMLDataFieldType(typeof(Invalidnost))]
        [DataMember(Name = "disability", EmitDefaultValue = false, Order = 9)]
        public Disability Disability { get; set; }

        /// <summary>
        ///     Учет личности
        /// </summary>
        [XMLDataFieldType(typeof(UchetLeechnosti))]
        [DataMember(Name = "registrationBeneficiary", EmitDefaultValue = false, Order = 10)]
        public RegistrationBeneficiary RegistrationBeneficiary { get; set; }

        /// <summary>
        ///     Назначение выплаты
        /// </summary>
        [XMLDataFieldType(typeof(NaznachenieVyplaty))]
        [DataMember(Name = "paymentAppointment", EmitDefaultValue = false, Order = 11)]
        public PaymentAppointment PaymentAppointment { get; set; }

        /// <summary>
        ///     Изменение назначения выплаты
        /// </summary>
        [XMLDataFieldType(typeof(IzmenenieNaznachVypl))]
        [DataMember(Name = "changeAppointmentPayment", EmitDefaultValue = false, Order = 12)]
        public ChangeAppointmentPayment ChangeAppointmentPayment { get; set; }

        /// <summary>
        ///     Факт льгот
        /// </summary>
        [XMLDataFieldType(typeof(FaktLgot))]
        [DataMember(Name = "factBenefits", EmitDefaultValue = false, Order = 13)]
        public FactBenefits FactBenefits { get; set; }

        /// <summary>
        ///     Проживание
        /// </summary>
        [XMLDataFieldType(typeof(Prozhivanie))]
        [DataMember(Name = "location", EmitDefaultValue = false, Order = 14)]
        public Location Location { get; set; }

        /// <summary>
        ///     Строение
        /// </summary>
        [XMLDataFieldType(typeof(Stroenie))]
        [DataMember(Name = "structure", EmitDefaultValue = false, Order = 15)]
        public Structure Structure { get; set; }

        /// <summary>
        ///     Заявление на гос. услуги.
        /// </summary>
        [XMLDataFieldType(typeof(Iis.Eais.GosUslugi.ZaiavlenieNaGosUslugu))]
        [DataMember(Name = "zaiavlenieNaGosUslugu", EmitDefaultValue = false, Order = 16)]
        public ZaiavlenieNaGosUslugu ZaiavlenieNaGosUslugu { get; set; }

        /// <summary>
        ///     Член семьи.
        /// </summary>
        [XMLDataFieldType(typeof(Iis.Eais.GosUslugi.ChlenSemi))]
        [DataMember(Name = "сhlenSemi", EmitDefaultValue = false, Order = 16)]
        public ChlenSemi ChlenSemi { get; set; }

        /// <summary>
        ///     Тип изменения
        /// </summary>
        [DataMember(Name = "state", IsRequired = true, Order = 0)]
        public tState State { get; set; }

        /// <summary>
        ///     Дата изменения
        /// </summary>
        [DataMember(Name = "Timestamp", IsRequired = true, Order = 1)]
        public DateTime? ChangeDate { get; set; }

        /// <inheritdoc />
        [DataMember(Name = "changedAttributes", EmitDefaultValue = false, Order = 3)]
        public List<AttributeDefinition> СhangedAttributes { get; set; }
    }
}