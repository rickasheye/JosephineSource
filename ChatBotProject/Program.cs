using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIMLbot;
using Newtonsoft.Json;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using DSharpPlus.EventArgs;
using DSharpPlus;

namespace ChatBotProject
{
    class Program
    {
        public static CancellationTokenSource CancelTokenSource { get; } = new CancellationTokenSource();
        private static CancellationToken CancelToken => CancelTokenSource.Token;
        private static List<JosephineBot> Shards { get; } = new List<JosephineBot>();

        public static void Main(string[] args)
            => MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();

        public static async Task MainAsync(string[] args)
        {
            Console.CancelKeyPress += Console_CancelKeyPress;

            Console.WriteLine("Configuring");
            Console.WriteLine("Checking the config file!");
            var cfg = new JosephineConfig();
            var json = string.Empty;
            if (!File.Exists("config.json"))
            {
                json = JsonConvert.SerializeObject(cfg);
                File.WriteAllText("config.json", json, new UTF8Encoding(false));
                Console.WriteLine("Config file was not found, a new one was generated. Fill it with proper values and rerun this program");
                Console.ReadKey();

                return;
            }

            Console.WriteLine("Checking the prefs file!");
            var savedConfig = string.Empty;
            List<guildData> dataSet = new List<guildData>();
            if (!File.Exists("prefs.json"))
            {
                savedConfig = JsonConvert.SerializeObject(dataSet);
                File.WriteAllText("prefs.json", savedConfig, new UTF8Encoding(false));
                Console.WriteLine("Written a new prefs file... as it didnt exist before");
            }

            Console.WriteLine("Loading the config file!");
            json = File.ReadAllText("config.json", new UTF8Encoding(false));
            cfg = JsonConvert.DeserializeObject<JosephineConfig>(json);

            Console.WriteLine("Loading the prefs file!");
            savedConfig = File.ReadAllText("prefs.json", new UTF8Encoding(false));
            JosephineBot.data = JsonConvert.DeserializeObject<List<guildData>>(savedConfig);

            Console.WriteLine("Checking user data!");
            var savedUsers = string.Empty;
            List<guildData> dataUser = new List<guildData>();
            if (!File.Exists("savedata.json"))
            {
                savedUsers = JsonConvert.SerializeObject(savedUsers);
                File.WriteAllText("savedata.json", savedUsers, new UTF8Encoding(false));
                Console.WriteLine("written a new savedata file... as it didnt exist before");
            }

            savedUsers = File.ReadAllText("savedata.json", new UTF8Encoding(false));
            JosephineBot.saveData = JsonConvert.DeserializeObject<List<UserData>>(savedUsers);

            Console.WriteLine("Configured!");

            var tskl = new List<Task>();
            for (var i = 0; i < cfg.ShardCount; i++)
            {
                var bot = new JosephineBot(cfg, i);
                Shards.Add(bot);
                tskl.Add(bot.RunAsync());
                await Task.Delay(7500).ConfigureAwait(false);
            }

            await Task.WhenAll(tskl).ConfigureAwait(false);

            try
            {
                await Task.Delay(-1, CancelToken).ConfigureAwait(false);
            }
            catch (Exception) { /* shush */ }
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;

            foreach (var shard in Shards)
                shard.StopAsync().GetAwaiter().GetResult(); // it dun matter

            CancelTokenSource.Cancel();
        }

        private void DebugLogger_LogMessageReceived(object sender, DebugLogMessageEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("[{0:yyyy-MM-dd HH:mm:ss zzz}] ", e.Timestamp.ToLocalTime());

            var tag = e.Application;
            if (tag.Length > 12)
                tag = tag.Substring(0, 12);
            if (tag.Length < 12)
                tag = tag.PadLeft(12, ' ');
            Console.Write("[{0}] ", tag);

            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.Write("[{0}] ", string.Concat("SHARD ", this.Discord.ShardId.ToString("00")));

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
            Console.Write("[{0}] ", e.Level.ToString().PadLeft(8));

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(e.Message);
        }
    }

    public class ChatBot
    {
        private User myUser;
        public Bot Aimlbot;

        public ChatBot(string UserId, Bot Bot)
        {
            if (Bot == null)
            {
                Aimlbot = new Bot();
            }
            else
            {
                Aimlbot = Bot;
            }
            myUser = new User(UserId, Aimlbot);
            Initialize();
        }

        // Loads all the AIML files in the \AIML folder         
        public void Initialize()
        {
            Aimlbot.loadSettings();
            Aimlbot.isAcceptingUserInput = false;
            Aimlbot.loadAIMLFromFiles();
            Aimlbot.isAcceptingUserInput = true;
        }

        // Given an input string, finds a response using AIMLbot lib
        public String getOutput(String input)
        {
            Request r = new Request(input, myUser, Aimlbot);
            Result res = Aimlbot.Chat(r);
            return (res.Output);
        }
    }
}
