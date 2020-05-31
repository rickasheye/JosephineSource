using System;

namespace Humanizer.Localisation.Ordinalizers
{
	// Token: 0x02000033 RID: 51
	internal class EnglishOrdinalizer : DefaultOrdinalizer
	{
		// Token: 0x06000122 RID: 290 RVA: 0x00003F34 File Offset: 0x00002134
		public override string Convert(int number, string numberString)
		{
			int nMod100 = number % 100;
			if (nMod100 >= 11 && nMod100 <= 13)
			{
				return numberString + "th";
			}
			switch (number % 10)
			{
			case 1:
				return numberString + "st";
			case 2:
				return numberString + "nd";
			case 3:
				return numberString + "rd";
			default:
				return numberString + "th";
			}
		}
	}
}
