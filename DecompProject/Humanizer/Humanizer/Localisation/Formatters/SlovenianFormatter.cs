using System;

namespace Humanizer.Localisation.Formatters
{
	// Token: 0x0200006B RID: 107
	internal class SlovenianFormatter : DefaultFormatter
	{
		// Token: 0x06000228 RID: 552 RVA: 0x0000C743 File Offset: 0x0000A943
		public SlovenianFormatter() : base("sl")
		{
		}

		// Token: 0x06000229 RID: 553 RVA: 0x0000C750 File Offset: 0x0000A950
		protected override string GetResourceKey(string resourceKey, int number)
		{
			if (number == 2)
			{
				return resourceKey + "_Dual";
			}
			if (number == 3 || number == 4)
			{
				return resourceKey + "_TrialQuadral";
			}
			return resourceKey;
		}

		// Token: 0x040000CE RID: 206
		private const string DualPostfix = "_Dual";

		// Token: 0x040000CF RID: 207
		private const string TrialQuadralPostfix = "_TrialQuadral";
	}
}
