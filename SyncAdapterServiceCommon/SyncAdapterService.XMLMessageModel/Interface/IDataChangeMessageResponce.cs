namespace SyncAdapterService.XMLMessageModel.Interface
{
    using System.Collections.Generic;
    using XMLDataModel.Interface;

    /// <summary>
    ///     Интерфейс содержит определение для сообщения-ответа с изменениями.
    /// </summary>
    /// <typeparam name="TChangeItems"> Реализация вида передаваемых изменений.</typeparam>
    public interface IDataChangeMessageResponce<TChangeItems> : ICommonMessage
        where TChangeItems : IChangedItem
    {
        /// <summary>
        ///     Изменения.
        /// </summary>
        List<TChangeItems> Items { get; set; }
    }
}