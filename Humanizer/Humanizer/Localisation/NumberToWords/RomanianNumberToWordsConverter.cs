using System;
using Humanizer.Localisation.NumberToWords.Romanian;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x02000052 RID: 82
	internal class RomanianNumberToWordsConverter : GenderedNumberToWordsConverter
	{
		// Token: 0x060001AF RID: 431 RVA: 0x00008A8A File Offset: 0x00006C8A
		public override string Convert(long number, GrammaticalGender gender)
		{
			if (number > 2147483647L || number < -2147483648L)
			{
				throw new NotImplementedException();
			}
			return new RomanianCardinalNumberConverter().Convert((int)number, gender);
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x00008AB1 File Offset: 0x00006CB1
		public override string ConvertToOrdinal(int number, GrammaticalGender gender)
		{
			return new RomanianOrdinalNumberConverter().Convert(number, gender);
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x00008ABF File Offset: 0x00006CBF
		public RomanianNumberToWordsConverter() : base(GrammaticalGender.Masculine)
		{
		}
	}
}
