namespace ServiceBus.ObjectDataModel.ToTU
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.Common.Interfaces;

    [DataContract(Name = "ChangedItem", Namespace = "")]
    public class ToTUChangeItem : IChangedItem
    {
        /// <summary>
        /// Тип изменения
        /// </summary>
        [DataMember(Name = "state", IsRequired = true, Order = 0)]
        public tState State { get; set; }

        /// <summary>
        /// Дата изменения
        /// </summary>
        [DataMember(Name = "changeDate", IsRequired = true, Order = 1)]
        public DateTime? ChangeDate { get; set; }

        /// <summary>
        /// Наименование типа сведений, который передается
        /// </summary>
        [DataMember(Name = "changedObjectType", IsRequired = true, Order = 2)]
        public string ChangedObjectType { get; set; }

        /// <inheritdoc />
        [DataMember(Name = "changedAttributes", EmitDefaultValue = false, Order = 3)]
        public List<AttributeDefinition> СhangedAttributes { get; set; }

        public const string TerritoryName = "territory";

        public const string SocialProtectionAuthorityName = "socialProtectionAuthority";

        public const string StreetName = "street";

        public const string CountryName = "country";

        public const string PreferentialCategoryName = "preferentialCategory";

        public const string BenefitForCategoryName = "benefitForCategory";

        public const string BenefitName = "benefit";

        public const string TypeBenefitName = "typeBenefit";

        public const string FundingSourceName = "fundingSource";

        public const string LegalActName = "legalAct";

        public const string ActName = "act";

        public const string TypeLegalActName = "typeLegalAct";

        public const string GovernmentLevelName = "governmentLevel";

        public const string AuthorityIssuedDocumentName = "authorityIssuedDocument";

        public const string SpecialistName = "specialist";

        public const string PeriodName = "period";

        public const string DeregestrationReasonName = "deregestrationReason";

        public const string DisplacementReasonName = "displacementReason";

        public const string FamilyRelationName = "familyRelation";

        public const string KindDocumentName = "kindDocument";

        public const string TypeDocumentName = "typeDocument";

        /// <summary>
        /// Территория.
        /// </summary>
        [DataMember(Name = TerritoryName, EmitDefaultValue = false, Order = 4)]
        public Territory Territory { get; set; }

        /// <summary>
        /// Орган социальной защиты.
        /// </summary>
        [DataMember(Name = SocialProtectionAuthorityName, EmitDefaultValue = false, Order = 5)]
        public SocialProtectionAuthority SocialProtectionAuthority { get; set; }

        /// <summary>
        /// Улица.
        /// </summary>
        [DataMember(Name = StreetName, EmitDefaultValue = false, Order = 6)]
        public Street Street { get; set; }

        /// <summary>
        /// Страна.
        /// </summary>
        [DataMember(Name = CountryName, EmitDefaultValue = false, Order = 7)]
        public Country Country { get; set; }

        /// <summary>
        /// Льготная категория.
        /// </summary>
        [DataMember(Name = PreferentialCategoryName, EmitDefaultValue = false, Order = 8)]
        public PreferentialCategory PreferentialCategory { get; set; }

        /// <summary>
        /// Льгота для категории.
        /// </summary>
        [DataMember(Name = BenefitForCategoryName, EmitDefaultValue = false, Order = 9)]
        public BenefitForCategory BenefitForCategory { get; set; }

        /// <summary>
        /// Льгота.
        /// </summary>
        [DataMember(Name = BenefitName, EmitDefaultValue = false, Order = 10)]
        public Benefit Benefit { get; set; }

        /// <summary>
        /// Тип льготы.
        /// </summary>
        [DataMember(Name = TypeBenefitName, EmitDefaultValue = false, Order = 11)]
        public TypeBenefit TypeBenefit { get; set; }

        /// <summary>
        /// Источник финансирования.
        /// </summary>
        [DataMember(Name = FundingSourceName, EmitDefaultValue = false, Order = 12)]
        public FundingSource FundingSource { get; set; }

        /// <summary>
        /// Нормативный акт.
        /// </summary>
        [DataMember(Name = LegalActName, EmitDefaultValue = false, Order = 13)]
        public LegalAct LegalAct { get; set; }

        /// <summary>
        /// Статья акта.
        /// </summary>
        [DataMember(Name = ActName, EmitDefaultValue = false, Order = 14)]
        public Act Act { get; set; }

        /// <summary>
        /// Тип нормативного акта.
        /// </summary>
        [DataMember(Name = TypeLegalActName, EmitDefaultValue = false, Order = 15)]
        public TypeLegalAct TypeLegalAct { get; set; }

        /// <summary>
        /// Уровень власти.
        /// </summary>
        [DataMember(Name = GovernmentLevelName, EmitDefaultValue = false, Order = 16)]
        public GovernmentLevel GovernmentLevel { get; set; }

        /// <summary>
        /// Орган, выдавший документ.
        /// </summary>
        [DataMember(Name = AuthorityIssuedDocumentName, EmitDefaultValue = false, Order = 17)]
        public AuthorityIssuedDocument AuthorityIssuedDocument { get; set; }

        /// <summary>
        /// Специалист ОСЗ.
        /// </summary>
        [DataMember(Name = SpecialistName, EmitDefaultValue = false, Order = 18)]
        public Specialist Specialist { get; set; }

        /// <summary>
        /// Период.
        /// </summary>
        [DataMember(Name = PeriodName, EmitDefaultValue = false, Order = 19)]
        public Period Period { get; set; }

        /// <summary>
        /// Причина снятия с учета.
        /// </summary>
        [DataMember(Name = DeregestrationReasonName, EmitDefaultValue = false, Order = 20)]
        public DeregestrationReason DeregestrationReason { get; set; }

        /// <summary>
        /// Причина перемещения.
        /// </summary>
        [DataMember(Name = DisplacementReasonName, EmitDefaultValue = false, Order = 21)]
        public DisplacementReason DisplacementReason { get; set; }

        /// <summary>
        /// Родственные отношения.
        /// </summary>
        [DataMember(Name = FamilyRelationName, EmitDefaultValue = false, Order = 22)]
        public FamilyRelation FamilyRelation { get; set; }

        /// <summary>
        /// Вид удостоверяющего документа.
        /// </summary>
        [DataMember(Name = KindDocumentName, EmitDefaultValue = false, Order = 23)]
        public KindDocument KindDocument { get; set; }

        /// <summary>
        /// Тип удостоверяющего документа.
        /// </summary>
        [DataMember(Name = TypeDocumentName, EmitDefaultValue = false, Order = 24)]
        public TypeDocument TypeDocument { get; set; }

        public SyncXMLDataObject GetObjectByType(string type)
        {
            switch (type)
            {
                case TerritoryName:
                    return Territory;
                case SocialProtectionAuthorityName:
                    return SocialProtectionAuthority;
                case StreetName:
                    return Street;
                case CountryName:
                    return Country;
                case PreferentialCategoryName:
                    return PreferentialCategory;
                case BenefitForCategoryName:
                    return BenefitForCategory;
                case BenefitName:
                    return Benefit;
                case TypeBenefitName:
                    return TypeBenefit;
                case FundingSourceName:
                    return FundingSource;
                case LegalActName:
                    return LegalAct;
                case ActName:
                    return Act;
                case TypeLegalActName:
                    return LegalAct;
                case GovernmentLevelName:
                    return GovernmentLevel;
                case AuthorityIssuedDocumentName:
                    return AuthorityIssuedDocument;
                case SpecialistName:
                    return Specialist;
                case PeriodName:
                    return Period;
                case DeregestrationReasonName:
                    return DeregestrationReason;
                case DisplacementReasonName:
                    return DisplacementReason;
                case FamilyRelationName:
                    return FamilyRelation;
                case KindDocumentName:
                    return KindDocument;
                case TypeDocumentName:
                    return TypeDocument;
                default:
                    throw new Exception("Не удалось определить свойство по наименованию типа.");
            }
        }
    }
}
