using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis.TtsEngine;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatBotProject
{
    public class CommandModule : BaseCommandModule
    {
        public static ConcurrentDictionary<ulong, string> PrefixSettings { get; } = new ConcurrentDictionary<ulong, string>();
        //public List<Permissions> permissionsAvaliable = new List<Permissions>();

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
            //Maybe check for pre-execution checks
            await ctx.TriggerTypingAsync();
        }
    }
}
