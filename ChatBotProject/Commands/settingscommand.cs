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
    public class settingscommand : CommandModule
    {
        [Command("settings")]
        [Description("Setting's prompt for the main user or owner.")]
        [Aliases("settingsprompt")]
        public async Task Settings(CommandContext ctx)
        {
            await base.OperateCommand(ctx);

        }
    }
}
