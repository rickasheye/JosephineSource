using System;

namespace Humanizer.Localisation.GrammaticalNumber
{
	// Token: 0x02000061 RID: 97
	internal static class RussianGrammaticalNumberDetector
	{
		// Token: 0x06000205 RID: 517 RVA: 0x0000C3BC File Offset: 0x0000A5BC
		public static RussianGrammaticalNumber Detect(int number)
		{
			if (number % 100 / 10 != 1)
			{
				int unity = number % 10;
				if (unity == 1)
				{
					return RussianGrammaticalNumber.Singular;
				}
				if (unity > 1 && unity < 5)
				{
					return RussianGrammaticalNumber.Paucal;
				}
			}
			return RussianGrammaticalNumber.Plural;
		}
	}
}
