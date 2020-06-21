using System;
using System.Xml;
using AIMLbot.Normalize;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x02000008 RID: 8
	public class person2 : AIMLTagHandler
	{
		// Token: 0x06000015 RID: 21 RVA: 0x000024B6 File Offset: 0x000014B6
		public person2(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000024C8 File Offset: 0x000014C8
		protected override string ProcessChange()
		{
			if (!(this.templateNode.Name.ToLower() == "person2"))
			{
				return string.Empty;
			}
			if (this.templateNode.InnerText.Length > 0)
			{
				return ApplySubstitutions.Substitute(this.bot, this.bot.Person2Substitutions, this.templateNode.InnerText);
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
