using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject.Commands
{
    public class funfactcommand : CommandModule
    {
        [Command("funfact")]
        [Description("Getting a funfact.")]
        [Aliases("fact")]
        public async Task Fact(CommandContext ctx)
        {
            await base.OperateCommand(ctx);
            //Fun fact generator
            await base.OperateCommand(ctx);
            DiscordEmbed embedMeme = JosephineEmbedBuilder.CreateEmbedMessage(ctx, "Heres your random meme template!", null, JosephineBot.BotName, JosephineBot.defaultColor);
            DiscordEmbedBuilder builder = new DiscordEmbedBuilder(embedMeme);
            //get a random meme
            var memeString = await Utils.GetAsync("https://www.reddit.com/r/showerthoughts/hot.json?limit=1");
            RedditPost memeConvert = JsonConvert.DeserializeObject<RedditPost>(memeString);
            //Get the random meme now
            RedditPostData data = memeConvert.Data;
            Random random = new Random();
            int randMeme = random.Next(0, data.Children.Length);
            Child childrenMeme = data.Children[randMeme];
            Debug.Log("displaying a funfact of: " + childrenMeme.Data.Selftext);
            builder.Title = childrenMeme.Data.Title;
            builder.Description = childrenMeme.Data.Selftext;
            DiscordEmbed embedNew = builder.Build();
            await ctx.RespondAsync("", false, embedNew);
        }
    }
}
