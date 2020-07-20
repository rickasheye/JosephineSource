using AIMLbot;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject
{
    public class UserData
    {
        public ulong id;
        public List<GameSaveData> saveDatas = new List<GameSaveData>();
        public List<DiscordGuild> guildsIn = new List<DiscordGuild>();

        public UserData(ulong id, List<GameSaveData> gameSaves, List<DiscordGuild> discordGuilds)
        {
            this.id = id;
            saveDatas = gameSaves;
            guildsIn = discordGuilds;
        }

        public UserData(ulong id, List<GameSaveData> gameSaves)
        {
            this.id = id;
            saveDatas = gameSaves;
        }

        public UserData(ulong id)
        {
            this.id = id;
        }

        public UserData()
        {
            Debug.Warning("No user data provided unable to create an instance without arguments given!");
        }
    }
}
