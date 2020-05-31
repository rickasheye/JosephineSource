using System;
using System.Collections.Generic;
using System.Text;
using AIMLbot.Utils;

namespace AIMLbot
{
	// Token: 0x0200001A RID: 26
	public class Result
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600004B RID: 75 RVA: 0x000037E0 File Offset: 0x000027E0
		public string RawInput
		{
			get
			{
				return this.request.rawInput;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600004C RID: 76 RVA: 0x000037F0 File Offset: 0x000027F0
		public string Output
		{
			get
			{
				if (this.OutputSentences.Count > 0)
				{
					return this.RawOutput;
				}
				if (this.request.hasTimedOut)
				{
					return this.bot.TimeOutMessage;
				}
				StringBuilder stringBuilder = new StringBuilder();
				foreach (string str in this.NormalizedPaths)
				{
					stringBuilder.Append(str + Environment.NewLine);
				}
				this.bot.writeToLog(string.Concat(new string[]
				{
					"The bot could not find any response for the input: ",
					this.RawInput,
					" with the path(s): ",
					Environment.NewLine,
					stringBuilder.ToString(),
					" from the user with an id: ",
					this.user.UserID
				}));
				return string.Empty;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600004D RID: 77 RVA: 0x000038E0 File Offset: 0x000028E0
		public string RawOutput
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (string text in this.OutputSentences)
				{
					string text2 = text.Trim();
					if (!this.checkEndsAsSentence(text2))
					{
						text2 += ".";
					}
					stringBuilder.Append(text2 + " ");
				}
				return stringBuilder.ToString().Trim();
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000396C File Offset: 0x0000296C
		public Result(User user, Bot bot, Request request)
		{
			this.user = user;
			this.bot = bot;
			this.request = request;
			this.request.result = this;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000039CC File Offset: 0x000029CC
		public override string ToString()
		{
			return this.Output;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000039D4 File Offset: 0x000029D4
		private bool checkEndsAsSentence(string sentence)
		{
			foreach (string value in this.bot.Splitters)
			{
				if (sentence.Trim().EndsWith(value))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0400001A RID: 26
		public Bot bot;

		// Token: 0x0400001B RID: 27
		public User user;

		// Token: 0x0400001C RID: 28
		public Request request;

		// Token: 0x0400001D RID: 29
		public List<string> NormalizedPaths = new List<string>();

		// Token: 0x0400001E RID: 30
		public TimeSpan Duration;

		// Token: 0x0400001F RID: 31
		public List<SubQuery> SubQueries = new List<SubQuery>();

		// Token: 0x04000020 RID: 32
		public List<string> OutputSentences = new List<string>();

		// Token: 0x04000021 RID: 33
		public List<string> InputSentences = new List<string>();
	}
}
