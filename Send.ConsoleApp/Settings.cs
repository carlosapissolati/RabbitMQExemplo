using System;
using System.Collections.Generic;
using System.Text;

namespace Send.ConsoleApp
{
    public class Settings
    {
        public string HostName { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string VirtualHost { get; set; }
        public string QueueName { get; set; }
        public string URL { get; set; }
    }
}
