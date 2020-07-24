using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject.ConsoleCommands
{
    public class ping : ConsoleCommand
    {
        public ping() : base("ping")
        {

        }

        //A Command to globally chat on every server the bot is on!
        public override void Execute()
        {
            base.Execute();
            //Execute here
            Debug.Log("You have a ping of: " + JosephineBot.Discord.Ping);
        }
    }
}
