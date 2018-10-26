namespace SyncAdapterService.XMLMessageModel.Interface
{
    using SyncAdapterService.XMLDataModel.Interface;
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     Интерфейс содержит определение для сообщения-запроса изменений.
    /// </summary>
    /// <typeparam name="TType">Реализация вида запрашиваемых типов.</typeparam>
    public interface IDataChangeMessageRequest<TType> : ICommonMessage where TType : IType
    {
        /// <summary>
        ///     Запрашиваемые типы.
        /// </summary>
        List<TType> Type { get; set; }

        /// <summary>
        ///     Дата начала периода изменений.
        /// </summary>
        DateTime From { get; set; }

        /// <summary>
        ///     Дата окончания периода изменений (не включается).
        /// </summary>
        DateTime Until { get; set; }
    }
}