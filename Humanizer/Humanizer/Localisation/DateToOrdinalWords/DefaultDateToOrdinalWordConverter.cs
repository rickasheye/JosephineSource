using System;

namespace Humanizer.Localisation.DateToOrdinalWords
{
	// Token: 0x0200006D RID: 109
	internal class DefaultDateToOrdinalWordConverter : IDateToOrdinalWordConverter
	{
		// Token: 0x0600022D RID: 557 RVA: 0x0000C7C1 File Offset: 0x0000A9C1
		public virtual string Convert(DateTime date)
		{
			return date.Day.Ordinalize() + date.ToString(" MMMM yyyy");
		}

		// Token: 0x0600022E RID: 558 RVA: 0x0000C7E0 File Offset: 0x0000A9E0
		public virtual string Convert(DateTime date, GrammaticalCase grammaticalCase)
		{
			return this.Convert(date);
		}
	}
}
