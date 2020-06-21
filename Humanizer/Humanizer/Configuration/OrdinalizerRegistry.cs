using System;
using Humanizer.Localisation.Ordinalizers;

namespace Humanizer.Configuration
{
	// Token: 0x02000082 RID: 130
	internal class OrdinalizerRegistry : LocaliserRegistry<IOrdinalizer>
	{
		// Token: 0x06000276 RID: 630 RVA: 0x0000DE64 File Offset: 0x0000C064
		public OrdinalizerRegistry() : base(new DefaultOrdinalizer())
		{
			base.Register("de", new GermanOrdinalizer());
			base.Register("en", new EnglishOrdinalizer());
			base.Register("es", new SpanishOrdinalizer());
			base.Register("it", new ItalianOrdinalizer());
			base.Register("nl", new DutchOrdinalizer());
			base.Register("pt", new PortugueseOrdinalizer());
			base.Register("ro", new RomanianOrdinalizer());
			base.Register("ru", new RussianOrdinalizer());
			base.Register("tr", new TurkishOrdinalizer());
			base.Register("uk", new UkrainianOrdinalizer());
		}
	}
}
