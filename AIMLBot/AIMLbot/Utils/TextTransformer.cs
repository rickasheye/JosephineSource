using System;

namespace AIMLbot.Utils
{
	// Token: 0x02000002 RID: 2
	public abstract class TextTransformer
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00001050
		// (set) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00001058
		public string InputString
		{
			get
			{
				return this.inputString;
			}
			set
			{
				this.inputString = value;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002061 File Offset: 0x00001061
		public string OutputString
		{
			get
			{
				return this.Transform();
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002069 File Offset: 0x00001069
		public TextTransformer(Bot bot, string inputString)
		{
			this.bot = bot;
			this.inputString = inputString;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x0000207F File Offset: 0x0000107F
		public TextTransformer(Bot bot)
		{
			this.bot = bot;
			this.inputString = string.Empty;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002099 File Offset: 0x00001099
		public TextTransformer()
		{
			this.bot = null;
			this.inputString = string.Empty;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000020B3 File Offset: 0x000010B3
		public string Transform(string input)
		{
			this.inputString = input;
			return this.Transform();
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000020C2 File Offset: 0x000010C2
		public string Transform()
		{
			if (this.inputString.Length > 0)
			{
				return this.ProcessChange();
			}
			return string.Empty;
		}

		// Token: 0x06000009 RID: 9
		protected abstract string ProcessChange();

		// Token: 0x04000001 RID: 1
		protected string inputString;

		// Token: 0x04000002 RID: 2
		public Bot bot;
	}
}
