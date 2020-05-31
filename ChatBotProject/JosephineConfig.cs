using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject
{
    public class JosephineConfig
    {
        [JsonProperty("token")]
        public string Token { get; private set; } = string.Empty;

        [JsonProperty("command_prefixes")]
        public string[] CommandPrefixes { get; private set; } = new[] { ";;" };

        [JsonProperty("shards")]
        public int ShardCount { get; private set; } = 1;

        [JsonProperty("debugGuild")]
        public string DebugGuildID { get; private set; }

        [JsonProperty("debugMode")]
        public bool debug { get; private set; }
    }
}
