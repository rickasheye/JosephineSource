using System;
using System.Collections.Generic;
using System.Reflection;

namespace AIMLbot.Utils
{
	// Token: 0x02000007 RID: 7
	public class TagHandler
	{
		// Token: 0x06000013 RID: 19 RVA: 0x0000246C File Offset: 0x0000146C
		public AIMLTagHandler Instantiate(Dictionary<string, Assembly> Assemblies)
		{
			if (Assemblies.ContainsKey(this.AssemblyName))
			{
				Assembly assembly = Assemblies[this.AssemblyName];
				assembly.GetTypes();
				return (AIMLTagHandler)assembly.CreateInstance(this.ClassName);
			}
			return null;
		}

		// Token: 0x04000009 RID: 9
		public string AssemblyName;

		// Token: 0x0400000A RID: 10
		public string ClassName;

		// Token: 0x0400000B RID: 11
		public string TagName;
	}
}
