using ChatBotProject.Misc;
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
    public class icanhasdadjoke : CommandModule
    {
        [Command("icanhasdadjoke")]
        [Description("Generates a dad joke for you.")]
        [Hidden]
        public async Task joke(CommandContext ctx)
        {
            await base.OperateCommand(ctx);
            //get a random meme
            var memeString = await Utils.GetAsync("https://icanhazdadjoke.com/");
            Joke memeConvert = JsonConvert.DeserializeObject<Joke>(memeString);
            DiscordEmbed embedMeme = JosephineEmbedBuilder.CreateEmbedMessage(ctx, "Here is your dad joke!", memeConvert.JokeJoke, JosephineBot.BotName, JosephineBot.defaultColor);
            await ctx.RespondAsync("", false, embedMeme);
        }
    }
}
