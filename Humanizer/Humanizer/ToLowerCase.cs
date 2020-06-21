using System;
using System.Globalization;

namespace Humanizer
{
	// Token: 0x02000022 RID: 34
	internal class ToLowerCase : IStringTransformer
	{
		// Token: 0x060000FF RID: 255 RVA: 0x00003A92 File Offset: 0x00001C92
		public string Transform(string input)
		{
			return CultureInfo.CurrentCulture.TextInfo.ToLower(input);
		}
	}
}
