using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Worker.Api.RabbitMQ.Interfaces;

namespace Worker.Api.Controllers
{
    public class FilaController : Controller
    {

        private readonly IRabbitMQBase _rabbitMQBase;

        public FilaController(IRabbitMQBase rabbitMQBase)
        {
            _rabbitMQBase = rabbitMQBase;
        }

        [HttpPost]
        [Route("/api/v1/SendFila")]
        public async Task<IActionResult> SendFila()
        {
            _rabbitMQBase.SendQueue("TESTE");
            return Ok("OK");
        }
    }
}
