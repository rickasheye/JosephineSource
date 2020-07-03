using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject.Misc
{
    public class Joke
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("joke")]
        public string JokeJoke { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }
    }
}
