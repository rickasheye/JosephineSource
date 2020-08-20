﻿using AIMLbot;
using ChatBotProject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JosephineCore
{
    public class Program
    {
        public static ChatBot bot;
        public static bool read = true;

        public static string BotName = "Katamura Kanetu";
        public static bool debugMode = true;

        public static string BUILDID = "0.34B";

        public static bool commands = false;
        static ConsoleHandler handler;
        static Updater systemUpdater;

        static void Main(string[] args)
        {
            Debug.Log("Starting core... yes this is main core where we do main core things.");
            if (debugMode == true) { Debug.Log("Debug mode is enabled"); }
            if(commands == true) { Debug.Log("Commands are enabled!"); }
            if(bot == null){ bot = new ChatBot("user", null);}
            if(handler == null && commands == true){ handler = new ConsoleHandler(); }
            if (systemUpdater == null) { systemUpdater = new Updater(); }

            while (read)
            {
                Console.Write(">");
                string waitingMessage = Console.ReadLine();
                if (waitingMessage.Contains("!") && commands == true)
                {
                    handler.SetupDebugConsole(waitingMessage);
                }
                else
                {
                    Debug.UserMessage(showOutput(waitingMessage), Debug.UserType.BOT);
                }
            }
        }

        public static string showOutput(string message)
        {
            if(bot == null)
            {
                bot = new ChatBot("user", null);
            }

            string replyMessage = null;
            if (!(string.IsNullOrWhiteSpace(message))) // Make sure the textbox isnt empty
            {
                // Store the Bot's Output by giving it our input.
                string outtt = bot.getOutput(message);
                replyMessage = outtt;

                //=========== Creates backup of chat from user and bot to the given location ============
                FileStream fs = new FileStream(@"chat.log", FileMode.Append, FileAccess.Write);
                if (fs.CanWrite)
                {
                    byte[] write = System.Text.Encoding.ASCII.GetBytes(message + Environment.NewLine + outtt + Environment.NewLine);
                    fs.Write(write, 0, write.Length);
                }
                fs.Flush();
                fs.Close();
            }
            return replyMessage;
        }
    }

    public class ChatBot
    {
        private User myUser;
        public Bot Aimlbot;

        public ChatBot(string UserId, Bot Bot)
        {
            if (Bot == null)
            {
                Aimlbot = new Bot();
            }
            else
            {
                Aimlbot = Bot;
            }
            myUser = new User(UserId, Aimlbot);
            Initialize();
        }

        // Loads all the AIML files in the \AIML folder         
        public void Initialize()
        {
            Aimlbot.loadSettings();
            Aimlbot.isAcceptingUserInput = false;
            Aimlbot.loadAIMLFromFiles();
            Aimlbot.isAcceptingUserInput = true;
        }

        // Given an input string, finds a response using AIMLbot lib
        public String getOutput(String input)
        {
            Request r = new Request(input, myUser, Aimlbot);
            Result res = Aimlbot.Chat(r);
            return (res.Output);
        }
    }
}
