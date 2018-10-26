using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iis.Eais.Common.Exceptions
{
    /// <summary>
    /// Исключение при попытки изменения объекта, заблокированного другим пользователем.
    /// </summary>
    public class LockServiceException : UserException
    {
        /// <summary>
        /// Сообщение конечному пользователю.
        /// </summary>
        public override string Message
        {
            get
            {
                return "Данный объект заблокирован для редактирования другим пользователем.";
            }
        }
    }
}
