using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject
{
    public class channelcommand : CommandModule
    {
        [Command("channel"), Description("Gets the channel stastics.")]
        public async Task channel(CommandContext ctx) // this command takes no arguments
        {
            await base.OperateCommand(ctx);
            //return the channel name if the args are null otherwise return with a result of changing the channel name
            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields.Add("ID", ctx.Message.Channel.Id.ToString());
            fields.Add("Topic", ctx.Message.Channel.Topic);
            fields.Add("Type", ctx.Message.Channel.Type.ToString());
            fields.Add("UserLimit", ctx.Message.Channel.UserLimit.ToString());
            fields.Add("Position", ctx.Message.Channel.Position.ToString());
            fields.Add("IsPrivate", ctx.Message.Channel.IsPrivate.ToString());
            fields.Add("IsNSFW", ctx.Message.Channel.IsNSFW.ToString());
            DiscordEmbed embed = JosephineEmbedBuilder.CreateEmbedMessage(ctx, "Channel Status", "The Stats of this Channel", null, JosephineBot.defaultColor, fields, true);
            await ctx.Channel.SendMessageAsync("", false, embed);
        }
    }
}
