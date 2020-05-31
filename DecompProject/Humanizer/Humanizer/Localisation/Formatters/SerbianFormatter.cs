using System;

namespace Humanizer.Localisation.Formatters
{
	// Token: 0x0200006A RID: 106
	internal class SerbianFormatter : DefaultFormatter
	{
		// Token: 0x06000226 RID: 550 RVA: 0x0000C711 File Offset: 0x0000A911
		public SerbianFormatter(string localeCode) : base(localeCode)
		{
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000C71C File Offset: 0x0000A91C
		protected override string GetResourceKey(string resourceKey, int number)
		{
			int mod10 = number % 10;
			if (mod10 > 1 && mod10 < 5)
			{
				return resourceKey + "_Paucal";
			}
			return resourceKey;
		}

		// Token: 0x040000CD RID: 205
		private const string PaucalPostfix = "_Paucal";
	}
}
