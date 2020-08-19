using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JosephineCore
{
    public class Debug
    {
        public static void Log(string message)
        {
            Console.WriteLine("[LOG] " + message);
        }

        public static void Warning(string message)
        {
            Console.WriteLine("[WARNING] " + message);
        }

        public enum UserType
        {
            BOT, USER
        }

        public static void UserMessage(string message, UserType type)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[" + type.ToString() + "] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
        }
    }
}
