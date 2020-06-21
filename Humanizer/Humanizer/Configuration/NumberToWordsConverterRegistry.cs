using System;
using System.Globalization;
using Humanizer.Localisation.NumberToWords;

namespace Humanizer.Configuration
{
	// Token: 0x02000081 RID: 129
	internal class NumberToWordsConverterRegistry : LocaliserRegistry<INumberToWordsConverter>
	{
		// Token: 0x06000275 RID: 629 RVA: 0x0000DC10 File Offset: 0x0000BE10
		public NumberToWordsConverterRegistry() : base((CultureInfo culture) => new DefaultNumberToWordsConverter(culture))
		{
			base.Register("af", new AfrikaansNumberToWordsConverter());
			base.Register("en", new EnglishNumberToWordsConverter());
			base.Register("ar", new ArabicNumberToWordsConverter());
			base.Register("fa", new FarsiNumberToWordsConverter());
			base.Register("es", new SpanishNumberToWordsConverter());
			base.Register("pl", (CultureInfo culture) => new PolishNumberToWordsConverter(culture));
			base.Register("pt-BR", new BrazilianPortugueseNumberToWordsConverter());
			base.Register("ro", new RomanianNumberToWordsConverter());
			base.Register("ru", new RussianNumberToWordsConverter());
			base.Register("fi", new FinnishNumberToWordsConverter());
			base.Register("fr-BE", new FrenchBelgianNumberToWordsConverter());
			base.Register("fr-CH", new FrenchSwissNumberToWordsConverter());
			base.Register("fr", new FrenchNumberToWordsConverter());
			base.Register("nl", new DutchNumberToWordsConverter());
			base.Register("he", (CultureInfo culture) => new HebrewNumberToWordsConverter(culture));
			base.Register("sl", (CultureInfo culture) => new SlovenianNumberToWordsConverter(culture));
			base.Register("de", new GermanNumberToWordsConverter());
			base.Register("bn-BD", new BanglaNumberToWordsConverter());
			base.Register("tr", new TurkishNumberToWordConverter());
			base.Register("it", new ItalianNumberToWordsConverter());
			base.Register("uk", new UkrainianNumberToWordsConverter());
			base.Register("uz-Latn-UZ", new UzbekLatnNumberToWordConverter());
			base.Register("uz-Cyrl-UZ", new UzbekCyrlNumberToWordConverter());
			base.Register("sr", (CultureInfo culture) => new SerbianCyrlNumberToWordsConverter(culture));
			base.Register("sr-Latn", (CultureInfo culture) => new SerbianNumberToWordsConverter(culture));
			base.Register("nb", new NorwegianBokmalNumberToWordsConverter());
		}
	}
}
