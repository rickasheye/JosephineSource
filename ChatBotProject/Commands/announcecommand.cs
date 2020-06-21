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

namespace ChatBotProject
{
    public class announcecommand : CommandModule
    {
        [Command("announce")] // let's define this method as a command
        [Description("Manage the announcer everytime someone joins")] // this will be displayed to tell users what this command does when they invoke help
        public override async Task OperateCommand(CommandContext ctx, params string[] args) // this command takes no arguments
        {
            await base.OperateCommand(ctx);
            string argumentType = args[0];
            guildData specificGuild = Utils.returnGuildData(ctx.Guild.Id);

            List<DiscordEmoji> emojis = new List<DiscordEmoji>();
            emojis.Add(DiscordEmoji.FromName(ctx.Client, ":100:"));
            emojis.Add(DiscordEmoji.FromName(ctx.Client, ":ok_hand:"));
            List<DiscordEmoji> emojisFiltered = Utils.GetRandomPoggersEmoji(emojis);
            Random rnd = new Random();
            var emoji = emojisFiltered[rnd.Next(emojisFiltered.Count)];

            if (args.Length > 0)
            {
                switch (argumentType.ToLower())
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
                        switch (args[1].ToLower())
                        {
                            case "user":
                                //Set the user join message
                                if (args[2] != null || !args[2].Contains(string.Empty))
                                {
                                    //string afterwardsMessage = string.Join()
                                    specificGuild.AnnounceFormatUser = string.Join(" ", args).Substring(args[1].Length + args[2].Length);
                                    await ctx.RespondAsync("Changed the announcer message for the user. TO see what it looks like try ';;announce demo'");
                                }
                                else
                                {
                                    await ctx.RespondAsync("No message was defined!");
                                }
                                break;
                            case "bot":
                                if (args[2] != null || !args[2].Contains(string.Empty))
                                {
                                    specificGuild.AnnounceFormatBot = string.Join(" ", args).Substring(args[1].Length + args[2].Length);
                                    await ctx.RespondAsync("Changed the announcer message for the bot. To see what it looks like try ';;announce demo'");
                                }
                                else
                                {
                                    await ctx.RespondAsync("No message was defined!");
                                }
                                break;
                            case "description":
                                if (args[2] != null || !args[2].Contains(string.Empty))
                                {
                                    specificGuild.AnnounceFormatDesc = string.Join(" ", args).Substring(args[1].Length + args[2].Length);
                                    await ctx.RespondAsync("Changed the description message for the bot. To see what it looks like try ';;announce demo'");
                                }
                                else
                                {
                                    await ctx.RespondAsync("No message was defined!");
                                }
                                break;
                            default:
                            case "help":
                                if (!args[1].ToLower().Contains("help"))
                                {
                                    await ctx.RespondAsync("Unable to change as there is either an incorrect command argument(s) or no arguments at all!");
                                }
                                Dictionary<string, string> arguments = new System.Collections.Generic.Dictionary<string, string>();
                                arguments.Add(";;announce set user <message>", "sets the user greeting (use {user} to be replaced with thier username)");
                                arguments.Add(";;announce set bot <message>", "sets the bot greeting (use {bot} to be replaced with the bot username)");
                                arguments.Add(";;announce set description <message>", "sets the greeting for both messages (use {guildname} to be replaced with the guild name)");
                                DiscordEmbed embed = JosephineEmbedBuilder.CreateEmbedMessage(ctx, "Sub-Commands", "for ';;announce set'", null, JosephineBot.defaultColor, arguments);
                                await ctx.RespondAsync("Go to http://discord.rickasheye.xyz/ for all sub-commands", false, embed);
                                break;
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
            } else
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
    }
}
