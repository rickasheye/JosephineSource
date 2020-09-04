using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject
{
    [System.Serializable]
    public class guildData
    {
        //General
        public ulong guildId;
        public bool on;
        public List<string> prefixes = new List<string>();
        public string buildLast = "0.1B";

        //Announcer
        public bool announceJoin = true;
        public string AnnounceFormatUser = "Welcome {user} to this guild!";
        public string AnnounceFormatBot = "Welcome fellow {bot} to this guild!";
        public string AnnounceFormatDesc = "You have arrived at: {guildname}";

        public bool botTalkOFF;

        public guildData(ulong newGuildID, bool on, List<string> prefixes, string buildString, bool announce)
        {
            guildId = newGuildID;
            this.on = on;
            this.prefixes = prefixes;
            buildLast = buildString;
            announceJoin = announce;
        }

        public guildData(ulong newGuildID, bool on, List<string> prefixes, string buildString)
        {
            guildId = newGuildID;
            this.on = on;
            this.prefixes = prefixes;
            buildLast = buildString;
            announceJoin = true;
        }

        public guildData(ulong newGuildID, bool on, List<string> prefixes)
        {
            guildId = newGuildID;
            this.on = on;
            this.prefixes = prefixes;
            buildLast = JosephineBot.BUILDID;
            announceJoin = true;
        }

        public guildData(ulong newGuildID, bool on, ulong lockedChannel)
        {
            guildId = newGuildID;
            this.on = on;
            List<string> prefixes = new List<string>();
            prefixes.Add(";;");
            this.prefixes = prefixes;
            buildLast = JosephineBot.BUILDID;
            announceJoin = true;
        }

        public guildData(ulong newGuildID, bool on)
        {
            guildId = newGuildID;
            this.on = on;
            List<string> prefixes = new List<string>();
            prefixes.Add(";;");
            this.prefixes = prefixes;
            buildLast = JosephineBot.BUILDID;
            announceJoin = true;
        }

        public guildData(ulong newGuildID)
        {
            guildId = newGuildID;
            this.on = false;
            List<string> prefixes = new List<string>();
            prefixes.Add(";;");
            this.prefixes = prefixes;
            buildLast = JosephineBot.BUILDID;
            announceJoin = true;
        }

        public guildData()
        {
            Debug.Warning("Unable to create a new guild data instance from method as no arguments were provided!!!");
        }
    }
}
