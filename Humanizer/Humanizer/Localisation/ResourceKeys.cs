using System;

namespace Humanizer.Localisation
{
	// Token: 0x0200002D RID: 45
	public class ResourceKeys
	{
		// Token: 0x06000118 RID: 280 RVA: 0x00003EA8 File Offset: 0x000020A8
		private static void ValidateRange(int count)
		{
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
		}

		// Token: 0x04000030 RID: 48
		private const string Single = "Single";

		// Token: 0x04000031 RID: 49
		private const string Multiple = "Multiple";

		// Token: 0x020000A7 RID: 167
		public static class DateHumanize
		{
			// Token: 0x060004E0 RID: 1248 RVA: 0x00012D84 File Offset: 0x00010F84
			public static string GetResourceKey(TimeUnit timeUnit, Tense timeUnitTense, int count = 1)
			{
				ResourceKeys.ValidateRange(count);
				if (count == 0)
				{
					return "DateHumanize_Now";
				}
				string singularity = (count == 1) ? "Single" : "Multiple";
				string tense = (timeUnitTense == Tense.Future) ? "FromNow" : "Ago";
				string unit = timeUnit.ToString().ToQuantity(count, ShowQuantityAs.None);
				return "DateHumanize_{0}{1}{2}".FormatWith(new object[]
				{
					singularity,
					unit,
					tense
				});
			}

			// Token: 0x0400010B RID: 267
			public const string Now = "DateHumanize_Now";

			// Token: 0x0400010C RID: 268
			public const string Never = "DateHumanize_Never";

			// Token: 0x0400010D RID: 269
			private const string DateTimeFormat = "DateHumanize_{0}{1}{2}";

			// Token: 0x0400010E RID: 270
			private const string Ago = "Ago";

			// Token: 0x0400010F RID: 271
			private const string FromNow = "FromNow";
		}

		// Token: 0x020000A8 RID: 168
		public static class TimeSpanHumanize
		{
			// Token: 0x060004E1 RID: 1249 RVA: 0x00012DF4 File Offset: 0x00010FF4
			public static string GetResourceKey(TimeUnit unit, int count = 1)
			{
				ResourceKeys.ValidateRange(count);
				if (count == 0)
				{
					return "TimeSpanHumanize_Zero";
				}
				return "TimeSpanHumanize_{0}{1}{2}".FormatWith(new object[]
				{
					(count == 1) ? "Single" : "Multiple",
					unit,
					(count == 1) ? "" : "s"
				});
			}

			// Token: 0x04000110 RID: 272
			private const string TimeSpanFormat = "TimeSpanHumanize_{0}{1}{2}";

			// Token: 0x04000111 RID: 273
			private const string Zero = "TimeSpanHumanize_Zero";
		}
	}
}
