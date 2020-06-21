using ChatBotProject;
using ChatBotProject.Misc;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Unosquare.Swan.Formatters;

public class memetemplatecommand : CommandModule
{
    [Command("memetemplate")] // let's define this method as a command
    [Description("Grabs a random meme template for you!")] // this will be displayed to tell users what this command does when they invoke help
    [Aliases("memestemplate")] // alternative names for the command
    public async Task MemesTemplate(CommandContext ctx) // this command takes no arguments
    {
        await base.OperateCommand(ctx);
        DiscordEmbed embedMeme = JosephineEmbedBuilder.CreateEmbedMessage(ctx, "Heres your random meme template!", null, JosephineBot.BotName, JosephineBot.defaultColor);
        DiscordEmbedBuilder builder = new DiscordEmbedBuilder(embedMeme);
        //get a random meme
        var memeString = await Utils.GetAsync("https://api.imgflip.com/get_memes");
        MemeFile memeConvert = JsonConvert.DeserializeObject<MemeFile>(memeString);
        //Get the random meme now
        Meme memeRandom = null;
        Random random = new Random();
        int randMeme = random.Next(0, memeConvert.Data.Memes.Length);
        memeRandom = memeConvert.Data.Memes[randMeme];
        builder.WithImageUrl(memeRandom.Url);
        DiscordEmbed embedNew = builder.Build();
        await ctx.RespondAsync("", false, embedNew);
    }
}