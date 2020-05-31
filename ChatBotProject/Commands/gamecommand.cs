using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatBotProject.Misc;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace ChatBotProject
{
    public class gamecommand : CommandModule
    {
        [Command("game")] // let's define this method as a command
        [Description("Pick a game!")] // this will be displayed to tell users what this command does when they invoke help
        [Aliases("games")] // alternative names for the command
        public async Task Ping(CommandContext ctx, params string[] args) // this command takes no arguments
        {
            await base.OperateCommand(ctx);
            //Which game would you like to pick
            switch (args[0].ToLower())
            {
                case "zombies":
                case "zombie":
                    //Initiate the zombie game!
                    Game game = returnGame("Zombie");
                    await game.StartGame(ctx);
                    break;
                case "snailrace":
                    //Initiate the snail race game!
                    break;
            }
        }

        public Game returnGame(string name)
        {
            Game n = null;
            foreach(Game m in JosephineBot.games)
            {
                if(m.name == name)
                {
                    n = m;
                }
            }
            return n;
        }
    }
}
