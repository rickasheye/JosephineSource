using System;
using System.Collections.Generic;
using System.Linq;

namespace Humanizer.Localisation.CollectionFormatters
{
	// Token: 0x02000070 RID: 112
	internal class DefaultCollectionFormatter : ICollectionFormatter
	{
		// Token: 0x06000234 RID: 564 RVA: 0x0000C824 File Offset: 0x0000AA24
		public DefaultCollectionFormatter(string defaultSeparator)
		{
			this.DefaultSeparator = defaultSeparator;
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0000C83E File Offset: 0x0000AA3E
		public virtual string Humanize<T>(IEnumerable<T> collection)
		{
			return this.Humanize<T>(collection, delegate(T o)
			{
				if (o == null)
				{
					return null;
				}
				return o.ToString();
			}, this.DefaultSeparator);
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0000C86C File Offset: 0x0000AA6C
		public virtual string Humanize<T>(IEnumerable<T> collection, Func<T, string> objectFormatter)
		{
			return this.Humanize<T>(collection, objectFormatter, this.DefaultSeparator);
		}

		// Token: 0x06000237 RID: 567 RVA: 0x0000C87C File Offset: 0x0000AA7C
		public virtual string Humanize<T>(IEnumerable<T> collection, string separator)
		{
			return this.Humanize<T>(collection, delegate(T o)
			{
				if (o == null)
				{
					return null;
				}
				return o.ToString();
			}, separator);
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0000C8A8 File Offset: 0x0000AAA8
		public virtual string Humanize<T>(IEnumerable<T> collection, Func<T, string> objectFormatter, string separator)
		{
			if (collection == null)
			{
				throw new ArgumentException("collection");
			}
			string[] itemsArray = (from item in collection.Select(objectFormatter).Select(delegate(string item)
			{
				if (item != null)
				{
					return item.Trim();
				}
				return string.Empty;
			})
			where !string.IsNullOrWhiteSpace(item)
			select item).ToArray<string>();
			int count = itemsArray.Length;
			if (count == 0)
			{
				return "";
			}
			if (count == 1)
			{
				return itemsArray[0];
			}
			IEnumerable<string> itemsBeforeLast = itemsArray.Take(count - 1);
			string lastItem = itemsArray.Skip(count - 1).First<string>();
			return string.Format(this.GetConjunctionFormatString(count), new object[]
			{
				string.Join(", ", itemsBeforeLast),
				separator,
				lastItem
			});
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0000C96E File Offset: 0x0000AB6E
		protected virtual string GetConjunctionFormatString(int itemCount)
		{
			return "{0} {1} {2}";
		}

		// Token: 0x040000D0 RID: 208
		protected string DefaultSeparator = "";
	}
}
