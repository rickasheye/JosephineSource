using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject.Misc
{
    public class Achievement
    {
        //Stores all kind of achievement data
        public string name = "Unnamed Achievement";
        public string description = "No Description Found!";

        public Achievement(string chosenName, string chosenDescription)
        {
            name = chosenName;
            description = chosenDescription;
        }

        public async virtual Task executeAchievement(CommandContext ctx)
        {
            DiscordEmbed embed = JosephineEmbedBuilder.CreateEmbedMessage(ctx, name, description);
            await ctx.Message.RespondAsync("", false, embed);
        }
    }
}
