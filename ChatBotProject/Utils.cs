using AIMLbot;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject
{
    public static class Utils
    {
        public static bool DiscordChannelExists(string channelName, DiscordGuild guild)
        {
            bool existChannel = false;
            foreach (DiscordChannel guilds in guild.Channels.Values)
            {
                if (guilds.Name == channelName)
                {
                    existChannel = true;
                }
            }
            return existChannel;
        }

        public static List<DiscordEmoji> GetRandomPoggersEmoji(List<DiscordEmoji> emojuis)
        {
            List<DiscordEmoji> emojiLeft = new List<DiscordEmoji>();
            foreach (DiscordEmoji emoji in emojuis)
            {
                if (emoji != null)
                {
                    emojiLeft.Add(emoji);
                }
            }
            return emojiLeft;
        }

        public static void setOpen(bool open, ulong id)
        {
            //get the guild data
            int guild = retrieveGuild(id);
            if (JosephineBot.data[guild].on == open)
            {
                Console.WriteLine("The guild " + id + " is already open!");
            }
            else if (JosephineBot.data[guild].on != open)
            {
                JosephineBot.data[guild].on = open;
                Console.WriteLine("The guild " + id + " is now open... or closed");
            }
        }

        public static void setChannel(ulong channelID, ulong id)
        {
            //Set the guild name
            int guild = retrieveGuild(id);
            if (JosephineBot.data[guild].disabledChannelID == channelID)
            {
                Console.WriteLine("The channel is already closed");
            }
            else if (JosephineBot.data[guild].disabledChannelID != channelID)
            {
                JosephineBot.data[guild].disabledChannelID = channelID;
            }
        }

        public static bool returnOpenState(ulong id)
        {
            int guild = retrieveGuild(id);
            //We want to check if the person has permissions before checking the lock too
            return JosephineBot.data[guild].on;
        }

        public static ulong returnChannelLock(ulong id)
        {
            int guild = retrieveGuild(id);
            return JosephineBot.data[guild].disabledChannelID;
        }

        public static int retrieveGuild(ulong id)
        {
            int number = 99999;
            for (int i = 0; i < JosephineBot.data.Count; i++)
            {
                if (JosephineBot.data[i].guildId == id)
                {
                    number = i;
                }
            }

            if (number == 99999)
            {
                //Guild doesnt exist time to create one
                List<string> commandsNew = new List<string>();
                commandsNew.AddRange(JosephineBot.Config.CommandPrefixes);
                JosephineBot.data.Add(new guildData(id, false, 0, commandsNew, JosephineBot.BUILDID, true));
                number = retrieveGuild(id);
            }
            return number;
        }

        public static DiscordChannel retrieveChannelID(string channelName, DiscordGuild guild)
        {
            DiscordChannel userChannel = null;
            foreach(DiscordChannel channel in guild.Channels.Values){
                if(channel.Name == channelName)
                {
                    userChannel = channel;
                }
            }
            return userChannel;
        }

        public static guildData returnGuildData(ulong guild)
        {
            guildData dataReturn = null;
            foreach(guildData data in JosephineBot.data)
            {
                if(data.guildId == guild)
                {
                    dataReturn = data;
                }
            }
            return dataReturn;
        }

        public static async Task<string> PostAsync(string uri, string data, string contentType, string method = "POST")
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.ContentLength = dataBytes.Length;
            request.ContentType = contentType;
            request.Method = method;

            using (Stream requestBody = request.GetRequestStream())
            {
                await requestBody.WriteAsync(dataBytes, 0, dataBytes.Length);
            }

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public static async Task<string> GetAsync(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
