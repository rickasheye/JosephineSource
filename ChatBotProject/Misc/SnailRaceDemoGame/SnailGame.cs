using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject.Misc.SnailRaceDemoGame
{
    public class SnailGame : Game
    {
        public SnailGame():base("Snail Game")
        {
            //Run the snail game!
            Console.WriteLine("The snail game has been called!");
        }

        public override void InitialiseGame()
        {
            base.InitialiseGame();
        }

        public override void DestroyGame()
        {
            base.DestroyGame();
            //Save the game save data mainly!!!!
            //Stop the game
            //This is when the game gets destroyed please delete or save what you need!
            Console.WriteLine("Stopping... Zombie Game!!!");
            //When the game gets initialised! we want to load the save files!
            string Config = Path.Combine(Directory.GetCurrentDirectory(), "snail.json");
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
                Console.WriteLine("No Snail Game config found so one was created!");
                //InitialiseGame();
            }
        }
    }
}
