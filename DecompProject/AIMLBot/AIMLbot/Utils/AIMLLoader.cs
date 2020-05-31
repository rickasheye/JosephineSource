using System;
using System.IO;
using System.Text;
using System.Xml;
using AIMLbot.Normalize;

namespace AIMLbot.Utils
{
	// Token: 0x02000020 RID: 32
	public class AIMLLoader
	{
		// Token: 0x0600005B RID: 91 RVA: 0x00004263 File Offset: 0x00003263
		public AIMLLoader(Bot bot)
		{
			this.bot = bot;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00004272 File Offset: 0x00003272
		public void loadAIML()
		{
			this.loadAIML(this.bot.PathToAIML);
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00004288 File Offset: 0x00003288
		public void loadAIML(string path)
		{
			if (!Directory.Exists(path))
			{
				throw new FileNotFoundException("The directory specified as the path to the AIML files (" + path + ") cannot be found by the AIMLLoader object. Please make sure the directory where you think the AIML files are to be found is the same as the directory specified in the settings file.");
			}
			this.bot.writeToLog("Starting to process AIML files found in the directory " + path);
			string[] files = Directory.GetFiles(path, "*.aiml");
			if (files.Length > 0)
			{
				foreach (string filename in files)
				{
					this.loadAIMLFile(filename);
				}
				this.bot.writeToLog("Finished processing the AIML files. " + Convert.ToString(this.bot.Size) + " categories processed.");
				return;
			}
			throw new FileNotFoundException("Could not find any .aiml files in the specified directory (" + path + "). Please make sure that your aiml file end in a lowercase aiml extension, for example - myFile.aiml is valid but myFile.AIML is not.");
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0000433C File Offset: 0x0000333C
		public void loadAIMLFile(string filename)
		{
			this.bot.writeToLog("Processing AIML file: " + filename);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(filename);
			this.loadAIMLFromXML(xmlDocument, filename);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00004374 File Offset: 0x00003374
		public void loadAIMLFromXML(XmlDocument doc, string filename)
		{
			XmlNodeList childNodes = doc.DocumentElement.ChildNodes;
			foreach (object obj in childNodes)
			{
				XmlNode xmlNode = (XmlNode)obj;
				if (xmlNode.Name == "topic")
				{
					this.processTopic(xmlNode, filename);
				}
				else if (xmlNode.Name == "category")
				{
					this.processCategory(xmlNode, filename);
				}
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00004404 File Offset: 0x00003404
		private void processTopic(XmlNode node, string filename)
		{
			string topicName = "*";
			if (node.Attributes.Count == 1 & node.Attributes[0].Name == "name")
			{
				topicName = node.Attributes["name"].Value;
			}
			foreach (object obj in node.ChildNodes)
			{
				XmlNode xmlNode = (XmlNode)obj;
				if (xmlNode.Name == "category")
				{
					this.processCategory(xmlNode, topicName, filename);
				}
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000044BC File Offset: 0x000034BC
		private void processCategory(XmlNode node, string filename)
		{
			this.processCategory(node, "*", filename);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000044CC File Offset: 0x000034CC
		private void processCategory(XmlNode node, string topicName, string filename)
		{
			XmlNode xmlNode = this.FindNode("pattern", node);
			XmlNode xmlNode2 = this.FindNode("template", node);
			if (object.Equals(null, xmlNode))
			{
				throw new XmlException("Missing pattern tag in a node found in " + filename);
			}
			if (object.Equals(null, xmlNode2))
			{
				throw new XmlException("Missing template tag in the node with pattern: " + xmlNode.InnerText + " found in " + filename);
			}
			string text = this.generatePath(node, topicName, false);
			if (text.Length > 0)
			{
				try
				{
					this.bot.Graphmaster.addCategory(text, xmlNode2.OuterXml, filename);
					this.bot.Size++;
					return;
				}
				catch
				{
					this.bot.writeToLog(string.Concat(new string[]
					{
						"ERROR! Failed to load a new category into the graphmaster where the path = ",
						text,
						" and template = ",
						xmlNode2.OuterXml,
						" produced by a category in the file: ",
						filename
					}));
					return;
				}
			}
			this.bot.writeToLog(string.Concat(new string[]
			{
				"WARNING! Attempted to load a new category with an empty pattern where the path = ",
				text,
				" and template = ",
				xmlNode2.OuterXml,
				" produced by a category in the file: ",
				filename
			}));
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00004614 File Offset: 0x00003614
		public string generatePath(XmlNode node, string topicName, bool isUserInput)
		{
			XmlNode xmlNode = this.FindNode("pattern", node);
			XmlNode xmlNode2 = this.FindNode("that", node);
			string that = "*";
			string pattern;
			if (object.Equals(null, xmlNode))
			{
				pattern = string.Empty;
			}
			else
			{
				pattern = xmlNode.InnerText;
			}
			if (!object.Equals(null, xmlNode2))
			{
				that = xmlNode2.InnerText;
			}
			return this.generatePath(pattern, that, topicName, isUserInput);
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00004674 File Offset: 0x00003674
		private XmlNode FindNode(string name, XmlNode node)
		{
			foreach (object obj in node.ChildNodes)
			{
				XmlNode xmlNode = (XmlNode)obj;
				if (xmlNode.Name == name)
				{
					return xmlNode;
				}
			}
			return null;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000046DC File Offset: 0x000036DC
		public string generatePath(string pattern, string that, string topicName, bool isUserInput)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string text = string.Empty;
			string text2;
			string text3;
			if (this.bot.TrustAIML & !isUserInput)
			{
				text = pattern.Trim();
				text2 = that.Trim();
				text3 = topicName.Trim();
			}
			else
			{
				text = this.Normalize(pattern, isUserInput).Trim();
				text2 = this.Normalize(that, isUserInput).Trim();
				text3 = this.Normalize(topicName, isUserInput).Trim();
			}
			if (text.Length > 0)
			{
				if (text2.Length == 0)
				{
					text2 = "*";
				}
				if (text3.Length == 0)
				{
					text3 = "*";
				}
				if (text2.Length > this.bot.MaxThatSize)
				{
					text2 = "*";
				}
				stringBuilder.Append(text);
				stringBuilder.Append(" <that> ");
				stringBuilder.Append(text2);
				stringBuilder.Append(" <topic> ");
				stringBuilder.Append(text3);
				return stringBuilder.ToString();
			}
			return string.Empty;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000047D4 File Offset: 0x000037D4
		public string Normalize(string input, bool isUserInput)
		{
			StringBuilder stringBuilder = new StringBuilder();
			ApplySubstitutions applySubstitutions = new ApplySubstitutions(this.bot);
			StripIllegalCharacters stripIllegalCharacters = new StripIllegalCharacters(this.bot);
			string text = applySubstitutions.Transform(input);
			string[] array = text.Split(" \r\n\t".ToCharArray());
			foreach (string text2 in array)
			{
				string text3;
				if (isUserInput)
				{
					text3 = stripIllegalCharacters.Transform(text2);
				}
				else if (text2 == "*" || text2 == "_")
				{
					text3 = text2;
				}
				else
				{
					text3 = stripIllegalCharacters.Transform(text2);
				}
				stringBuilder.Append(text3.Trim() + " ");
			}
			return stringBuilder.ToString().Replace("  ", " ");
		}

		// Token: 0x04000022 RID: 34
		private Bot bot;
	}
}
