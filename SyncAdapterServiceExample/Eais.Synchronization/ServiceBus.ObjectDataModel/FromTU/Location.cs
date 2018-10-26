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
    /// Проживание
    /// </summary>
    [DataContract(Namespace = "")]
    public class Location: SyncXMLDataObject
    {
        public const string ConstStructure = "structure";
        /// <summary>
        /// Строение
        /// </summary>
        [DataMember(Name = ConstStructure, EmitDefaultValue = false, Order = 1)]
        public SyncXMLDataObject Structure { get; set; }

        public const string ConstTerritory = "territory";
        /// <summary>
        ///     Территория.
        /// </summary>
        [DataMember(Name = ConstTerritory, IsRequired = true, Order = 2)]
        public SyncXMLDataObject Territory { get; set; }

        public const string ConstStreet = "street";
        /// <summary>
        ///     Улица.
        /// </summary>
        [DataMember(Name = ConstStreet, IsRequired = true, Order = 3)]
        public SyncXMLDataObject Street { get; set; }

        public const string ConstNumber = "number";
        /// <summary>
        ///     Номер дома.
        /// </summary>
        [DataMember(Name = ConstNumber, EmitDefaultValue = false, Order = 4)]
        public int? Number { get; set; }

        public const string ConstHouseNumber = "houseNumber";
        /// <summary>
        ///     Номер строения.
        /// </summary>
        [DataMember(Name = ConstHouseNumber, EmitDefaultValue = false, Order = 5)]
        public string HouseNumber { get; set; }

        public const string ConstIndex = "index";
        /// <summary>
        /// Почтовый индекс
        /// </summary>
        [DataMember(Name = ConstIndex, EmitDefaultValue = false, Order = 6)]
        public string Index { get; set; }

        public const string ConstAppartment = "appartment";
        /// <summary>
        ///     Квартира.
        /// </summary>
        [DataMember(Name = ConstAppartment, EmitDefaultValue = false, Order = 7)]
        public string Appartment { get; set; }

        public const string ConstPhone = "phone";
        /// <summary>
        ///     Номер телефон.
        /// </summary>
        [DataMember(Name = ConstPhone, EmitDefaultValue = false, Order = 8)]
        public string Phone { get; set; }

        public const string ConstArea = "area";
        /// <summary>
        ///     Номер дома.
        /// </summary>
        [DataMember(Name = ConstArea, EmitDefaultValue = false, Order = 9)]
        public int? Area { get; set; }

        public const string ConstNumberRooms = "numberRooms";
        /// <summary>
        ///  Количество комнат
        /// </summary>
        [DataMember(Name = ConstNumberRooms, EmitDefaultValue = false, Order = 10)]
        public int? NumberRooms { get; set; }

        public const string ConstDeterioration = "deterioration";
        /// <summary>
        ///  Износ
        /// </summary>
        [DataMember(Name = ConstDeterioration, EmitDefaultValue = false, Order = 11)]
        public int? Deterioration { get; set; }

        public const string ConstNumberResidents = "numberResidents";
        /// <summary>
        ///  Количество проживающих
        /// </summary>
        [DataMember(Name = ConstNumberResidents, EmitDefaultValue = false, Order = 12)]
        public int? NumberResidents { get; set; }

        public const string ConstOtherCharacteristics = "otherCharacteristics";
        /// <summary>
        ///  Прочие характеристики
        /// </summary>
        [DataMember(Name = ConstOtherCharacteristics, EmitDefaultValue = false, Order = 13)]
        public string OtherCharacteristics { get; set; }


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
