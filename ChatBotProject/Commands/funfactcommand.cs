using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
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
        [Description("Getting how many servers this bot serves on")]
        [Aliases("fact")]
        public async Task Fact(CommandContext ctx)
        {
            await base.OperateCommand(ctx);
            //Fun fact generator
            await ctx.RespondAsync("I serve on: " + JosephineBot.data.Count + " servers!");
        }
    }
}
