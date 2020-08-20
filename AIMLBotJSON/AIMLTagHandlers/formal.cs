using System;
using System.Text;
using System.Xml;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x0200000A RID: 10
	public class formal : AIMLTagHandler
	{
		// Token: 0x06000019 RID: 25 RVA: 0x000026FD File Offset: 0x000016FD
		public formal(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002710 File Offset: 0x00001710
		protected override string ProcessChange()
		{
			if (this.templateNode.Name.ToLower() == "formal")
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (this.templateNode.InnerText.Length > 0)
				{
					string[] array = this.templateNode.InnerText.ToLower().Split(new char[0]);
					foreach (string text in array)
					{
						string text2 = text.Substring(0, 1);
						text2 = text2.ToUpper();
						if (text.Length > 1)
						{
							text2 += text.Substring(1);
						}
						stringBuilder.Append(text2 + " ");
					}
				}
				return stringBuilder.ToString().Trim();
			}
			return string.Empty;
		}
	}
}
