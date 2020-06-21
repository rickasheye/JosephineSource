using System;
using System.Globalization;

namespace Humanizer.DateTimeHumanizeStrategy
{
	// Token: 0x0200007A RID: 122
	public class PrecisionDateTimeHumanizeStrategy : IDateTimeHumanizeStrategy
	{
		// Token: 0x06000254 RID: 596 RVA: 0x0000D660 File Offset: 0x0000B860
		public PrecisionDateTimeHumanizeStrategy(double precision = 0.75)
		{
			this._precision = precision;
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0000D66F File Offset: 0x0000B86F
		public string Humanize(DateTime input, DateTime comparisonBase, CultureInfo culture)
		{
			return DateTimeHumanizeAlgorithms.PrecisionHumanize(input, comparisonBase, this._precision, culture);
		}

		// Token: 0x040000D5 RID: 213
		private readonly double _precision;
	}
}
