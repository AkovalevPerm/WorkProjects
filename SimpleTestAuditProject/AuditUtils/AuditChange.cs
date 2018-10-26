using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditUtils
{
    public class AuditChange
    {
        /// <summary>
        /// Изменение детейлов объекта. (Название ключа детела формируется из типа детейла и его первичного ключа заключенного в между@@)
        /// </summary>
        public readonly Dictionary<string, AuditChange> DetailsChanges = new Dictionary<string, AuditChange>();

        /// <summary>
        /// Изменение собственных полей объекта.
        /// </summary>
        public readonly Dictionary<string, string> FieldsChanges = new Dictionary<string, string>();

        /// <summary>
        /// Изменение мастеров объекта.
        /// </summary>
        public readonly Dictionary<string, AuditChange> MastersChanges = new Dictionary<string, AuditChange>();

        /// <summary>
        /// Тип изменённого объекта.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Ключ изменённого объекта.
        /// </summary>
        public string ObjPrimaryKey { get; set; }

        /// <summary>
        /// Операция с объектом.
        /// </summary>
        public tAuditOperation Operation { get; set; }
    }
}
