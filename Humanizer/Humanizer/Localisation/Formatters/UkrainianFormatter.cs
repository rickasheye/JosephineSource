using System;
using Humanizer.Localisation.GrammaticalNumber;

namespace Humanizer.Localisation.Formatters
{
	// Token: 0x0200006C RID: 108
	internal class UkrainianFormatter : DefaultFormatter
	{
		// Token: 0x0600022A RID: 554 RVA: 0x0000C777 File Offset: 0x0000A977
		public UkrainianFormatter() : base("uk")
		{
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0000C784 File Offset: 0x0000A984
		protected override string GetResourceKey(string resourceKey, int number)
		{
			RussianGrammaticalNumber grammaticalNumber = RussianGrammaticalNumberDetector.Detect(number);
			string suffix = this.GetSuffix(grammaticalNumber);
			return resourceKey + suffix;
		}

		// Token: 0x0600022C RID: 556 RVA: 0x0000C7A7 File Offset: 0x0000A9A7
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
