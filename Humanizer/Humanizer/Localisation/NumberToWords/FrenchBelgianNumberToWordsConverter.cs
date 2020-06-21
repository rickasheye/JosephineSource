using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x02000046 RID: 70
	internal class FrenchBelgianNumberToWordsConverter : FrenchNumberToWordsConverterBase
	{
		// Token: 0x06000170 RID: 368 RVA: 0x00007200 File Offset: 0x00005400
		protected override void CollectPartsUnderAHundred(ICollection<string> parts, ref int number, GrammaticalGender gender, bool pluralize)
		{
			if (number == 80)
			{
				parts.Add(pluralize ? "quatre-vingts" : "quatre-vingt");
				return;
			}
			if (number == 81)
			{
				parts.Add((gender == GrammaticalGender.Feminine) ? "quatre-vingt-une" : "quatre-vingt-un");
				return;
			}
			base.CollectPartsUnderAHundred(parts, ref number, gender, pluralize);
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00007252 File Offset: 0x00005452
		protected override string GetTens(int tens)
		{
			if (tens == 8)
			{
				return "quatre-vingt";
			}
			return base.GetTens(tens);
		}
	}
}
