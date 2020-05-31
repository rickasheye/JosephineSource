using System;

namespace Humanizer.Localisation.Ordinalizers
{
	// Token: 0x02000038 RID: 56
	internal class RomanianOrdinalizer : DefaultOrdinalizer
	{
		// Token: 0x0600012E RID: 302 RVA: 0x00004035 File Offset: 0x00002235
		public override string Convert(int number, string numberString)
		{
			return this.Convert(number, numberString, GrammaticalGender.Masculine);
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00004040 File Offset: 0x00002240
		public override string Convert(int number, string numberString, GrammaticalGender gender)
		{
			if (number == 0)
			{
				return "0";
			}
			if (number == 1)
			{
				if (gender == GrammaticalGender.Feminine)
				{
					return "prima";
				}
				return "primul";
			}
			else
			{
				if (gender == GrammaticalGender.Feminine)
				{
					return string.Format("a {0}-a", new object[]
					{
						numberString
					});
				}
				return string.Format("al {0}-lea", new object[]
				{
					numberString
				});
			}
		}
	}
}
