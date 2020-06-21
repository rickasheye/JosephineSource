using System;
using System.Xml;
using AIMLbot.Normalize;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x0200001F RID: 31
	public class gender : AIMLTagHandler
	{
		// Token: 0x06000059 RID: 89 RVA: 0x0000418A File Offset: 0x0000318A
		public gender(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0000419C File Offset: 0x0000319C
		protected override string ProcessChange()
		{
			if (!(this.templateNode.Name.ToLower() == "gender"))
			{
				return string.Empty;
			}
			if (this.templateNode.InnerText.Length > 0)
			{
				return ApplySubstitutions.Substitute(this.bot, this.bot.GenderSubstitutions, this.templateNode.InnerText);
			}
			XmlNode node = AIMLTagHandler.getNode("<star/>");
			star star = new star(this.bot, this.user, this.query, this.request, this.result, node);
			this.templateNode.InnerText = star.Transform();
			if (this.templateNode.InnerText.Length > 0)
			{
				return this.ProcessChange();
			}
			return string.Empty;
		}
	}
}
