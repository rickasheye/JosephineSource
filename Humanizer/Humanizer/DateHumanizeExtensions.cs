using System;
using System.Globalization;
using Humanizer.Configuration;

namespace Humanizer
{
	// Token: 0x02000005 RID: 5
	public static class DateHumanizeExtensions
	{
		// Token: 0x06000037 RID: 55 RVA: 0x000022F8 File Offset: 0x000004F8
		public static string Humanize(this DateTime input, bool utcDate = true, DateTime? dateToCompareAgainst = null, CultureInfo culture = null)
		{
			DateTime comparisonBase = dateToCompareAgainst ?? DateTime.UtcNow;
			if (!utcDate)
			{
				comparisonBase = comparisonBase.ToLocalTime();
			}
			return Configurator.DateTimeHumanizeStrategy.Humanize(input, comparisonBase, culture);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002337 File Offset: 0x00000537
		public static string Humanize(this DateTime? input, bool utcDate = true, DateTime? dateToCompareAgainst = null, CultureInfo culture = null)
		{
			if (input != null)
			{
				return input.Value.Humanize(utcDate, dateToCompareAgainst, culture);
			}
			return Configurator.GetFormatter(culture).DateHumanize_Never();
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002360 File Offset: 0x00000560
		public static string Humanize(this DateTimeOffset input, DateTimeOffset? dateToCompareAgainst = null, CultureInfo culture = null)
		{
			DateTimeOffset comparisonBase = dateToCompareAgainst ?? DateTimeOffset.UtcNow;
			return Configurator.DateTimeOffsetHumanizeStrategy.Humanize(input, comparisonBase, culture);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002394 File Offset: 0x00000594
		public static string Humanize(this DateTimeOffset? input, DateTimeOffset? dateToCompareAgainst = null, CultureInfo culture = null)
		{
			if (input != null)
			{
				return input.Value.Humanize(dateToCompareAgainst, culture);
			}
			return Configurator.GetFormatter(culture).DateHumanize_Never();
		}
	}
}
