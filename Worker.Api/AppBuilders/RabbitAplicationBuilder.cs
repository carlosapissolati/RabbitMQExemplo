using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Worker.Api.RabbitMQ.Interfaces;

namespace Worker.Api.AppBuilders
{
    public static class RabbitAplicationBuilder
    {
        public static IApplicationBuilder applicationBuilder { get; set; }
        public static IServiceScope _scope { get; set; }

        public static IApplicationBuilder UseRabbitConsumer(this IApplicationBuilder app)
        {
            applicationBuilder = app;
            var life = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();

            life.ApplicationStarted.Register(StartReciboFila);
            return app;
        }

        public static void StartReciboFila()
        {
            using (_scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var clientReciboFila = _scope.ServiceProvider.GetRequiredService<IRabbitMQBase>();
                clientReciboFila.ConsumeQueue();
            }
        }
    }
}
