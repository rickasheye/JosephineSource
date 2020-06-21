using DSharpPlus.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject.Misc
{
    public class MessageHandler
    {
        //This helps to store messages and read and write them to memory or storage to help.

        //message, respond message
        public List<MessageContainer> messages = new List<MessageContainer>();

        public void WriteMessage(MessageContainer container)
        {
            //Write a respond and the original message to file if not recent.
            messages.Add(container);
        }

        public void MessageUpdate()
        {
            //Check through all of the messages if so save the message to file or delete it if out of the question
            List<MessageContainer> containerDuplicate = new List<MessageContainer>();
            containerDuplicate.AddRange(messages);
            foreach(MessageContainer container in messages)
            {
                if(container.originalMessage.Timestamp.Hour < DateTime.Now.Hour + 3)
                {
                    //Delete it..
                    if (container.pathStored != null)
                    {
                        File.Delete(container.pathStored);
                        containerDuplicate.Remove(container);
                        Debug.Log("Deleted message: " + container.originalMessage.Content + " in storage!", JosephineBot.Discord);
                    }
                    else
                    {
                        //There is no path found here
                        Debug.Log("No Path Found: " + container.pathStored);
                    }
                }else if(container.originalMessage.Timestamp.Hour < DateTime.Now.Hour + 1)
                {
                    //Save it..
                    if (container.pathStored == "")
                    {
                        string pathStored = Path.Combine(Directory.GetCurrentDirectory(), "" + DateTime.Now + ".json");
                        File.WriteAllText(pathStored, JsonConvert.SerializeObject(container));
                        Debug.Log("Message stored to storage! : " + container.originalMessage.Content, JosephineBot.Discord);
                        container.pathStored = pathStored;
                    }
                    else
                    {
                        Debug.Log("Message failed to store to storage as there is already a path in this entry!", JosephineBot.Discord);
                    }
                }else if(container.originalMessage.Timestamp.Hour < DateTime.Now.Hour)
                {
                    //Keep it in memory!
                }
            }
            messages.Clear();
            messages.AddRange(containerDuplicate);
        }
    }
}
