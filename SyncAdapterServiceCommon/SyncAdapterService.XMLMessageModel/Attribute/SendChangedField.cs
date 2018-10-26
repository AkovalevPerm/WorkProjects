namespace SyncAdapterService.XMLMessageModel.Attribute
{
    using System;

    /// <summary>
    ///     Атрибут, который указывает нужно ли в сообщение дописывать изменившиеся поля.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SendChangedField : Attribute
    {
        public SendChangedField(bool e)
        {
            Enable = e;
        }

        public bool Enable { get; }
    }
}