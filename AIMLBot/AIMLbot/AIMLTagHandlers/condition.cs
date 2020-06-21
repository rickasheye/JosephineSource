using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Xml;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x0200001D RID: 29
	public class condition : AIMLTagHandler
	{
		// Token: 0x06000055 RID: 85 RVA: 0x00003B0C File Offset: 0x00002B0C
		public condition(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
			this.isRecursive = false;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00003B24 File Offset: 0x00002B24
		protected override string ProcessChange()
		{
			if (this.templateNode.Name.ToLower() == "condition")
			{
				if (this.templateNode.Attributes.Count != 2)
				{
					if (this.templateNode.Attributes.Count == 1)
					{
						if (!(this.templateNode.Attributes[0].Name == "name"))
						{
							goto IL_4E9;
						}
						string value = this.templateNode.Attributes[0].Value;
						IEnumerator enumerator = templateNode.ChildNodes.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							XmlNode xmlNode = (XmlNode)obj;
							if (xmlNode.Name.ToLower() == "li")
							{
								if (xmlNode.Attributes.Count == 1)
								{
									if (xmlNode.Attributes[0].Name.ToLower() == "value")
									{
										string input = this.user.Predicates.grabSetting(value);
										Regex regex = new Regex(xmlNode.Attributes[0].Value.Replace(" ", "\\s").Replace("*", "[\\sA-Z0-9]+"), RegexOptions.IgnoreCase);
										if (regex.IsMatch(input))
										{
											return xmlNode.InnerXml;
										}
									}
								}
								else if (xmlNode.Attributes.Count == 0)
								{
									return xmlNode.InnerXml;
								}
							}
							goto IL_4E9;
						}
					}
					if (this.templateNode.Attributes.Count == 0)
					{
						foreach (object obj2 in this.templateNode.ChildNodes)
						{
							XmlNode xmlNode2 = (XmlNode)obj2;
							if (xmlNode2.Name.ToLower() == "li")
							{
								if (xmlNode2.Attributes.Count == 2)
								{
									string text = "";
									string text2 = "";
									if (xmlNode2.Attributes[0].Name == "name")
									{
										text = xmlNode2.Attributes[0].Value;
									}
									else if (xmlNode2.Attributes[0].Name == "value")
									{
										text2 = xmlNode2.Attributes[0].Value;
									}
									if (xmlNode2.Attributes[1].Name == "name")
									{
										text = xmlNode2.Attributes[1].Value;
									}
									else if (xmlNode2.Attributes[1].Name == "value")
									{
										text2 = xmlNode2.Attributes[1].Value;
									}
									if (text.Length > 0 & text2.Length > 0)
									{
										string input2 = this.user.Predicates.grabSetting(text);
										Regex regex2 = new Regex(text2.Replace(" ", "\\s").Replace("*", "[\\sA-Z0-9]+"), RegexOptions.IgnoreCase);
										if (regex2.IsMatch(input2))
										{
											return xmlNode2.InnerXml;
										}
									}
								}
								else if (xmlNode2.Attributes.Count == 0)
								{
									return xmlNode2.InnerXml;
								}
							}
						}
					}
					goto IL_4E9;
				}
				string text3 = "";
				string text4 = "";
				if (this.templateNode.Attributes[0].Name == "name")
				{
					text3 = this.templateNode.Attributes[0].Value;
				}
				else if (this.templateNode.Attributes[0].Name == "value")
				{
					text4 = this.templateNode.Attributes[0].Value;
				}
				if (this.templateNode.Attributes[1].Name == "name")
				{
					text3 = this.templateNode.Attributes[1].Value;
				}
				else if (this.templateNode.Attributes[1].Name == "value")
				{
					text4 = this.templateNode.Attributes[1].Value;
				}
				if (text3.Length > 0 & text4.Length > 0)
				{
					string input3 = this.user.Predicates.grabSetting(text3);
					Regex regex3 = new Regex(text4.Replace(" ", "\\s").Replace("*", "[\\sA-Z0-9]+"), RegexOptions.IgnoreCase);
					if (regex3.IsMatch(input3))
					{
						return this.templateNode.InnerXml;
					}
				}
			}
			IL_4E9:
			return string.Empty;
		}
	}
}
