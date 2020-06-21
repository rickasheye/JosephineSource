using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using AIMLbot.Normalize;

namespace AIMLbot.Utils
{
	// Token: 0x0200000B RID: 11
	[Serializable]
	public class Node
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600001B RID: 27 RVA: 0x000027D7 File Offset: 0x000017D7
		public int NumberOfChildNodes
		{
			get
			{
				return this.children.Count;
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000027E4 File Offset: 0x000017E4
		public void addCategory(string path, string template, string filename)
		{
			if (template.Length == 0)
			{
				throw new XmlException(string.Concat(new string[]
				{
					"The category with a pattern: ",
					path,
					" found in file: ",
					filename,
					" has an empty template tag. ABORTING"
				}));
			}
			if (path.Trim().Length == 0)
			{
				this.template = template;
				this.filename = filename;
				return;
			}
			string[] array = path.Trim().Split(" ".ToCharArray());
			string text = MakeCaseInsensitive.TransformInput(array[0]);
			string path2 = path.Substring(text.Length, path.Length - text.Length).Trim();
			if (this.children.ContainsKey(text))
			{
				Node node = this.children[text];
				node.addCategory(path2, template, filename);
				return;
			}
			Node node2 = new Node();
			node2.word = text;
			node2.addCategory(path2, template, filename);
			this.children.Add(node2.word, node2);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000028E0 File Offset: 0x000018E0
		public string evaluate(string path, SubQuery query, Request request, MatchState matchstate, StringBuilder wildcard)
		{
			if (request.StartedOn.AddMilliseconds(request.bot.TimeOut) < DateTime.Now)
			{
				request.bot.writeToLog(string.Concat(new string[]
				{
					"WARNING! Request timeout. User: ",
					request.user.UserID,
					" raw input: \"",
					request.rawInput,
					"\""
				}));
				request.hasTimedOut = true;
				return string.Empty;
			}
			path = path.Trim();
			if (this.children.Count == 0)
			{
				if (path.Length > 0)
				{
					this.storeWildCard(path, wildcard);
				}
				return this.template;
			}
			if (path.Length == 0)
			{
				return this.template;
			}
			string[] array = path.Split(" \r\n\t".ToCharArray());
			string text = MakeCaseInsensitive.TransformInput(array[0]);
			string path2 = path.Substring(text.Length, path.Length - text.Length);
			if (this.children.ContainsKey("_"))
			{
				Node node = this.children["_"];
				StringBuilder stringBuilder = new StringBuilder();
				this.storeWildCard(array[0], stringBuilder);
				string text2 = node.evaluate(path2, query, request, matchstate, stringBuilder);
				if (text2.Length > 0)
				{
					if (stringBuilder.Length > 0)
					{
						switch (matchstate)
						{
						case MatchState.UserInput:
							query.InputStar.Add(stringBuilder.ToString());
							stringBuilder.Remove(0, stringBuilder.Length);
							break;
						case MatchState.That:
							query.ThatStar.Add(stringBuilder.ToString());
							break;
						case MatchState.Topic:
							query.TopicStar.Add(stringBuilder.ToString());
							break;
						}
					}
					return text2;
				}
			}
			if (this.children.ContainsKey(text))
			{
				MatchState matchstate2 = matchstate;
				if (text == "<THAT>")
				{
					matchstate2 = MatchState.That;
				}
				else if (text == "<TOPIC>")
				{
					matchstate2 = MatchState.Topic;
				}
				Node node2 = this.children[text];
				StringBuilder stringBuilder2 = new StringBuilder();
				string text3 = node2.evaluate(path2, query, request, matchstate2, stringBuilder2);
				if (text3.Length > 0)
				{
					if (stringBuilder2.Length > 0)
					{
						switch (matchstate)
						{
						case MatchState.UserInput:
							query.InputStar.Add(stringBuilder2.ToString());
							stringBuilder2.Remove(0, stringBuilder2.Length);
							break;
						case MatchState.That:
							query.ThatStar.Add(stringBuilder2.ToString());
							stringBuilder2.Remove(0, stringBuilder2.Length);
							break;
						case MatchState.Topic:
							query.TopicStar.Add(stringBuilder2.ToString());
							stringBuilder2.Remove(0, stringBuilder2.Length);
							break;
						}
					}
					return text3;
				}
			}
			if (this.children.ContainsKey("*"))
			{
				Node node3 = this.children["*"];
				StringBuilder stringBuilder3 = new StringBuilder();
				this.storeWildCard(array[0], stringBuilder3);
				string text4 = node3.evaluate(path2, query, request, matchstate, stringBuilder3);
				if (text4.Length > 0)
				{
					if (stringBuilder3.Length > 0)
					{
						switch (matchstate)
						{
						case MatchState.UserInput:
							query.InputStar.Add(stringBuilder3.ToString());
							stringBuilder3.Remove(0, stringBuilder3.Length);
							break;
						case MatchState.That:
							query.ThatStar.Add(stringBuilder3.ToString());
							break;
						case MatchState.Topic:
							query.TopicStar.Add(stringBuilder3.ToString());
							break;
						}
					}
					return text4;
				}
			}
			if (this.word == "_" || this.word == "*")
			{
				this.storeWildCard(array[0], wildcard);
				return this.evaluate(path2, query, request, matchstate, wildcard);
			}
			wildcard = new StringBuilder();
			return string.Empty;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002CA4 File Offset: 0x00001CA4
		private void storeWildCard(string word, StringBuilder wildcard)
		{
			if (wildcard.Length > 0)
			{
				wildcard.Append(" ");
			}
			wildcard.Append(word);
		}

		// Token: 0x0400000C RID: 12
		private Dictionary<string, Node> children = new Dictionary<string, Node>();

		// Token: 0x0400000D RID: 13
		public string template = string.Empty;

		// Token: 0x0400000E RID: 14
		public string filename = string.Empty;

		// Token: 0x0400000F RID: 15
		public string word = string.Empty;
	}
}
