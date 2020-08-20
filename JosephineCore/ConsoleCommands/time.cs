using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JosephineCore
{
    public class time : ConsoleCommand
    {
        public time() : base("time")
        {

        }

        //A Command to globally chat on every server the bot is on!
        public override void Execute()
        {
            base.Execute();
            //Execute here
            Debug.Log("Chat bot status is " + DateTime.Now);
        }
    }
}
