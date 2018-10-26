using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iis.Eais.Common.Exceptions
{
    public class SimpleUserException : UserException
    {
        private string message;

        public override string Message
        {
            get
            {
                return message;
            }
        }

        public SimpleUserException(string message)
        {
            this.message = message;
        }
    }
}
