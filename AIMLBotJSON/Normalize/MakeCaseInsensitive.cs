using System;
using AIMLbot.Utils;

namespace AIMLbot.Normalize
{
	// Token: 0x02000015 RID: 21
	public class MakeCaseInsensitive : TextTransformer
	{
		// Token: 0x0600003B RID: 59 RVA: 0x000033AE File Offset: 0x000023AE
		public MakeCaseInsensitive(Bot bot, string inputString) : base(bot, inputString)
		{
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000033B8 File Offset: 0x000023B8
		public MakeCaseInsensitive(Bot bot) : base(bot)
		{
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000033C1 File Offset: 0x000023C1
		protected override string ProcessChange()
		{
			return this.inputString.ToUpper();
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000033CE File Offset: 0x000023CE
		public static string TransformInput(string input)
		{
			return input.ToUpper();
		}
	}
}
