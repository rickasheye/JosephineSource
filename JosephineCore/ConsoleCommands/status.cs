using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JosephineCore
{
    public class status : ConsoleCommand
    {
        public status() : base("status")
        {

        }

        //A Command to globally chat on every server the bot is on!
        public override void Execute()
        {
            base.Execute();
            //Execute here
            Debug.Log("Chat bot status is " + botIsRunning());
        }
        

        public bool botIsRunning()
        {
            bool running = false;
            if(Program.bot == null)
            {
                running = false;
            }
            else
            {
                running = true;
            }
            return running;
        }
    }
}
