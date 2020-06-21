using System;

namespace Humanizer.Localisation.Ordinalizers
{
	// Token: 0x02000036 RID: 54
	internal class ItalianOrdinalizer : DefaultOrdinalizer
	{
		// Token: 0x06000128 RID: 296 RVA: 0x00003FC3 File Offset: 0x000021C3
		public override string Convert(int number, string numberString)
		{
			return this.Convert(number, numberString, GrammaticalGender.Masculine);
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00003FCE File Offset: 0x000021CE
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
			return numberString + "°";
		}
	}
}
