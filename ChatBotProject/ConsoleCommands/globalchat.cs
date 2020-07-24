using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject.ConsoleCommands
{
    public class globalchat : ConsoleCommand
    {
        public globalchat() : base("globalchat")
        {

        }

        //A Command to globally chat on every server the bot is on!
        public override void Execute(string[] args)
        {
            base.Execute(args);
            //Execute here
            foreach(DiscordGuild guild in JosephineBot.Discord.Guilds.Values)
            {
                string message = string.Join(" ", args);
                Debug.Log("Sending message with the message of: " + message);
                Debug.Log("Sent message to: " + guild.Name);
                guild.GetDefaultChannel().SendMessageAsync(message);
            }
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("globalchat command needs arguments!!!!");
        }
    }
}
