using System;

namespace Humanizer.Localisation.Ordinalizers
{
	// Token: 0x0200003B RID: 59
	internal class TurkishOrdinalizer : DefaultOrdinalizer
	{
		// Token: 0x06000137 RID: 311 RVA: 0x00004117 File Offset: 0x00002317
		public override string Convert(int number, string numberString)
		{
			return numberString + ".";
		}
	}
}
