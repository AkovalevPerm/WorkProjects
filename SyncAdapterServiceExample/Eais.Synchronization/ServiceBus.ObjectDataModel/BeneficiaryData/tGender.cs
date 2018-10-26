namespace ServiceBus.ObjectDataModel.BeneficiaryData
{
    using System.Runtime.Serialization;

    [DataContract]
    public enum tGender
    {
        [EnumMember(Value = "муж.")]
        Муж = 0,

        [EnumMember(Value = "жен.")]
        Жен = 1
    }
}