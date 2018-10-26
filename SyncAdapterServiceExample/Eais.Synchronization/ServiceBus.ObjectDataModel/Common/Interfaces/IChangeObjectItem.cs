using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.ObjectDataModel.Common.Interfaces
{
    /// <summary>
    /// Интерфейс содержит определение для типа и самого передаваемого объекта, поддерживающего интерфес определения объекта по типу
    /// </summary>
    /// <typeparam name="TChangeObject"></typeparam>
    public interface IChangeObjectItem<TChangeObject>
        where TChangeObject : IChangeObject
    {
        /// <summary>
        /// Тип передаваемого объекта
        /// </summary>
        string ChangedObjectType { get; set; }

        /// <summary>
        /// Передаваемый объект
        /// </summary>
        TChangeObject ChangedObject { get; set; }
    }
}
