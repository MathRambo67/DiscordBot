namespace DiscordBotWorker.Modules
{
    public class PublicModule : ModuleBase<SocketCommandContext>
    {
        private readonly ILogger<PublicModule> _logger;

        public PublicModule(ILogger<PublicModule> logger)
        {
            _logger = logger;
        }

        [Command("ping")]
        [Alias("pong", "hello")]
        public async Task PingAsync()
        {
            _logger.LogInformation("User {user} used the ping command!", Context.User.Username);
            await ReplyAsync("pong!");
        }
    }
}
