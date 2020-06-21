using System;
using System.Xml;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x02000023 RID: 35
	public class version : AIMLTagHandler
	{
		// Token: 0x0600006C RID: 108 RVA: 0x00004AD0 File Offset: 0x00003AD0
		public version(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00004AE1 File Offset: 0x00003AE1
		protected override string ProcessChange()
		{
			if (this.templateNode.Name.ToLower() == "version")
			{
				return this.bot.GlobalSettings.grabSetting("version");
			}
			return string.Empty;
		}
	}
}
