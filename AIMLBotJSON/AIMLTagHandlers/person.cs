using System;
using System.Xml;
using AIMLbot.Normalize;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x0200002D RID: 45
	public class person : AIMLTagHandler
	{
		// Token: 0x0600009D RID: 157 RVA: 0x00006670 File Offset: 0x00005670
		public person(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00006684 File Offset: 0x00005684
		protected override string ProcessChange()
		{
			if (!(this.templateNode.Name.ToLower() == "person"))
			{
				return string.Empty;
			}
			if (this.templateNode.InnerText.Length > 0)
			{
				return ApplySubstitutions.Substitute(this.bot, this.bot.PersonSubstitutions, this.templateNode.InnerText);
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
