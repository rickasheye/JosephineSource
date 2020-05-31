using System;

namespace Humanizer.Localisation.Formatters
{
	// Token: 0x02000063 RID: 99
	internal class CroatianFormatter : DefaultFormatter
	{
		// Token: 0x06000208 RID: 520 RVA: 0x0000C41E File Offset: 0x0000A61E
		public CroatianFormatter() : base("hr")
		{
		}

		// Token: 0x06000209 RID: 521 RVA: 0x0000C42B File Offset: 0x0000A62B
		protected override string GetResourceKey(string resourceKey, int number)
		{
			if ((number % 10 == 2 || number % 10 == 3 || number % 10 == 4) && number != 12 && number != 13 && number != 14)
			{
				return resourceKey + "_DualTrialQuadral";
			}
			return resourceKey;
		}

		// Token: 0x040000C1 RID: 193
		private const string DualTrialQuadralPostfix = "_DualTrialQuadral";
	}
}
