namespace ServiceBus.ObjectDataModel.Common
{
    using System;
    using System.Runtime.Serialization;
    using IIS.Synchronizer;

    /// <summary>
    ///     Класс, содержащий поле Guid в качестве уникального ключа.
    ///     Основная единица данных в синхронизационных сообщениях типа IDataChangeMessageResponce.
    ///     Используется в универсальном обработчике сообщений.
    /// </summary>
    [DataContract(Namespace = "")]
    public class SyncXMLDataObject : ISync
    {
        public const string ConstCreateTime = "CreateTime";
        public const string ConstCreator = "Creator";
        public const string ConstEditTime = "EditTime";
        public const string ConstEditor = "Editor";

        /// <summary>
        ///     Уникальный идентификатор.
        /// </summary>
        [DataMember(Name = "guid", IsRequired = true, Order = 0)]
        public virtual Guid Guid { get; set; }
    }
}