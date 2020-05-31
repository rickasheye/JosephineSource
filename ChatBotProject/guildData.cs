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
        public ulong disabledChannelID;
        public bool on;
        public List<string> prefixes = new List<string>();
        public string buildLast = "0.1B";

        //Announcer
        public bool announceJoin = true;
        public string AnnounceFormatUser = "Welcome {user} to this guild!";
        public string AnnounceFormatBot = "Welcome fellow {bot} to this guild!";
        public string AnnounceFormatDesc = "You have arrived at: {guildname}";

        //Singer
        public ulong voiceChannel = 00;
        public bool autoSongLeave = true;
        public List<string> queue = new List<string>();
        public bool loopSong;

        public guildData(ulong newGuildID, bool on, ulong lockedChannel, List<string> prefixes, string buildString, bool announce)
        {
            guildId = newGuildID;
            disabledChannelID = lockedChannel;
            this.on = on;
            this.prefixes = prefixes;
            buildLast = buildString;
            announceJoin = announce;
        }
    }
}
