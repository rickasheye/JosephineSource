using AIMLbot;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unosquare.Swan;

namespace ChatBotProject
{
    public class announcecommand : CommandModule
    {
        [Command("announce")] // let's define this method as a command
        [Description("Manage the announcer everytime someone joins")] // this will be displayed to tell users what this command does when they invoke help
        public async Task AnnounceCommand(CommandContext ctx, string subparams1, string subparams2, params string[] otherargs) // this command takes no arguments
        {
            await base.OperateCommand(ctx);
            await CommandOperable(ctx, subparams1, subparams2, convertArgumentsToOtherArgs(otherargs));
        }

        [Command("announce")]
        [Description("Manage the announcer everytime someone joins")]
        public async Task AnnounceCommand(CommandContext ctx, string subparams1, string subparams2, string otherargs)
        {
            await base.OperateCommand(ctx);
            await CommandOperable(ctx, subparams1, subparams2, otherargs);
        }

        [Command("announce")]
        [Description("Manage the announcer everytime someone joins")]
        public async Task AnnounceCommand(CommandContext ctx, string subparams1, string subparams2)
        {
            await base.OperateCommand(ctx);
            await CommandOperable(ctx, subparams1, subparams2, null);
        }

        [Command("announce")]
        [Description("Manage the announcer everytime someone joins")]
        public async Task AnnounceCommand(CommandContext ctx, string subparams1)
        {
            await base.OperateCommand(ctx);
            await CommandOperable(ctx, subparams1, null, null);
        }

        [Command("announce")]
        [Description("Manage the anouncer everytime someone joins")]
        public async Task AnnounceCommand(CommandContext ctx)
        {
            await base.OperateCommand(ctx);
            await CommandOperable(ctx, null, null, null);
        }

        public string convertArgumentsToOtherArgs(string[] arguments)
        {
            //Convert string arguments to a single string
            return string.Join(" ", arguments);
        }

        public async Task CommandOperable(CommandContext ctx, string subparams1, string subparams2, string otherargs)
        {
            //Currently its not possible for commands to input "otherargs" as the command handler will interpret one word as the whole string as thats what it thinks!
            guildData specificGuild = Utils.returnGuildData(ctx.Guild.Id);

            List<DiscordEmoji> emojis = new List<DiscordEmoji>();
            emojis.Add(DiscordEmoji.FromName(ctx.Client, ":100:"));
            emojis.Add(DiscordEmoji.FromName(ctx.Client, ":ok_hand:"));
            List<DiscordEmoji> emojisFiltered = Utils.GetRandomPoggersEmoji(emojis);
            Random rnd = new Random();
            var emoji = emojisFiltered[rnd.Next(emojisFiltered.Count)];

            if (subparams1 != null)
            {
                switch (subparams1.ToLower())
                {
                    case "demo":
                        //Bring up a version of the put command
                        await ctx.RespondAsync("Here are the demo embed messages");
                        string announcerMessage = specificGuild.AnnounceFormatDesc;
                        string finalannouncerMessage = announcerMessage.Replace("{guildname}", ctx.Guild.Name);

                        string announceTitle = specificGuild.AnnounceFormatBot;
                        string finalAnnouncerTitle = announceTitle.Replace("{bot}", ctx.Client.CurrentUser.Username);
                        DiscordEmbed embedMessageUser = JosephineEmbedBuilder.CreateEmbedMessage(ctx, finalAnnouncerTitle, finalannouncerMessage);
                        await ctx.RespondAsync("", false, embedMessageUser);

                        string announceTitleUser = specificGuild.AnnounceFormatUser;
                        string finalAnnouncerTitleUser = announceTitleUser.Replace("{user}", ctx.Member.Username);
                        DiscordEmbed embedMessageBot = JosephineEmbedBuilder.CreateEmbedMessage(ctx, finalAnnouncerTitleUser, finalannouncerMessage);
                        await ctx.RespondAsync("", false, embedMessageBot);
                        break;
                    case "set":
                        if (subparams2 != null)
                        {
                            switch (subparams2.ToLower())
                            {
                                case "user":
                                    //Set the user join message
                                    if (otherargs != null ? !otherargs.Contains(string.Empty) : false)
                                    {
                                        specificGuild.AnnounceFormatUser = otherargs;
                                        await ctx.RespondAsync("Changed the announcer message for the user. TO see what it looks like try ';;announce demo'");
                                    }
                                    else
                                    {
                                        await ctx.RespondAsync("No message was defined!");
                                    }
                                    break;
                                case "bot":
                                    if (otherargs != null ? !otherargs.Contains(string.Empty) : false)
                                    {
                                        specificGuild.AnnounceFormatBot = otherargs;
                                        await ctx.RespondAsync("Changed the announcer message for the bot. To see what it looks like try ';;announce demo'");
                                    }
                                    else
                                    {
                                        await ctx.RespondAsync("No message was defined!");
                                    }
                                    break;
                                case "description":
                                    if (otherargs != null ? !otherargs.Contains(string.Empty) : false)
                                    {
                                        specificGuild.AnnounceFormatDesc = otherargs;
                                        await ctx.RespondAsync("Changed the description message for the bot. To see what it looks like try ';;announce demo'");
                                    }
                                    else
                                    {
                                        await ctx.RespondAsync("No message was defined!");
                                    }
                                    break;
                                case "tips":
                                    Dictionary<string, string> titles = new System.Collections.Generic.Dictionary<string, string>();
                                    titles.Add("{bot}", "To display the name of the bot joining the server.");
                                    titles.Add("{guildname}", "To display the name of the guild.");
                                    titles.Add("{user}", "To display the name of the user joining the server");
                                    DiscordEmbed embedMessageBotM = JosephineEmbedBuilder.CreateEmbedMessage(ctx, "Tips", "Here are some tips for your messages", JosephineBot.BotName, JosephineBot.defaultColor, titles);
                                    await ctx.RespondAsync("", false, embedMessageBotM);
                                    break;
                                default:
                                case "help":
                                    await runHelpSet(ctx, subparams2);
                                    break;
                            }
                        }
                        else
                        {
                            await runHelpSet(ctx, subparams2);
                        }
                        break;
                    case "off":
                        if (specificGuild.announceJoin == false)
                        {
                            await ctx.RespondAsync("Announcer is already off run the on sub-command");
                        }
                        else
                        {
                            specificGuild.announceJoin = false;
                            await ctx.Message.CreateReactionAsync(emoji);
                        }
                        break;
                    case "on":
                        if (specificGuild.announceJoin == true)
                        {
                            await ctx.RespondAsync("Announcer is already on run the off sub-command");
                        }
                        else
                        {
                            specificGuild.announceJoin = true;
                            await ctx.Message.CreateReactionAsync(emoji);
                        }
                        break;
                    default:
                    case "help":
                        await runHelp(ctx);
                        break;
                }
            }
            else
            {
                await runHelp(ctx);
            }
        }

        public async Task runHelp(CommandContext ctx)
        {
            Dictionary<string, string> argumentsHelp = new System.Collections.Generic.Dictionary<string, string>();
            argumentsHelp.Add(";;announce demo", "shows the greeting messages for the user and the bots on this server");
            argumentsHelp.Add(";;announce set", "utility to set the greeting messages on this server");
            argumentsHelp.Add(";;announce off", "turns the announcer off");
            argumentsHelp.Add(";;announce on", "turns the announcer on");
            DiscordEmbed embedHelp = JosephineEmbedBuilder.CreateEmbedMessage(ctx, "Sub-Commands", "for ';;announce set'", null, JosephineBot.defaultColor, argumentsHelp);
            await ctx.RespondAsync("Go to http://discord.rickasheye.xyz/ for all sub-commands", false, embedHelp);
        }

        public async Task runHelpSet(CommandContext ctx, string subparams2)
        {
            if (subparams2 != null && !subparams2.ToLower().Contains("help"))
            {
                await ctx.RespondAsync("Unable to change as there is either an incorrect command argument(s) or no arguments at all!");
            }
            Dictionary<string, string> arguments = new System.Collections.Generic.Dictionary<string, string>();
            arguments.Add(";;announce set user <message>", "sets the user greeting (use {user} to be replaced with thier username)");
            arguments.Add(";;announce set bot <message>", "sets the bot greeting (use {bot} to be replaced with the bot username)");
            arguments.Add(";;announce set description <message>", "sets the greeting for both messages (use {guildname} to be replaced with the guild name)");
            arguments.Add(";;announce set tips", "gives the user tips on info on how to use this function");
            DiscordEmbed embed = JosephineEmbedBuilder.CreateEmbedMessage(ctx, "Sub-Commands", "for ';;announce set'", null, JosephineBot.defaultColor, arguments);
            await ctx.RespondAsync("Go to http://discord.rickasheye.xyz/ for all sub-commands", false, embed);
        }
    }
}
