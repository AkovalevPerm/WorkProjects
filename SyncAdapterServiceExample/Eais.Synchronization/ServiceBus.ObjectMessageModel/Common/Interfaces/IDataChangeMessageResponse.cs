namespace ServiceBus.ObjectMessageModel.Common.Interfaces
{
    using System.Collections.Generic;
    using ObjectDataModel.Common.Interfaces;

    /// <summary>
    ///     Интерфейс содержит определение для сообщения-ответа с изменениями.
    /// </summary>
    /// <typeparam name="TChangeItems"> Реализация вида передаваемых изменений.</typeparam>
    public interface IDataChangeMessageResponse<TChangeItems> : ICommonMessage
        where TChangeItems : IChangedItem
    {
        /// <summary>
        ///     Изменения.
        /// </summary>
        List<TChangeItems> Items { get; set; }
    }
}