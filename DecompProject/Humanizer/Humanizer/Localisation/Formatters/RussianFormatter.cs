using System;
using Humanizer.Localisation.GrammaticalNumber;

namespace Humanizer.Localisation.Formatters
{
	// Token: 0x02000069 RID: 105
	internal class RussianFormatter : DefaultFormatter
	{
		// Token: 0x06000223 RID: 547 RVA: 0x0000C6C7 File Offset: 0x0000A8C7
		public RussianFormatter() : base("ru")
		{
		}

		// Token: 0x06000224 RID: 548 RVA: 0x0000C6D4 File Offset: 0x0000A8D4
		protected override string GetResourceKey(string resourceKey, int number)
		{
			RussianGrammaticalNumber grammaticalNumber = RussianGrammaticalNumberDetector.Detect(number);
			string suffix = this.GetSuffix(grammaticalNumber);
			return resourceKey + suffix;
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0000C6F7 File Offset: 0x0000A8F7
		private string GetSuffix(RussianGrammaticalNumber grammaticalNumber)
		{
			if (grammaticalNumber == RussianGrammaticalNumber.Singular)
			{
				return "_Singular";
			}
			if (grammaticalNumber == RussianGrammaticalNumber.Paucal)
			{
				return "_Paucal";
			}
			return "";
		}
	}
}
