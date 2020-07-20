using AIMLbot.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AIMLbot.AIMLTagHandlers
{
	public class web : AIMLTagHandler
	{
		// Token: 0x0600006C RID: 108 RVA: 0x00004AD0 File Offset: 0x00003AD0
		public web(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00004AE1 File Offset: 0x00003AE1
		protected override string ProcessChange()
		{
			//Bring up a web adress to copy with
			//string parsableText = 
			//return "https://www.google.com/search?q=goo&rlz=1C1GCEA_enAU888AU888&oq=goo&aqs=chrome..69i57l2j69i59j69i60l2j69i61.558j0j7&sourceid=chrome&ie=UTF-8";
			return null;
		}
	}
}
