using System;
using System.Collections.Generic;

namespace AIMLbot.Utils
{
	// Token: 0x02000025 RID: 37
	public class SubQuery
	{
		// Token: 0x06000070 RID: 112 RVA: 0x00004B5F File Offset: 0x00003B5F
		public SubQuery(string fullPath)
		{
			this.FullPath = fullPath;
		}

		// Token: 0x04000023 RID: 35
		public string FullPath;

		// Token: 0x04000024 RID: 36
		public string Template = string.Empty;

		// Token: 0x04000025 RID: 37
		public List<string> InputStar = new List<string>();

		// Token: 0x04000026 RID: 38
		public List<string> ThatStar = new List<string>();

		// Token: 0x04000027 RID: 39
		public List<string> TopicStar = new List<string>();
	}
}
