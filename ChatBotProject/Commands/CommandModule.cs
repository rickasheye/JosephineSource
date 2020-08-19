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
            foreach(CheckBaseAttribute cattr in ctx.Command.ExecutionChecks)
            {
                if(await cattr.ExecuteCheckAsync(ctx, false))
                {
                    //Not executed from help
                    Debug.Log("Not executed from help!");
                }
                else
                {
                    Debug.Log("FALSE!!!");
                }
            }
            //Check the permissions before executing other wise pull an error for no permissions!
            List<DiscordRole> roles = new List<DiscordRole>();
            roles.AddRange(ctx.Guild.GetMemberAsync(ctx.User.Id).Result.Roles);

            RequireBotPermissionsAttribute attr = null;
            foreach(Attribute bute in ctx.Command.CustomAttributes)
            {
                var perm = (RequireBotPermissionsAttribute)bute;
                if(perm != null)
                {
                    attr = perm;
                }
                else
                {
                    Debug.Log("This is not a RequireBotPermissionsAttr or this command doesnt have any!");
                }
            }

            if (HasPermissions(roles, attr.Permissions))
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
            else
            {
                await ctx.RespondAsync("I require a permission called " + attr.Permissions.ToPermissionString());
                await Task.CompletedTask;
            }
        }

        //Really i did not know how to interpret the inclusion of permissions control on this bot!!!

        public bool HasPermissions(List<DiscordRole> roles, Permissions permission)
        {
            bool newPermissions = false;
            foreach(DiscordRole role in roles)
            {
                if(permission == role.Permissions)
                {
                    newPermissions = true;
                }
            }
            return newPermissions;
        }
    }
}
