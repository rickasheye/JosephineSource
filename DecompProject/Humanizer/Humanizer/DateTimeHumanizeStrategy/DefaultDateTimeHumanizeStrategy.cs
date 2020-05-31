using System;
using System.Globalization;

namespace Humanizer.DateTimeHumanizeStrategy
{
	// Token: 0x02000076 RID: 118
	public class DefaultDateTimeHumanizeStrategy : IDateTimeHumanizeStrategy
	{
		// Token: 0x0600024E RID: 590 RVA: 0x0000D630 File Offset: 0x0000B830
		public string Humanize(DateTime input, DateTime comparisonBase, CultureInfo culture)
		{
			return DateTimeHumanizeAlgorithms.DefaultHumanize(input, comparisonBase, culture);
		}
	}
}
