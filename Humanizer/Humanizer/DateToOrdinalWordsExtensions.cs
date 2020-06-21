using System;
using Humanizer.Configuration;

namespace Humanizer
{
	// Token: 0x02000006 RID: 6
	public static class DateToOrdinalWordsExtensions
	{
		// Token: 0x0600003B RID: 59 RVA: 0x000023B9 File Offset: 0x000005B9
		public static string ToOrdinalWords(this DateTime input)
		{
			return Configurator.DateToOrdinalWordsConverter.Convert(input);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000023C6 File Offset: 0x000005C6
		public static string ToOrdinalWords(this DateTime input, GrammaticalCase grammaticalCase)
		{
			return Configurator.DateToOrdinalWordsConverter.Convert(input, grammaticalCase);
		}
	}
}
