using ICSSoft.STORMNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceBus.ObjectDataModel.Common;

namespace ServiceBus.ObjectDataModel.FromTU
{
    /// <summary>
    /// Строение
    /// </summary>
    [DataContract(Namespace = "")]
    public class Structure: SyncXMLDataObject
    {
        public const string ConstFIAS = "FIAS";
        /// <summary>
        ///  Код ФИАС
        /// </summary>
        [DataMember(Name = ConstFIAS, EmitDefaultValue = false, Order = 1)]
        public string FIAS { get; set; }

        public const string ConstType = "type";
        /// <summary>
        /// Вид строения
        /// </summary>
        [DataMember(Name = ConstType, EmitDefaultValue = false, Order = 2)]
        public string strTypeStructure
        {
            get { return EnumCaption.GetCaptionFor(TypeStructure); }
            set { TypeStructure = string.IsNullOrWhiteSpace(value) ? tTypeStructure.Pusto : (tTypeStructure)EnumCaption.GetValueFor(value, typeof(tTypeStructure)); }
        }
        public tTypeStructure TypeStructure { get; set; }

        public const string ConstNumber = "number";
        /// <summary>
        ///     Номер.
        /// </summary>
        [DataMember(Name = ConstNumber, IsRequired = true, Order = 3)]
        public int Number { get; set; }

        public const string ConstPostIndex = "postIndex";
        /// <summary>
        /// Почтовый индекс
        /// </summary>
        [DataMember(Name = ConstPostIndex, IsRequired = true, Order = 4)]
        public string PostIndex { get; set; }

        public const string ConstAdditional = "additional";
        /// <summary>
        ///     Дополнительное строение.
        /// </summary>
        [DataMember(Name = ConstAdditional, EmitDefaultValue = false, Order = 5)]
        public string Additional { get; set; }

        public const string ConstVerificationCode = "verificationCode";
        /// <summary>
        /// Код подтверждения
        /// </summary>
        [DataMember(Name = ConstVerificationCode, EmitDefaultValue = false, Order = 6)]
        public int? VerificationCode { get; set; }

        public const string ConstArea = "area";
        /// <summary>
        /// Район
        /// </summary>
        [DataMember(Name = ConstArea, IsRequired = true, Order = 7)]
        public SyncXMLDataObject Area { get; set; }

        public const string ConstStreet = "street";
        /// <summary>
        ///     Улица.
        /// </summary>
        [DataMember(Name = ConstStreet, IsRequired = true, Order = 8)]
        public SyncXMLDataObject Street { get; set; }



        /// <summary>
        ///  Время создания объекта
        /// </summary>
        [DataMember(Name = ConstCreateTime, EmitDefaultValue = false, Order = 100)]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// Создатель
        /// </summary>
        [DataMember(Name = ConstCreator, EmitDefaultValue = false, Order = 101)]
        public string Creator { get; set; }

        /// <summary>
        ///  Время последнего редактирования объекта
        /// </summary>
        [DataMember(Name = ConstEditTime, EmitDefaultValue = false, Order = 102)]
        public DateTime? EditTime { get; set; }

        /// <summary>
        /// Последний редактор объекта
        /// </summary>
        [DataMember(Name = ConstEditor, EmitDefaultValue = false, Order = 103)]
        public string Editor { get; set; }
    }
}
