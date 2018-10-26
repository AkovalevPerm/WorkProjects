namespace SyncAdapterService.XMLDataModel.Interface
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
