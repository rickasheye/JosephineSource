using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x02000047 RID: 71
	internal class FrenchNumberToWordsConverter : FrenchNumberToWordsConverterBase
	{
		// Token: 0x06000173 RID: 371 RVA: 0x00007270 File Offset: 0x00005470
		protected override void CollectPartsUnderAHundred(ICollection<string> parts, ref int number, GrammaticalGender gender, bool pluralize)
		{
			if (number == 71)
			{
				parts.Add("soixante et onze");
				return;
			}
			if (number == 80)
			{
				parts.Add(pluralize ? "quatre-vingts" : "quatre-vingt");
				return;
			}
			if (number >= 70)
			{
				int @base = (number < 80) ? 60 : 80;
				int units = number - @base;
				int tens = @base / 10;
				parts.Add(string.Format("{0}-{1}", new object[]
				{
					this.GetTens(tens),
					FrenchNumberToWordsConverterBase.GetUnits(units, gender)
				}));
				return;
			}
			base.CollectPartsUnderAHundred(parts, ref number, gender, pluralize);
		}

		// Token: 0x06000174 RID: 372 RVA: 0x000072FF File Offset: 0x000054FF
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
