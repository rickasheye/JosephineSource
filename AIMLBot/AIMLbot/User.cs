using System;
using System.Collections.Generic;
using AIMLbot.Utils;

namespace AIMLbot
{
	// Token: 0x0200000C RID: 12
	public class User
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000020 RID: 32 RVA: 0x00002CF7 File Offset: 0x00001CF7
		public string UserID
		{
			get
			{
				return this.id;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000021 RID: 33 RVA: 0x00002CFF File Offset: 0x00001CFF
		public string Topic
		{
			get
			{
				return this.Predicates.grabSetting("topic");
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00002D11 File Offset: 0x00001D11
		public Result LastResult
		{
			get
			{
				if (this.Results.Count > 0)
				{
					return this.Results[0];
				}
				return null;
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002D30 File Offset: 0x00001D30
		public User(string UserID, Bot bot)
		{
			if (UserID.Length > 0)
			{
				this.id = UserID;
				this.bot = bot;
				this.Predicates = new SettingsDictionary(this.bot);
				this.bot.DefaultPredicates.Clone(this.Predicates);
				this.Predicates.addSetting("topic", "*");
				return;
			}
			throw new Exception("The UserID cannot be empty");
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002DAC File Offset: 0x00001DAC
		public string getLastBotOutput()
		{
			if (this.Results.Count > 0)
			{
				return this.Results[0].RawOutput;
			}
			return "*";
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002DD3 File Offset: 0x00001DD3
		public string getThat()
		{
			return this.getThat(0, 0);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002DDD File Offset: 0x00001DDD
		public string getThat(int n)
		{
			return this.getThat(n, 0);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002DE8 File Offset: 0x00001DE8
		public string getThat(int n, int sentence)
		{
			if (n >= 0 & n < this.Results.Count)
			{
				Result result = this.Results[n];
				if (sentence >= 0 & sentence < result.OutputSentences.Count)
				{
					return result.OutputSentences[sentence];
				}
			}
			return string.Empty;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002E44 File Offset: 0x00001E44
		public string getResultSentence()
		{
			return this.getResultSentence(0, 0);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002E4E File Offset: 0x00001E4E
		public string getResultSentence(int n)
		{
			return this.getResultSentence(n, 0);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002E58 File Offset: 0x00001E58
		public string getResultSentence(int n, int sentence)
		{
			if (n >= 0 & n < this.Results.Count)
			{
				Result result = this.Results[n];
				if (sentence >= 0 & sentence < result.InputSentences.Count)
				{
					return result.InputSentences[sentence];
				}
			}
			return string.Empty;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002EB4 File Offset: 0x00001EB4
		public void addResult(Result latestResult)
		{
			this.Results.Insert(0, latestResult);
		}

		// Token: 0x04000010 RID: 16
		private string id;

		// Token: 0x04000011 RID: 17
		public Bot bot;

		// Token: 0x04000012 RID: 18
		private List<Result> Results = new List<Result>();

		// Token: 0x04000013 RID: 19
		public SettingsDictionary Predicates;
	}
}
