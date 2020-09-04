using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatBotProject.Commands
{
    public class settingscommand : CommandModule
    {
        [Command("settings")]
        [Description("Setting's prompt for the main user or owner.")]
        [Aliases("settingsprompt")]
        public async Task Settings(CommandContext ctx, string arguments)
        {
            await base.OperateCommand(ctx);
            switch (arguments.ToLower())
            {
                case "poggers":
                    string[] pogchampnoises = { "pogchamp", "poggers", "pog", "pogchop" };
                    Random rand = new Random();
                    int randomPog = rand.Next(pogchampnoises.Length);
                    await ctx.RespondAsync(pogchampnoises[randomPog]);
                    break;
                case "prefixes":
                    //manage your prefixes here
                    break;
                case "help":
                default:
                    //Pull up a help prompt here!
                    await helpSettings(ctx);
                    break;
            }
        }

        [Command("settings")]
        [Description("Setting's prompt for the main user or owner.")]
        public async Task Settings(CommandContext ctx)
        {
            await base.OperateCommand(ctx);
            await helpSettings(ctx);
        }

        public async Task helpSettings(CommandContext ctx)
        {
            await ctx.RespondAsync("Theres supposed to be a help prompt here!");
        }
    }
}
