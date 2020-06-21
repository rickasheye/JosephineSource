using System;

namespace Humanizer.Localisation.Ordinalizers
{
	// Token: 0x02000037 RID: 55
	internal class PortugueseOrdinalizer : DefaultOrdinalizer
	{
		// Token: 0x0600012B RID: 299 RVA: 0x00003FFC File Offset: 0x000021FC
		public override string Convert(int number, string numberString)
		{
			return this.Convert(number, numberString, GrammaticalGender.Masculine);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00004007 File Offset: 0x00002207
		public override string Convert(int number, string numberString, GrammaticalGender gender)
		{
			if (number == 0)
			{
				return "0";
			}
			if (gender == GrammaticalGender.Feminine)
			{
				return numberString + "ª";
			}
			return numberString + "º";
		}
	}
}
