namespace ServiceBus.ObjectDataModel.Common.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Common;

    /// <summary>
    /// Интерфейс содержит определение для передаваемого в сообщении изменения объекта.
    /// </summary>
    //TODO Если реализация IChangedItem будет содержать свойста с одинаковыми типами, то возможны ошибки в CreateChangedItem
    public interface IChangedItem
    {
        /// <summary>
        ///     Тип изменения.
        /// </summary>
        tState State { get; set; }

        /// <summary>
        ///     Дата изменения объекта.
        /// </summary>
        DateTime? ChangeDate { get; set; }

        /// <summary>
        ///     Изменившиеся собственные атрибуты.
        /// </summary>
        List<AttributeDefinition> СhangedAttributes { get; set; }
    }
}