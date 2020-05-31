using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject
{
    public class Debug
    {
        public static void Log(string message, DiscordClient client)
        {
            client.DebugLogger.LogMessage(LogLevel.Debug, JosephineBot.BotName, message, DateTime.Now);
        }

        public static void Warning(string message, DiscordClient client)
        {
            client.DebugLogger.LogMessage(LogLevel.Warning, JosephineBot.BotName, message, DateTime.Now);
        }
    }
}
