using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iis.Eais.Common.Errors
{
    /// <summary>
    /// Простая реализация интерфейса IError.
    /// </summary>
    public class SimpleError: IError
    {
        /// <summary>
        /// Текст ошибки.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="message">Текст ошибки.</param>
        public SimpleError(string message) { this.Text = message; }
    }
}
