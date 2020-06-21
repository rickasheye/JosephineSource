using System;
using System.Xml;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x02000010 RID: 16
	public class lowercase : AIMLTagHandler
	{
		// Token: 0x06000031 RID: 49 RVA: 0x00002FC9 File Offset: 0x00001FC9
		public lowercase(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002FDA File Offset: 0x00001FDA
		protected override string ProcessChange()
		{
			if (this.templateNode.Name.ToLower() == "lowercase")
			{
				return this.templateNode.InnerText.ToLower(this.bot.Locale);
			}
			return string.Empty;
		}
	}
}
