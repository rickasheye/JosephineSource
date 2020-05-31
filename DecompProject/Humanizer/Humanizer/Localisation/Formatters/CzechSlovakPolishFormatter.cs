using System;

namespace Humanizer.Localisation.Formatters
{
	// Token: 0x02000064 RID: 100
	internal class CzechSlovakPolishFormatter : DefaultFormatter
	{
		// Token: 0x0600020A RID: 522 RVA: 0x0000C45E File Offset: 0x0000A65E
		public CzechSlovakPolishFormatter(string localeCode) : base(localeCode)
		{
		}

		// Token: 0x0600020B RID: 523 RVA: 0x0000C467 File Offset: 0x0000A667
		protected override string GetResourceKey(string resourceKey, int number)
		{
			if (number > 1 && number < 5)
			{
				return resourceKey + "_Paucal";
			}
			return resourceKey;
		}

		// Token: 0x040000C2 RID: 194
		private const string PaucalPostfix = "_Paucal";
	}
}
