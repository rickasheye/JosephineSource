using System;
using System.Xml;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x0200000E RID: 14
	public class bot : AIMLTagHandler
	{
		// Token: 0x0600002E RID: 46 RVA: 0x00002F1B File Offset: 0x00001F1B
		public bot(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002F2C File Offset: 0x00001F2C
		protected override string ProcessChange()
		{
			if (this.templateNode.Name.ToLower() == "bot" && this.templateNode.Attributes.Count == 1 && this.templateNode.Attributes[0].Name.ToLower() == "name")
			{
				string value = this.templateNode.Attributes["name"].Value;
				return this.bot.GlobalSettings.grabSetting(value);
			}
			return string.Empty;
		}
	}
}
