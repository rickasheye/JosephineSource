using System;

namespace Humanizer.Localisation.Ordinalizers
{
	// Token: 0x02000032 RID: 50
	internal class DutchOrdinalizer : DefaultOrdinalizer
	{
		// Token: 0x0600011F RID: 287 RVA: 0x00003F09 File Offset: 0x00002109
		public override string Convert(int number, string numberString)
		{
			return this.Convert(number, numberString, GrammaticalGender.Masculine);
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00003F14 File Offset: 0x00002114
		public override string Convert(int number, string numberString, GrammaticalGender gender)
		{
			if (number == 0)
			{
				return "0";
			}
			return numberString + "e";
		}
	}
}
