using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Worker.Api.RabbitMQ.Interfaces
{
    public interface IRabbitMQBase
    {
        void ConsumeQueue();
        void SendQueue(string message);
    }
}
