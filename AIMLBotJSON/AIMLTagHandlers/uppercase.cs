using System;
using System.Xml;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x02000017 RID: 23
	public class uppercase : AIMLTagHandler
	{
		// Token: 0x06000045 RID: 69 RVA: 0x0000353A File Offset: 0x0000253A
		public uppercase(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x06000046 RID: 70 RVA: 0x0000354B File Offset: 0x0000254B
		protected override string ProcessChange()
		{
			if (this.templateNode.Name.ToLower() == "uppercase")
			{
				return this.templateNode.InnerText.ToUpper(this.bot.Locale);
			}
			return string.Empty;
		}
	}
}
