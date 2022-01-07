namespace DiscordBotWorker.Handlers;
using DiscordBotWorker.Events;

public class MemberHandler : HandlerBase
{
    
    public MemberHandler(DiscordSocketClient client, ILogger<DiscordClientService> logger, IConfiguration config) : base(client, logger, config)
    {
    }

    protected override Task ExecuteAsync(CancellationToken cancellationToken)
    {
        Client.UserJoined +=Client_UserJoined;
        Client.UserLeft +=Client_UserLeft;

        return Task.CompletedTask;
    }

    private Task Client_UserLeft(SocketGuild socketGuild, SocketUser socketUser)
    {
        return MembersEvent.UserLeft(socketGuild, socketUser, Client);
    }

    private Task Client_UserJoined(SocketGuildUser SocketGuildUser)
    {
        return MembersEvent.UserJoined(SocketGuildUser, Client);
    }
}


