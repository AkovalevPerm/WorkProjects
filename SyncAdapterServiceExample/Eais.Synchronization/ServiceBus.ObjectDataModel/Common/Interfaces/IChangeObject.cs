using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.ObjectDataModel.Common.Interfaces
{
    public interface IChangeObject
    {
        /// <summary>
        /// Получить объект по описанию типа
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        SyncXMLDataObject GetObjectByType(string type);
    }
}
