using System;

namespace Humanizer
{
	// Token: 0x02000011 RID: 17
	public class NoMatchFoundException : Exception
	{
		// Token: 0x0600007A RID: 122 RVA: 0x00002EB3 File Offset: 0x000010B3
		public NoMatchFoundException()
		{
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00002EBB File Offset: 0x000010BB
		public NoMatchFoundException(string message) : base(message)
		{
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00002EC4 File Offset: 0x000010C4
		public NoMatchFoundException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
