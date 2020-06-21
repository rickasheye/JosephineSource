using System;
using Humanizer.Localisation;

namespace Humanizer.Bytes
{
	// Token: 0x02000083 RID: 131
	public class ByteRate
	{
		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000277 RID: 631 RVA: 0x0000DF1C File Offset: 0x0000C11C
		// (set) Token: 0x06000278 RID: 632 RVA: 0x0000DF24 File Offset: 0x0000C124
		public ByteSize Size { get; private set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000279 RID: 633 RVA: 0x0000DF2D File Offset: 0x0000C12D
		// (set) Token: 0x0600027A RID: 634 RVA: 0x0000DF35 File Offset: 0x0000C135
		public TimeSpan Interval { get; private set; }

		// Token: 0x0600027B RID: 635 RVA: 0x0000DF3E File Offset: 0x0000C13E
		public ByteRate(ByteSize size, TimeSpan interval)
		{
			this.Size = size;
			this.Interval = interval;
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0000DF54 File Offset: 0x0000C154
		public string Humanize(TimeUnit timeUnit = TimeUnit.Second)
		{
			return this.Humanize(null, timeUnit);
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0000DF60 File Offset: 0x0000C160
		public string Humanize(string format, TimeUnit timeUnit = TimeUnit.Second)
		{
			TimeSpan displayInterval;
			string displayUnit;
			if (timeUnit == TimeUnit.Second)
			{
				displayInterval = TimeSpan.FromSeconds(1.0);
				displayUnit = "s";
			}
			else if (timeUnit == TimeUnit.Minute)
			{
				displayInterval = TimeSpan.FromMinutes(1.0);
				displayUnit = "min";
			}
			else
			{
				if (timeUnit != TimeUnit.Hour)
				{
					throw new NotSupportedException("timeUnit must be Second, Minute, or Hour");
				}
				displayInterval = TimeSpan.FromHours(1.0);
				displayUnit = "hour";
			}
			return new ByteSize(this.Size.Bytes / this.Interval.TotalSeconds * displayInterval.TotalSeconds).Humanize(format) + "/" + displayUnit;
		}
	}
}
