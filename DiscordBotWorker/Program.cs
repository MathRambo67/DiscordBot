
var host = Host.CreateDefaultBuilder()
    .ConfigureDiscordHost((context, config) =>
    {
        config.SocketConfig = new DiscordSocketConfig
        {
            LogLevel = LogSeverity.Verbose,
            AlwaysDownloadUsers = true,
            MessageCacheSize = 200,
            GatewayIntents = GatewayIntents.All
        };
        config.Token = context.Configuration["Token"];
    })
    // Optionally wire up the command service
    .UseCommandService((context, config) =>
    {
        config.DefaultRunMode = Discord.Commands.RunMode.Async;
        config.CaseSensitiveCommands = false;
    })
    // Optionally wire up the interactions service
    .ConfigureServices((context, services) =>
    {
        //Discord DI
        services.AddHostedService<CommandHandler>();
        services.AddHostedService<MemberHandler>();
        services.AddHostedService<LongRunningService>();
        services.AddHostedService<BotStatusService>();
       // services.AddHostedService<InteractionHandler>(); //TODO to be Implemented

       //DAL DI
      

    })
    .Build();

await host.RunAsync();
