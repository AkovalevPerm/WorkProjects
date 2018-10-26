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
    /// Назначение выплаты
    /// </summary>
    [DataContract(Namespace = "")]
    public class PaymentAppointment: SyncXMLDataObject
    {
        public const string ConstConfirmed = "confirmed";
        /// <summary>
        /// Подтверждено
        /// </summary>
        [DataMember(Name = ConstConfirmed, IsRequired = true, Order = 1)]
        public tBool Confirmed { get; set; }

        
        public const string ConstBenefit = "benefit";
        /// <summary>
        /// Льгота
        /// </summary>
        [DataMember(Name = ConstBenefit, IsRequired = true, Order = 2)]
        public SyncXMLDataObject Benefit { get; set; }

        public const string ConstMedium = "medium";
        /// <summary>
        /// Носитель
        /// </summary>
        [DataMember(Name = ConstMedium, IsRequired = true, Order = 3)]
        public SyncXMLDataObject Medium { get; set; }

        public const string ConstDependent = "dependent";
        /// <summary>
        /// Иждивенец
        /// </summary>
        [DataMember(Name = ConstDependent, EmitDefaultValue = false, Order = 4)]
        public SyncXMLDataObject Dependent { get; set; }


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
