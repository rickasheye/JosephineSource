using System;

namespace Humanizer.Localisation.Formatters
{
	// Token: 0x02000062 RID: 98
	internal class ArabicFormatter : DefaultFormatter
	{
		// Token: 0x06000206 RID: 518 RVA: 0x0000C3E9 File Offset: 0x0000A5E9
		public ArabicFormatter() : base("ar")
		{
		}

		// Token: 0x06000207 RID: 519 RVA: 0x0000C3F6 File Offset: 0x0000A5F6
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

		// Token: 0x040000BF RID: 191
		private const string DualPostfix = "_Dual";

		// Token: 0x040000C0 RID: 192
		private const string PluralPostfix = "_Plural";
	}
}
