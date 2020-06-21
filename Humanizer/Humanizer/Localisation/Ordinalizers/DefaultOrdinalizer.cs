using System;

namespace Humanizer.Localisation.Ordinalizers
{
	// Token: 0x02000031 RID: 49
	internal class DefaultOrdinalizer : IOrdinalizer
	{
		// Token: 0x0600011C RID: 284 RVA: 0x00003EF4 File Offset: 0x000020F4
		public virtual string Convert(int number, string numberString, GrammaticalGender gender)
		{
			return this.Convert(number, numberString);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00003EFE File Offset: 0x000020FE
		public virtual string Convert(int number, string numberString)
		{
			return numberString;
		}
	}
}
