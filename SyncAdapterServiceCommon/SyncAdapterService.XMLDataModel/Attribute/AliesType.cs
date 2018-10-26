namespace SyncAdapterService.XMLDataModel.Attribute
{
    using System;

    /// <summary>
    /// Атрибут для указания псевдонима типа.
    /// В сообщении-запросе тип может быть указан как "1403", у нас 1403 = Classifier
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class AliasType : Attribute
    {
        public string Alias { get; private set; }

        public AliasType(string a)
        {
            Alias = a;
        }
    }
}