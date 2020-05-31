using System;
using System.Xml;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x0200002B RID: 43
	public class system : AIMLTagHandler
	{
		// Token: 0x06000099 RID: 153 RVA: 0x000064C0 File Offset: 0x000054C0
		public system(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000064D1 File Offset: 0x000054D1
		protected override string ProcessChange()
		{
			this.bot.writeToLog("The system tag is not implemented in this bot");
			return string.Empty;
		}
	}
}
