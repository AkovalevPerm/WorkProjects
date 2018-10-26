namespace Synchronization.Utils.CustomException
{
    using System;
    public class XSDExistenceException : Exception
    {
        public XSDExistenceException(string XSDpathIn) : base($"Не удалось найти XSD-схему по указанному пути - {XSDpathIn}")
        {
        }
    }
}
