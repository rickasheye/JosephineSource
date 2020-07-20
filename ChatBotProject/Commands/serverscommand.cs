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
    public class serverscommand : CommandModule
    {
        [Command("server")]
        [Description("Getting how many servers this bot serves on")]
        [Aliases("servers")]
        public async Task Servers(CommandContext ctx)
        {
            await base.OperateCommand(ctx);
            await ctx.RespondAsync("I serve on: " + JosephineBot.data.Count + " servers!");
        }
    }
}
