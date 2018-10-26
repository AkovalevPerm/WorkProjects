using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iis.Eais.Common.Errors
{
    /// <summary>
    /// Ошибка из-за ограничения по внешнему ключу.
    /// </summary>
    public class ForeignKeyConstraintError : IError
    {
        /// <summary>
        /// Тип зависимого объекта.
        /// </summary>
        private string foreignType;

        /// <summary>
        /// Тип зависимого объекта
        /// </summary>
        public string ForeignType
        {
            get
            {
                return foreignType;
            }
        }

        /// <summary>
        /// Название класса, отображаемое для пользователя.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Указывает тип зависимого объекта.
        /// </summary>
        /// <param name="type">Тип объекта.</param>
        public void SetForeignType(Type type)
        {
            this.foreignType = type.Name;
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        public ForeignKeyConstraintError(Type type, string text)
        {
            this.foreignType = type.Name;
            this.Text = text;
        }

    }
}
