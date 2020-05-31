using System;

namespace Humanizer
{
	// Token: 0x0200002C RID: 44
	public static class Truncator
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000115 RID: 277 RVA: 0x00003E93 File Offset: 0x00002093
		public static ITruncator FixedLength
		{
			get
			{
				return new FixedLengthTruncator();
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000116 RID: 278 RVA: 0x00003E9A File Offset: 0x0000209A
		public static ITruncator FixedNumberOfCharacters
		{
			get
			{
				return new FixedNumberOfCharactersTruncator();
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000117 RID: 279 RVA: 0x00003EA1 File Offset: 0x000020A1
		public static ITruncator FixedNumberOfWords
		{
			get
			{
				return new FixedNumberOfWordsTruncator();
			}
		}
	}
}
