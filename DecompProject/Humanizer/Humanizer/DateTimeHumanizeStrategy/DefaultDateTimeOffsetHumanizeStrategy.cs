using System;
using System.Globalization;

namespace Humanizer.DateTimeHumanizeStrategy
{
	// Token: 0x02000077 RID: 119
	public class DefaultDateTimeOffsetHumanizeStrategy : IDateTimeOffsetHumanizeStrategy
	{
		// Token: 0x06000250 RID: 592 RVA: 0x0000D642 File Offset: 0x0000B842
		public string Humanize(DateTimeOffset input, DateTimeOffset comparisonBase, CultureInfo culture)
		{
			return DateTimeHumanizeAlgorithms.DefaultHumanize(input.UtcDateTime, comparisonBase.UtcDateTime, culture);
		}
	}
}
