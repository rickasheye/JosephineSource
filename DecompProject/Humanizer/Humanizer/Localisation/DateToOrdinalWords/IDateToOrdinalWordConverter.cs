using System;

namespace Humanizer.Localisation.DateToOrdinalWords
{
	// Token: 0x0200006E RID: 110
	public interface IDateToOrdinalWordConverter
	{
		// Token: 0x06000230 RID: 560
		string Convert(DateTime date);

		// Token: 0x06000231 RID: 561
		string Convert(DateTime date, GrammaticalCase grammaticalCase);
	}
}
