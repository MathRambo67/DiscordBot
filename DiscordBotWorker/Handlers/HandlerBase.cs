using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotWorker.Handlers
{
    public abstract class HandlerBase : DiscordClientService
    {
        public readonly IConfiguration _config;

        public HandlerBase(DiscordSocketClient client, ILogger<DiscordClientService> logger, IConfiguration config) : base(client, logger)
        {
            _config = config;
        }
    }
}
