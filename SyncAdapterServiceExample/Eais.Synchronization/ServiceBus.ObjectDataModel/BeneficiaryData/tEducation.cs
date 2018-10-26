namespace ServiceBus.ObjectDataModel.BeneficiaryData
{
    using System.Runtime.Serialization;
    
    [DataContract]
    public enum tEducation
    {
        [EnumMember(Value = "Общее")]
        Общее,

        [EnumMember(Value = "Среднее профессиональное")]
        Среднеепрофессиональное,

        [EnumMember(Value = "Высшее")]
        Высшее
    }
}