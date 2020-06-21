using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject.Misc
{
    public class MessageContainer
    {
        //store a basic message inside here!
        public DiscordMessage originalMessage;
        public DiscordMessage replyMessage;
        public string pathStored = "";
    }
}
