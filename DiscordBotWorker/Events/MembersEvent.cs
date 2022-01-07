using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotWorker.Events
{
    public static class MembersEvent
    {

        public static Task UserLeft(SocketGuild socketGuild, SocketUser socketUser, BaseSocketClient client) 
        {
           
            var channel = (IMessageChannel) client.GetChannel(844602476842057741);
            channel.SendMessageAsync("Au revoir @" + socketUser.Username);
            return Task.CompletedTask;
        }

        public static Task UserJoined(SocketGuildUser guildUser, BaseSocketClient client)
        {
            var channel = (IMessageChannel)client.GetChannel(844602476842057741);
            channel.SendMessageAsync("Bienvenue @" + guildUser.Username);

            return Task.CompletedTask;
        }
    }
}

