using System;

namespace AIMLbot
{
	// Token: 0x02000030 RID: 48
	public class Request
	{
		// Token: 0x060000AF RID: 175 RVA: 0x00006C30 File Offset: 0x00005C30
		public Request(string rawInput, User user, Bot bot)
		{
			this.rawInput = rawInput;
			this.user = user;
			this.bot = bot;
			this.StartedOn = DateTime.Now;
		}

		// Token: 0x04000041 RID: 65
		public string rawInput;

		// Token: 0x04000042 RID: 66
		public DateTime StartedOn;

		// Token: 0x04000043 RID: 67
		public User user;

		// Token: 0x04000044 RID: 68
		public Bot bot;

		// Token: 0x04000045 RID: 69
		public Result result;

		// Token: 0x04000046 RID: 70
		public bool hasTimedOut;
	}
}
