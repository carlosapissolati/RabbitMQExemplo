using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Worker.Api.RabbitMQ;

namespace Worker.Api
{
    public class FilaService : RabbitMQBase
    {

        public FilaService( IOptions<Settings> options) : base(options)
        {
        }


        public override void Processar(string obj)
        {
            Console.WriteLine(Environment.NewLine + "[Nova mensagem recebida] " + obj);
        }
    }
}
