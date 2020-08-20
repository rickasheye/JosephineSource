using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JosephineCore
{
    public class ConsoleHandler
    {
        public static List<ConsoleCommand> commands = new List<ConsoleCommand>();

        public ConsoleHandler()
        {
            //Add or assign subclasses
            foreach(Type m in returnSubclasses())
            {
                ConsoleCommand command = m as ConsoleCommand;
                commands.Add(command);
            }
        }

        public static IEnumerable<Type> returnSubclasses()
        {
            Type parentType = typeof(ConsoleCommand);
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();
            IEnumerable<Type> subclasses = types.Where(t => t.IsSubclassOf(parentType));
            return subclasses;
        }

        public void SetupDebugConsole(string readLine)
        {
            bool executeSuccessful = false;
            foreach (ConsoleCommand cmd in commands)
            {
                readLine = readLine.Replace("!", "");
                if (cmd != null && readLine == cmd.name)
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
