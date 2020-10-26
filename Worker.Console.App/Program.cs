using Microsoft.Extensions.DependencyInjection;
using System;

namespace Worker.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {


            var service = Startup.ConfigureServices();
            var RabbitMQBase = service.GetRequiredService<TesteFila>();
            RabbitMQBase.ConsumeQueue();

            Console.ReadLine();
        }

    }


}



