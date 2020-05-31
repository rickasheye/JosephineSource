using AIMLbot.AIMLTagHandlers;
using DSharpPlus.EventArgs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject.Misc.LevelUp
{
    public class LevelUpGame : Game
    {
        public List<PlayerSave_LevelUp> playerSaves = new List<PlayerSave_LevelUp>();

        public LevelUpGame():base("Level Up Game")
        {
            //This is a private game
            Console.WriteLine("Running the game as default!");
            gameRunning = true;
        }

        public override void InitialiseGame()
        {
            base.InitialiseGame();
            //Start the game
            try
            {
                Console.WriteLine("Loading... Level Up Game!!!");
                //When the game gets initialised! we want to load the save files!
                string levelupConfig = Path.Combine(Directory.GetCurrentDirectory(), "levelup.json");
                if (File.Exists(levelupConfig))
                {
                    //Game save does exist find the file and load it!
                    var loadFile = File.ReadAllText(levelupConfig, new UTF8Encoding(false));
                    playerSaves = JsonConvert.DeserializeObject<List<PlayerSave_LevelUp>>(loadFile);
                }
                else
                {
                    //Game save does not exist!
                    //Create a file and reload!
                    File.WriteAllText(levelupConfig, "", new UTF8Encoding(false));
                    Console.WriteLine("No zombie config found so one was created! core is now reloading!");
                    InitialiseGame();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("fucking retarded piece of shit fuck!");
                Console.WriteLine(e.Message);
                File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "levelup.json"));
                InitialiseGame();
            }
        }

        public override void DestroyGame()
        {
            base.DestroyGame();
        }

        public override void UpdateChatGame(MessageCreateEventArgs e)
        {
            base.UpdateChatGame(e);
            //When a message updates tallie the message!
            if(gameRunning == true)
            {
                //The game is running count up player score and match it!
            }
        }
    }
}
