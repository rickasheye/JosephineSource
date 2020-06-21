using System;
using System.Xml;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x0200002E RID: 46
	public class gossip : AIMLTagHandler
	{
		// Token: 0x0600009F RID: 159 RVA: 0x0000674B File Offset: 0x0000574B
		public gossip(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000675C File Offset: 0x0000575C
		protected override string ProcessChange()
		{
			if (this.templateNode.Name.ToLower() == "gossip" && this.templateNode.InnerText.Length > 0)
			{
				this.bot.writeToLog(string.Concat(new string[]
				{
					"GOSSIP from user: ",
					this.user.UserID,
					", '",
					this.templateNode.InnerText,
					"'"
				}));
			}
			return string.Empty;
		}
	}
}
