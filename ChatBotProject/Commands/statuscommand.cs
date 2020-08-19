using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace ChatBotProject
{
    public class statuscommand : CommandModule
    {
        [Command("stats")] // let's define this method as a command
        [Description("Getting the stats for this bot like from version number to set colour")] // this will be displayed to tell users what this command does when they invoke help
        [Aliases("status")] // alternative names for the command
        public async Task Status(CommandContext ctx, string argument)
        {
            await base.OperateCommand(ctx);
            switch (argument.ToLower())
            {
                case "version":
                    await ctx.RespondAsync("The version number of this bot is: " + JosephineBot.BUILDID);
                    break;
                case "colour":
                case "color":
                    await ctx.RespondAsync("The colour of this bot is: " + JosephineBot.defaultColor);
                    break;
                case "debug":
                    await ctx.RespondAsync("Is this bot in debug mode? " + JosephineBot.debugMode);
                    break;
                case "servers":
                    await ctx.RespondAsync("This bot serves on: " + JosephineBot.data.Count + "servers!");
                    break;
                case "help":
                default:
                    await CallHelp(ctx);
                    break;
            }
        }

        [Command("stats")]
        [Description("Getting the stats for this bot like from version number to set colour")]
        public async Task Status(CommandContext ctx)
        {
            await base.OperateCommand(ctx);
            await CallHelp(ctx);
        }

        public async Task CallHelp(CommandContext ctx)
        {
            Dictionary<string, string> argumentsHelp = new System.Collections.Generic.Dictionary<string, string>();
            argumentsHelp.Add(";;status/stats <help>", "pulls up the current dialog.");
            argumentsHelp.Add(";;status/stats version", "utility to show the version number of the current running bot.");
            argumentsHelp.Add(";;status/stats color/colour", "displays what colour/color the bot is running with.");
            argumentsHelp.Add(";;status/stats debug", "tells whether the bot is in debug mode or not!");
            argumentsHelp.Add(";;status/stats servers", "tells what servers the bot is running on");
            DiscordEmbed embedHelp = JosephineEmbedBuilder.CreateEmbedMessage(ctx, "Sub-Commands", "for ';;status' or ';;stats'", null, JosephineBot.defaultColor, argumentsHelp);
            await ctx.RespondAsync("Go to http://discord.rickasheye.xyz/ for more sub-commands", false, embedHelp);
        }
    }
}
