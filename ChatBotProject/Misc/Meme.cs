using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ChatBotProject.Misc
{

    public class MemeFile
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("data")]
        public MemeData Data { get; set; }
    }

    public class MemeData
    {
        [JsonProperty("memes")]
        public Meme[] Memes { get; set; }
    }

    public class Meme
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("box_count")]
        public long BoxCount { get; set; }
    }
}
