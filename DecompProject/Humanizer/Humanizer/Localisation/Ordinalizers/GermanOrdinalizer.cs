using System;

namespace Humanizer.Localisation.Ordinalizers
{
	// Token: 0x02000034 RID: 52
	internal class GermanOrdinalizer : DefaultOrdinalizer
	{
		// Token: 0x06000124 RID: 292 RVA: 0x00003FAE File Offset: 0x000021AE
		public override string Convert(int number, string numberString)
		{
			return numberString + ".";
		}
	}
}
