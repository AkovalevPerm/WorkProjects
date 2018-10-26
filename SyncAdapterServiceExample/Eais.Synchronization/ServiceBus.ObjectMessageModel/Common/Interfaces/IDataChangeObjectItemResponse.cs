namespace ServiceBus.ObjectMessageModel.Common.Interfaces
{
    using System;
    using ObjectDataModel.Common.Interfaces;

    public interface IDataChangeObjectItemResponse<TChanageItem, TChangeObject>: IDataChangeMessageResponse<TChanageItem>       
        where TChanageItem : IChangedItem, IChangeObjectItem<TChangeObject>       
        where TChangeObject : IChangeObject
    {

    }
}
