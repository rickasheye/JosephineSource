using System;
using System.Xml;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x02000021 RID: 33
	public class thatstar : AIMLTagHandler
	{
		// Token: 0x06000067 RID: 103 RVA: 0x0000489F File Offset: 0x0000389F
		public thatstar(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000048B0 File Offset: 0x000038B0
		protected override string ProcessChange()
		{
			if (this.templateNode.Name.ToLower() == "thatstar")
			{
				if (this.templateNode.Attributes.Count == 0)
				{
					if (this.query.ThatStar.Count > 0)
					{
						return this.query.ThatStar[0];
					}
					this.bot.writeToLog("ERROR! An out of bounds index to thatstar was encountered when processing the input: " + this.request.rawInput);
				}
				else if (this.templateNode.Attributes.Count == 1 && this.templateNode.Attributes[0].Name.ToLower() == "index" && this.templateNode.Attributes[0].Value.Length > 0)
				{
					try
					{
						int num = Convert.ToInt32(this.templateNode.Attributes[0].Value.Trim());
						if (this.query.ThatStar.Count > 0)
						{
							if (num > 0)
							{
								return this.query.ThatStar[num - 1];
							}
							this.bot.writeToLog("ERROR! An input tag with a bady formed index (" + this.templateNode.Attributes[0].Value + ") was encountered processing the input: " + this.request.rawInput);
						}
						else
						{
							this.bot.writeToLog("ERROR! An out of bounds index to thatstar was encountered when processing the input: " + this.request.rawInput);
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
