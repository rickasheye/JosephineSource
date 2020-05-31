using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.CollectionFormatters
{
	// Token: 0x02000071 RID: 113
	public interface ICollectionFormatter
	{
		// Token: 0x0600023A RID: 570
		string Humanize<T>(IEnumerable<T> collection);

		// Token: 0x0600023B RID: 571
		string Humanize<T>(IEnumerable<T> collection, Func<T, string> objectFormatter);

		// Token: 0x0600023C RID: 572
		string Humanize<T>(IEnumerable<T> collection, string separator);

		// Token: 0x0600023D RID: 573
		string Humanize<T>(IEnumerable<T> collection, Func<T, string> objectFormatter, string separator);
	}
}
