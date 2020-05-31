using System;
using Humanizer.Localisation.DateToOrdinalWords;

namespace Humanizer.Configuration
{
	// Token: 0x0200007E RID: 126
	internal class DateToOrdinalWordsConverterRegistry : LocaliserRegistry<IDateToOrdinalWordConverter>
	{
		// Token: 0x0600026A RID: 618 RVA: 0x0000D8A6 File Offset: 0x0000BAA6
		public DateToOrdinalWordsConverterRegistry() : base(new DefaultDateToOrdinalWordConverter())
		{
			base.Register("en-UK", new DefaultDateToOrdinalWordConverter());
			base.Register("de", new DefaultDateToOrdinalWordConverter());
			base.Register("en-US", new UsDateToOrdinalWordsConverter());
		}
	}
}
