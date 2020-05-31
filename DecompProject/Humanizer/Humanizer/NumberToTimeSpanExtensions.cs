using System;

namespace Humanizer
{
	// Token: 0x02000013 RID: 19
	public static class NumberToTimeSpanExtensions
	{
		// Token: 0x06000096 RID: 150 RVA: 0x00002FB5 File Offset: 0x000011B5
		public static TimeSpan Milliseconds(this byte ms)
		{
			return ((double)ms).Milliseconds();
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00002FBE File Offset: 0x000011BE
		public static TimeSpan Milliseconds(this sbyte ms)
		{
			return ((double)ms).Milliseconds();
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00002FC7 File Offset: 0x000011C7
		public static TimeSpan Milliseconds(this short ms)
		{
			return ((double)ms).Milliseconds();
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00002FD0 File Offset: 0x000011D0
		public static TimeSpan Milliseconds(this ushort ms)
		{
			return ((double)ms).Milliseconds();
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00002FD9 File Offset: 0x000011D9
		public static TimeSpan Milliseconds(this int ms)
		{
			return ((double)ms).Milliseconds();
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00002FE2 File Offset: 0x000011E2
		public static TimeSpan Milliseconds(this uint ms)
		{
			return ms.Milliseconds();
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00002FEC File Offset: 0x000011EC
		public static TimeSpan Milliseconds(this long ms)
		{
			return ((double)ms).Milliseconds();
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00002FF5 File Offset: 0x000011F5
		public static TimeSpan Milliseconds(this ulong ms)
		{
			return ms.Milliseconds();
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00002FFF File Offset: 0x000011FF
		public static TimeSpan Milliseconds(this double ms)
		{
			return TimeSpan.FromMilliseconds(ms);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00003007 File Offset: 0x00001207
		public static TimeSpan Seconds(this byte seconds)
		{
			return ((double)seconds).Seconds();
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00003010 File Offset: 0x00001210
		public static TimeSpan Seconds(this sbyte seconds)
		{
			return ((double)seconds).Seconds();
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00003019 File Offset: 0x00001219
		public static TimeSpan Seconds(this short seconds)
		{
			return ((double)seconds).Seconds();
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00003022 File Offset: 0x00001222
		public static TimeSpan Seconds(this ushort seconds)
		{
			return ((double)seconds).Seconds();
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000302B File Offset: 0x0000122B
		public static TimeSpan Seconds(this int seconds)
		{
			return ((double)seconds).Seconds();
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00003034 File Offset: 0x00001234
		public static TimeSpan Seconds(this uint seconds)
		{
			return seconds.Seconds();
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000303E File Offset: 0x0000123E
		public static TimeSpan Seconds(this long seconds)
		{
			return ((double)seconds).Seconds();
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00003047 File Offset: 0x00001247
		public static TimeSpan Seconds(this ulong seconds)
		{
			return seconds.Seconds();
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00003051 File Offset: 0x00001251
		public static TimeSpan Seconds(this double seconds)
		{
			return TimeSpan.FromSeconds(seconds);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00003059 File Offset: 0x00001259
		public static TimeSpan Minutes(this byte minutes)
		{
			return ((double)minutes).Minutes();
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00003062 File Offset: 0x00001262
		public static TimeSpan Minutes(this sbyte minutes)
		{
			return ((double)minutes).Minutes();
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000306B File Offset: 0x0000126B
		public static TimeSpan Minutes(this short minutes)
		{
			return ((double)minutes).Minutes();
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00003074 File Offset: 0x00001274
		public static TimeSpan Minutes(this ushort minutes)
		{
			return ((double)minutes).Minutes();
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000307D File Offset: 0x0000127D
		public static TimeSpan Minutes(this int minutes)
		{
			return ((double)minutes).Minutes();
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00003086 File Offset: 0x00001286
		public static TimeSpan Minutes(this uint minutes)
		{
			return minutes.Minutes();
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00003090 File Offset: 0x00001290
		public static TimeSpan Minutes(this long minutes)
		{
			return ((double)minutes).Minutes();
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00003099 File Offset: 0x00001299
		public static TimeSpan Minutes(this ulong minutes)
		{
			return minutes.Minutes();
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000030A3 File Offset: 0x000012A3
		public static TimeSpan Minutes(this double minutes)
		{
			return TimeSpan.FromMinutes(minutes);
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000030AB File Offset: 0x000012AB
		public static TimeSpan Hours(this byte hours)
		{
			return ((double)hours).Hours();
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x000030B4 File Offset: 0x000012B4
		public static TimeSpan Hours(this sbyte hours)
		{
			return ((double)hours).Hours();
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000030BD File Offset: 0x000012BD
		public static TimeSpan Hours(this short hours)
		{
			return ((double)hours).Hours();
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000030C6 File Offset: 0x000012C6
		public static TimeSpan Hours(this ushort hours)
		{
			return ((double)hours).Hours();
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x000030CF File Offset: 0x000012CF
		public static TimeSpan Hours(this int hours)
		{
			return ((double)hours).Hours();
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000030D8 File Offset: 0x000012D8
		public static TimeSpan Hours(this uint hours)
		{
			return hours.Hours();
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000030E2 File Offset: 0x000012E2
		public static TimeSpan Hours(this long hours)
		{
			return ((double)hours).Hours();
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x000030EB File Offset: 0x000012EB
		public static TimeSpan Hours(this ulong hours)
		{
			return hours.Hours();
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000030F5 File Offset: 0x000012F5
		public static TimeSpan Hours(this double hours)
		{
			return TimeSpan.FromHours(hours);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000030FD File Offset: 0x000012FD
		public static TimeSpan Days(this byte days)
		{
			return ((double)days).Days();
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00003106 File Offset: 0x00001306
		public static TimeSpan Days(this sbyte days)
		{
			return ((double)days).Days();
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000310F File Offset: 0x0000130F
		public static TimeSpan Days(this short days)
		{
			return ((double)days).Days();
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00003118 File Offset: 0x00001318
		public static TimeSpan Days(this ushort days)
		{
			return ((double)days).Days();
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00003121 File Offset: 0x00001321
		public static TimeSpan Days(this int days)
		{
			return ((double)days).Days();
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000312A File Offset: 0x0000132A
		public static TimeSpan Days(this uint days)
		{
			return days.Days();
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00003134 File Offset: 0x00001334
		public static TimeSpan Days(this long days)
		{
			return ((double)days).Days();
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000313D File Offset: 0x0000133D
		public static TimeSpan Days(this ulong days)
		{
			return days.Days();
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00003147 File Offset: 0x00001347
		public static TimeSpan Days(this double days)
		{
			return TimeSpan.FromDays(days);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000314F File Offset: 0x0000134F
		public static TimeSpan Weeks(this byte input)
		{
			return ((double)input).Weeks();
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00003158 File Offset: 0x00001358
		public static TimeSpan Weeks(this sbyte input)
		{
			return ((double)input).Weeks();
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00003161 File Offset: 0x00001361
		public static TimeSpan Weeks(this short input)
		{
			return ((double)input).Weeks();
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000316A File Offset: 0x0000136A
		public static TimeSpan Weeks(this ushort input)
		{
			return ((double)input).Weeks();
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00003173 File Offset: 0x00001373
		public static TimeSpan Weeks(this int input)
		{
			return ((double)input).Weeks();
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000317C File Offset: 0x0000137C
		public static TimeSpan Weeks(this uint input)
		{
			return input.Weeks();
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00003186 File Offset: 0x00001386
		public static TimeSpan Weeks(this long input)
		{
			return ((double)input).Weeks();
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000318F File Offset: 0x0000138F
		public static TimeSpan Weeks(this ulong input)
		{
			return input.Weeks();
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00003199 File Offset: 0x00001399
		public static TimeSpan Weeks(this double input)
		{
			return (7.0 * input).Days();
		}
	}
}
