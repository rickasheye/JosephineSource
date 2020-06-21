using System;
using System.Xml;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x0200001B RID: 27
	public class srai : AIMLTagHandler
	{
		// Token: 0x06000051 RID: 81 RVA: 0x00003A3C File Offset: 0x00002A3C
		public srai(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00003A50 File Offset: 0x00002A50
		protected override string ProcessChange()
		{
			if (this.templateNode.Name.ToLower() == "srai" && this.templateNode.InnerText.Length > 0)
			{
				Request request = new Request(this.templateNode.InnerText, this.user, this.bot);
				request.StartedOn = this.request.StartedOn;
				Result result = this.bot.Chat(request);
				this.request.hasTimedOut = request.hasTimedOut;
				return result.Output;
			}
			return string.Empty;
		}
	}
}
