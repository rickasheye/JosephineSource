using System;
using Humanizer.Localisation.Formatters;

namespace Humanizer.Configuration
{
	// Token: 0x0200007F RID: 127
	internal class FormatterRegistry : LocaliserRegistry<IFormatter>
	{
		// Token: 0x0600026B RID: 619 RVA: 0x0000D8E4 File Offset: 0x0000BAE4
		public FormatterRegistry() : base(new DefaultFormatter("en-US"))
		{
			base.Register("ar", new ArabicFormatter());
			base.Register("he", new HebrewFormatter());
			base.Register("ro", new RomanianFormatter());
			base.Register("ru", new RussianFormatter());
			base.Register("sl", new SlovenianFormatter());
			base.Register("hr", new CroatianFormatter());
			base.Register("sr", new SerbianFormatter("sr"));
			base.Register("sr-Latn", new SerbianFormatter("sr-Latn"));
			base.Register("uk", new UkrainianFormatter());
			this.RegisterCzechSlovakPolishFormatter("cs");
			this.RegisterCzechSlovakPolishFormatter("pl");
			this.RegisterCzechSlovakPolishFormatter("sk");
			this.RegisterDefaultFormatter("bg");
			this.RegisterDefaultFormatter("pt");
			this.RegisterDefaultFormatter("sv");
			this.RegisterDefaultFormatter("tr");
			this.RegisterDefaultFormatter("vi");
			this.RegisterDefaultFormatter("en-US");
			this.RegisterDefaultFormatter("af");
			this.RegisterDefaultFormatter("da");
			this.RegisterDefaultFormatter("de");
			this.RegisterDefaultFormatter("el");
			this.RegisterDefaultFormatter("es");
			this.RegisterDefaultFormatter("fa");
			this.RegisterDefaultFormatter("fi-FI");
			this.RegisterDefaultFormatter("fr");
			this.RegisterDefaultFormatter("fr-BE");
			this.RegisterDefaultFormatter("hu");
			this.RegisterDefaultFormatter("id");
			this.RegisterDefaultFormatter("ja");
			this.RegisterDefaultFormatter("nb");
			this.RegisterDefaultFormatter("nb-NO");
			this.RegisterDefaultFormatter("nl");
			this.RegisterDefaultFormatter("bn-BD");
			this.RegisterDefaultFormatter("it");
			this.RegisterDefaultFormatter("uz-Latn-UZ");
			this.RegisterDefaultFormatter("uz-Cyrl-UZ");
			this.RegisterDefaultFormatter("zh-CN");
			this.RegisterDefaultFormatter("zh-Hans");
			this.RegisterDefaultFormatter("zh-Hant");
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0000DAF0 File Offset: 0x0000BCF0
		private void RegisterDefaultFormatter(string localeCode)
		{
			base.Register(localeCode, new DefaultFormatter(localeCode));
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000DAFF File Offset: 0x0000BCFF
		private void RegisterCzechSlovakPolishFormatter(string localeCode)
		{
			base.Register(localeCode, new CzechSlovakPolishFormatter(localeCode));
		}
	}
}
