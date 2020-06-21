using System;
using System.Globalization;
using Humanizer.Configuration;
using Humanizer.Localisation;
using Humanizer.Localisation.Formatters;

namespace Humanizer.DateTimeHumanizeStrategy
{
	// Token: 0x02000075 RID: 117
	internal static class DateTimeHumanizeAlgorithms
	{
		// Token: 0x0600024C RID: 588 RVA: 0x0000D1E8 File Offset: 0x0000B3E8
		public static string PrecisionHumanize(DateTime input, DateTime comparisonBase, double precision, CultureInfo culture)
		{
			TimeSpan ts = new TimeSpan(Math.Abs(comparisonBase.Ticks - input.Ticks));
			Tense tense = (input > comparisonBase) ? Tense.Future : Tense.Past;
			int seconds = ts.Seconds;
			int minutes = ts.Minutes;
			int hours = ts.Hours;
			int days = ts.Days;
			int years = 0;
			int months = 0;
			if ((double)ts.Milliseconds >= 999.0 * precision)
			{
				seconds++;
			}
			if ((double)seconds >= 59.0 * precision)
			{
				minutes++;
			}
			if ((double)minutes >= 59.0 * precision)
			{
				hours++;
			}
			if ((double)hours >= 23.0 * precision)
			{
				days++;
			}
			if ((double)days >= 30.0 * precision & days <= 31)
			{
				months = 1;
			}
			if (days > 31 && (double)days < 365.0 * precision)
			{
				int factor = Convert.ToInt32(Math.Floor((double)days / 30.0));
				int maxMonths = Convert.ToInt32(Math.Ceiling((double)days / 30.0));
				months = (((double)days >= 30.0 * ((double)factor + precision)) ? maxMonths : (maxMonths - 1));
			}
			if ((double)days >= 365.0 * precision && days <= 366)
			{
				years = 1;
			}
			if (days > 365)
			{
				int factor2 = Convert.ToInt32(Math.Floor((double)days / 365.0));
				int maxMonths2 = Convert.ToInt32(Math.Ceiling((double)days / 365.0));
				years = (((double)days >= 365.0 * ((double)factor2 + precision)) ? maxMonths2 : (maxMonths2 - 1));
			}
			IFormatter formatter = Configurator.GetFormatter(culture);
			if (years > 0)
			{
				return formatter.DateHumanize(TimeUnit.Year, tense, years);
			}
			if (months > 0)
			{
				return formatter.DateHumanize(TimeUnit.Month, tense, months);
			}
			if (days > 0)
			{
				return formatter.DateHumanize(TimeUnit.Day, tense, days);
			}
			if (hours > 0)
			{
				return formatter.DateHumanize(TimeUnit.Hour, tense, hours);
			}
			if (minutes > 0)
			{
				return formatter.DateHumanize(TimeUnit.Minute, tense, minutes);
			}
			if (seconds > 0)
			{
				return formatter.DateHumanize(TimeUnit.Second, tense, seconds);
			}
			return formatter.DateHumanize(TimeUnit.Millisecond, tense, 0);
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0000D410 File Offset: 0x0000B610
		public static string DefaultHumanize(DateTime input, DateTime comparisonBase, CultureInfo culture)
		{
			Tense tense = (input > comparisonBase) ? Tense.Future : Tense.Past;
			TimeSpan ts = new TimeSpan(Math.Abs(comparisonBase.Ticks - input.Ticks));
			IFormatter formatter = Configurator.GetFormatter(culture);
			if (ts.TotalMilliseconds < 500.0)
			{
				return formatter.DateHumanize(TimeUnit.Millisecond, tense, 0);
			}
			if (ts.TotalSeconds < 60.0)
			{
				return formatter.DateHumanize(TimeUnit.Second, tense, ts.Seconds);
			}
			if (ts.TotalSeconds < 120.0)
			{
				return formatter.DateHumanize(TimeUnit.Minute, tense, 1);
			}
			if (ts.TotalMinutes < 60.0)
			{
				return formatter.DateHumanize(TimeUnit.Minute, tense, ts.Minutes);
			}
			if (ts.TotalMinutes < 90.0)
			{
				return formatter.DateHumanize(TimeUnit.Hour, tense, 1);
			}
			if (ts.TotalHours < 24.0)
			{
				return formatter.DateHumanize(TimeUnit.Hour, tense, ts.Hours);
			}
			if (ts.TotalHours < 48.0)
			{
				int days = Math.Abs((input.Date - comparisonBase.Date).Days);
				return formatter.DateHumanize(TimeUnit.Day, tense, days);
			}
			if (ts.TotalDays < 28.0)
			{
				return formatter.DateHumanize(TimeUnit.Day, tense, ts.Days);
			}
			if (ts.TotalDays >= 28.0 && ts.TotalDays < 30.0)
			{
				if (comparisonBase.Date.AddMonths((tense == Tense.Future) ? 1 : -1) == input.Date)
				{
					return formatter.DateHumanize(TimeUnit.Month, tense, 1);
				}
				return formatter.DateHumanize(TimeUnit.Day, tense, ts.Days);
			}
			else
			{
				if (ts.TotalDays < 345.0)
				{
					int months = Convert.ToInt32(Math.Floor(ts.TotalDays / 29.5));
					return formatter.DateHumanize(TimeUnit.Month, tense, months);
				}
				int years = Convert.ToInt32(Math.Floor(ts.TotalDays / 365.0));
				if (years == 0)
				{
					years = 1;
				}
				return formatter.DateHumanize(TimeUnit.Year, tense, years);
			}
		}
	}
}
