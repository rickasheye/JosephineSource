using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis.TtsEngine;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject
{
    public class CommandModule : BaseCommandModule
    {
        public static ConcurrentDictionary<ulong, string> PrefixSettings { get; } = new ConcurrentDictionary<ulong, string>();

        public async virtual Task OperateCommand(CommandContext ctx, params string[] args)
        {
            await GeneralTask(ctx, args);
        }

        public async virtual Task OperateCommand(CommandContext ctx)
        {
            await GeneralTask(ctx, null);
        }

        public async Task GeneralTask(CommandContext ctx, params string[] args)
        {
            if (!JosephineBot.debugMode || ctx.Guild.Id == ulong.Parse(JosephineBot.Config.DebugGuildID))
            {
                if (Utils.returnChannelLock(ctx.Guild.Id) == ctx.Channel.Id || Utils.returnChannelLock(ctx.Guild.Id) == 0)
                {
                    await ctx.TriggerTypingAsync();
                }
                else
                {
                    Console.WriteLine("User attempted to execute command while in a locked channel!");
                    await Task.CompletedTask;
                }
            }
            else
            {
                Console.WriteLine("Another command executed in the wrong guild!");
                await Task.CompletedTask;
            }
        }
    }
}
