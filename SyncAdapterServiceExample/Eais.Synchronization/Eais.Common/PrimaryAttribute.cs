namespace Iis.Eais.Common
{
    using System;

    /// <summary>
    /// Атрибут, сообщающий о том, что помеченный класс является первичной сущностью.
    /// </summary>
    public class PrimaryAttribute : Attribute
    {
        public bool IsMain { get; set; }

        /// <summary>
        /// Конструктор без параметров.
        /// </summary>
        public PrimaryAttribute()
        {
            IsMain = false;
        }

        /// <summary>
        /// Контруктор, устанавливающий свойство <see cref="IsMain"/>.
        /// </summary>
        /// <param name="isMain">Является ли данный класс основным (т.е. его присутствие обязательно) среди других первичных.</param>
        public PrimaryAttribute(bool isMain)
        {
            IsMain = isMain;
        }
    }
}
