using System;

namespace ChatBotProject
{
    public class Updater
    {
        //More like a self patcher!
        public Updater()
        {
            Console.WriteLine("Checking for updates updater not enabled!");
            if(JosephineBot.debugMode == false)
            {
                //Check for updates on the master branch otherwise cancel!!!
            }
        }
    }
}
