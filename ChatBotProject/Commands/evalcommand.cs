using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace ChatBotProject.Commands
{
    public class evalcommand : CommandModule
    {
        [Command("evalcs")] // let's define this method as a command
        [Aliases("eval", "csval", "roslyn")]
        [Description("Evaluates C# code.")] // this will be displayed to tell users what this command does when they invoke help
        [Hidden]
        [RequireOwner]
        public async Task EvalCS(CommandContext ctx, [RemainingText] string code) // this command takes no arguments
        {
            await base.OperateCommand(ctx);
            var msg = ctx.Message;

            var cs1 = code.IndexOf("```") + 3;
            cs1 = code.IndexOf('\n', cs1) + 1;
            var cs2 = code.LastIndexOf("```");

            if (cs1 == -1 || cs2 == -1)
                throw new ArgumentException("You need to wrap the code into a code block.");

            var cs = code.Substring(cs1, cs2 - cs1);

            DiscordEmbed embed = JosephineEmbedBuilder.CreateEmbedMessage(ctx, null, "Evaluating...");
            msg = await ctx.RespondAsync("", false, embed).ConfigureAwait(false);

            try
            {
                var globals = new TestVariables(ctx.Message, ctx.Client, ctx);

                var sopts = ScriptOptions.Default;
                sopts = sopts.WithImports("System", "System.Collections.Generic", "System.Linq", "System.Text", "System.Threading.Tasks", "DSharpPlus", "DSharpPlus.CommandsNext", "DSharpPlus.Interactivity");
                sopts = sopts.WithReferences(AppDomain.CurrentDomain.GetAssemblies().Where(xa => !xa.IsDynamic && !string.IsNullOrWhiteSpace(xa.Location)));

                var script = CSharpScript.Create(cs, sopts, typeof(TestVariables));
                script.Compile();
                var result = await script.RunAsync(globals).ConfigureAwait(false);

                if (result != null && result.ReturnValue != null && !string.IsNullOrWhiteSpace(result.ReturnValue.ToString()))
                {
                    DiscordEmbed embedError0 = JosephineEmbedBuilder.CreateEmbedMessage(ctx, "Evaluation Result", result.ReturnValue.ToString(), null, new DiscordColor("#007FFF"));
                    await msg.ModifyAsync(embed: embedError0).ConfigureAwait(false);
                }
                else
                {
                    DiscordEmbed embedError1 = JosephineEmbedBuilder.CreateEmbedMessage(ctx, "Evaluation Successful", "No result was returned.", null, new DiscordColor("#007FFF"));
                    await msg.ModifyAsync(embed: embedError1).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                DiscordEmbed embedError0 = JosephineEmbedBuilder.CreateEmbedMessage(ctx, "Evaluation Failure", string.Concat("**", ex.GetType().ToString(), "**: ", ex.Message), null, new DiscordColor("#FF0000"));
                await msg.ModifyAsync(embed: embedError0).ConfigureAwait(false);
            }
        }
    }

    public class TestVariables
    {
        public DiscordMessage Message { get; set; }
        public DiscordChannel Channel { get; set; }
        public DiscordGuild Guild { get; set; }
        public DiscordUser User { get; set; }
        public DiscordMember Member { get; set; }
        public CommandContext Context { get; set; }

        public TestVariables(DiscordMessage msg, DiscordClient client, CommandContext ctx)
        {
            this.Client = client;

            this.Message = msg;
            this.Channel = msg.Channel;
            this.Guild = this.Channel.Guild;
            this.User = this.Message.Author;
            if (this.Guild != null)
                this.Member = this.Guild.GetMemberAsync(this.User.Id).ConfigureAwait(false).GetAwaiter().GetResult();
            this.Context = ctx;
        }

        public DiscordClient Client;
    }
}
