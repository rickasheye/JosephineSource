using System;
using System.Xml;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x02000013 RID: 19
	public class get : AIMLTagHandler
	{
		// Token: 0x06000039 RID: 57 RVA: 0x000032FA File Offset: 0x000022FA
		public get(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0000330C File Offset: 0x0000230C
		protected override string ProcessChange()
		{
			if (this.templateNode.Name.ToLower() == "get" && this.bot.GlobalSettings.Count > 0 && this.templateNode.Attributes.Count == 1 && this.templateNode.Attributes[0].Name.ToLower() == "name")
			{
				return this.user.Predicates.grabSetting(this.templateNode.Attributes[0].Value);
			}
			return string.Empty;
		}
	}
}
