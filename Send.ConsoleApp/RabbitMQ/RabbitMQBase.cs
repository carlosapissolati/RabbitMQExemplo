using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Send.ConsoleApp.RabbitMQ
{
    public abstract class RabbitMQBase
    {

        private IConnection _connection;
        private IModel _channel;
        public string QueueSectionName { get; set; }
        private readonly IConnectionFactory _connectionFactory;

        private readonly Settings _settings;
        public RabbitMQBase(IOptions<Settings> options)
        {
            _settings = options.Value;

            _connectionFactory = new ConnectionFactory();
            _connectionFactory.Uri = new Uri(_settings.URL);
        }


        private string ObterNomeFila()
        {
            var nome = "Teste";
            return nome;
        }

        public void SendQueue(string message)
        {
            try
            {
                _connection = _connectionFactory.CreateConnection();
                _channel = _connection.CreateModel();

                var nomeCompleto = ObterNomeFila();

                //Ativar a confirmação de recebimento
                _channel.ConfirmSelect();

                _channel.QueueDeclare(queue: nomeCompleto, durable: false, exclusive: false, autoDelete: false, arguments: null);

                var body = Encoding.UTF8.GetBytes(message);


                var properties = _channel.CreateBasicProperties();
                properties.Persistent = true;
                properties.Headers = new Dictionary<string, object>();
                properties.Headers.Add("type-queue", Encoding.UTF8.GetBytes("string"));

                _channel.BasicPublish(exchange: "", routingKey: nomeCompleto, basicProperties: properties, body: body);
                _channel.WaitForConfirmsOrDie(new TimeSpan(0, 0, 10));

                _channel.Dispose();
                _connection.Close();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
