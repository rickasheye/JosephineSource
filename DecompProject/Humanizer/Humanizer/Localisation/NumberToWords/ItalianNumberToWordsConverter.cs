using System;
using Humanizer.Localisation.NumberToWords.Italian;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x0200004F RID: 79
	internal class ItalianNumberToWordsConverter : GenderedNumberToWordsConverter
	{
		// Token: 0x0600019E RID: 414 RVA: 0x00008158 File Offset: 0x00006358
		public override string Convert(long input, GrammaticalGender gender)
		{
			if (input > 2147483647L || input < -2147483648L)
			{
				throw new NotImplementedException();
			}
			int number = (int)input;
			if (number < 0)
			{
				return "meno " + this.Convert((long)Math.Abs(number), gender);
			}
			return new ItalianCardinalNumberCruncher(number, gender).Convert();
		}

		// Token: 0x0600019F RID: 415 RVA: 0x000081A9 File Offset: 0x000063A9
		public override string ConvertToOrdinal(int number, GrammaticalGender gender)
		{
			return new ItalianOrdinalNumberCruncher(number, gender).Convert();
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x000081B7 File Offset: 0x000063B7
		public ItalianNumberToWordsConverter() : base(GrammaticalGender.Masculine)
		{
		}
	}
}
