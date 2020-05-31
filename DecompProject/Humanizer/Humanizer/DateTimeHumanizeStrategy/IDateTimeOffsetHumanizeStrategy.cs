using System;
using System.Globalization;

namespace Humanizer.DateTimeHumanizeStrategy
{
	// Token: 0x02000079 RID: 121
	public interface IDateTimeOffsetHumanizeStrategy
	{
		// Token: 0x06000253 RID: 595
		string Humanize(DateTimeOffset input, DateTimeOffset comparisonBase, CultureInfo culture);
	}
}
