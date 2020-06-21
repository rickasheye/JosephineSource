using System;
using AIMLbot.Utils;

namespace AIMLbot.Normalize
{
	// Token: 0x02000022 RID: 34
	public class StripIllegalCharacters : TextTransformer
	{
		// Token: 0x06000069 RID: 105 RVA: 0x00004AA0 File Offset: 0x00003AA0
		public StripIllegalCharacters(Bot bot, string inputString) : base(bot, inputString)
		{
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00004AAA File Offset: 0x00003AAA
		public StripIllegalCharacters(Bot bot) : base(bot)
		{
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00004AB3 File Offset: 0x00003AB3
		protected override string ProcessChange()
		{
			return this.bot.Strippers.Replace(this.inputString, " ");
		}
	}
}
