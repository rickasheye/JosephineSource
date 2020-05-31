using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject
{
    public  class talkcommand : CommandModule
    {
        [Command("talk")] // let's define this method as a command
        [Description("Turn on or off the ChatBot")] // this will be displayed to tell users what this command does when they invoke help
        public override async Task OperateCommand(CommandContext ctx, params string[] args) // this command takes no arguments
        {
            await base.OperateCommand(ctx);
            List<DiscordEmoji> emojis = new List<DiscordEmoji>();
            emojis.Add(DiscordEmoji.FromName(ctx.Client, ":100:"));
            emojis.Add(DiscordEmoji.FromName(ctx.Client, ":ok_hand:"));
            List<DiscordEmoji> emojisFiltered = Utils.GetRandomPoggersEmoji(emojis);
            Random rnd = new Random();
            var emoji = emojisFiltered[rnd.Next(emojisFiltered.Count)];
            if (Utils.returnOpenState(ctx.Guild.Id) == false && args[0].ToLower().Contains("on"))
            {
                if (Utils.returnOpenState(ctx.Guild.Id) == false)
                {
                    // respond with ping
                    Utils.setOpen(true, ctx.Guild.Id);
                    await ctx.Message.CreateReactionAsync(emoji);
                }
                else
                {
                    await ctx.Message.RespondAsync("The bot is already active!");
                }
            }
            else if (Utils.returnOpenState(ctx.Guild.Id) == true && args[0].ToLower().Contains("off"))
            {
                if (Utils.returnOpenState(ctx.Guild.Id) == true)
                {
                    Utils.setOpen(false, ctx.Guild.Id);
                    await ctx.Message.CreateReactionAsync(emoji);
                }
                else
                {
                    await ctx.Message.RespondAsync("The bot is already deactivated!");
                }
            }
        }
    }
}
