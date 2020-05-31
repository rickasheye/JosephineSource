using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject
{
    public class ChatBotModuleArkadius
    {
        //We want to gather results from existing arguments and paste them into a folder?
        //And then we also want to use the current arguments we have and gather them in.

        public void Start()
        {
            //Start the chatbot
            string botLog = Path.Combine(Directory.GetCurrentDirectory(), "botLog");
            if(!File.Exists(botLog))
            {
                File.WriteAllText(botLog, "poggers");
            }
        }

        public string Chat(string message, string username)
        {
            string begginingMessage = null;
            //Bring the message and the user name and return with a message!
            if(message.Contains("blackjack") && message.Contains("play"))
            {
                begginingMessage = "We are now playing blackjack!";
            }else if(message.Contains("blackjack") && message.Contains("stop"))
            {
                begginingMessage = "We now need to stop playing blackjack!";
            }
            return begginingMessage;
        }
    }
}
