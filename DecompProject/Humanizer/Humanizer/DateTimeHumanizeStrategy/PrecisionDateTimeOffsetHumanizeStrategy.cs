using System;
using System.Globalization;

namespace Humanizer.DateTimeHumanizeStrategy
{
	// Token: 0x0200007B RID: 123
	public class PrecisionDateTimeOffsetHumanizeStrategy : IDateTimeOffsetHumanizeStrategy
	{
		// Token: 0x06000256 RID: 598 RVA: 0x0000D67F File Offset: 0x0000B87F
		public PrecisionDateTimeOffsetHumanizeStrategy(double precision = 0.75)
		{
			this._precision = precision;
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0000D68E File Offset: 0x0000B88E
		public string Humanize(DateTimeOffset input, DateTimeOffset comparisonBase, CultureInfo culture)
		{
			return DateTimeHumanizeAlgorithms.PrecisionHumanize(input.UtcDateTime, comparisonBase.UtcDateTime, this._precision, culture);
		}

		// Token: 0x040000D6 RID: 214
		private readonly double _precision;
	}
}
