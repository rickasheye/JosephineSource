using System;
using Humanizer.Bytes;

namespace Humanizer
{
	// Token: 0x02000002 RID: 2
	public static class ByteSizeExtensions
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static ByteSize Bits(this byte input)
		{
			return ByteSize.FromBits((long)((ulong)input));
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002059 File Offset: 0x00000259
		public static ByteSize Bits(this sbyte input)
		{
			return ByteSize.FromBits((long)input);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002062 File Offset: 0x00000262
		public static ByteSize Bits(this short input)
		{
			return ByteSize.FromBits((long)input);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x0000206B File Offset: 0x0000026B
		public static ByteSize Bits(this ushort input)
		{
			return ByteSize.FromBits((long)((ulong)input));
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002074 File Offset: 0x00000274
		public static ByteSize Bits(this int input)
		{
			return ByteSize.FromBits((long)input);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000207D File Offset: 0x0000027D
		public static ByteSize Bits(this uint input)
		{
			return ByteSize.FromBits((long)((ulong)input));
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002086 File Offset: 0x00000286
		public static ByteSize Bits(this long input)
		{
			return ByteSize.FromBits(input);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000208E File Offset: 0x0000028E
		public static ByteSize Bytes(this byte input)
		{
			return ByteSize.FromBytes((double)input);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002097 File Offset: 0x00000297
		public static ByteSize Bytes(this sbyte input)
		{
			return ByteSize.FromBytes((double)input);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000020A0 File Offset: 0x000002A0
		public static ByteSize Bytes(this short input)
		{
			return ByteSize.FromBytes((double)input);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000020A9 File Offset: 0x000002A9
		public static ByteSize Bytes(this ushort input)
		{
			return ByteSize.FromBytes((double)input);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000020B2 File Offset: 0x000002B2
		public static ByteSize Bytes(this int input)
		{
			return ByteSize.FromBytes((double)input);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000020BB File Offset: 0x000002BB
		public static ByteSize Bytes(this uint input)
		{
			return ByteSize.FromBytes(input);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000020C5 File Offset: 0x000002C5
		public static ByteSize Bytes(this double input)
		{
			return ByteSize.FromBytes(input);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000020CD File Offset: 0x000002CD
		public static ByteSize Bytes(this long input)
		{
			return ByteSize.FromBytes((double)input);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000020D6 File Offset: 0x000002D6
		public static ByteSize Kilobytes(this byte input)
		{
			return ByteSize.FromKilobytes((double)input);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000020DF File Offset: 0x000002DF
		public static ByteSize Kilobytes(this sbyte input)
		{
			return ByteSize.FromKilobytes((double)input);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000020E8 File Offset: 0x000002E8
		public static ByteSize Kilobytes(this short input)
		{
			return ByteSize.FromKilobytes((double)input);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000020F1 File Offset: 0x000002F1
		public static ByteSize Kilobytes(this ushort input)
		{
			return ByteSize.FromKilobytes((double)input);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000020FA File Offset: 0x000002FA
		public static ByteSize Kilobytes(this int input)
		{
			return ByteSize.FromKilobytes((double)input);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002103 File Offset: 0x00000303
		public static ByteSize Kilobytes(this uint input)
		{
			return ByteSize.FromKilobytes(input);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000210D File Offset: 0x0000030D
		public static ByteSize Kilobytes(this double input)
		{
			return ByteSize.FromKilobytes(input);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002115 File Offset: 0x00000315
		public static ByteSize Kilobytes(this long input)
		{
			return ByteSize.FromKilobytes((double)input);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000211E File Offset: 0x0000031E
		public static ByteSize Megabytes(this byte input)
		{
			return ByteSize.FromMegabytes((double)input);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002127 File Offset: 0x00000327
		public static ByteSize Megabytes(this sbyte input)
		{
			return ByteSize.FromMegabytes((double)input);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002130 File Offset: 0x00000330
		public static ByteSize Megabytes(this short input)
		{
			return ByteSize.FromMegabytes((double)input);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002139 File Offset: 0x00000339
		public static ByteSize Megabytes(this ushort input)
		{
			return ByteSize.FromMegabytes((double)input);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002142 File Offset: 0x00000342
		public static ByteSize Megabytes(this int input)
		{
			return ByteSize.FromMegabytes((double)input);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000214B File Offset: 0x0000034B
		public static ByteSize Megabytes(this uint input)
		{
			return ByteSize.FromMegabytes(input);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002155 File Offset: 0x00000355
		public static ByteSize Megabytes(this double input)
		{
			return ByteSize.FromMegabytes(input);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000215D File Offset: 0x0000035D
		public static ByteSize Megabytes(this long input)
		{
			return ByteSize.FromMegabytes((double)input);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002166 File Offset: 0x00000366
		public static ByteSize Gigabytes(this byte input)
		{
			return ByteSize.FromGigabytes((double)input);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000216F File Offset: 0x0000036F
		public static ByteSize Gigabytes(this sbyte input)
		{
			return ByteSize.FromGigabytes((double)input);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002178 File Offset: 0x00000378
		public static ByteSize Gigabytes(this short input)
		{
			return ByteSize.FromGigabytes((double)input);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002181 File Offset: 0x00000381
		public static ByteSize Gigabytes(this ushort input)
		{
			return ByteSize.FromGigabytes((double)input);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000218A File Offset: 0x0000038A
		public static ByteSize Gigabytes(this int input)
		{
			return ByteSize.FromGigabytes((double)input);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002193 File Offset: 0x00000393
		public static ByteSize Gigabytes(this uint input)
		{
			return ByteSize.FromGigabytes(input);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000219D File Offset: 0x0000039D
		public static ByteSize Gigabytes(this double input)
		{
			return ByteSize.FromGigabytes(input);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000021A5 File Offset: 0x000003A5
		public static ByteSize Gigabytes(this long input)
		{
			return ByteSize.FromGigabytes((double)input);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000021AE File Offset: 0x000003AE
		public static ByteSize Terabytes(this byte input)
		{
			return ByteSize.FromTerabytes((double)input);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000021B7 File Offset: 0x000003B7
		public static ByteSize Terabytes(this sbyte input)
		{
			return ByteSize.FromTerabytes((double)input);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000021C0 File Offset: 0x000003C0
		public static ByteSize Terabytes(this short input)
		{
			return ByteSize.FromTerabytes((double)input);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000021C9 File Offset: 0x000003C9
		public static ByteSize Terabytes(this ushort input)
		{
			return ByteSize.FromTerabytes((double)input);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000021D2 File Offset: 0x000003D2
		public static ByteSize Terabytes(this int input)
		{
			return ByteSize.FromTerabytes((double)input);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000021DB File Offset: 0x000003DB
		public static ByteSize Terabytes(this uint input)
		{
			return ByteSize.FromTerabytes(input);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000021E5 File Offset: 0x000003E5
		public static ByteSize Terabytes(this double input)
		{
			return ByteSize.FromTerabytes(input);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000021ED File Offset: 0x000003ED
		public static ByteSize Terabytes(this long input)
		{
			return ByteSize.FromTerabytes((double)input);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000021F6 File Offset: 0x000003F6
		public static string Humanize(this ByteSize input, string format = null)
		{
			if (!string.IsNullOrWhiteSpace(format))
			{
				return input.ToString(format);
			}
			return input.ToString();
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002216 File Offset: 0x00000416
		public static ByteRate Per(this ByteSize size, TimeSpan interval)
		{
			return new ByteRate(size, interval);
		}
	}
}
