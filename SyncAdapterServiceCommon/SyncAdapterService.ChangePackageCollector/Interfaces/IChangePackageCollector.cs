namespace SyncAdapterService.ChangePackageCollector.Interfaces
{
    using System;
    using XMLDataModel.Interface;
    using XMLMessageModel.Interface;

    public interface IChangePackageCollector

    {
        /// <summary>
        /// Упаковать в сообщение изменения за период.
        /// </summary>
        /// <typeparam name="TMessage">Тип сообщения</typeparam>
        /// <typeparam name="TItem">Тип объекта-изменения внутри сообщения</typeparam>
        /// <param name="fromDate">Дата с которой собирать изменения.</param>
        /// <param name="toDate">Дата до которой брать изменения.</param>
        void PackChanges<TMessage, TItem>(DateTime? fromDate = null, DateTime? toDate = null)
            where TMessage : IDataChangeMessageResponce<TItem>
            where TItem : IChangedItem;
    }
}