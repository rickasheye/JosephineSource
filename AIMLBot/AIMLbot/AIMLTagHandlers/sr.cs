using System;
using System.Xml;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x02000027 RID: 39
	public class sr : AIMLTagHandler
	{
		// Token: 0x06000071 RID: 113 RVA: 0x00004B9A File Offset: 0x00003B9A
		public sr(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00004BAC File Offset: 0x00003BAC
		protected override string ProcessChange()
		{
			if (this.templateNode.Name.ToLower() == "sr")
			{
				XmlNode node = AIMLTagHandler.getNode("<star/>");
				star star = new star(this.bot, this.user, this.query, this.request, this.result, node);
				string str = star.Transform();
				XmlNode node2 = AIMLTagHandler.getNode("<srai>" + str + "</srai>");
				srai srai = new srai(this.bot, this.user, this.query, this.request, this.result, node2);
				return srai.Transform();
			}
			return string.Empty;
		}
	}
}
