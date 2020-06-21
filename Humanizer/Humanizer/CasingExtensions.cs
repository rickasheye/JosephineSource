using System;

namespace Humanizer
{
	// Token: 0x02000003 RID: 3
	public static class CasingExtensions
	{
		// Token: 0x06000032 RID: 50 RVA: 0x00002220 File Offset: 0x00000420
		public static string ApplyCase(this string input, LetterCasing casing)
		{
			switch (casing)
			{
			case LetterCasing.Title:
				return input.Transform(new IStringTransformer[]
				{
					To.TitleCase
				});
			case LetterCasing.AllCaps:
				return input.Transform(new IStringTransformer[]
				{
					To.UpperCase
				});
			case LetterCasing.LowerCase:
				return input.Transform(new IStringTransformer[]
				{
					To.LowerCase
				});
			case LetterCasing.Sentence:
				return input.Transform(new IStringTransformer[]
				{
					To.SentenceCase
				});
			default:
				throw new ArgumentOutOfRangeException("casing");
			}
		}
	}
}
