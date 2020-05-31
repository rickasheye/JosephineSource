using System;

namespace Humanizer
{
	// Token: 0x02000026 RID: 38
	public static class TruncateExtensions
	{
		// Token: 0x06000108 RID: 264 RVA: 0x00003BB0 File Offset: 0x00001DB0
		public static string Truncate(this string input, int length)
		{
			return input.Truncate(length, "…", Truncator.FixedLength, TruncateFrom.Right);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00003BC4 File Offset: 0x00001DC4
		public static string Truncate(this string input, int length, ITruncator truncator, TruncateFrom from = TruncateFrom.Right)
		{
			return input.Truncate(length, "…", truncator, from);
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00003BD4 File Offset: 0x00001DD4
		public static string Truncate(this string input, int length, string truncationString, TruncateFrom from = TruncateFrom.Right)
		{
			return input.Truncate(length, truncationString, Truncator.FixedLength, from);
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00003BE4 File Offset: 0x00001DE4
		public static string Truncate(this string input, int length, string truncationString, ITruncator truncator, TruncateFrom from = TruncateFrom.Right)
		{
			if (truncator == null)
			{
				throw new ArgumentNullException("truncator");
			}
			if (input == null)
			{
				return null;
			}
			return truncator.Truncate(input, length, truncationString, from);
		}
	}
}
