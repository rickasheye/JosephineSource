using System;
using System.Globalization;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x02000041 RID: 65
	internal class DefaultNumberToWordsConverter : GenderlessNumberToWordsConverter
	{
		// Token: 0x06000154 RID: 340 RVA: 0x00005F21 File Offset: 0x00004121
		public DefaultNumberToWordsConverter(CultureInfo culture)
		{
			this._culture = culture;
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00005F30 File Offset: 0x00004130
		public override string Convert(long number)
		{
			return number.ToString(this._culture);
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00005F3F File Offset: 0x0000413F
		public override string ConvertToOrdinal(int number)
		{
			return number.ToString(this._culture);
		}

		// Token: 0x04000056 RID: 86
		private readonly CultureInfo _culture;
	}
}
