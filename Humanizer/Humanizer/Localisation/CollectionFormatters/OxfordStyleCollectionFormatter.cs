using System;

namespace Humanizer.Localisation.CollectionFormatters
{
	// Token: 0x02000072 RID: 114
	internal class OxfordStyleCollectionFormatter : DefaultCollectionFormatter
	{
		// Token: 0x0600023E RID: 574 RVA: 0x0000C975 File Offset: 0x0000AB75
		public OxfordStyleCollectionFormatter(string defaultSeparator) : base(defaultSeparator ?? "and")
		{
		}

		// Token: 0x0600023F RID: 575 RVA: 0x0000C987 File Offset: 0x0000AB87
		protected override string GetConjunctionFormatString(int itemCount)
		{
			if (itemCount <= 2)
			{
				return "{0} {1} {2}";
			}
			return "{0}, {1} {2}";
		}
	}
}
