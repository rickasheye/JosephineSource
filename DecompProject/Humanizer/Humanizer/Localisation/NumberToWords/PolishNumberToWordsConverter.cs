using System;
using System.Collections.Generic;
using System.Globalization;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x02000051 RID: 81
	internal class PolishNumberToWordsConverter : GenderlessNumberToWordsConverter
	{
		// Token: 0x060001A9 RID: 425 RVA: 0x0000870D File Offset: 0x0000690D
		public PolishNumberToWordsConverter(CultureInfo culture)
		{
			this._culture = culture;
		}

		// Token: 0x060001AA RID: 426 RVA: 0x0000871C File Offset: 0x0000691C
		private static void CollectPartsUnderThousand(ICollection<string> parts, int number)
		{
			int hundreds = number / 100;
			if (hundreds > 0)
			{
				parts.Add(PolishNumberToWordsConverter.HundredsMap[hundreds]);
				number %= 100;
			}
			int tens = number / 10;
			if (tens > 1)
			{
				parts.Add(PolishNumberToWordsConverter.TensMap[tens]);
				number %= 10;
			}
			if (number > 0)
			{
				parts.Add(PolishNumberToWordsConverter.UnitsMap[number]);
			}
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00008774 File Offset: 0x00006974
		private static int GetMappingIndex(int number)
		{
			if (number == 1)
			{
				return 0;
			}
			if (number > 1 && number < 5)
			{
				return 1;
			}
			if (number / 10 > 1)
			{
				int unity = number % 10;
				if (unity > 1 && unity < 5)
				{
					return 1;
				}
			}
			return 2;
		}

		// Token: 0x060001AC RID: 428 RVA: 0x000087A8 File Offset: 0x000069A8
		public override string Convert(long input)
		{
			if (input > 2147483647L || input < -2147483648L)
			{
				throw new NotImplementedException();
			}
			int number = (int)input;
			if (number == 0)
			{
				return "zero";
			}
			List<string> parts = new List<string>();
			if (number < 0)
			{
				parts.Add("minus");
				number = -number;
			}
			int milliard = number / 1000000000;
			if (milliard > 0)
			{
				if (milliard > 1)
				{
					PolishNumberToWordsConverter.CollectPartsUnderThousand(parts, milliard);
				}
				string[] map = new string[]
				{
					"miliard",
					"miliardy",
					"miliardów"
				};
				parts.Add(map[PolishNumberToWordsConverter.GetMappingIndex(milliard)]);
				number %= 1000000000;
			}
			int million = number / 1000000;
			if (million > 0)
			{
				if (million > 1)
				{
					PolishNumberToWordsConverter.CollectPartsUnderThousand(parts, million);
				}
				string[] map2 = new string[]
				{
					"milion",
					"miliony",
					"milionów"
				};
				parts.Add(map2[PolishNumberToWordsConverter.GetMappingIndex(million)]);
				number %= 1000000;
			}
			int thouthand = number / 1000;
			if (thouthand > 0)
			{
				if (thouthand > 1)
				{
					PolishNumberToWordsConverter.CollectPartsUnderThousand(parts, thouthand);
				}
				string[] thousand = new string[]
				{
					"tysiąc",
					"tysiące",
					"tysięcy"
				};
				parts.Add(thousand[PolishNumberToWordsConverter.GetMappingIndex(thouthand)]);
				number %= 1000;
			}
			int units = number / 1;
			if (units > 0)
			{
				PolishNumberToWordsConverter.CollectPartsUnderThousand(parts, units);
			}
			return string.Join(" ", parts);
		}

		// Token: 0x060001AD RID: 429 RVA: 0x000088FD File Offset: 0x00006AFD
		public override string ConvertToOrdinal(int number)
		{
			return number.ToString(this._culture);
		}

		// Token: 0x04000076 RID: 118
		private static readonly string[] HundredsMap = new string[]
		{
			"zero",
			"sto",
			"dwieście",
			"trzysta",
			"czterysta",
			"pięćset",
			"sześćset",
			"siedemset",
			"osiemset",
			"dziewięćset"
		};

		// Token: 0x04000077 RID: 119
		private static readonly string[] TensMap = new string[]
		{
			"zero",
			"dziesięć",
			"dwadzieścia",
			"trzydzieści",
			"czterdzieści",
			"pięćdziesiąt",
			"sześćdziesiąt",
			"siedemdziesiąt",
			"osiemdziesiąt",
			"dziewięćdziesiąt"
		};

		// Token: 0x04000078 RID: 120
		private static readonly string[] UnitsMap = new string[]
		{
			"zero",
			"jeden",
			"dwa",
			"trzy",
			"cztery",
			"pięć",
			"sześć",
			"siedem",
			"osiem",
			"dziewięć",
			"dziesięć",
			"jedenaście",
			"dwanaście",
			"trzynaście",
			"czternaście",
			"piętnaście",
			"szesnaście",
			"siedemnaście",
			"osiemnaście",
			"dziewiętnaście"
		};

		// Token: 0x04000079 RID: 121
		private readonly CultureInfo _culture;
	}
}
