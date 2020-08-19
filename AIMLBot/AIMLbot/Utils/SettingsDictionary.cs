using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using AIMLbot.Normalize;

namespace AIMLbot.Utils
{
	// Token: 0x0200002F RID: 47
	public class SettingsDictionary
	{
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x000067E9 File Offset: 0x000057E9
		public int Count
		{
			get
			{
				return this.orderedKeys.Count;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x000067F8 File Offset: 0x000057F8
		public XmlDocument DictionaryAsXML
		{
			get
			{
				XmlDocument xmlDocument = new XmlDocument();
				XmlDeclaration newChild = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", "");
				xmlDocument.AppendChild(newChild);
				XmlNode xmlNode = xmlDocument.CreateNode(XmlNodeType.Element, "root", "");
				xmlDocument.AppendChild(xmlNode);
				foreach (string text in this.orderedKeys)
				{
					XmlNode xmlNode2 = xmlDocument.CreateNode(XmlNodeType.Element, "item", "");
					XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("name");
					xmlAttribute.Value = text;
					XmlAttribute xmlAttribute2 = xmlDocument.CreateAttribute("value");
					xmlAttribute2.Value = this.settingsHash[text];
					xmlNode2.Attributes.Append(xmlAttribute);
					xmlNode2.Attributes.Append(xmlAttribute2);
					xmlNode.AppendChild(xmlNode2);
				}
				return xmlDocument;
			}
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000068F4 File Offset: 0x000058F4
		public SettingsDictionary(Bot bot)
		{
			this.bot = bot;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000691C File Offset: 0x0000591C
		public void loadSettings(string pathToSettings)
		{
			if (pathToSettings.Length <= 0)
			{
				throw new FileNotFoundException();
			}
			FileInfo fileInfo = new FileInfo(pathToSettings);
			if (fileInfo.Exists)
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(pathToSettings);
				this.loadSettings(xmlDocument);
				return;
			}else if (!fileInfo.Exists)
			{
				//create a new file but for now throw it
				throw new FileNotFoundException();
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00006964 File Offset: 0x00005964
		public void loadSettings(XmlDocument settingsAsXML)
		{
			this.clearSettings();
			XmlNodeList childNodes = settingsAsXML.DocumentElement.ChildNodes;
			foreach (object obj in childNodes)
			{
				XmlNode xmlNode = (XmlNode)obj;
				if ((xmlNode.Name == "item" & xmlNode.Attributes.Count == 2) && (xmlNode.Attributes[0].Name == "name" & xmlNode.Attributes[1].Name == "value"))
				{
					string value = xmlNode.Attributes["name"].Value;
					string value2 = xmlNode.Attributes["value"].Value;
					if (value.Length > 0)
					{
						this.addSetting(value, value2);
					}
				}
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00006A68 File Offset: 0x00005A68
		public void addSetting(string name, string value)
		{
			string text = MakeCaseInsensitive.TransformInput(name);
			if (text.Length > 0)
			{
				this.removeSetting(text);
				this.orderedKeys.Add(text);
				this.settingsHash.Add(MakeCaseInsensitive.TransformInput(text), value);
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00006AAC File Offset: 0x00005AAC
		public void removeSetting(string name)
		{
			string text = MakeCaseInsensitive.TransformInput(name);
			this.orderedKeys.Remove(text);
			this.removeFromHash(text);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00006AD4 File Offset: 0x00005AD4
		private void removeFromHash(string name)
		{
			string key = MakeCaseInsensitive.TransformInput(name);
			this.settingsHash.Remove(key);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00006AF8 File Offset: 0x00005AF8
		public void updateSetting(string name, string value)
		{
			string text = MakeCaseInsensitive.TransformInput(name);
			if (this.orderedKeys.Contains(text))
			{
				this.removeFromHash(text);
				this.settingsHash.Add(MakeCaseInsensitive.TransformInput(text), value);
			}
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00006B33 File Offset: 0x00005B33
		public void clearSettings()
		{
			this.orderedKeys.Clear();
			this.settingsHash.Clear();
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00006B4C File Offset: 0x00005B4C
		public string grabSetting(string name)
		{
			string text = MakeCaseInsensitive.TransformInput(name);
			if (this.containsSettingCalled(text))
			{
				return this.settingsHash[text];
			}
			return string.Empty;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00006B7C File Offset: 0x00005B7C
		public bool containsSettingCalled(string name)
		{
			string text = MakeCaseInsensitive.TransformInput(name);
			return text.Length > 0 && this.orderedKeys.Contains(text);
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000AD RID: 173 RVA: 0x00006BA8 File Offset: 0x00005BA8
		public string[] SettingNames
		{
			get
			{
				string[] array = new string[this.orderedKeys.Count];
				this.orderedKeys.CopyTo(array, 0);
				return array;
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00006BD4 File Offset: 0x00005BD4
		public void Clone(SettingsDictionary target)
		{
			foreach (string name in this.orderedKeys)
			{
				target.addSetting(name, this.grabSetting(name));
			}
		}

		// Token: 0x0400003E RID: 62
		private Dictionary<string, string> settingsHash = new Dictionary<string, string>();

		// Token: 0x0400003F RID: 63
		private List<string> orderedKeys = new List<string>();

		// Token: 0x04000040 RID: 64
		protected Bot bot;
	}
}
