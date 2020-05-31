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
    }
}
