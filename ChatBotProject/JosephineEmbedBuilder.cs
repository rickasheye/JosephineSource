using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject
{
    public class JosephineEmbedBuilder
    {

        public static DiscordEmbed CreateEmbedMessage(CommandContext ctx, string title, string description, string author, DiscordColor color, Dictionary<string, string> fields, bool inline)
        {
            Console.WriteLine("Hit");
            var embed = new DiscordEmbedBuilder
            {
                Color = color,
                Title = title,
                Description = description,
                Timestamp = DateTime.UtcNow
            };
            Console.WriteLine("Created embed");
            if (fields != null)
            {
                foreach (KeyValuePair<string, string> val in fields)
                {
                    if (val.Value != string.Empty)
                    {
                        Console.WriteLine("Created instance");
                        embed.AddField(val.Value, val.Key, inline);
                        Console.WriteLine("Add Instance");
                    }
                } 
            }
            Console.WriteLine("Added fields");
            if (ctx != null) { embed.WithFooter(ctx.Client.CurrentUser.Username, ctx.Client.CurrentUser.AvatarUrl); }
            if (author != null) { embed.WithAuthor(author); }
            Console.WriteLine("Finished");
            return embed.Build();
        }

        public static DiscordEmbed CreateEmbedMessage(CommandContext ctx, string title, string description, string author, DiscordColor color, Dictionary<string, string> fields)
        {
            return CreateEmbedMessage(ctx, title, description, author, color, fields, false);
        }

        public static DiscordEmbed CreateEmbedMessage(CommandContext ctx, string title, string description, string author, DiscordColor color)
        {
            return CreateEmbedMessage(ctx, title, description, author, color, null, false);
        }

        public static DiscordEmbed CreateEmbedMessage(CommandContext ctx, string title, string description, string author)
        {
            return CreateEmbedMessage(ctx, title, description, author, JosephineBot.defaultColor);
        }

        public static DiscordEmbed CreateEmbedMessage(CommandContext ctx, string title, string description)
        {
            return CreateEmbedMessage(ctx, title, description, null);
        }

        public static DiscordEmbed CreateEmbedMessage(DiscordClient ctx, string title, string description, string author, DiscordColor color, Dictionary<string, string> fields, bool inline)
        {
            Console.WriteLine("Hit");
            var embed = new DiscordEmbedBuilder
            {
                Color = color,
                Title = title,
                Description = description,
                Timestamp = DateTime.UtcNow
            };
            Console.WriteLine("Created embed");
            if (fields != null)
            {
                foreach (KeyValuePair<string, string> val in fields)
                {
                    if (val.Value != string.Empty)
                    {
                        Console.WriteLine("Created instance");
                        embed.AddField(val.Value, val.Key, inline);
                        Console.WriteLine("Add Instance");
                    }
                } 
            }
            Console.WriteLine("Added fields");
            if (ctx != null) { embed.WithFooter(ctx.CurrentUser.Username, ctx.CurrentUser.AvatarUrl); }
            if (author != null) { embed.WithAuthor(author); }
            Console.WriteLine("Finished");
            return embed.Build();
        }

        public static DiscordEmbed CreateEmbedMessage(DiscordClient ctx, string title, string description, string author, DiscordColor color, Dictionary<string, string> fields)
        {
            return CreateEmbedMessage(ctx, title, description, author, color, fields, false);
        }

        public static DiscordEmbed CreateEmbedMessage(DiscordClient ctx, string title, string description, string author, DiscordColor color)
        {
            return CreateEmbedMessage(ctx, title, description, author, color, null, false);
        }

        public static DiscordEmbed CreateEmbedMessage(DiscordClient ctx, string title, string description, string author)
        {
            return CreateEmbedMessage(ctx, title, description, author, JosephineBot.defaultColor);
        }

        public static DiscordEmbed CreateEmbedMessage(DiscordClient ctx, string title, string description)
        {
            return CreateEmbedMessage(ctx, title, description, null);
        }
    }
}
