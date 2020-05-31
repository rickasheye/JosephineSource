using System;

namespace Humanizer
{
	// Token: 0x0200001B RID: 27
	public static class StringExtensions
	{
		// Token: 0x060000DD RID: 221 RVA: 0x000034FD File Offset: 0x000016FD
		public static string FormatWith(this string format, params object[] args)
		{
			return string.Format(format, args);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00003506 File Offset: 0x00001706
		public static string FormatWith(this string format, IFormatProvider provider, params object[] args)
		{
			return string.Format(provider, format, args);
		}
	}
}
