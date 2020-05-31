using System;
using System.Collections.Generic;
using Humanizer.Localisation.GrammaticalNumber;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x02000053 RID: 83
	internal class RussianNumberToWordsConverter : GenderedNumberToWordsConverter
	{
		// Token: 0x060001B2 RID: 434 RVA: 0x00008AC8 File Offset: 0x00006CC8
		public override string Convert(long input, GrammaticalGender gender)
		{
			if (input > 2147483647L || input < -2147483648L)
			{
				throw new NotImplementedException();
			}
			int number = (int)input;
			if (number == 0)
			{
				return "ноль";
			}
			List<string> parts = new List<string>();
			if (number < 0)
			{
				parts.Add("минус");
				number = -number;
			}
			RussianNumberToWordsConverter.CollectParts(parts, ref number, 1000000000, GrammaticalGender.Masculine, new string[]
			{
				"миллиард",
				"миллиарда",
				"миллиардов"
			});
			RussianNumberToWordsConverter.CollectParts(parts, ref number, 1000000, GrammaticalGender.Masculine, new string[]
			{
				"миллион",
				"миллиона",
				"миллионов"
			});
			RussianNumberToWordsConverter.CollectParts(parts, ref number, 1000, GrammaticalGender.Feminine, new string[]
			{
				"тысяча",
				"тысячи",
				"тысяч"
			});
			if (number > 0)
			{
				RussianNumberToWordsConverter.CollectPartsUnderOneThousand(parts, number, gender);
			}
			return string.Join(" ", parts);
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x00008BAC File Offset: 0x00006DAC
		public override string ConvertToOrdinal(int number, GrammaticalGender gender)
		{
			if (number == 0)
			{
				return "нулев" + RussianNumberToWordsConverter.GetEndingForGender(gender, number);
			}
			List<string> parts = new List<string>();
			if (number < 0)
			{
				parts.Add("минус");
				number = -number;
			}
			RussianNumberToWordsConverter.CollectOrdinalParts(parts, ref number, 1000000000, GrammaticalGender.Masculine, "миллиардн" + RussianNumberToWordsConverter.GetEndingForGender(gender, number), new string[]
			{
				"миллиард",
				"миллиарда",
				"миллиардов"
			});
			RussianNumberToWordsConverter.CollectOrdinalParts(parts, ref number, 1000000, GrammaticalGender.Masculine, "миллионн" + RussianNumberToWordsConverter.GetEndingForGender(gender, number), new string[]
			{
				"миллион",
				"миллиона",
				"миллионов"
			});
			RussianNumberToWordsConverter.CollectOrdinalParts(parts, ref number, 1000, GrammaticalGender.Feminine, "тысячн" + RussianNumberToWordsConverter.GetEndingForGender(gender, number), new string[]
			{
				"тысяча",
				"тысячи",
				"тысяч"
			});
			if (number >= 100)
			{
				string ending = RussianNumberToWordsConverter.GetEndingForGender(gender, number);
				int hundreds = number / 100;
				number %= 100;
				if (number == 0)
				{
					parts.Add(RussianNumberToWordsConverter.UnitsOrdinalPrefixes[hundreds] + "сот" + ending);
				}
				else
				{
					parts.Add(RussianNumberToWordsConverter.HundredsMap[hundreds]);
				}
			}
			if (number >= 20)
			{
				string ending2 = RussianNumberToWordsConverter.GetEndingForGender(gender, number);
				int tens = number / 10;
				number %= 10;
				if (number == 0)
				{
					parts.Add(RussianNumberToWordsConverter.TensOrdinal[tens] + ending2);
				}
				else
				{
					parts.Add(RussianNumberToWordsConverter.TensMap[tens]);
				}
			}
			if (number > 0)
			{
				parts.Add(RussianNumberToWordsConverter.UnitsOrdinal[number] + RussianNumberToWordsConverter.GetEndingForGender(gender, number));
			}
			return string.Join(" ", parts);
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x00008D48 File Offset: 0x00006F48
		private static void CollectPartsUnderOneThousand(ICollection<string> parts, int number, GrammaticalGender gender)
		{
			if (number >= 100)
			{
				int hundreds = number / 100;
				number %= 100;
				parts.Add(RussianNumberToWordsConverter.HundredsMap[hundreds]);
			}
			if (number >= 20)
			{
				int tens = number / 10;
				parts.Add(RussianNumberToWordsConverter.TensMap[tens]);
				number %= 10;
			}
			if (number > 0)
			{
				if (number == 1 && gender == GrammaticalGender.Feminine)
				{
					parts.Add("одна");
					return;
				}
				if (number == 1 && gender == GrammaticalGender.Neuter)
				{
					parts.Add("одно");
					return;
				}
				if (number == 2 && gender == GrammaticalGender.Feminine)
				{
					parts.Add("две");
					return;
				}
				if (number < 20)
				{
					parts.Add(RussianNumberToWordsConverter.UnitsMap[number]);
				}
			}
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x00008DE4 File Offset: 0x00006FE4
		private static string GetPrefix(int number)
		{
			List<string> parts = new List<string>();
			if (number >= 100)
			{
				int hundreds = number / 100;
				number %= 100;
				if (hundreds != 1)
				{
					parts.Add(RussianNumberToWordsConverter.UnitsOrdinalPrefixes[hundreds] + "сот");
				}
				else
				{
					parts.Add("сто");
				}
			}
			if (number >= 20)
			{
				int tens = number / 10;
				number %= 10;
				parts.Add(RussianNumberToWordsConverter.TensOrdinalPrefixes[tens]);
			}
			if (number > 0)
			{
				parts.Add((number == 1) ? "одно" : RussianNumberToWordsConverter.UnitsOrdinalPrefixes[number]);
			}
			return string.Join("", parts);
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x00008E74 File Offset: 0x00007074
		private static void CollectParts(ICollection<string> parts, ref int number, int divisor, GrammaticalGender gender, params string[] forms)
		{
			if (number < divisor)
			{
				return;
			}
			int result = number / divisor;
			number %= divisor;
			RussianNumberToWordsConverter.CollectPartsUnderOneThousand(parts, result, gender);
			parts.Add(RussianNumberToWordsConverter.ChooseOneForGrammaticalNumber(result, forms));
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x00008EA8 File Offset: 0x000070A8
		private static void CollectOrdinalParts(ICollection<string> parts, ref int number, int divisor, GrammaticalGender gender, string prefixedForm, params string[] forms)
		{
			if (number < divisor)
			{
				return;
			}
			int result = number / divisor;
			number %= divisor;
			if (number != 0)
			{
				RussianNumberToWordsConverter.CollectPartsUnderOneThousand(parts, result, gender);
				parts.Add(RussianNumberToWordsConverter.ChooseOneForGrammaticalNumber(result, forms));
				return;
			}
			if (result == 1)
			{
				parts.Add(prefixedForm);
				return;
			}
			parts.Add(RussianNumberToWordsConverter.GetPrefix(result) + prefixedForm);
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x00008F01 File Offset: 0x00007101
		private static int GetIndex(RussianGrammaticalNumber number)
		{
			if (number == RussianGrammaticalNumber.Singular)
			{
				return 0;
			}
			if (number == RussianGrammaticalNumber.Paucal)
			{
				return 1;
			}
			return 2;
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x00008F0F File Offset: 0x0000710F
		private static string ChooseOneForGrammaticalNumber(int number, string[] forms)
		{
			return forms[RussianNumberToWordsConverter.GetIndex(RussianGrammaticalNumberDetector.Detect(number))];
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00008F20 File Offset: 0x00007120
		private static string GetEndingForGender(GrammaticalGender gender, int number)
		{
			switch (gender)
			{
			case GrammaticalGender.Masculine:
				if (number == 0 || number == 2 || number == 6 || number == 7 || number == 8 || number == 40)
				{
					return "ой";
				}
				if (number == 3)
				{
					return "ий";
				}
				return "ый";
			case GrammaticalGender.Feminine:
				if (number == 3)
				{
					return "ья";
				}
				return "ая";
			case GrammaticalGender.Neuter:
				if (number == 3)
				{
					return "ье";
				}
				return "ое";
			default:
				throw new ArgumentOutOfRangeException("gender");
			}
		}

		// Token: 0x060001BB RID: 443 RVA: 0x00008F99 File Offset: 0x00007199
		public RussianNumberToWordsConverter() : base(GrammaticalGender.Masculine)
		{
		}

		// Token: 0x0400007A RID: 122
		private static readonly string[] HundredsMap = new string[]
		{
			"ноль",
			"сто",
			"двести",
			"триста",
			"четыреста",
			"пятьсот",
			"шестьсот",
			"семьсот",
			"восемьсот",
			"девятьсот"
		};

		// Token: 0x0400007B RID: 123
		private static readonly string[] TensMap = new string[]
		{
			"ноль",
			"десять",
			"двадцать",
			"тридцать",
			"сорок",
			"пятьдесят",
			"шестьдесят",
			"семьдесят",
			"восемьдесят",
			"девяносто"
		};

		// Token: 0x0400007C RID: 124
		private static readonly string[] UnitsMap = new string[]
		{
			"ноль",
			"один",
			"два",
			"три",
			"четыре",
			"пять",
			"шесть",
			"семь",
			"восемь",
			"девять",
			"десять",
			"одиннадцать",
			"двенадцать",
			"тринадцать",
			"четырнадцать",
			"пятнадцать",
			"шестнадцать",
			"семнадцать",
			"восемнадцать",
			"девятнадцать"
		};

		// Token: 0x0400007D RID: 125
		private static readonly string[] UnitsOrdinalPrefixes = new string[]
		{
			string.Empty,
			string.Empty,
			"двух",
			"трёх",
			"четырёх",
			"пяти",
			"шести",
			"семи",
			"восьми",
			"девяти",
			"десяти",
			"одиннадцати",
			"двенадцати",
			"тринадцати",
			"четырнадцати",
			"пятнадцати",
			"шестнадцати",
			"семнадцати",
			"восемнадцати",
			"девятнадцати"
		};

		// Token: 0x0400007E RID: 126
		private static readonly string[] TensOrdinalPrefixes = new string[]
		{
			string.Empty,
			"десяти",
			"двадцати",
			"тридцати",
			"сорока",
			"пятидесяти",
			"шестидесяти",
			"семидесяти",
			"восьмидесяти",
			"девяносто"
		};

		// Token: 0x0400007F RID: 127
		private static readonly string[] TensOrdinal = new string[]
		{
			string.Empty,
			"десят",
			"двадцат",
			"тридцат",
			"сороков",
			"пятидесят",
			"шестидесят",
			"семидесят",
			"восьмидесят",
			"девяност"
		};

		// Token: 0x04000080 RID: 128
		private static readonly string[] UnitsOrdinal = new string[]
		{
			string.Empty,
			"перв",
			"втор",
			"трет",
			"четверт",
			"пят",
			"шест",
			"седьм",
			"восьм",
			"девят",
			"десят",
			"одиннадцат",
			"двенадцат",
			"тринадцат",
			"четырнадцат",
			"пятнадцат",
			"шестнадцат",
			"семнадцат",
			"восемнадцат",
			"девятнадцат"
		};
	}
}
