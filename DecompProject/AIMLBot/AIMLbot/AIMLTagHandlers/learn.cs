using System;
using System.IO;
using System.Xml;
using AIMLbot.Utils;

namespace AIMLbot.AIMLTagHandlers
{
	// Token: 0x02000005 RID: 5
	public class learn : AIMLTagHandler
	{
		// Token: 0x0600000F RID: 15 RVA: 0x00002374 File Offset: 0x00001374
		public learn(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002388 File Offset: 0x00001388
		protected override string ProcessChange()
		{
			if (this.templateNode.Name.ToLower() == "learn" && this.templateNode.InnerText.Length > 0)
			{
				string innerText = this.templateNode.InnerText;
				FileInfo fileInfo = new FileInfo(innerText);
				if (fileInfo.Exists)
				{
					XmlDocument xmlDocument = new XmlDocument();
					try
					{
						xmlDocument.Load(innerText);
						this.bot.loadAIMLFromXML(xmlDocument, innerText);
					}
					catch
					{
						this.bot.writeToLog("ERROR! Attempted (but failed) to <learn> some new AIML from the following URI: " + innerText);
					}
				}
			}
			return string.Empty;
		}
	}
}
