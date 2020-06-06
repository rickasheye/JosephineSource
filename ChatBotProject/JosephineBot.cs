using System;
using System.Windows.Forms;
using System.IO; // needed for filing
using DSharpPlus;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using DSharpPlus.EventArgs;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Exceptions;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Linq;
using System.Diagnostics;
using DSharpPlus.VoiceNext;
using Microsoft.Extensions.DependencyInjection;
using ChatBotProject.Misc;
using ChatBotProject.Misc.ZombieDemoGame;
using ChatBotProject.Misc.LevelUp;
using ChatBotProject.Misc.SnailRaceDemoGame;

namespace ChatBotProject
{
    internal sealed class JosephineBot
    {
        ChatBot bot;
        public static JosephineConfig Config { get; set; }
        public DiscordClient Discord { get; }
        private pingcommand Commands { get; }
        private CommandsNextExtension CommandsNextService { get; }
        private Timer GameGuard { get; set; }
        public static string BotName = "Josephine";
        public static bool debugMode = true;
        public static List<guildData> data = new List<guildData>();
        public static List<UserData> saveData = new List<UserData>();
        public static VoiceNextExtension VoiceService;
        public static DiscordColor defaultColor;

        public static string BUILDID = "0.2B";

        public JosephineBot(JosephineConfig cfg, int shardid)
        {
            Updater update = new Updater();
            Config = cfg;

            var dcfg = new DiscordConfiguration
            {
                AutoReconnect = true,
                LargeThreshold = 250,
                LogLevel = LogLevel.Debug,
                Token = Config.Token,
                TokenType = TokenType.Bot,
                UseInternalLogHandler = false,
                ShardId = shardid,
                ShardCount = Config.ShardCount,
                MessageCacheSize = 2048,
                DateTimeFormat = "dd-MM-yyyy HH:mm:ss zzz"
            };

            debugMode = Config.debug;
            Discord = new DiscordClient(dcfg);

            Discord.DebugLogger.LogMessageReceived += this.DebugLogger_LogMessageRecieved;
            Discord.Ready += this.Client_Ready;
            Discord.ClientErrored += this.Client_ClientError;
            Discord.GuildUpdated += this.Discord_GuildUpdated;
            Discord.ChannelDeleted += this.Discord_ChannelDeleted;
            Discord.MessageCreated += this.Client_Chat;
            Discord.MessageUpdated += this.MessageUpdated;
            //Discord.GuildMemberAdded += this.Join_Chat;

            var vcfg = new VoiceNextConfiguration
            {
                AudioFormat = AudioFormat.Default,
                EnableIncoming = true
            };
            VoiceService = Discord.UseVoiceNext(vcfg);

            var depco = new ServiceCollection();

            // commandsnext config and the commandsnext service itself
            var cncfg = new CommandsNextConfiguration
            {
                StringPrefixes = Config.CommandPrefixes,
                EnableDms = false,
                EnableMentionPrefix = true,
                CaseSensitive = false,
                Services = depco.BuildServiceProvider(true),
                IgnoreExtraArguments = false,
                UseDefaultCommandHandler = true,
            };
            this.CommandsNextService = Discord.UseCommandsNext(cncfg);
            this.CommandsNextService.CommandErrored += this.CommandsNextService_CommandErrored;
            this.CommandsNextService.CommandExecuted += this.Commands_CommandExecuted;
            this.CommandsNextService.RegisterCommands(typeof(JosephineBot).GetTypeInfo().Assembly);
            this.CommandsNextService.SetHelpFormatter<HelpFormatter>();
        }

        public async Task MessageUpdated(MessageUpdateEventArgs e)
        {
            //When the chat update has been called!
            foreach(Game m in games)
            {
                m.UpdateEditChatGame(e);
            }
        }

        public async Task RunAsync()
        {
            var act = new DiscordActivity("the screams of your ancestors", ActivityType.ListeningTo);
            await Discord.ConnectAsync(act, UserStatus.DoNotDisturb).ConfigureAwait(false);
        }

        public async Task StopAsync()
        {
            Debug.Warning("Stopping Server!!!", Discord);
            if (games != null)
            {
                foreach (Game m in games)
                {
                    m.DestroyGame();
                } 
            }
            Debug.Warning("Writing log file", Discord);
            File.WriteAllLines(Path.Combine(Directory.GetCurrentDirectory(), "log"), logFile.ToArray());
            await Discord.DisconnectAsync().ConfigureAwait(false);
        }

        private async Task Join_Chat(object sender, GuildMemberAddEventArgs e)
        {
            guildData specificGuild = Utils.returnGuildData(e.Guild.Id);
            //When joined the chat add an embed message
            if (specificGuild.announceJoin)
            {
                string announcerMessage = specificGuild.AnnounceFormatDesc;
                string finalannouncerMessage = announcerMessage.Replace("{guildname}", e.Guild.Name);
                if (e.Member.IsBot)
                {
                    string announceTitle = specificGuild.AnnounceFormatBot;
                    string finalAnnouncerTitle = announceTitle.Replace("{bot}", e.Member.Username);
                    JosephineEmbedBuilder.CreateEmbedMessage(Discord, finalAnnouncerTitle, finalannouncerMessage);
                }else if (!e.Member.IsBot)
                {
                    string announceTitle = specificGuild.AnnounceFormatUser;
                    string finalAnnouncerTitle = announceTitle.Replace("{user}", e.Member.Username);
                    JosephineEmbedBuilder.CreateEmbedMessage(Discord, finalAnnouncerTitle, finalannouncerMessage);
                }
            }
        }

        public List<string> logFile = new List<string>();

        private void DebugLogger_LogMessageRecieved(object sender, DebugLogMessageEventArgs e)
        {
            switch (e.Level)
            {
                case LogLevel.Critical:
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case LogLevel.Info:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;

                case LogLevel.Debug:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
            }
            Console.Write("[{0:yyyy-MM-dd HH:mm:ss zzz}] ", e.Timestamp.ToLocalTime());

            var tag = e.Application;
            if (tag.Length > 12)
                tag = tag.Substring(0, 12);
            if (tag.Length < 12)
                tag = tag.PadLeft(12, ' ');
            Console.Write("[{0}] ", tag);

            Console.Write("[{0}] ", string.Concat("SHARD ", this.Discord.ShardId.ToString("00")));

            Console.Write("[{0}] ", e.Level.ToString().PadLeft(8));

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(e.Message);
            logFile.Add(e.Message);
        }

        private async Task CommandsNextService_CommandErrored(CommandErrorEventArgs e)
        {
            if (e.Exception is CommandNotFoundException && (e.Command == null || e.Command.QualifiedName != "help"))
                return;

            Discord.DebugLogger.LogMessage(LogLevel.Error, BotName, $"An exception occured during {e.Context.User.Username}'s invocation of '{e.Context.Command.QualifiedName}': {e.Exception.GetType()}", DateTime.Now.Date, e.Exception);

            var exs = new List<Exception>();
            if (e.Exception is AggregateException ae)
                exs.AddRange(ae.InnerExceptions);
            else
                exs.Add(e.Exception);

            foreach (var ex in exs)
            {
                if (ex is CommandNotFoundException && (e.Command == null || e.Command.QualifiedName != "help"))
                    return;

                var embed = new DiscordEmbedBuilder
                {
                    Color = new DiscordColor("#FF0000"),
                    Title = "An exception occured when executing a command",
                    Description = $"`{e.Exception.GetType()}` occured when executing `{e.Command.QualifiedName}`.",
                    Timestamp = DateTime.UtcNow
                };
                embed.WithFooter(Discord.CurrentUser.Username, Discord.CurrentUser.AvatarUrl)
                    .AddField("Message", ex.Message);
                await e.Context.RespondAsync(embed: embed.Build());
            }
        }

        private string showOutput(string message)
        {
            string replyMessage = null;
            if (!(string.IsNullOrWhiteSpace(message))) // Make sure the textbox isnt empty
            {
                // Store the Bot's Output by giving it our input.
                string outtt = bot.getOutput(message);
                replyMessage = outtt;

                //=========== Creates backup of chat from user and bot to the given location ============
                FileStream fs = new FileStream(@"chat.log", FileMode.Append, FileAccess.Write);
                if (fs.CanWrite)
                {
                    byte[] write = System.Text.Encoding.ASCII.GetBytes(message + Environment.NewLine + outtt + Environment.NewLine);
                    fs.Write(write, 0, write.Length);
                }
                fs.Flush();
                fs.Close();
            }
            return replyMessage;
        }

        private Task Commands_CommandExecuted(CommandExecutionEventArgs e)
        {
            if(debugMode == true)
            {
                if(e.Context.Guild.Id == ulong.Parse(Config.DebugGuildID))
                {
                    //e.Context.RespondAsync("Commands are disabled");
                    return Task.CompletedTask;
                }
            }
            // let's log the name of the command and user
            e.Context.Client.DebugLogger.LogMessage(LogLevel.Info, BotName, $"{e.Context.User.Username} successfully executed '{e.Command.QualifiedName}'", DateTime.Now);
            return Task.CompletedTask;
        }

        private Task Discord_GuildUpdated(GuildUpdateEventArgs e)
        {
            var str = new StringBuilder();

            str.AppendLine($"The guild {e.GuildBefore.Name} has been updated.");

            foreach (var prop in typeof(DiscordGuild).GetProperties())
            {
                try
                {
                    var bfr = prop.GetValue(e.GuildBefore);
                    var aft = prop.GetValue(e.GuildAfter);

                    if (bfr is null)
                    {
                        Discord.DebugLogger.LogMessage(LogLevel.Debug, "GuildUpdated", $"Property {prop.Name} in before was null.", DateTime.Now);
                    }

                    if (aft is null)
                    {
                        Discord.DebugLogger.LogMessage(LogLevel.Debug, "GuildUpdated", $"Property {prop.Name} in after was null.", DateTime.Now);
                    }

                    if (bfr is null || aft is null)
                    {
                        continue;
                    }

                    if (bfr.ToString() == aft.ToString())
                    {
                        continue;
                    }

                    str.AppendLine($" - {prop.Name}: `{bfr}` to `{aft}`");
                }
                catch (Exception ex)
                {
                    Discord.DebugLogger.LogMessage(LogLevel.Debug, "GuildUpdated", $"An exception occurred: {ex.GetType()}", DateTime.Now, ex);
                }
            }

            str.AppendLine($" - VoiceRegion: `{e.GuildBefore.VoiceRegion?.Name}` to `{e.GuildAfter.VoiceRegion?.Name}`");

            Console.WriteLine(str);

            return Task.CompletedTask;
        }

        private async Task Discord_ChannelDeleted(ChannelDeleteEventArgs e)
        {
            var logs = (await e.Guild.GetAuditLogsAsync(5, null, AuditLogActionType.ChannelDelete).ConfigureAwait(false)).Cast<DiscordAuditLogChannelEntry>();
            foreach (var entry in logs)
            {
                Debug.Log("TargetId: " + entry.Target.Id, Discord);
            }

            //Check through the guild entries and make sure that theres no deleted recorded adresses
            foreach(guildData dataEntries in data)
            {
                ulong guildID = dataEntries.guildId;
                DiscordGuild guild = await Discord.GetGuildAsync(guildID);
                DiscordChannel channel = await Discord.GetChannelAsync(dataEntries.disabledChannelID);
                if(channel == null || dataEntries.disabledChannelID == 0)
                {
                    dataEntries.disabledChannelID = 0;
                }
            }
        }

        public static List<Game> games = new List<Game>();
        private async Task Client_Ready(ReadyEventArgs e)
        {
            if (debugMode == true)
            {
                Console.WriteLine("Debug Mode initiated");
                DiscordActivity game = new DiscordActivity("DEBUG MODE");
                await Discord.UpdateStatusAsync(game, UserStatus.DoNotDisturb);
            }
            else
            {
                Console.WriteLine("Non-Debug mode!");
                DiscordActivity game = new DiscordActivity("READY");
                await Discord.UpdateStatusAsync(game, UserStatus.Online);
            }

            //Check the guilds to make sure they've recieved the latest update on the bot
            foreach (guildData entry in data)
            {
                DiscordGuild guild = await Discord.GetGuildAsync(entry.guildId);
                if(entry.buildLast != BUILDID)
                {
                    DiscordChannel channel = await Discord.GetChannelAsync(entry.disabledChannelID);
                    DiscordEmbed JosephineEmbed = JosephineEmbedBuilder.CreateEmbedMessage(Discord, "Bot update to " + BUILDID + "!", "This bot has been updated to check out the new features go to http://discord.rickasheye.xyz/");
                    await channel.SendMessageAsync("", false, JosephineEmbed);
                    entry.buildLast = BUILDID;
                }
            }

            //Start all the games
            //games.Add(new ZombieGame());
            //games.Add(new LevelUpGame());
            //games.Add(new SnailGame());

            if (games != null)
            {
                //Loading all the games
                foreach (Game game in games)
                {
                    game.InitialiseGame();
                } 
            }

            // let's log the fact that this event occured
            e.Client.DebugLogger.LogMessage(LogLevel.Info, BotName, "Client is ready to process events.", DateTime.Now);
        }

        public static bool use = false;
        public static ulong Channel = 0;

        public bool containPrefix(string[] prefixes, string text)
        {
            bool finalResult = false;
            foreach(string m in prefixes)
            {
                if (text.Contains(m))
                {
                    finalResult = true;
                }
            }
            return finalResult;
        }

        private Task Client_Chat(MessageCreateEventArgs e)
        {
            DSharpPlus.Entities.DiscordMessage content = e.Message;
            if (!e.Channel.IsPrivate)
            {
                guildData dataGet = data[Utils.retrieveGuild(e.Guild.Id)];
                use = dataGet.on;
                Channel = dataGet.disabledChannelID;
            }
            else
            {
                Channel = 0;
                use = true;
            }

            if (!containPrefix(Config.CommandPrefixes, content.Content))
            {
                if (!debugMode || e.Channel.IsPrivate ? true : e.Guild.Id == ulong.Parse(Config.DebugGuildID))
                {
                    if (use == true)
                    {
                        if (e.Author != Discord.CurrentUser)
                        {
                            if (e.Channel.Id == Channel || Channel == 0)
                            {
                                //Refresh all of the games
                                foreach(Game game in games)
                                {
                                    game.UpdateChatGame(e);
                                }
                                bot = new ChatBot(e.Message.Author.Username, null);
                                content.RespondAsync(showOutput(content.Content));
                                bot = null;
                            }
                        }
                    }
                    Debug.Log("Chat: " + content.Author + " : " + content.Content, Discord);
                } 
            }else if(containPrefix(Config.CommandPrefixes, content.Content) && e.Channel.IsPrivate)
            {
                content.RespondAsync("No commands are executable in private messaging!");
            }
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText("prefs.json", json);
            return Task.CompletedTask;
        }

        private Task Client_GuildAvailable(GuildCreateEventArgs e)
        {
            // let's log the name of the guild that was just
            // sent to our client
            e.Client.DebugLogger.LogMessage(LogLevel.Info, BotName, $"Guild available: {e.Guild.Name}", DateTime.Now);

            // since this method is not async, let's return
            // a completed task, so that no additional work
            // is done
            return Task.CompletedTask;
        }

        private Task Client_ClientError(ClientErrorEventArgs e)
        {
            // let's log the details of the error that just 
            // occured in our client
            e.Client.DebugLogger.LogMessage(LogLevel.Error, BotName, $"Exception occured: {e.Exception.GetType()}: {e.Exception.Message}", DateTime.Now);

            // since this method is not async, let's return
            // a completed task, so that no additional work
            // is done
            return Task.CompletedTask;
        }
    }
}