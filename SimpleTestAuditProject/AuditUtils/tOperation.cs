using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditUtils
{
    /// <summary>
    /// Операции изменения над объектом.
    /// </summary>
    public enum tAuditOperation
    {
        NoChange = 0,/*Объект не изменялся*/
        Create = 1,
        Edited = 2,
        Delete = 3,
        CreateAndDelete = 4/*Объект был создан и удалён*/
    }
}
