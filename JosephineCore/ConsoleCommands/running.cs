using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JosephineCore
{
    public class running : ConsoleCommand
    {
        public running() : base("running")
        {

        }

        //A Command to globally chat on every server the bot is on!
        public override void Execute()
        {
            base.Execute();
            //Execute here
            Debug.Log("Running on: " + Environment.MachineName);
            Debug.Log("OSVersion: " + Environment.OSVersion);
            Debug.Log("Is 64bit: " + Environment.Is64BitOperatingSystem);
            Debug.Log("Application running as 64bit: " + Environment.Is64BitProcess);
        }
    }
}
