using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JosephineCore
{
    public class ConsoleHandler
    {
        public static List<ConsoleCommand> commands = new List<ConsoleCommand>();

        public ConsoleHandler()
        {
            AddCommand(new stop());
            AddCommand(new commandsloaded());
            AddCommand(new status());
            AddCommand(new running());
            AddCommand(new time());
        }

        public void AddCommand(ConsoleCommand command)
        {
            bool checkAvaliable = false;
            foreach (ConsoleCommand cmd in commands)
            {
                if (cmd.name == command.name)
                {
                    checkAvaliable = true;
                }
            }

            if (checkAvaliable == false)
            {
                commands.Add(command);
            }
        }
        public void SetupDebugConsole(string readLine)
        {
            bool executeSuccessful = false;
            foreach (ConsoleCommand cmd in commands)
            {
                readLine = readLine.Replace("!", "");
                if (readLine == cmd.name)
                {
                    //Debug.Log("Hit command run: " + cmd.name);

                    string[] arguments = readLine.Split(' ');
                    if (arguments.Length > 1)
                    {
                        string[] withoutarg = arguments.Where(w => w != arguments[0]).ToArray();
                        cmd.Execute(withoutarg);
                    }
                    else
                    {
                        cmd.Execute();
                    }
                    executeSuccessful = true;
                }
            }

            if(executeSuccessful == false)
            {
                Debug.Log("Nothing was executed at this time!");
            }
            //SetupDebugConsole();
        }
    }
}
