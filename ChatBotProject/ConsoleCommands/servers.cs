using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject.ConsoleCommands
{
    public class servers : ConsoleCommand
    {
        public servers() : base("servers")
        {

        }

        //A Command to globally chat on every server the bot is on!
        public override void Execute()
        {
            base.Execute();
            //Execute here
            Debug.Log("I am serving " + JosephineBot.data.Count + " servers which are");
            foreach(guildData data in JosephineBot.data)
            {
                Debug.Log(JosephineBot.Discord.GetChannelAsync(data.guildId).Result.Name);
            }
        }
    }
}
