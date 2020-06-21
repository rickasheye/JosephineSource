using System;
using System.Collections.Generic;

namespace AIMLbot.Normalize
{
	// Token: 0x02000012 RID: 18
	public class SplitIntoSentences
	{
		// Token: 0x06000035 RID: 53 RVA: 0x00003258 File Offset: 0x00002258
		public SplitIntoSentences(Bot bot, string inputString)
		{
			this.bot = bot;
			this.inputString = inputString;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x0000326E File Offset: 0x0000226E
		public SplitIntoSentences(Bot bot)
		{
			this.bot = bot;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000327D File Offset: 0x0000227D
		public string[] Transform(string inputString)
		{
			this.inputString = inputString;
			return this.Transform();
		}

		// Token: 0x06000038 RID: 56 RVA: 0x0000328C File Offset: 0x0000228C
		public string[] Transform()
		{
			string[] separator = this.bot.Splitters.ToArray();
			string[] array = this.inputString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
			List<string> list = new List<string>();
			foreach (string text in array)
			{
				string text2 = text.Trim();
				if (text2.Length > 0)
				{
					list.Add(text2);
				}
			}
			return list.ToArray();
		}

		// Token: 0x04000014 RID: 20
		private Bot bot;

		// Token: 0x04000015 RID: 21
		private string inputString;
	}
}
