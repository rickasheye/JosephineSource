using System;
using System.Globalization;
using Humanizer.Configuration;

namespace Humanizer
{
	// Token: 0x02000016 RID: 22
	public static class OrdinalizeExtensions
	{
		// Token: 0x060000D2 RID: 210 RVA: 0x000031FA File Offset: 0x000013FA
		public static string Ordinalize(this string numberString)
		{
			return Configurator.Ordinalizer.Convert(int.Parse(numberString), numberString);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000320D File Offset: 0x0000140D
		public static string Ordinalize(this string numberString, GrammaticalGender gender)
		{
			return Configurator.Ordinalizer.Convert(int.Parse(numberString), numberString, gender);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00003221 File Offset: 0x00001421
		public static string Ordinalize(this int number)
		{
			return Configurator.Ordinalizer.Convert(number, number.ToString(CultureInfo.InvariantCulture));
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000323A File Offset: 0x0000143A
		public static string Ordinalize(this int number, GrammaticalGender gender)
		{
			return Configurator.Ordinalizer.Convert(number, number.ToString(CultureInfo.InvariantCulture), gender);
		}
	}
}
