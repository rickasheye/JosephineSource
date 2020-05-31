using System;

namespace Humanizer.Localisation.Ordinalizers
{
	// Token: 0x0200003A RID: 58
	internal class SpanishOrdinalizer : DefaultOrdinalizer
	{
		// Token: 0x06000134 RID: 308 RVA: 0x000040DE File Offset: 0x000022DE
		public override string Convert(int number, string numberString)
		{
			return this.Convert(number, numberString, GrammaticalGender.Masculine);
		}

		// Token: 0x06000135 RID: 309 RVA: 0x000040E9 File Offset: 0x000022E9
		public override string Convert(int number, string numberString, GrammaticalGender gender)
		{
			if (number == 0)
			{
				return "0";
			}
			if (gender == GrammaticalGender.Feminine)
			{
				return numberString + ".ª";
			}
			return numberString + ".º";
		}
	}
}
