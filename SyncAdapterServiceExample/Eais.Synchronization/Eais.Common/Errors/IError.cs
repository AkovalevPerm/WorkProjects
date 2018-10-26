using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iis.Eais.Common.Errors
{
    /// <summary>
    /// Общее описание пользовательской ошибки.
    /// </summary>
    public interface IError
    {
        /// <summary>
        /// Текст ошибки.
        /// </summary>
        string Text { get; set; }
    }
}
