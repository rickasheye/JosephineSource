using System;
using System.Xml;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x0200001C RID: 28
	public class javascript : AIMLTagHandler
	{
		// Token: 0x06000053 RID: 83 RVA: 0x00003AE4 File Offset: 0x00002AE4
		public javascript(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00003AF5 File Offset: 0x00002AF5
		protected override string ProcessChange()
		{
			this.bot.writeToLog("The javascript tag is not implemented in this bot");
			return string.Empty;
		}
	}
}
