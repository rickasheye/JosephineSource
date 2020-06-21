using System;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Humanizer.Localisation
{
	// Token: 0x0200002E RID: 46
	public static class Resources
	{
		// Token: 0x0600011A RID: 282 RVA: 0x00003EC1 File Offset: 0x000020C1
		public static string GetResource(string resourceKey, CultureInfo culture = null)
		{
			return Resources.ResourceManager.GetString(resourceKey, culture);
		}

		// Token: 0x04000032 RID: 50
		private static readonly ResourceManager ResourceManager = new ResourceManager("Humanizer.Properties.Resources", typeof(Resources).GetTypeInfo().Assembly);
	}
}
