using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject.Misc
{
    public class Game
    {
        public string name;
        public bool gameRunning = false;

        public Game(string title)
        {
            name = title;
        }

        public async virtual Task StartGame(CommandContext ctx)
        {
            if(gameRunning == false)
            {
                //Run the game!
                gameRunning = true;
            }
            else
            {
                //Game is already running!
                Console.WriteLine("Game is already running!: " + name);
            }
        }

        public virtual void UpdateChatGame(MessageCreateEventArgs e)
        {
            //When the update hits on the chat
        }

        public virtual void UpdateEditChatGame(MessageUpdateEventArgs e)
        {
            //When any message is updated
        }

        public virtual void InitialiseGame()
        {

        }

        public virtual void DestroyGame()
        {
        }
    }
}
