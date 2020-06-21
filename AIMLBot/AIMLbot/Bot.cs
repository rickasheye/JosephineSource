using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using AIMLbot.AIMLTagHandlers;
using AIMLbot.Normalize;
using AIMLbot.Utils;

namespace AIMLbot
{
	// Token: 0x02000029 RID: 41
	public class Bot
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000075 RID: 117 RVA: 0x00004D4C File Offset: 0x00003D4C
		private int MaxLogBufferSize
		{
			get
			{
				return Convert.ToInt32(this.GlobalSettings.grabSetting("maxlogbuffersize"));
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000076 RID: 118 RVA: 0x00004D63 File Offset: 0x00003D63
		private string NotAcceptingUserInputMessage
		{
			get
			{
				return this.GlobalSettings.grabSetting("notacceptinguserinputmessage");
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00004D75 File Offset: 0x00003D75
		public double TimeOut
		{
			get
			{
				return Convert.ToDouble(this.GlobalSettings.grabSetting("timeout"));
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000078 RID: 120 RVA: 0x00004D8C File Offset: 0x00003D8C
		public string TimeOutMessage
		{
			get
			{
				return this.GlobalSettings.grabSetting("timeoutmessage");
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00004D9E File Offset: 0x00003D9E
		public CultureInfo Locale
		{
			get
			{
				return new CultureInfo(this.GlobalSettings.grabSetting("culture"));
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600007A RID: 122 RVA: 0x00004DB5 File Offset: 0x00003DB5
		public Regex Strippers
		{
			get
			{
				return new Regex(this.GlobalSettings.grabSetting("stripperregex"), RegexOptions.IgnorePatternWhitespace);
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00004DCE File Offset: 0x00003DCE
		// (set) Token: 0x0600007C RID: 124 RVA: 0x00004DE0 File Offset: 0x00003DE0
		public string AdminEmail
		{
			get
			{
				return this.GlobalSettings.grabSetting("adminemail");
			}
			set
			{
				if (value.Length <= 0)
				{
					this.GlobalSettings.addSetting("adminemail", "");
					return;
				}
				string pattern = "^(([^<>()[\\]\\\\.,;:\\s@\\\"]+(\\.[^<>()[\\]\\\\.,;:\\s@\\\"]+)*)|(\\\".+\\\"))@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\])|(([a-zA-Z\\-0-9]+\\.)+[a-zA-Z]{2,}))$";
				Regex regex = new Regex(pattern);
				if (regex.IsMatch(value))
				{
					this.GlobalSettings.addSetting("adminemail", value);
					return;
				}
				throw new Exception("The AdminEmail is not a valid email address");
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600007D RID: 125 RVA: 0x00004E40 File Offset: 0x00003E40
		public bool IsLogging
		{
			get
			{
				string text = this.GlobalSettings.grabSetting("islogging");
				return text.ToLower() == "true";
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600007E RID: 126 RVA: 0x00004E74 File Offset: 0x00003E74
		public bool WillCallHome
		{
			get
			{
				string text = this.GlobalSettings.grabSetting("willcallhome");
				return text.ToLower() == "true";
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600007F RID: 127 RVA: 0x00004EA8 File Offset: 0x00003EA8
		public Gender Sex
		{
			get
			{
				Gender result;
				switch (Convert.ToInt32(this.GlobalSettings.grabSetting("gender")))
				{
				case -1:
					result = Gender.Unknown;
					break;
				case 0:
					result = Gender.Female;
					break;
				case 1:
					result = Gender.Male;
					break;
				default:
					result = Gender.Unknown;
					break;
				}
				return result;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00004EF2 File Offset: 0x00003EF2
		public string PathToAIML
		{
			get
			{
				return Path.Combine(Environment.CurrentDirectory, this.GlobalSettings.grabSetting("aimldirectory"));
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000081 RID: 129 RVA: 0x00004F0E File Offset: 0x00003F0E
		public string PathToConfigFiles
		{
			get
			{
				return Path.Combine(Environment.CurrentDirectory, this.GlobalSettings.grabSetting("configdirectory"));
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00004F2A File Offset: 0x00003F2A
		public string PathToLogs
		{
			get
			{
				return Path.Combine(Environment.CurrentDirectory, this.GlobalSettings.grabSetting("logdirectory"));
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000083 RID: 131 RVA: 0x00004F46 File Offset: 0x00003F46
		// (remove) Token: 0x06000084 RID: 132 RVA: 0x00004F5F File Offset: 0x00003F5F
		public event Bot.LogMessageDelegate WrittenToLog;

		// Token: 0x06000085 RID: 133 RVA: 0x00004F78 File Offset: 0x00003F78
		public Bot()
		{
			this.setup();
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00004FE4 File Offset: 0x00003FE4
		public void loadAIMLFromFiles()
		{
			AIMLLoader aimlloader = new AIMLLoader(this);
			aimlloader.loadAIML();
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00005000 File Offset: 0x00004000
		public void loadAIMLFromXML(XmlDocument newAIML, string filename)
		{
			AIMLLoader aimlloader = new AIMLLoader(this);
			aimlloader.loadAIMLFromXML(newAIML, filename);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0000501C File Offset: 0x0000401C
		private void setup()
		{
			this.GlobalSettings = new SettingsDictionary(this);
			this.GenderSubstitutions = new SettingsDictionary(this);
			this.Person2Substitutions = new SettingsDictionary(this);
			this.PersonSubstitutions = new SettingsDictionary(this);
			this.Substitutions = new SettingsDictionary(this);
			this.DefaultPredicates = new SettingsDictionary(this);
			this.CustomTags = new Dictionary<string, TagHandler>();
			this.Graphmaster = new Node();
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00005088 File Offset: 0x00004088
		public void loadSettings()
		{
			string pathToSettings = Path.Combine(Environment.CurrentDirectory, Path.Combine("config", "Settings.xml"));
			this.loadSettings(pathToSettings);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000050B8 File Offset: 0x000040B8
		public void loadSettings(string pathToSettings)
		{
			this.GlobalSettings.loadSettings(pathToSettings);
			if (!this.GlobalSettings.containsSettingCalled("version"))
			{
				this.GlobalSettings.addSetting("version", Environment.Version.ToString());
			}
			if (!this.GlobalSettings.containsSettingCalled("name"))
			{
				this.GlobalSettings.addSetting("name", "Unknown");
			}
			if (!this.GlobalSettings.containsSettingCalled("botmaster"))
			{
				this.GlobalSettings.addSetting("botmaster", "Unknown");
			}
			if (!this.GlobalSettings.containsSettingCalled("master"))
			{
				this.GlobalSettings.addSetting("botmaster", "Unknown");
			}
			if (!this.GlobalSettings.containsSettingCalled("author"))
			{
				this.GlobalSettings.addSetting("author", "Nicholas H.Tollervey");
			}
			if (!this.GlobalSettings.containsSettingCalled("location"))
			{
				this.GlobalSettings.addSetting("location", "Unknown");
			}
			if (!this.GlobalSettings.containsSettingCalled("gender"))
			{
				this.GlobalSettings.addSetting("gender", "-1");
			}
			if (!this.GlobalSettings.containsSettingCalled("birthday"))
			{
				this.GlobalSettings.addSetting("birthday", "2006/11/08");
			}
			if (!this.GlobalSettings.containsSettingCalled("birthplace"))
			{
				this.GlobalSettings.addSetting("birthplace", "Towcester, Northamptonshire, UK");
			}
			if (!this.GlobalSettings.containsSettingCalled("website"))
			{
				this.GlobalSettings.addSetting("website", "http://sourceforge.net/projects/aimlbot");
			}
			if (this.GlobalSettings.containsSettingCalled("adminemail"))
			{
				string adminEmail = this.GlobalSettings.grabSetting("adminemail");
				this.AdminEmail = adminEmail;
			}
			else
			{
				this.GlobalSettings.addSetting("adminemail", "");
			}
			if (!this.GlobalSettings.containsSettingCalled("islogging"))
			{
				this.GlobalSettings.addSetting("islogging", "False");
			}
			if (!this.GlobalSettings.containsSettingCalled("willcallhome"))
			{
				this.GlobalSettings.addSetting("willcallhome", "False");
			}
			if (!this.GlobalSettings.containsSettingCalled("timeout"))
			{
				this.GlobalSettings.addSetting("timeout", "2000");
			}
			if (!this.GlobalSettings.containsSettingCalled("timeoutmessage"))
			{
				this.GlobalSettings.addSetting("timeoutmessage", "ERROR: The request has timed out.");
			}
			if (!this.GlobalSettings.containsSettingCalled("culture"))
			{
				this.GlobalSettings.addSetting("culture", "en-US");
			}
			if (!this.GlobalSettings.containsSettingCalled("splittersfile"))
			{
				this.GlobalSettings.addSetting("splittersfile", "Splitters.xml");
			}
			if (!this.GlobalSettings.containsSettingCalled("person2substitutionsfile"))
			{
				this.GlobalSettings.addSetting("person2substitutionsfile", "Person2Substitutions.xml");
			}
			if (!this.GlobalSettings.containsSettingCalled("personsubstitutionsfile"))
			{
				this.GlobalSettings.addSetting("personsubstitutionsfile", "PersonSubstitutions.xml");
			}
			if (!this.GlobalSettings.containsSettingCalled("gendersubstitutionsfile"))
			{
				this.GlobalSettings.addSetting("gendersubstitutionsfile", "GenderSubstitutions.xml");
			}
			if (!this.GlobalSettings.containsSettingCalled("defaultpredicates"))
			{
				this.GlobalSettings.addSetting("defaultpredicates", "DefaultPredicates.xml");
			}
			if (!this.GlobalSettings.containsSettingCalled("substitutionsfile"))
			{
				this.GlobalSettings.addSetting("substitutionsfile", "Substitutions.xml");
			}
			if (!this.GlobalSettings.containsSettingCalled("aimldirectory"))
			{
				this.GlobalSettings.addSetting("aimldirectory", "aiml");
			}
			if (!this.GlobalSettings.containsSettingCalled("configdirectory"))
			{
				this.GlobalSettings.addSetting("configdirectory", "config");
			}
			if (!this.GlobalSettings.containsSettingCalled("logdirectory"))
			{
				this.GlobalSettings.addSetting("logdirectory", "logs");
			}
			if (!this.GlobalSettings.containsSettingCalled("maxlogbuffersize"))
			{
				this.GlobalSettings.addSetting("maxlogbuffersize", "64");
			}
			if (!this.GlobalSettings.containsSettingCalled("notacceptinguserinputmessage"))
			{
				this.GlobalSettings.addSetting("notacceptinguserinputmessage", "This bot is currently set to not accept user input.");
			}
			if (!this.GlobalSettings.containsSettingCalled("stripperregex"))
			{
				this.GlobalSettings.addSetting("stripperregex", "[^0-9a-zA-Z]");
			}
			this.Person2Substitutions.loadSettings(Path.Combine(this.PathToConfigFiles, this.GlobalSettings.grabSetting("person2substitutionsfile")));
			this.PersonSubstitutions.loadSettings(Path.Combine(this.PathToConfigFiles, this.GlobalSettings.grabSetting("personsubstitutionsfile")));
			this.GenderSubstitutions.loadSettings(Path.Combine(this.PathToConfigFiles, this.GlobalSettings.grabSetting("gendersubstitutionsfile")));
			this.DefaultPredicates.loadSettings(Path.Combine(this.PathToConfigFiles, this.GlobalSettings.grabSetting("defaultpredicates")));
			this.Substitutions.loadSettings(Path.Combine(this.PathToConfigFiles, this.GlobalSettings.grabSetting("substitutionsfile")));
			this.loadSplitters(Path.Combine(this.PathToConfigFiles, this.GlobalSettings.grabSetting("splittersfile")));
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00005614 File Offset: 0x00004614
		private void loadSplitters(string pathToSplitters)
		{
			FileInfo fileInfo = new FileInfo(pathToSplitters);
			if (fileInfo.Exists)
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(pathToSplitters);
				if (xmlDocument.ChildNodes.Count == 2 && xmlDocument.LastChild.HasChildNodes)
				{
					foreach (object obj in xmlDocument.LastChild.ChildNodes)
					{
						XmlNode xmlNode = (XmlNode)obj;
						if (xmlNode.Name == "item" & xmlNode.Attributes.Count == 1)
						{
							string value = xmlNode.Attributes["value"].Value;
							this.Splitters.Add(value);
						}
					}
				}
			}
			if (this.Splitters.Count == 0)
			{
				this.Splitters.Add(".");
				this.Splitters.Add("!");
				this.Splitters.Add("?");
				this.Splitters.Add(";");
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00005744 File Offset: 0x00004744
		public void writeToLog(string message)
		{
			this.LastLogMessage = message;
			if (this.IsLogging)
			{
				this.LogBuffer.Add(DateTime.Now.ToString() + ": " + message + Environment.NewLine);
				if (this.LogBuffer.Count > this.MaxLogBufferSize - 1)
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(this.PathToLogs);
					if (!directoryInfo.Exists)
					{
						directoryInfo.Create();
					}
					string path = DateTime.Now.ToString("yyyyMMdd") + ".log";
					FileInfo fileInfo = new FileInfo(Path.Combine(this.PathToLogs, path));
					StreamWriter streamWriter;
					if (!fileInfo.Exists)
					{
						streamWriter = fileInfo.CreateText();
					}
					else
					{
						streamWriter = fileInfo.AppendText();
					}
					foreach (string value in this.LogBuffer)
					{
						streamWriter.WriteLine(value);
					}
					streamWriter.Close();
					this.LogBuffer.Clear();
				}
			}
			if (!object.Equals(null, this.WrittenToLog))
			{
				this.WrittenToLog();
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00005880 File Offset: 0x00004880
		public Result Chat(string rawInput, string UserGUID)
		{
			Request request = new Request(rawInput, new User(UserGUID, this), this);
			return this.Chat(request);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000058A4 File Offset: 0x000048A4
		public Result Chat(Request request)
		{
			Result result = new Result(request.user, this, request);
			if (this.isAcceptingUserInput)
			{
				AIMLLoader aimlloader = new AIMLLoader(this);
				SplitIntoSentences splitIntoSentences = new SplitIntoSentences(this);
				string[] array = splitIntoSentences.Transform(request.rawInput);
				foreach (string text in array)
				{
					result.InputSentences.Add(text);
					string item = aimlloader.generatePath(text, request.user.getLastBotOutput(), request.user.Topic, true);
					result.NormalizedPaths.Add(item);
				}
				foreach (string text2 in result.NormalizedPaths)
				{
					SubQuery subQuery = new SubQuery(text2);
					subQuery.Template = this.Graphmaster.evaluate(text2, subQuery, request, MatchState.UserInput, new StringBuilder());
					result.SubQueries.Add(subQuery);
				}
				using (List<SubQuery>.Enumerator enumerator2 = result.SubQueries.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						SubQuery subQuery2 = enumerator2.Current;
						if (subQuery2.Template.Length > 0)
						{
							try
							{
								XmlNode node = AIMLTagHandler.getNode(subQuery2.Template);
								string text3 = this.processNode(node, subQuery2, request, result, request.user);
								if (text3.Length > 0)
								{
									result.OutputSentences.Add(text3);
								}
							}
							catch (Exception ex)
							{
								if (this.WillCallHome)
								{
									this.phoneHome(ex.Message, request);
								}
								this.writeToLog(string.Concat(new string[]
								{
									"WARNING! A problem was encountered when trying to process the input: ",
									request.rawInput,
									" with the template: \"",
									subQuery2.Template,
									"\""
								}));
							}
						}
					}
					goto IL_1E4;
				}
			}
			result.OutputSentences.Add(this.NotAcceptingUserInputMessage);
			IL_1E4:
			result.Duration = DateTime.Now - request.StartedOn;
			request.user.addResult(result);
			return result;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00005AE0 File Offset: 0x00004AE0
		private string processNode(XmlNode node, SubQuery query, Request request, Result result, User user)
		{
			if (request.StartedOn.AddMilliseconds(request.bot.TimeOut) < DateTime.Now)
			{
				request.bot.writeToLog(string.Concat(new string[]
				{
					"WARNING! Request timeout. User: ",
					request.user.UserID,
					" raw input: \"",
					request.rawInput,
					"\" processing template: \"",
					query.Template,
					"\""
				}));
				request.hasTimedOut = true;
				return string.Empty;
			}
			string text = node.Name.ToLower();
			if (text == "template")
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (node.HasChildNodes)
				{
					foreach (object obj in node.ChildNodes)
					{
						XmlNode node2 = (XmlNode)obj;
						stringBuilder.Append(this.processNode(node2, query, request, result, user));
					}
				}
				return stringBuilder.ToString();
			}
			AIMLTagHandler aimltagHandler = null;
			aimltagHandler = this.getBespokeTags(user, query, request, result, node);
			if (object.Equals(null, aimltagHandler))
			{
				string key;
				switch (key = text)
				{
				case "bot":
					aimltagHandler = new bot(this, user, query, request, result, node);
					goto IL_53F;
				case "condition":
					aimltagHandler = new condition(this, user, query, request, result, node);
					goto IL_53F;
				case "date":
					aimltagHandler = new date(this, user, query, request, result, node);
					goto IL_53F;
				case "formal":
					aimltagHandler = new formal(this, user, query, request, result, node);
					goto IL_53F;
				case "gender":
					aimltagHandler = new gender(this, user, query, request, result, node);
					goto IL_53F;
				case "get":
					aimltagHandler = new get(this, user, query, request, result, node);
					goto IL_53F;
				case "gossip":
					aimltagHandler = new gossip(this, user, query, request, result, node);
					goto IL_53F;
				case "id":
					aimltagHandler = new id(this, user, query, request, result, node);
					goto IL_53F;
				case "input":
					aimltagHandler = new input(this, user, query, request, result, node);
					goto IL_53F;
				case "javascript":
					aimltagHandler = new javascript(this, user, query, request, result, node);
					goto IL_53F;
				case "learn":
					aimltagHandler = new learn(this, user, query, request, result, node);
					goto IL_53F;
				case "lowercase":
					aimltagHandler = new lowercase(this, user, query, request, result, node);
					goto IL_53F;
				case "person":
					aimltagHandler = new person(this, user, query, request, result, node);
					goto IL_53F;
				case "person2":
					aimltagHandler = new person2(this, user, query, request, result, node);
					goto IL_53F;
				case "random":
					aimltagHandler = new random(this, user, query, request, result, node);
					goto IL_53F;
				case "sentence":
					aimltagHandler = new sentence(this, user, query, request, result, node);
					goto IL_53F;
				case "set":
					aimltagHandler = new set(this, user, query, request, result, node);
					goto IL_53F;
				case "size":
					aimltagHandler = new size(this, user, query, request, result, node);
					goto IL_53F;
				case "sr":
					aimltagHandler = new sr(this, user, query, request, result, node);
					goto IL_53F;
				case "srai":
					aimltagHandler = new srai(this, user, query, request, result, node);
					goto IL_53F;
				case "star":
					aimltagHandler = new star(this, user, query, request, result, node);
					goto IL_53F;
				case "system":
					aimltagHandler = new system(this, user, query, request, result, node);
					goto IL_53F;
				case "that":
					aimltagHandler = new that(this, user, query, request, result, node);
					goto IL_53F;
				case "thatstar":
					aimltagHandler = new thatstar(this, user, query, request, result, node);
					goto IL_53F;
				case "think":
					aimltagHandler = new think(this, user, query, request, result, node);
					goto IL_53F;
				case "topicstar":
					aimltagHandler = new topicstar(this, user, query, request, result, node);
					goto IL_53F;
				case "uppercase":
					aimltagHandler = new uppercase(this, user, query, request, result, node);
					goto IL_53F;
				case "version":
					aimltagHandler = new version(this, user, query, request, result, node);
					goto IL_53F;
				}
				aimltagHandler = null;
			}
			IL_53F:
			if (object.Equals(null, aimltagHandler))
			{
				return node.InnerText;
			}
			if (aimltagHandler.isRecursive)
			{
				if (node.HasChildNodes)
				{
					foreach (object obj2 in node.ChildNodes)
					{
						XmlNode xmlNode = (XmlNode)obj2;
						if (xmlNode.NodeType != XmlNodeType.Text)
						{
							xmlNode.InnerXml = this.processNode(xmlNode, query, request, result, user);
						}
					}
				}
				return aimltagHandler.Transform();
			}
			string str = aimltagHandler.Transform();
			XmlNode node3 = AIMLTagHandler.getNode("<node>" + str + "</node>");
			if (node3.HasChildNodes)
			{
				StringBuilder stringBuilder2 = new StringBuilder();
				foreach (object obj3 in node3.ChildNodes)
				{
					XmlNode node4 = (XmlNode)obj3;
					stringBuilder2.Append(this.processNode(node4, query, request, result, user));
				}
				return stringBuilder2.ToString();
			}
			return node3.InnerXml;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000616C File Offset: 0x0000516C
		public AIMLTagHandler getBespokeTags(User user, SubQuery query, Request request, Result result, XmlNode node)
		{
			if (!this.CustomTags.ContainsKey(node.Name.ToLower()))
			{
				return null;
			}
			TagHandler tagHandler = this.CustomTags[node.Name.ToLower()];
			AIMLTagHandler aimltagHandler = tagHandler.Instantiate(this.LateBindingAssemblies);
			if (object.Equals(null, aimltagHandler))
			{
				return null;
			}
			aimltagHandler.user = user;
			aimltagHandler.query = query;
			aimltagHandler.request = request;
			aimltagHandler.result = result;
			aimltagHandler.templateNode = node;
			aimltagHandler.bot = this;
			return aimltagHandler;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000061F4 File Offset: 0x000051F4
		public void saveToBinaryFile(string path)
		{
			FileInfo fileInfo = new FileInfo(path);
			if (fileInfo.Exists)
			{
				fileInfo.Delete();
			}
			FileStream fileStream = File.Create(path);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.Serialize(fileStream, this.Graphmaster);
			fileStream.Close();
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00006238 File Offset: 0x00005238
		public void loadFromBinaryFile(string path)
		{
			FileStream fileStream = File.OpenRead(path);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			this.Graphmaster = (Node)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000626C File Offset: 0x0000526C
		public void loadCustomTagHandlers(string pathToDLL)
		{
			Assembly assembly = Assembly.LoadFrom(pathToDLL);
			Type[] types = assembly.GetTypes();
			for (int i = 0; i < types.Length; i++)
			{
				object[] customAttributes = types[i].GetCustomAttributes(false);
				for (int j = 0; j < customAttributes.Length; j++)
				{
					if (customAttributes[j] is CustomTagAttribute)
					{
						if (!this.LateBindingAssemblies.ContainsKey(assembly.FullName))
						{
							this.LateBindingAssemblies.Add(assembly.FullName, assembly);
						}
						TagHandler tagHandler = new TagHandler();
						tagHandler.AssemblyName = assembly.FullName;
						tagHandler.ClassName = types[i].FullName;
						tagHandler.TagName = types[i].Name.ToLower();
						if (this.CustomTags.ContainsKey(tagHandler.TagName))
						{
							throw new Exception(string.Concat(new string[]
							{
								"ERROR! Unable to add the custom tag: <",
								tagHandler.TagName,
								">, found in: ",
								pathToDLL,
								" as a handler for this tag already exists."
							}));
						}
						this.CustomTags.Add(tagHandler.TagName, tagHandler);
					}
				}
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00006390 File Offset: 0x00005390
		public void phoneHome(string errorMessage, Request request)
		{
			MailMessage mailMessage = new MailMessage("donotreply@aimlbot.com", this.AdminEmail);
			mailMessage.Subject = "WARNING! AIMLBot has encountered a problem...";
			string text = "Dear Botmaster,\r\n\r\nThis is an automatically generated email to report errors with your bot.\r\n\r\nAt *TIME* the bot encountered the following error:\r\n\r\n\"*MESSAGE*\"\r\n\r\nwhilst processing the following input:\r\n\r\n\"*RAWINPUT*\"\r\n\r\nfrom the user with an id of: *USER*\r\n\r\nThe normalized paths generated by the raw input were as follows:\r\n\r\n*PATHS*\r\n\r\nPlease check your AIML!\r\n\r\nRegards,\r\n\r\nThe AIMLbot program.\r\n";
			text = text.Replace("*TIME*", DateTime.Now.ToString());
			text = text.Replace("*MESSAGE*", errorMessage);
			text = text.Replace("*RAWINPUT*", request.rawInput);
			text = text.Replace("*USER*", request.user.UserID);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string str in request.result.NormalizedPaths)
			{
				stringBuilder.Append(str + Environment.NewLine);
			}
			text = text.Replace("*PATHS*", stringBuilder.ToString());
			mailMessage.Body = text;
			mailMessage.IsBodyHtml = false;
			try
			{
				if (mailMessage.To.Count > 0)
				{
					SmtpClient smtpClient = new SmtpClient();
					smtpClient.Send(mailMessage);
				}
			}
			catch
			{
			}
		}

		// Token: 0x0400002C RID: 44
		public SettingsDictionary GlobalSettings;

		// Token: 0x0400002D RID: 45
		public SettingsDictionary GenderSubstitutions;

		// Token: 0x0400002E RID: 46
		public SettingsDictionary Person2Substitutions;

		// Token: 0x0400002F RID: 47
		public SettingsDictionary PersonSubstitutions;

		// Token: 0x04000030 RID: 48
		public SettingsDictionary Substitutions;

		// Token: 0x04000031 RID: 49
		public SettingsDictionary DefaultPredicates;

		// Token: 0x04000032 RID: 50
		private Dictionary<string, TagHandler> CustomTags;

		// Token: 0x04000033 RID: 51
		private Dictionary<string, Assembly> LateBindingAssemblies = new Dictionary<string, Assembly>();

		// Token: 0x04000034 RID: 52
		public List<string> Splitters = new List<string>();

		// Token: 0x04000035 RID: 53
		private List<string> LogBuffer = new List<string>();

		// Token: 0x04000036 RID: 54
		public bool isAcceptingUserInput = true;

		// Token: 0x04000037 RID: 55
		public DateTime StartedOn = DateTime.Now;

		// Token: 0x04000038 RID: 56
		public int Size;

		// Token: 0x04000039 RID: 57
		public Node Graphmaster;

		// Token: 0x0400003A RID: 58
		public bool TrustAIML = true;

		// Token: 0x0400003B RID: 59
		public int MaxThatSize = 256;

		// Token: 0x0400003D RID: 61
		public string LastLogMessage = string.Empty;

		// Token: 0x0200002A RID: 42
		// (Invoke) Token: 0x06000096 RID: 150
		public delegate void LogMessageDelegate();
	}
}
