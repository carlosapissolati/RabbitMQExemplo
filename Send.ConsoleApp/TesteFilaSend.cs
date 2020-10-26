using Microsoft.Extensions.Options;
using Send.ConsoleApp.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace Send.ConsoleApp
{
    public class TesteFilaSend : RabbitMQBase 
    {

        public TesteFilaSend(IOptions<Settings> options) : base(options)
        {

        }
    }
}
