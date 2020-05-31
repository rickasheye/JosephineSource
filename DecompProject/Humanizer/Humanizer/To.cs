using System;
using System.Linq;

namespace Humanizer
{
	// Token: 0x02000021 RID: 33
	public static class To
	{
		// Token: 0x060000FA RID: 250 RVA: 0x00003A4E File Offset: 0x00001C4E
		public static string Transform(this string input, params IStringTransformer[] transformers)
		{
			return transformers.Aggregate(input, (string current, IStringTransformer stringTransformer) => stringTransformer.Transform(current));
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x060000FB RID: 251 RVA: 0x00003A76 File Offset: 0x00001C76
		public static IStringTransformer TitleCase
		{
			get
			{
				return new ToTitleCase();
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060000FC RID: 252 RVA: 0x00003A7D File Offset: 0x00001C7D
		public static IStringTransformer LowerCase
		{
			get
			{
				return new ToLowerCase();
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060000FD RID: 253 RVA: 0x00003A84 File Offset: 0x00001C84
		public static IStringTransformer UpperCase
		{
			get
			{
				return new ToUpperCase();
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000FE RID: 254 RVA: 0x00003A8B File Offset: 0x00001C8B
		public static IStringTransformer SentenceCase
		{
			get
			{
				return new ToSentenceCase();
			}
		}
	}
}
