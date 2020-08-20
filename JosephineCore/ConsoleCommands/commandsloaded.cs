using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JosephineCore
{
    public class commandsloaded : ConsoleCommand
    {
        public commandsloaded() : base("commandsloaded")
        {

        }

        //A Command to globally chat on every server the bot is on!
        public override void Execute()
        {
            base.Execute();
            //Execute here
            Debug.Log("There is: " + ConsoleHandler.commands.Count + " commands loaded which are: ");
            foreach (ConsoleCommand command in ConsoleHandler.commands)
            {
                Debug.Log(command.name);
            }
        }
    }
}
