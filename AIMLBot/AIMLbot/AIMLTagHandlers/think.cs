using System;
using System.Xml;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x02000018 RID: 24
	public class think : AIMLTagHandler
	{
		// Token: 0x06000047 RID: 71 RVA: 0x0000358A File Offset: 0x0000258A
		public think(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0000359B File Offset: 0x0000259B
		protected override string ProcessChange()
		{
			return string.Empty;
		}
	}
}
