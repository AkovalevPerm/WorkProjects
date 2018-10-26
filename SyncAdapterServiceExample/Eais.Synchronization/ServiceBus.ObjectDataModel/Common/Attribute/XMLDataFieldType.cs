namespace ServiceBus.ObjectDataModel.Common.Attribute
{
    using System;

    /// <summary>
    /// Атрибут для указания? что поле в классе является ссылкой на XML-класс данных.
    /// Type указывает на соответствующий тип объектов-источников. 
    /// Изменения объектов XMLDataFieldType типов ChangePackageCollector включает в синхонизационное сообщение.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class XMLDataFieldType : Attribute
    {
        public Type Type { get; }

        public XMLDataFieldType(Type t)
        {
            Type = t;
        }
    }
}