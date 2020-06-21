using System;
using System.Text.RegularExpressions;

namespace Humanizer
{
	// Token: 0x02000018 RID: 24
	internal static class RegexOptionsUtil
	{
		// Token: 0x060000D6 RID: 214 RVA: 0x00003254 File Offset: 0x00001454
		static RegexOptionsUtil()
		{
			RegexOptions compiled;
			RegexOptionsUtil._compiled = (Enum.TryParse<RegexOptions>("Compiled", out compiled) ? compiled : RegexOptions.None);
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x00003278 File Offset: 0x00001478
		public static RegexOptions Compiled
		{
			get
			{
				return RegexOptionsUtil._compiled;
			}
		}

		// Token: 0x04000020 RID: 32
		private static readonly RegexOptions _compiled;
	}
}
