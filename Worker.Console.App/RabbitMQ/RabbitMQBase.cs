using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Worker.ConsoleApp.RabbitMQ
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

            //_connectionFactory = new ConnectionFactory
            //{
            //    HostName = _settings.HostName,
            //    Port = _settings.Port,
            //    VirtualHost = _settings.VirtualHost,
            //    UserName = _settings.UserName,
            //    Password = _settings.Password,
            //    AutomaticRecoveryEnabled = true
            //};

            _connectionFactory = new ConnectionFactory();
            _connectionFactory.Uri = new Uri("amqps://htasymiw:rs6Hc519hZSTfDAIM993xajtYKPbcafU@jackal.rmq.cloudamqp.com/htasymiw");

            _connection = _connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        private string ObterNomeFila()
        {
            var nome = "Teste";
            return nome;
        }


        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            string message = Encoding.UTF8.GetString(body);

            this.Processar(message);
        }

        public void ConsumeQueue()
        {
            var nomeCompleto = ObterNomeFila();
            _channel.QueueDeclare(nomeCompleto, false, false, false, null);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += Consumer_Received;

            _channel.BasicConsume(nomeCompleto, autoAck: true, consumer: consumer);
        }


        public abstract void Processar(string obj);
    }
}
