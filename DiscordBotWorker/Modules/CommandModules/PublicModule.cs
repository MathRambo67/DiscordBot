namespace DiscordBotWorker.Modules.CommandModules
{
    public class PublicModule : BaseModule { 
    
        public PublicModule(ILogger<PublicModule> logger): base(logger) { }

        [Command("ping")]
        [Alias("pong", "hello")]
        public async Task PingAsync()
        {
            _logger.LogInformation("User {user} used the ping command!", Context.User.Username);
            await ReplyAsync("pong!");
        }
    }
}
