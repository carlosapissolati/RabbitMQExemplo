
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker.Api.RabbitMQ.Interfaces;

namespace Worker.Api.RabbitMQ
{
    public abstract class RabbitMQBase : IRabbitMQBase
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
            _connectionFactory.Uri = new Uri(_settings.URL);

            _connection = _connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        ~RabbitMQBase()
        {
            _channel.Close();
            _connection.Close();
        }

        private string ObterNomeFila()
        {
            var nome = _settings.QueueName;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Deserialize(byte[] bytes)
        {
            var value = Encoding.UTF8.GetString(bytes);
            value = value.Replace("\\", "");
            if (value.IndexOf("\"") == 0)
                value = value.Substring(value.IndexOf("\"") + 1, value.LastIndexOf("\"") - 1);
            return value;
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
