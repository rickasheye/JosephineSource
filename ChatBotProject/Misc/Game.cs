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

        public virtual void InitialiseGame(string gameName, List<GameSaveData> data)
        {
            try
            {
                Console.WriteLine("Loading... " + gameName + " Game!!!");
                //When the game gets initialised! we want to load the save files!
                string Config = Path.Combine(Directory.GetCurrentDirectory(), gameName + ".json");
                if (File.Exists(Config))
                {
                    //Game save does exist find the file and load it!
                    var loadFile = File.ReadAllText(Config, new UTF8Encoding(false));
                    data.AddRange(JsonConvert.DeserializeObject<List<GameSaveData>>(loadFile));
                }
                else
                {
                    //Game save does not exist!
                    //Create a file and reload!
                    File.WriteAllText(Config, "", new UTF8Encoding(false));
                    Console.WriteLine("No " + gameName + " config found so one was created! core is now reloading!");
                    InitialiseGame(gameName, data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("fucking retarded piece of shit fuck!");
                Console.WriteLine(e.Message);
                //See if deleting the file works!
                File.Delete(Path.Combine(Directory.GetCurrentDirectory(), gameName + ".json"));
                InitialiseGame(gameName, data);
            }
        }

        public virtual void DestroyGame(string gameName)
        {
            //Save the game save data mainly!!!!
            //Stop the game
            //This is when the game gets destroyed please delete or save what you need!
            Console.WriteLine("Stopping... " + gameName + "!!!");
            //When the game gets initialised! we want to load the save files!
            string Config = Path.Combine(Directory.GetCurrentDirectory(), gameName + ".json");
            if (File.Exists(Config))
            {
                //Game save does exist find the file and load it!
                File.WriteAllText(Config, JsonConvert.SerializeObject(Config));
                Console.WriteLine("Saved all the saves!");
            }
            else
            {
                //Game save does not exist!
                //Create a file and reload!
                File.WriteAllText(Config, "{}");
                Console.WriteLine("No " + gameName + " config found so one was created!");
                //InitialiseGame();
            }
        }
    }
}
