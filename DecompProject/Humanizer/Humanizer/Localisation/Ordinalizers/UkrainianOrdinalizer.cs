using System;

namespace Humanizer.Localisation.Ordinalizers
{
	// Token: 0x0200003C RID: 60
	internal class UkrainianOrdinalizer : DefaultOrdinalizer
	{
		// Token: 0x06000139 RID: 313 RVA: 0x0000412C File Offset: 0x0000232C
		public override string Convert(int number, string numberString)
		{
			return this.Convert(number, numberString, GrammaticalGender.Masculine);
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00004138 File Offset: 0x00002338
		public override string Convert(int number, string numberString, GrammaticalGender gender)
		{
			if (gender == GrammaticalGender.Masculine)
			{
				return numberString + "-й";
			}
			if (gender == GrammaticalGender.Feminine)
			{
				if (number % 10 == 3)
				{
					return numberString + "-я";
				}
				return numberString + "-а";
			}
			else
			{
				if (gender == GrammaticalGender.Neuter && number % 10 == 3)
				{
					return numberString + "-є";
				}
				return numberString + "-е";
			}
		}
	}
}
