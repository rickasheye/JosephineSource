using System;

namespace Humanizer
{
	// Token: 0x0200002B RID: 43
	public interface ITruncator
	{
		// Token: 0x06000114 RID: 276
		string Truncate(string value, int length, string truncationString, TruncateFrom truncateFrom = TruncateFrom.Right);
	}
}
