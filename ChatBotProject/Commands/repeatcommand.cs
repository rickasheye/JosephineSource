using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject.Commands
{
    public class repeatcommand : CommandModule
    {
        [Command("repeat")] // let's define this method as a command
        [Description("Repeats the command given with a multiple of times")] // this will be displayed to tell users what this command does when they invoke help
        [Aliases("rp")] // alternative names for the command
        public async Task Repeat(CommandContext ctx, params string[] args) // this command takes no arguments
        {
            await base.OperateCommand(ctx);
            //repeat the command
            int beggingArgument = int.Parse(args[0]);
            string command = args[1];
        }
    }
}
