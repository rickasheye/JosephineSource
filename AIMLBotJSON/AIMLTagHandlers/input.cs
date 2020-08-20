using System;
using System.Xml;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x02000011 RID: 17
	public class input : AIMLTagHandler
	{
		// Token: 0x06000033 RID: 51 RVA: 0x00003019 File Offset: 0x00002019
		public input(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x06000034 RID: 52 RVA: 0x0000302C File Offset: 0x0000202C
		protected override string ProcessChange()
		{
			if (this.templateNode.Name.ToLower() == "input")
			{
				if (this.templateNode.Attributes.Count == 0)
				{
					return this.user.getResultSentence();
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
								return this.user.getResultSentence(num - 1, num2 - 1);
							}
							this.bot.writeToLog("ERROR! An input tag with a bady formed index (" + this.templateNode.Attributes[0].Value + ") was encountered processing the input: " + this.request.rawInput);
						}
						else
						{
							int num3 = Convert.ToInt32(this.templateNode.Attributes[0].Value.Trim());
							if (num3 > 0)
							{
								return this.user.getResultSentence(num3 - 1);
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
