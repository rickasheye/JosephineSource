using System;

namespace Humanizer
{
	// Token: 0x02000025 RID: 37
	internal class ToUpperCase : IStringTransformer
	{
		// Token: 0x06000106 RID: 262 RVA: 0x00003BA0 File Offset: 0x00001DA0
		public string Transform(string input)
		{
			return input.ToUpper();
		}
	}
}
