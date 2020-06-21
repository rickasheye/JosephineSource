using System;
using System.Collections.Generic;
using System.Globalization;

namespace Humanizer.Configuration
{
	// Token: 0x02000080 RID: 128
	public class LocaliserRegistry<TLocaliser> where TLocaliser : class
	{
		// Token: 0x0600026E RID: 622 RVA: 0x0000DB10 File Offset: 0x0000BD10
		public LocaliserRegistry(TLocaliser defaultLocaliser)
		{
			this._defaultLocaliser = ((CultureInfo culture) => defaultLocaliser);
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0000DB4D File Offset: 0x0000BD4D
		public LocaliserRegistry(Func<CultureInfo, TLocaliser> defaultLocaliser)
		{
			this._defaultLocaliser = defaultLocaliser;
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0000DB67 File Offset: 0x0000BD67
		public TLocaliser ResolveForUiCulture()
		{
			return this.ResolveForCulture(null);
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000DB70 File Offset: 0x0000BD70
		public TLocaliser ResolveForCulture(CultureInfo culture)
		{
			return this.FindLocaliser(culture ?? CultureInfo.CurrentUICulture)(culture);
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0000DB88 File Offset: 0x0000BD88
		public void Register(string localeCode, TLocaliser localiser)
		{
			this._localisers[localeCode] = ((CultureInfo culture) => localiser);
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000DBBA File Offset: 0x0000BDBA
		public void Register(string localeCode, Func<CultureInfo, TLocaliser> localiser)
		{
			this._localisers[localeCode] = localiser;
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0000DBCC File Offset: 0x0000BDCC
		private Func<CultureInfo, TLocaliser> FindLocaliser(CultureInfo culture)
		{
			Func<CultureInfo, TLocaliser> localiser;
			if (this._localisers.TryGetValue(culture.Name, out localiser))
			{
				return localiser;
			}
			if (this._localisers.TryGetValue(culture.TwoLetterISOLanguageName, out localiser))
			{
				return localiser;
			}
			return this._defaultLocaliser;
		}

		// Token: 0x040000E0 RID: 224
		private readonly IDictionary<string, Func<CultureInfo, TLocaliser>> _localisers = new Dictionary<string, Func<CultureInfo, TLocaliser>>();

		// Token: 0x040000E1 RID: 225
		private readonly Func<CultureInfo, TLocaliser> _defaultLocaliser;
	}
}
