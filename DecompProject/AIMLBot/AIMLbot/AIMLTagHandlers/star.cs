using System;
using System.Xml;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x0200002C RID: 44
	public class star : AIMLTagHandler
	{
		// Token: 0x0600009B RID: 155 RVA: 0x000064E8 File Offset: 0x000054E8
		public star(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000064FC File Offset: 0x000054FC
		protected override string ProcessChange()
		{
			if (this.templateNode.Name.ToLower() == "star")
			{
				if (this.query.InputStar.Count > 0)
				{
					if (this.templateNode.Attributes.Count == 0)
					{
						return this.query.InputStar[0];
					}
					if (this.templateNode.Attributes.Count != 1 || !(this.templateNode.Attributes[0].Name.ToLower() == "index"))
					{
						goto IL_14F;
					}
					try
					{
						int num = Convert.ToInt32(this.templateNode.Attributes[0].Value);
						num--;
						if (num >= 0 & num < this.query.InputStar.Count)
						{
							return this.query.InputStar[num];
						}
						this.bot.writeToLog("InputStar out of bounds reference caused by input: " + this.request.rawInput);
						goto IL_14F;
					}
					catch
					{
						this.bot.writeToLog("Index set to non-integer value whilst processing star tag in response to the input: " + this.request.rawInput);
						goto IL_14F;
					}
				}
				this.bot.writeToLog("A star tag tried to reference an empty InputStar collection when processing the input: " + this.request.rawInput);
			}
			IL_14F:
			return string.Empty;
		}
	}
}
