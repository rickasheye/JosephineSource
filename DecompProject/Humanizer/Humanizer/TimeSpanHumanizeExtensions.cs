using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Humanizer.Configuration;
using Humanizer.Localisation;
using Humanizer.Localisation.Formatters;

namespace Humanizer
{
	// Token: 0x0200001D RID: 29
	public static class TimeSpanHumanizeExtensions
	{
		// Token: 0x060000E4 RID: 228 RVA: 0x00003656 File Offset: 0x00001856
		public static string Humanize(this TimeSpan timeSpan, int precision = 1, CultureInfo culture = null, TimeUnit maxUnit = TimeUnit.Week, TimeUnit minUnit = TimeUnit.Millisecond, string collectionSeparator = ", ")
		{
			return timeSpan.Humanize(precision, false, culture, maxUnit, minUnit, collectionSeparator);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00003666 File Offset: 0x00001866
		public static string Humanize(this TimeSpan timeSpan, int precision, bool countEmptyUnits, CultureInfo culture = null, TimeUnit maxUnit = TimeUnit.Week, TimeUnit minUnit = TimeUnit.Millisecond, string collectionSeparator = ", ")
		{
			return TimeSpanHumanizeExtensions.ConcatenateTimeSpanParts(TimeSpanHumanizeExtensions.SetPrecisionOfTimeSpan(TimeSpanHumanizeExtensions.CreateTheTimePartsWithUpperAndLowerLimits(timeSpan, culture, maxUnit, minUnit), precision, countEmptyUnits), collectionSeparator);
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00003684 File Offset: 0x00001884
		private static IEnumerable<string> CreateTheTimePartsWithUpperAndLowerLimits(TimeSpan timespan, CultureInfo culture, TimeUnit maxUnit, TimeUnit minUnit)
		{
			IFormatter cultureFormatter = Configurator.GetFormatter(culture);
			bool firstValueFound = false;
			IEnumerable<TimeUnit> enumTypesForTimeUnit = TimeSpanHumanizeExtensions.GetEnumTypesForTimeUnit();
			List<string> timeParts = new List<string>();
			foreach (TimeUnit timeUnitToGet in enumTypesForTimeUnit)
			{
				string timepart = TimeSpanHumanizeExtensions.GetTimeUnitPart(timeUnitToGet, timespan, culture, maxUnit, minUnit, cultureFormatter);
				if (timepart != null || firstValueFound)
				{
					firstValueFound = true;
					timeParts.Add(timepart);
				}
			}
			if (TimeSpanHumanizeExtensions.IsContainingOnlyNullValue(timeParts))
			{
				timeParts = TimeSpanHumanizeExtensions.CreateTimePartsWithNoTimeValue(cultureFormatter.TimeSpanHumanize_Zero());
			}
			return timeParts;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000370C File Offset: 0x0000190C
		private static IEnumerable<TimeUnit> GetEnumTypesForTimeUnit()
		{
			return ((IEnumerable<TimeUnit>)Enum.GetValues(typeof(TimeUnit))).Reverse<TimeUnit>();
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00003728 File Offset: 0x00001928
		private static string GetTimeUnitPart(TimeUnit timeUnitToGet, TimeSpan timespan, CultureInfo culture, TimeUnit maximumTimeUnit, TimeUnit minimumTimeUnit, IFormatter cultureFormatter)
		{
			if (timeUnitToGet <= maximumTimeUnit && timeUnitToGet >= minimumTimeUnit)
			{
				bool isTimeUnitToGetTheMaximumTimeUnit = timeUnitToGet == maximumTimeUnit;
				int numberOfTimeUnits = TimeSpanHumanizeExtensions.GetTimeUnitNumericalValue(timeUnitToGet, timespan, isTimeUnitToGetTheMaximumTimeUnit);
				return TimeSpanHumanizeExtensions.BuildFormatTimePart(cultureFormatter, timeUnitToGet, numberOfTimeUnits);
			}
			return null;
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00003758 File Offset: 0x00001958
		private static int GetTimeUnitNumericalValue(TimeUnit timeUnitToGet, TimeSpan timespan, bool isTimeUnitToGetTheMaximumTimeUnit)
		{
			switch (timeUnitToGet)
			{
			case TimeUnit.Millisecond:
				return TimeSpanHumanizeExtensions.GetNormalCaseTimeAsInteger(timespan.Milliseconds, timespan.TotalMilliseconds, isTimeUnitToGetTheMaximumTimeUnit);
			case TimeUnit.Second:
				return TimeSpanHumanizeExtensions.GetNormalCaseTimeAsInteger(timespan.Seconds, timespan.TotalSeconds, isTimeUnitToGetTheMaximumTimeUnit);
			case TimeUnit.Minute:
				return TimeSpanHumanizeExtensions.GetNormalCaseTimeAsInteger(timespan.Minutes, timespan.TotalMinutes, isTimeUnitToGetTheMaximumTimeUnit);
			case TimeUnit.Hour:
				return TimeSpanHumanizeExtensions.GetNormalCaseTimeAsInteger(timespan.Hours, timespan.TotalHours, isTimeUnitToGetTheMaximumTimeUnit);
			case TimeUnit.Day:
				return TimeSpanHumanizeExtensions.GetSpecialCaseDaysAsInteger(timespan, isTimeUnitToGetTheMaximumTimeUnit);
			case TimeUnit.Week:
				return TimeSpanHumanizeExtensions.GetSpecialCaseWeeksAsInteger(timespan, isTimeUnitToGetTheMaximumTimeUnit);
			case TimeUnit.Month:
				return TimeSpanHumanizeExtensions.GetSpecialCaseMonthAsInteger(timespan, isTimeUnitToGetTheMaximumTimeUnit);
			case TimeUnit.Year:
				return TimeSpanHumanizeExtensions.GetSpecialCaseYearAsInteger(timespan);
			default:
				return 0;
			}
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00003801 File Offset: 0x00001A01
		private static int GetSpecialCaseMonthAsInteger(TimeSpan timespan, bool isTimeUnitToGetTheMaximumTimeUnit)
		{
			if (isTimeUnitToGetTheMaximumTimeUnit)
			{
				return (int)((double)timespan.Days / 30.436875);
			}
			return (int)((double)timespan.Days % 365.2425 / 30.436875);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00003837 File Offset: 0x00001A37
		private static int GetSpecialCaseYearAsInteger(TimeSpan timespan)
		{
			return (int)((double)timespan.Days / 365.2425);
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000384C File Offset: 0x00001A4C
		private static int GetSpecialCaseWeeksAsInteger(TimeSpan timespan, bool isTimeUnitToGetTheMaximumTimeUnit)
		{
			if (isTimeUnitToGetTheMaximumTimeUnit || (double)timespan.Days < 30.436875)
			{
				return timespan.Days / 7;
			}
			return 0;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000386F File Offset: 0x00001A6F
		private static int GetSpecialCaseDaysAsInteger(TimeSpan timespan, bool isTimeUnitToGetTheMaximumTimeUnit)
		{
			if (isTimeUnitToGetTheMaximumTimeUnit)
			{
				return timespan.Days;
			}
			if ((double)timespan.Days < 30.436875)
			{
				return timespan.Days % 7;
			}
			return (int)((double)timespan.Days % 30.436875);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x000038AC File Offset: 0x00001AAC
		private static int GetNormalCaseTimeAsInteger(int timeNumberOfUnits, double totalTimeNumberOfUnits, bool isTimeUnitToGetTheMaximumTimeUnit)
		{
			if (isTimeUnitToGetTheMaximumTimeUnit)
			{
				try
				{
					return (int)totalTimeNumberOfUnits;
				}
				catch
				{
					return 0;
				}
				return timeNumberOfUnits;
			}
			return timeNumberOfUnits;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000038DC File Offset: 0x00001ADC
		private static string BuildFormatTimePart(IFormatter cultureFormatter, TimeUnit timeUnitType, int amountOfTimeUnits)
		{
			if (amountOfTimeUnits == 0)
			{
				return null;
			}
			return cultureFormatter.TimeSpanHumanize(timeUnitType, Math.Abs(amountOfTimeUnits));
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000038F0 File Offset: 0x00001AF0
		private static List<string> CreateTimePartsWithNoTimeValue(string noTimeValue)
		{
			return new List<string>
			{
				noTimeValue
			};
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x000038FE File Offset: 0x00001AFE
		private static bool IsContainingOnlyNullValue(IEnumerable<string> timeParts)
		{
			return timeParts.Count((string x) => x != null) == 0;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00003928 File Offset: 0x00001B28
		private static IEnumerable<string> SetPrecisionOfTimeSpan(IEnumerable<string> timeParts, int precision, bool countEmptyUnits)
		{
			if (!countEmptyUnits)
			{
				timeParts = from x in timeParts
				where x != null
				select x;
			}
			timeParts = timeParts.Take(precision);
			if (countEmptyUnits)
			{
				timeParts = from x in timeParts
				where x != null
				select x;
			}
			return timeParts;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00003993 File Offset: 0x00001B93
		private static string ConcatenateTimeSpanParts(IEnumerable<string> timeSpanParts, string collectionSeparator)
		{
			if (collectionSeparator == null)
			{
				return Configurator.CollectionFormatter.Humanize<string>(timeSpanParts);
			}
			return string.Join(collectionSeparator, timeSpanParts);
		}

		// Token: 0x04000026 RID: 38
		private const int _daysInAWeek = 7;

		// Token: 0x04000027 RID: 39
		private const double _daysInAYear = 365.2425;

		// Token: 0x04000028 RID: 40
		private const double _daysInAMonth = 30.436875;
	}
}
