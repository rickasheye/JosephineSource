using System;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x0200004E RID: 78
	public interface INumberToWordsConverter
	{
		// Token: 0x0600019A RID: 410
		string Convert(long number);

		// Token: 0x0600019B RID: 411
		string Convert(long number, GrammaticalGender gender);

		// Token: 0x0600019C RID: 412
		string ConvertToOrdinal(int number);

		// Token: 0x0600019D RID: 413
		string ConvertToOrdinal(int number, GrammaticalGender gender);
	}
}
