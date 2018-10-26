namespace SyncAdapterService.XMLMessageModel.Attribute
{
    using System;

    /// <summary>
    ///     Атрибут для указания размера пакета сообщения.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class PackageSize : Attribute
    {
        public PackageSize(int s)
        {
            Size = s;
        }

        public int Size { get; }
    }
}