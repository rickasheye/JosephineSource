using System;
using System.Xml;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x0200000D RID: 13
	public class date : AIMLTagHandler
	{
		// Token: 0x0600002C RID: 44 RVA: 0x00002EC3 File Offset: 0x00001EC3
		public date(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002ED4 File Offset: 0x00001ED4
		protected override string ProcessChange()
		{
			if (this.templateNode.Name.ToLower() == "date")
			{
				return DateTime.Now.ToString(this.bot.Locale);
			}
			return string.Empty;
		}
	}
}
