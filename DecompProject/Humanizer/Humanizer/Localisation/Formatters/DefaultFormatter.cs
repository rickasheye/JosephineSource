using System;
using System.Globalization;

namespace Humanizer.Localisation.Formatters
{
	// Token: 0x02000065 RID: 101
	public class DefaultFormatter : IFormatter
	{
		// Token: 0x0600020C RID: 524 RVA: 0x0000C47E File Offset: 0x0000A67E
		public DefaultFormatter(string localeCode)
		{
			this._culture = new CultureInfo(localeCode);
		}

		// Token: 0x0600020D RID: 525 RVA: 0x0000C492 File Offset: 0x0000A692
		public virtual string DateHumanize_Now()
		{
			return this.GetResourceForDate(TimeUnit.Millisecond, Tense.Past, 0);
		}

		// Token: 0x0600020E RID: 526 RVA: 0x0000C49D File Offset: 0x0000A69D
		public virtual string DateHumanize_Never()
		{
			return this.Format("DateHumanize_Never");
		}

		// Token: 0x0600020F RID: 527 RVA: 0x0000C4AA File Offset: 0x0000A6AA
		public virtual string DateHumanize(TimeUnit timeUnit, Tense timeUnitTense, int unit)
		{
			return this.GetResourceForDate(timeUnit, timeUnitTense, unit);
		}

		// Token: 0x06000210 RID: 528 RVA: 0x0000C4B5 File Offset: 0x0000A6B5
		public virtual string TimeSpanHumanize_Zero()
		{
			return this.GetResourceForTimeSpan(TimeUnit.Millisecond, 0);
		}

		// Token: 0x06000211 RID: 529 RVA: 0x0000C4BF File Offset: 0x0000A6BF
		public virtual string TimeSpanHumanize(TimeUnit timeUnit, int unit)
		{
			return this.GetResourceForTimeSpan(timeUnit, unit);
		}

		// Token: 0x06000212 RID: 530 RVA: 0x0000C4CC File Offset: 0x0000A6CC
		private string GetResourceForDate(TimeUnit unit, Tense timeUnitTense, int count)
		{
			string resourceKey = ResourceKeys.DateHumanize.GetResourceKey(unit, timeUnitTense, count);
			if (count != 1)
			{
				return this.Format(resourceKey, count);
			}
			return this.Format(resourceKey);
		}

		// Token: 0x06000213 RID: 531 RVA: 0x0000C4F8 File Offset: 0x0000A6F8
		private string GetResourceForTimeSpan(TimeUnit unit, int count)
		{
			string resourceKey = ResourceKeys.TimeSpanHumanize.GetResourceKey(unit, count);
			if (count != 1)
			{
				return this.Format(resourceKey, count);
			}
			return this.Format(resourceKey);
		}

		// Token: 0x06000214 RID: 532 RVA: 0x0000C524 File Offset: 0x0000A724
		protected virtual string Format(string resourceKey)
		{
			string resourceString = Resources.GetResource(this.GetResourceKey(resourceKey), this._culture);
			if (string.IsNullOrEmpty(resourceString))
			{
				throw new ArgumentException(string.Format("The resource object with key '{0}' was not found", new object[]
				{
					resourceKey
				}), "resourceKey");
			}
			return resourceString;
		}

		// Token: 0x06000215 RID: 533 RVA: 0x0000C56C File Offset: 0x0000A76C
		protected virtual string Format(string resourceKey, int number)
		{
			string resourceString = Resources.GetResource(this.GetResourceKey(resourceKey, number), this._culture);
			if (string.IsNullOrEmpty(resourceString))
			{
				throw new ArgumentException(string.Format("The resource object with key '{0}' was not found", new object[]
				{
					resourceKey
				}), "resourceKey");
			}
			return resourceString.FormatWith(new object[]
			{
				number
			});
		}

		// Token: 0x06000216 RID: 534 RVA: 0x0000C5C9 File Offset: 0x0000A7C9
		protected virtual string GetResourceKey(string resourceKey, int number)
		{
			return resourceKey;
		}

		// Token: 0x06000217 RID: 535 RVA: 0x0000C5CC File Offset: 0x0000A7CC
		protected virtual string GetResourceKey(string resourceKey)
		{
			return resourceKey;
		}

		// Token: 0x040000C3 RID: 195
		private readonly CultureInfo _culture;
	}
}
