using DSharpPlus.CommandsNext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject.ConsoleCommands
{
    public class ConsoleCommand
    {
        public string name;
        
        public ConsoleCommand(string commandName)
        {
            name = commandName;
        }

        public virtual void Execute(string[] args)
        {

        }

        public virtual void Execute()
        {

        }
    }
}
