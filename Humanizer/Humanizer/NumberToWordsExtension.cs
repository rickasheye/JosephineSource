using System;
using System.Globalization;
using Humanizer.Configuration;

namespace Humanizer
{
	// Token: 0x02000014 RID: 20
	public static class NumberToWordsExtension
	{
		// Token: 0x060000CC RID: 204 RVA: 0x000031AB File Offset: 0x000013AB
		public static string ToWords(this int number, CultureInfo culture = null)
		{
			return ((long)number).ToWords(culture);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x000031B5 File Offset: 0x000013B5
		public static string ToWords(this int number, GrammaticalGender gender, CultureInfo culture = null)
		{
			return ((long)number).ToWords(gender, culture);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x000031C0 File Offset: 0x000013C0
		public static string ToWords(this long number, CultureInfo culture = null)
		{
			return Configurator.GetNumberToWordsConverter(culture).Convert(number);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x000031CE File Offset: 0x000013CE
		public static string ToWords(this long number, GrammaticalGender gender, CultureInfo culture = null)
		{
			return Configurator.GetNumberToWordsConverter(culture).Convert(number, gender);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x000031DD File Offset: 0x000013DD
		public static string ToOrdinalWords(this int number, CultureInfo culture = null)
		{
			return Configurator.GetNumberToWordsConverter(culture).ConvertToOrdinal(number);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x000031EB File Offset: 0x000013EB
		public static string ToOrdinalWords(this int number, GrammaticalGender gender, CultureInfo culture = null)
		{
			return Configurator.GetNumberToWordsConverter(culture).ConvertToOrdinal(number, gender);
		}
	}
}
