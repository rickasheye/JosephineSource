using System;
using System.Collections.Generic;
using System.Xml;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x02000028 RID: 40
	public class random : AIMLTagHandler
	{
		// Token: 0x06000073 RID: 115 RVA: 0x00004C55 File Offset: 0x00003C55
		public random(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
			this.isRecursive = false;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00004C70 File Offset: 0x00003C70
		protected override string ProcessChange()
		{
			if (this.templateNode.Name.ToLower() == "random" && this.templateNode.HasChildNodes)
			{
				List<XmlNode> list = new List<XmlNode>();
				foreach (object obj in this.templateNode.ChildNodes)
				{
					XmlNode xmlNode = (XmlNode)obj;
					if (xmlNode.Name == "li")
					{
						list.Add(xmlNode);
					}
				}
				if (list.Count > 0)
				{
					Random random = new Random();
					XmlNode xmlNode2 = list[random.Next(list.Count)];
					return xmlNode2.InnerXml;
				}
			}
			return string.Empty;
		}
	}
}
