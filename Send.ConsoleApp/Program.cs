using Microsoft.Extensions.DependencyInjection;
using System;

namespace Send.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {



            Console.WriteLine("Enviando para Fila");

            var service = Startup.ConfigureServices();
            var TesteFilaSend = service.GetRequiredService<TesteFilaSend>();

            string mensagem = "Teste Envio Fila";
            TesteFilaSend.SendQueue(mensagem);
        }
    }
}
