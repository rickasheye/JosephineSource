using System;
using System.Xml;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x02000006 RID: 6
	public class id : AIMLTagHandler
	{
		// Token: 0x06000011 RID: 17 RVA: 0x0000242C File Offset: 0x0000142C
		public id(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000243D File Offset: 0x0000143D
		protected override string ProcessChange()
		{
			if (this.templateNode.Name.ToLower() == "id")
			{
				return this.user.UserID;
			}
			return string.Empty;
		}
	}
}
