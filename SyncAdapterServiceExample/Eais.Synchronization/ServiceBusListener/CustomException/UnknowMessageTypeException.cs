namespace ServiceBusListener.CustomException
{
    using System;

    public class UnknowMessageTypeException : Exception
    {
        public UnknowMessageTypeException(string message) : base(message)
        {
        }
    }
}