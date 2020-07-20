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
            if (client != null)
            {
                client.DebugLogger.LogMessage(LogLevel.Debug, JosephineBot.BotName, message, DateTime.Now);
            }
            else
            {
                Console.WriteLine("[LOG] " + message);
            }
        }

        public static void Log(string message)
        {
            if (JosephineBot.Discord != null)
            {
                JosephineBot.Discord.DebugLogger.LogMessage(LogLevel.Debug, JosephineBot.BotName, message, DateTime.Now);
            }
            else
            {
                Console.WriteLine("[LOG] " + message);
            }
        }

        public static void Warning(string message, DiscordClient client)
        {
            if (client != null)
            {
                client.DebugLogger.LogMessage(LogLevel.Warning, JosephineBot.BotName, message, DateTime.Now);
            }
            else
            {
                Console.WriteLine("[WARNING] " + message);
            }
        }

        public static void Warning(string message)
        {
            if(JosephineBot.Discord != null)
            {
                JosephineBot.Discord.DebugLogger.LogMessage(LogLevel.Warning, JosephineBot.BotName, message, DateTime.Now);
            }
            else
            {
                Console.WriteLine("[WARNING] " + message);
            }
        }
    }
}
