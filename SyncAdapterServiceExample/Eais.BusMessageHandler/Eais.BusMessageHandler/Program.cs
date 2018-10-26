namespace BusMessageHandler
{    
    using System;
    using ICSSoft.STORMNET;
    using MessageHandlers;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Bus Message Handler...");

            var service = new MessageHandlerService();
            service.Process();

            Console.WriteLine("Finished Bus Message Handler.");
        }
    }
}
