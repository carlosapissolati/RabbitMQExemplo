using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Worker.ConsoleApp.RabbitMQ;

namespace Worker.ConsoleApp
{
    public class TesteFila : RabbitMQBase
    {

        public TesteFila(IOptions<Settings> options) : base(options)
        {

        }
        public override void Processar(string obj)
        {
            Console.WriteLine(Environment.NewLine + "[Nova mensagem recebida] " + obj);
        }


    }
}
