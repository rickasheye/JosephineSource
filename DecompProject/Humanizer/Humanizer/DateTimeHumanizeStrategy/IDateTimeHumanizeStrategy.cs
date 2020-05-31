using System;
using System.Globalization;

namespace Humanizer.DateTimeHumanizeStrategy
{
	// Token: 0x02000078 RID: 120
	public interface IDateTimeHumanizeStrategy
	{
		// Token: 0x06000252 RID: 594
		string Humanize(DateTime input, DateTime comparisonBase, CultureInfo culture);
	}
}
