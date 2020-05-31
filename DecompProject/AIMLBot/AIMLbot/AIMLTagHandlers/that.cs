using System;
using System.Xml;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x02000019 RID: 25
	public class that : AIMLTagHandler
	{
		// Token: 0x06000049 RID: 73 RVA: 0x000035A2 File Offset: 0x000025A2
		public that(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000035B4 File Offset: 0x000025B4
		protected override string ProcessChange()
		{
			if (this.templateNode.Name.ToLower() == "that")
			{
				if (this.templateNode.Attributes.Count == 0)
				{
					return this.user.getThat();
				}
				if (this.templateNode.Attributes.Count == 1 && this.templateNode.Attributes[0].Name.ToLower() == "index" && this.templateNode.Attributes[0].Value.Length > 0)
				{
					try
					{
						string[] array = this.templateNode.Attributes[0].Value.Split(",".ToCharArray());
						if (array.Length == 2)
						{
							int num = Convert.ToInt32(array[0].Trim());
							int num2 = Convert.ToInt32(array[1].Trim());
							if (num > 0 & num2 > 0)
							{
								return this.user.getThat(num - 1, num2 - 1);
							}
							this.bot.writeToLog("ERROR! An input tag with a bady formed index (" + this.templateNode.Attributes[0].Value + ") was encountered processing the input: " + this.request.rawInput);
						}
						else
						{
							int num3 = Convert.ToInt32(this.templateNode.Attributes[0].Value.Trim());
							if (num3 > 0)
							{
								return this.user.getThat(num3 - 1);
							}
							this.bot.writeToLog("ERROR! An input tag with a bady formed index (" + this.templateNode.Attributes[0].Value + ") was encountered processing the input: " + this.request.rawInput);
						}
					}
					catch
					{
						this.bot.writeToLog("ERROR! An input tag with a bady formed index (" + this.templateNode.Attributes[0].Value + ") was encountered processing the input: " + this.request.rawInput);
					}
				}
			}
			return string.Empty;
		}
	}
}
