using System;

namespace Humanizer
{
	// Token: 0x02000023 RID: 35
	internal class ToSentenceCase : IStringTransformer
	{
		// Token: 0x06000101 RID: 257 RVA: 0x00003AAC File Offset: 0x00001CAC
		public string Transform(string input)
		{
			if (input.Length >= 1)
			{
				return input.Substring(0, 1).ToUpper() + input.Substring(1);
			}
			return input.ToUpper();
		}
	}
}
