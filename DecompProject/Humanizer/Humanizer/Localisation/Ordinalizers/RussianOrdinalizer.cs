using System;

namespace Humanizer.Localisation.Ordinalizers
{
	// Token: 0x02000039 RID: 57
	internal class RussianOrdinalizer : DefaultOrdinalizer
	{
		// Token: 0x06000131 RID: 305 RVA: 0x0000409F File Offset: 0x0000229F
		public override string Convert(int number, string numberString)
		{
			return this.Convert(number, numberString, GrammaticalGender.Masculine);
		}

		// Token: 0x06000132 RID: 306 RVA: 0x000040AA File Offset: 0x000022AA
		public override string Convert(int number, string numberString, GrammaticalGender gender)
		{
			if (gender == GrammaticalGender.Masculine)
			{
				return numberString + "-й";
			}
			if (gender == GrammaticalGender.Feminine)
			{
				return numberString + "-я";
			}
			return numberString + "-е";
		}
	}
}
