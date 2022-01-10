

namespace DiscordBotWorker.Modules.CommandModules
{
    public class BaseModule : ModuleBase<SocketCommandContext>
    {
        public readonly ILogger<BaseModule> _logger;

        public BaseModule(ILogger<BaseModule> logger)
        {
            _logger = logger;
        }
    }
}
