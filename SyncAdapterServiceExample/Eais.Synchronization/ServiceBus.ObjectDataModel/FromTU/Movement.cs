using ICSSoft.STORMNET;
using IIS.Synchronizer;
using System;
using System.Runtime.Serialization;
using ServiceBus.ObjectDataModel.Common;

namespace ServiceBus.ObjectDataModel.FromTU
{
    /// <summary>
    /// Перемещение
    /// </summary>
    [DataContract(Name = "movement", Namespace = "")]
    public class Movement: SyncXMLDataObject
    {
        public const string ConstDepatureDate = "depatureDate";
        /// <summary>
        ///     Дата убытия
        /// </summary>
        [DataMember(Name = ConstDepatureDate, EmitDefaultValue = false, Order = 1)]
        public string strdepatureDate
        {
            get { return DepatureDate.HasValue ? DepatureDate?.ToString("yyyy-MM-dd") : null; }
            set { DepatureDate = string.IsNullOrWhiteSpace(value) ? default(DateTime?) : DateTime.Parse(value); }
        }

        public DateTime? DepatureDate { get; set; }

        public const string ConstAddressType = "addressType";
        /// <summary>
        /// Тип адреса
        /// </summary>
        [DataMember(Name = ConstAddressType, EmitDefaultValue = false, Order = 2)]        
        public string strAddressType
        {
            get { return EnumCaption.GetCaptionFor(AddressType); }
            set { AddressType = (tAddressType)EnumCaption.GetValueFor(value, typeof(tAddressType)); }
        }

        public tAddressType AddressType { get; set; }

        public const string ConstDepatureAddress = "depatureAddress";
        /// <summary>
        /// Адрес убытия
        /// </summary>
        [DataMember(Name = ConstDepatureAddress, IsRequired = true, Order = 3)]
        public Address DepatureAddress { get; set; }

        public const string ConstBeneficiary = "beneficiary";
        /// <summary>
        /// Личность
        /// </summary>
        [DataMember(Name = ConstBeneficiary, IsRequired = true, Order = 4)]
        public SyncXMLDataObject Beneficiary { get; set; }

        public const string ConstMovementCause = "movementCause";
        /// <summary>
        /// Причина перемещения
        /// </summary>
        [DataMember(Name = ConstMovementCause, EmitDefaultValue = false, Order = 5)]
        public SyncXMLDataObject MovementCause { get; set; }



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
