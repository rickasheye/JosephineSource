using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x02000009 RID: 9
	public class sentence : AIMLTagHandler
	{
		// Token: 0x06000017 RID: 23 RVA: 0x0000258F File Offset: 0x0000158F
		public sentence(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000025A0 File Offset: 0x000015A0
		protected override string ProcessChange()
		{
			if (!(this.templateNode.Name.ToLower() == "sentence"))
			{
				return string.Empty;
			}
			if (this.templateNode.InnerText.Length > 0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				char[] array = this.templateNode.InnerText.Trim().ToCharArray();
				bool flag = true;
				for (int i = 0; i < array.Length; i++)
				{
					string text = Convert.ToString(array[i]);
					if (this.bot.Splitters.Contains(text))
					{
						flag = true;
					}
					Regex regex = new Regex("[a-zA-Z]");
					if (regex.IsMatch(text))
					{
						if (flag)
						{
							stringBuilder.Append(text.ToUpper(this.bot.Locale));
							flag = false;
						}
						else
						{
							stringBuilder.Append(text.ToLower(this.bot.Locale));
						}
					}
					else
					{
						stringBuilder.Append(text);
					}
				}
				return stringBuilder.ToString();
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
