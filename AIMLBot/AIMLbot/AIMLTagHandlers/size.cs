using System;
using System.Xml;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x02000024 RID: 36
	public class size : AIMLTagHandler
	{
		// Token: 0x0600006E RID: 110 RVA: 0x00004B1A File Offset: 0x00003B1A
		public size(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00004B2B File Offset: 0x00003B2B
		protected override string ProcessChange()
		{
			if (this.templateNode.Name.ToLower() == "size")
			{
				return Convert.ToString(this.bot.Size);
			}
			return string.Empty;
		}
	}
}
