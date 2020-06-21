using System;

namespace Humanizer
{
	// Token: 0x0200001F RID: 31
	public static class ToQuantityExtensions
	{
		// Token: 0x060000F4 RID: 244 RVA: 0x000039AB File Offset: 0x00001BAB
		public static string ToQuantity(this string input, int quantity, ShowQuantityAs showQuantityAs = ShowQuantityAs.Numeric)
		{
			return input.ToQuantity((long)quantity, showQuantityAs, null, null);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x000039B8 File Offset: 0x00001BB8
		public static string ToQuantity(this string input, int quantity, string format, IFormatProvider formatProvider = null)
		{
			return input.ToQuantity((long)quantity, ShowQuantityAs.Numeric, format, formatProvider);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x000039C5 File Offset: 0x00001BC5
		public static string ToQuantity(this string input, long quantity, ShowQuantityAs showQuantityAs = ShowQuantityAs.Numeric)
		{
			return input.ToQuantity(quantity, showQuantityAs, null, null);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x000039D1 File Offset: 0x00001BD1
		public static string ToQuantity(this string input, long quantity, string format, IFormatProvider formatProvider = null)
		{
			return input.ToQuantity(quantity, ShowQuantityAs.Numeric, format, formatProvider);
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x000039E0 File Offset: 0x00001BE0
		private static string ToQuantity(this string input, long quantity, ShowQuantityAs showQuantityAs = ShowQuantityAs.Numeric, string format = null, IFormatProvider formatProvider = null)
		{
			string transformedInput = (quantity == 1L) ? input.Singularize(false) : input.Pluralize(false);
			if (showQuantityAs == ShowQuantityAs.None)
			{
				return transformedInput;
			}
			if (showQuantityAs == ShowQuantityAs.Numeric)
			{
				return string.Format(formatProvider, "{0} {1}", new object[]
				{
					quantity.ToString(format, formatProvider),
					transformedInput
				});
			}
			return string.Format("{0} {1}", new object[]
			{
				quantity.ToWords(null),
				transformedInput
			});
		}
	}
}
