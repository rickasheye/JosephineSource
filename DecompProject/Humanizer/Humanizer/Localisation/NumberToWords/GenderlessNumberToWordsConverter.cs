using System;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x0200004B RID: 75
	internal abstract class GenderlessNumberToWordsConverter : INumberToWordsConverter
	{
		// Token: 0x06000187 RID: 391
		public abstract string Convert(long number);

		// Token: 0x06000188 RID: 392 RVA: 0x000077A2 File Offset: 0x000059A2
		public string Convert(long number, GrammaticalGender gender)
		{
			return this.Convert(number);
		}

		// Token: 0x06000189 RID: 393
		public abstract string ConvertToOrdinal(int number);

		// Token: 0x0600018A RID: 394 RVA: 0x000077AB File Offset: 0x000059AB
		public string ConvertToOrdinal(int number, GrammaticalGender gender)
		{
			return this.ConvertToOrdinal(number);
		}
	}
}
