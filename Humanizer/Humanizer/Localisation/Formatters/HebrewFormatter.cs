using System;

namespace Humanizer.Localisation.Formatters
{
	// Token: 0x02000066 RID: 102
	internal class HebrewFormatter : DefaultFormatter
	{
		// Token: 0x06000218 RID: 536 RVA: 0x0000C5CF File Offset: 0x0000A7CF
		public HebrewFormatter() : base("he")
		{
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0000C5DC File Offset: 0x0000A7DC
		protected override string GetResourceKey(string resourceKey, int number)
		{
			if (number == 2)
			{
				return resourceKey + "_Dual";
			}
			if (number >= 3 && number <= 10)
			{
				return resourceKey + "_Plural";
			}
			return resourceKey;
		}

		// Token: 0x040000C4 RID: 196
		private const string DualPostfix = "_Dual";

		// Token: 0x040000C5 RID: 197
		private const string PluralPostfix = "_Plural";
	}
}
