using System;
using System.Runtime.CompilerServices;

namespace Humanizer
{
	// Token: 0x02000012 RID: 18
	public static class NumberToNumberExtensions
	{
		// Token: 0x0600007D RID: 125 RVA: 0x00002ECE File Offset: 0x000010CE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Tens(this int input)
		{
			return input * 10;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00002ED4 File Offset: 0x000010D4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint Tens(this uint input)
		{
			return input * 10U;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00002EDA File Offset: 0x000010DA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long Tens(this long input)
		{
			return input * 10L;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00002EE1 File Offset: 0x000010E1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong Tens(this ulong input)
		{
			return input * 10UL;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00002EE8 File Offset: 0x000010E8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Tens(this double input)
		{
			return input * 10.0;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00002EF5 File Offset: 0x000010F5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Hundreds(this int input)
		{
			return input * 100;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00002EFB File Offset: 0x000010FB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint Hundreds(this uint input)
		{
			return input * 100U;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00002F01 File Offset: 0x00001101
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long Hundreds(this long input)
		{
			return input * 100L;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00002F08 File Offset: 0x00001108
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong Hundreds(this ulong input)
		{
			return input * 100UL;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00002F0F File Offset: 0x0000110F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Hundreds(this double input)
		{
			return input * 100.0;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00002F1C File Offset: 0x0000111C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Thousands(this int input)
		{
			return input * 1000;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00002F25 File Offset: 0x00001125
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint Thousands(this uint input)
		{
			return input * 1000U;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00002F2E File Offset: 0x0000112E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long Thousands(this long input)
		{
			return input * 1000L;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00002F38 File Offset: 0x00001138
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong Thousands(this ulong input)
		{
			return input * 1000UL;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00002F42 File Offset: 0x00001142
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Thousands(this double input)
		{
			return input * 1000.0;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00002F4F File Offset: 0x0000114F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Millions(this int input)
		{
			return input * 1000000;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00002F58 File Offset: 0x00001158
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint Millions(this uint input)
		{
			return input * 1000000U;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00002F61 File Offset: 0x00001161
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long Millions(this long input)
		{
			return input * 1000000L;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00002F6B File Offset: 0x0000116B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong Millions(this ulong input)
		{
			return input * 1000000UL;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00002F75 File Offset: 0x00001175
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Millions(this double input)
		{
			return input * 1000000.0;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00002F82 File Offset: 0x00001182
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Billions(this int input)
		{
			return input * 1000000000;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00002F8B File Offset: 0x0000118B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint Billions(this uint input)
		{
			return input * 1000000000U;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00002F94 File Offset: 0x00001194
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long Billions(this long input)
		{
			return input * 1000000000L;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00002F9E File Offset: 0x0000119E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong Billions(this ulong input)
		{
			return input * 1000000000UL;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00002FA8 File Offset: 0x000011A8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Billions(this double input)
		{
			return input * 1000000000.0;
		}
	}
}
