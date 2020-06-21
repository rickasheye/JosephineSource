using System;
using System.Xml;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x0200001E RID: 30
	public class set : AIMLTagHandler
	{
		// Token: 0x06000057 RID: 87 RVA: 0x00004058 File Offset: 0x00003058
		public set(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x06000058 RID: 88 RVA: 0x0000406C File Offset: 0x0000306C
		protected override string ProcessChange()
		{
			if (!(this.templateNode.Name.ToLower() == "set") || this.bot.GlobalSettings.Count <= 0 || this.templateNode.Attributes.Count != 1 || !(this.templateNode.Attributes[0].Name.ToLower() == "name"))
			{
				return string.Empty;
			}
			if (this.templateNode.InnerText.Length > 0)
			{
				this.user.Predicates.addSetting(this.templateNode.Attributes[0].Value, this.templateNode.InnerText);
				return this.user.Predicates.grabSetting(this.templateNode.Attributes[0].Value);
			}
			this.user.Predicates.removeSetting(this.templateNode.Attributes[0].Value);
			return string.Empty;
		}
	}
}
