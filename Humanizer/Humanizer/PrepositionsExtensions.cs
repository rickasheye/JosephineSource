using System;

namespace Humanizer
{
	// Token: 0x0200000B RID: 11
	public static class PrepositionsExtensions
	{
		// Token: 0x06000060 RID: 96 RVA: 0x0000288D File Offset: 0x00000A8D
		public static DateTime At(this DateTime date, int hour, int min = 0, int second = 0, int millisecond = 0)
		{
			return new DateTime(date.Year, date.Month, date.Day, hour, min, second, millisecond);
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000028AE File Offset: 0x00000AAE
		public static DateTime AtMidnight(this DateTime date)
		{
			return date.At(0, 0, 0, 0);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000028BA File Offset: 0x00000ABA
		public static DateTime AtNoon(this DateTime date)
		{
			return date.At(12, 0, 0, 0);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000028C7 File Offset: 0x00000AC7
		public static DateTime In(this DateTime date, int year)
		{
			return new DateTime(year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);
		}
	}
}
