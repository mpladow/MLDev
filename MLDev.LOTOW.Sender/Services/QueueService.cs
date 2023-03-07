using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MLDev.LOTOW.Sender.Services
{
    internal class QueueService
    {
        private readonly IConfiguration _config;

        public QueueService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendMessageAsync<T>(T serviceBusMessage, string queueName)
        {
            //var queueClient = new QueueClient()
        }
    }
}
