using System;
using System.Collections.Generic;
using Humanizer.Configuration;

namespace Humanizer
{
	// Token: 0x02000004 RID: 4
	public static class CollectionHumanizeExtensions
	{
		// Token: 0x06000033 RID: 51 RVA: 0x000022A3 File Offset: 0x000004A3
		public static string Humanize<T>(this IEnumerable<T> collection)
		{
			return Configurator.CollectionFormatter.Humanize<T>(collection);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000022B0 File Offset: 0x000004B0
		public static string Humanize<T>(this IEnumerable<T> collection, Func<T, string> displayFormatter)
		{
			if (displayFormatter == null)
			{
				throw new ArgumentNullException("displayFormatter");
			}
			return Configurator.CollectionFormatter.Humanize<T>(collection, displayFormatter);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000022CC File Offset: 0x000004CC
		public static string Humanize<T>(this IEnumerable<T> collection, string separator)
		{
			return Configurator.CollectionFormatter.Humanize<T>(collection, separator);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000022DA File Offset: 0x000004DA
		public static string Humanize<T>(this IEnumerable<T> collection, Func<T, string> displayFormatter, string separator)
		{
			if (displayFormatter == null)
			{
				throw new ArgumentNullException("displayFormatter");
			}
			return Configurator.CollectionFormatter.Humanize<T>(collection, displayFormatter, separator);
		}
	}
}
