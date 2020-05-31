using System;
using System.Xml;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x02000004 RID: 4
	public class topicstar : AIMLTagHandler
	{
		// Token: 0x0600000D RID: 13 RVA: 0x00002170 File Offset: 0x00001170
		public topicstar(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002184 File Offset: 0x00001184
		protected override string ProcessChange()
		{
			if (this.templateNode.Name.ToLower() == "topicstar")
			{
				if (this.templateNode.Attributes.Count == 0)
				{
					if (this.query.TopicStar.Count > 0)
					{
						return this.query.TopicStar[0];
					}
					this.bot.writeToLog("ERROR! An out of bounds index to topicstar was encountered when processing the input: " + this.request.rawInput);
				}
				else if (this.templateNode.Attributes.Count == 1 && this.templateNode.Attributes[0].Name.ToLower() == "index" && this.templateNode.Attributes[0].Value.Length > 0)
				{
					try
					{
						int num = Convert.ToInt32(this.templateNode.Attributes[0].Value.Trim());
						if (this.query.TopicStar.Count > 0)
						{
							if (num > 0)
							{
								return this.query.TopicStar[num - 1];
							}
							this.bot.writeToLog("ERROR! An input tag with a bady formed index (" + this.templateNode.Attributes[0].Value + ") was encountered processing the input: " + this.request.rawInput);
						}
						else
						{
							this.bot.writeToLog("ERROR! An out of bounds index to topicstar was encountered when processing the input: " + this.request.rawInput);
						}
					}
					catch
					{
						this.bot.writeToLog("ERROR! A thatstar tag with a bady formed index (" + this.templateNode.Attributes[0].Value + ") was encountered processing the input: " + this.request.rawInput);
					}
				}
			}
			return string.Empty;
		}
	}
}
