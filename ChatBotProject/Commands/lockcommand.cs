using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject
{
    public class lockcommand : CommandModule
    {
        [Command("lock"), Description("Locks the bot to a single channel")]
        public async Task Lock(CommandContext ctx, params string[] args)
        {
            await base.OperateCommand(ctx);
            // note the params on the argument. It will indicate
            // that the command will capture all the remaining arguments
            // into a single array

            bool locked = false;
            string argument = args[0];

            if (argument.Contains("#"))
            {
                argument.Replace("#", string.Empty);
            }

            if (Utils.DiscordChannelExists(argument, ctx.Guild))
            {
                if (argument.Contains("none") || argument.Contains("nothing") || argument == string.Empty || argument == null)
                {
                    Utils.setChannel(0, ctx.Guild.Id);
                    locked = false;
                }

                if (!argument.Contains("none") || !argument.Contains("nothing") || !argument.Contains(string.Empty) || !argument.Contains(null))
                {
                    if (argument != null)
                    {
                        Utils.setChannel(Utils.retrieveChannelID(argument, ctx.Guild).Id, ctx.Guild.Id);
                        locked = true;
                    }
                }

                // and send it to the user
                if (locked == true)
                {
                    await ctx.RespondAsync($"I have been locked to: #" + argument);
                }
                else if (locked == false && Utils.returnChannelLock(ctx.Guild.Id) == 0)
                {
                    await ctx.RespondAsync("I have been unlocked");
                }
                else
                {
                    await ctx.RespondAsync("Either no Channel has been entered or this code is wrong");
                }
            }
            else
            {
                await ctx.Message.RespondAsync("That channel doesnt exist!");
            }
        }
    }
}
