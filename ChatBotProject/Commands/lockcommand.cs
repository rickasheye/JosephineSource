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
        public async Task Lock(CommandContext ctx, string channelName)
        {
            await base.OperateCommand(ctx);
            // note the params on the argument. It will indicate
            // that the command will capture all the remaining arguments
            // into a single array

            bool locked = false;

            if (channelName.Contains("#"))
            {
                channelName.Replace("#", string.Empty);
            }

            if (Utils.DiscordChannelExists(channelName, ctx.Guild))
            {
                if (!channelName.Contains(string.Empty) || !channelName.Contains(null))
                {
                    if (Utils.returnGuildData(ctx.Guild.Id).disabledChannelID != Utils.retrieveChannelID(channelName, ctx.Guild).Id)
                    {
                        Utils.setChannel(Utils.retrieveChannelID(channelName, ctx.Guild).Id, ctx.Guild.Id);
                        locked = true;
                    }
                    else
                    {
                        Utils.setChannel(Utils.retrieveChannelID(channelName, ctx.Guild).Id, 0);
                    }
                }

                // and send it to the user
                if (locked == true)
                {
                    await ctx.RespondAsync($"I have been locked to: #" + channelName);
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

        [Command("lock"), Description("Locks the bot to a single channel")]
        public async Task Lock(CommandContext ctx)
        {
            await base.OperateCommand(ctx);

            guildData data = Utils.returnGuildData(ctx.Guild.Id);
            if(data.disabledChannelID != 0)
            {
                await ctx.RespondAsync("The bot has been unlocked from this channel");
                Utils.setChannel(0, ctx.Guild.Id);
            }
            else
            {
                await ctx.RespondAsync("The bot has been locked to this channel");
                Utils.setChannel(ctx.Channel.Id, ctx.Guild.Id);
            }
        }
    }
}
