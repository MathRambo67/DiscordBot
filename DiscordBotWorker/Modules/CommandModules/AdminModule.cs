

namespace DiscordBotWorker.Modules.CommandModules
{
    [Discord.Commands.Group("Admin")]
    [RequireRole(587271027663568956)]
    public  class AdminModule : BaseModule
    {
        public AdminModule(ILogger<AdminModule> logger) : base(logger) { }

        [Command("clean")]
        [Alias("cls", "eff")]
        public async Task CleanAsync(int count = 10, string id = "")
        {
            var embed = new EmbedBuilder();
            var channelId = !String.IsNullOrEmpty(id) ? Convert.ToUInt64(id) : Context.Channel.Id;
            var Channel = Context.Guild.GetChannel(channelId) as SocketTextChannel;

            var messages = await Channel.GetMessagesAsync(count+1).FlattenAsync();
            var filteredMessages = messages.Where(x => (DateTimeOffset.UtcNow - x.Timestamp).TotalDays <= 14);
            var resCount = filteredMessages.Count();

            if (resCount == 0)
            {
                embed.WithTitle("Erreur durant la suppression")
                     .WithDescription("Il n'y a aucun message à supprimé")
                     .WithThumbnailUrl(Context.Client.CurrentUser.GetAvatarUrl(ImageFormat.Auto, 512))
                     .AddField($@"Commande demandé par ", $@"{Context.User.Mention}", true)
                     .WithColor(Color.Orange);

                await ReplyAsync(embed: embed.Build());
            }
            else
            {
                await (Channel as ITextChannel).DeleteMessagesAsync(messages);
                await ReplyAsync($"** {resCount-1} messages supprimé(s) dans le canal {Channel.Mention} :wastebasket: !** :ok_hand: ");
                await Task.Delay(3000);
                var RemoveLast = await Context.Channel.GetMessagesAsync(1, CacheMode.AllowDownload).FlattenAsync();
                await (Context.Channel as ITextChannel).DeleteMessagesAsync(RemoveLast);
             }
        }
        [Command("info")]
        public async Task ServerInfo()
        {
            var embed = new EmbedBuilder();

            var userCount = Context.Guild.Users.Count.ToString();

            embed.WithTitle("Server Informations").WithDescription("This command provide server informations")
                .AddField("Members in server : ", $"*{userCount} user(s)*", false)
                .AddField("Numbers of Roles availables", $"*{Context.Guild.Roles.Count}*", false)
                .AddField("Numbers of Text Channels", $"*{Context.Guild.TextChannels.Count} text channels*", false)
                .AddField("Numbers of Voices Channels", $"*{Context.Guild.VoiceChannels.Count}*", false)
                .WithFooter($"Requested by {Context.User.Username}")
                .WithTimestamp(DateTimeOffset.Now)
                .WithThumbnailUrl(Context.Guild.IconUrl)
                .WithColor(Discord.Color.Blue);

            await ReplyAsync(embed: embed.Build());


        }
    }
}
