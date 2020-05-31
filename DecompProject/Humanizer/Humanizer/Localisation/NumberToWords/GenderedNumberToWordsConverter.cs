using System;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x0200004A RID: 74
	internal abstract class GenderedNumberToWordsConverter : INumberToWordsConverter
	{
		// Token: 0x06000182 RID: 386 RVA: 0x00007775 File Offset: 0x00005975
		protected GenderedNumberToWordsConverter(GrammaticalGender defaultGender = GrammaticalGender.Masculine)
		{
			this._defaultGender = defaultGender;
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00007784 File Offset: 0x00005984
		public string Convert(long number)
		{
			return this.Convert(number, this._defaultGender);
		}

		// Token: 0x06000184 RID: 388
		public abstract string Convert(long number, GrammaticalGender gender);

		// Token: 0x06000185 RID: 389 RVA: 0x00007793 File Offset: 0x00005993
		public string ConvertToOrdinal(int number)
		{
			return this.ConvertToOrdinal(number, this._defaultGender);
		}

		// Token: 0x06000186 RID: 390
		public abstract string ConvertToOrdinal(int number, GrammaticalGender gender);

		// Token: 0x04000067 RID: 103
		private readonly GrammaticalGender _defaultGender;
	}
}
