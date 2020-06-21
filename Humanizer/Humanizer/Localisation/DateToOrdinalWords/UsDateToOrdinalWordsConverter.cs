using System;

namespace Humanizer.Localisation.DateToOrdinalWords
{
	// Token: 0x0200006F RID: 111
	internal class UsDateToOrdinalWordsConverter : DefaultDateToOrdinalWordConverter
	{
		// Token: 0x06000232 RID: 562 RVA: 0x0000C7F1 File Offset: 0x0000A9F1
		public override string Convert(DateTime date)
		{
			return date.ToString("MMMM ") + date.Day.Ordinalize() + date.ToString(", yyyy");
		}
	}
}
