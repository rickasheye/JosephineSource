using System;
using System.Xml;

namespace AIMLbot.Utils
{
	// Token: 0x02000003 RID: 3
	public abstract class AIMLTagHandler : TextTransformer
	{
		// Token: 0x0600000A RID: 10 RVA: 0x000020E0 File Offset: 0x000010E0
		public AIMLTagHandler(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, templateNode.OuterXml)
		{
			this.user = user;
			this.query = query;
			this.request = request;
			this.result = result;
			this.templateNode = templateNode;
			this.templateNode.Attributes.RemoveNamedItem("xmlns");
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000213E File Offset: 0x0000113E
		public AIMLTagHandler()
		{
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002150 File Offset: 0x00001150
		public static XmlNode getNode(string outerXML)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(outerXML);
			return xmlDocument.FirstChild;
		}

		// Token: 0x04000003 RID: 3
		public bool isRecursive = true;

		// Token: 0x04000004 RID: 4
		public User user;

		// Token: 0x04000005 RID: 5
		public SubQuery query;

		// Token: 0x04000006 RID: 6
		public Request request;

		// Token: 0x04000007 RID: 7
		public Result result;

		// Token: 0x04000008 RID: 8
		public XmlNode templateNode;
	}
}
