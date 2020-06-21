using System;
using System.Collections.Generic;
using Humanizer.Localisation.GrammaticalNumber;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x02000059 RID: 89
	internal class UkrainianNumberToWordsConverter : GenderedNumberToWordsConverter
	{
		// Token: 0x060001D4 RID: 468 RVA: 0x0000A660 File Offset: 0x00008860
		public override string Convert(long input, GrammaticalGender gender)
		{
			if (input > 2147483647L || input < -2147483648L)
			{
				throw new NotImplementedException();
			}
			int number = (int)input;
			if (number == 0)
			{
				return "нуль";
			}
			List<string> parts = new List<string>();
			if (number < 0)
			{
				parts.Add("мінус");
				number = -number;
			}
			UkrainianNumberToWordsConverter.CollectParts(parts, ref number, 1000000000, GrammaticalGender.Masculine, new string[]
			{
				"мільярд",
				"мільярда",
				"мільярдів"
			});
			UkrainianNumberToWordsConverter.CollectParts(parts, ref number, 1000000, GrammaticalGender.Masculine, new string[]
			{
				"мільйон",
				"мільйона",
				"мільйонів"
			});
			UkrainianNumberToWordsConverter.CollectParts(parts, ref number, 1000, GrammaticalGender.Feminine, new string[]
			{
				"тисяча",
				"тисячі",
				"тисяч"
			});
			if (number > 0)
			{
				UkrainianNumberToWordsConverter.CollectPartsUnderOneThousand(parts, number, gender);
			}
			return string.Join(" ", parts);
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x0000A744 File Offset: 0x00008944
		public override string ConvertToOrdinal(int number, GrammaticalGender gender)
		{
			if (number == 0)
			{
				return "нульов" + UkrainianNumberToWordsConverter.GetEndingForGender(gender, number);
			}
			List<string> parts = new List<string>();
			if (number < 0)
			{
				parts.Add("мінус");
				number = -number;
			}
			UkrainianNumberToWordsConverter.CollectOrdinalParts(parts, ref number, 1000000000, GrammaticalGender.Masculine, "мільярдн" + UkrainianNumberToWordsConverter.GetEndingForGender(gender, number), new string[]
			{
				"мільярд",
				"мільярда",
				"мільярдів"
			});
			UkrainianNumberToWordsConverter.CollectOrdinalParts(parts, ref number, 1000000, GrammaticalGender.Masculine, "мільйонн" + UkrainianNumberToWordsConverter.GetEndingForGender(gender, number), new string[]
			{
				"мільйон",
				"мільйона",
				"мільйонів"
			});
			UkrainianNumberToWordsConverter.CollectOrdinalParts(parts, ref number, 1000, GrammaticalGender.Feminine, "тисячн" + UkrainianNumberToWordsConverter.GetEndingForGender(gender, number), new string[]
			{
				"тисяча",
				"тисячі",
				"тисяч"
			});
			if (number >= 100)
			{
				string ending = UkrainianNumberToWordsConverter.GetEndingForGender(gender, number);
				int hundreds = number / 100;
				number %= 100;
				if (number == 0)
				{
					parts.Add(UkrainianNumberToWordsConverter.UnitsOrdinalPrefixes[hundreds] + "сот" + ending);
				}
				else
				{
					parts.Add(UkrainianNumberToWordsConverter.HundredsMap[hundreds]);
				}
			}
			if (number >= 20)
			{
				string ending2 = UkrainianNumberToWordsConverter.GetEndingForGender(gender, number);
				int tens = number / 10;
				number %= 10;
				if (number == 0)
				{
					parts.Add(UkrainianNumberToWordsConverter.TensOrdinal[tens] + ending2);
				}
				else
				{
					parts.Add(UkrainianNumberToWordsConverter.TensMap[tens]);
				}
			}
			if (number > 0)
			{
				parts.Add(UkrainianNumberToWordsConverter.UnitsOrdinal[number] + UkrainianNumberToWordsConverter.GetEndingForGender(gender, number));
			}
			return string.Join(" ", parts);
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x0000A8E0 File Offset: 0x00008AE0
		private static void CollectPartsUnderOneThousand(ICollection<string> parts, int number, GrammaticalGender gender)
		{
			if (number >= 100)
			{
				int hundreds = number / 100;
				number %= 100;
				parts.Add(UkrainianNumberToWordsConverter.HundredsMap[hundreds]);
			}
			if (number >= 20)
			{
				int tens = number / 10;
				parts.Add(UkrainianNumberToWordsConverter.TensMap[tens]);
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
					parts.Add("одне");
					return;
				}
				if (number == 2 && gender == GrammaticalGender.Feminine)
				{
					parts.Add("дві");
					return;
				}
				if (number < 20)
				{
					parts.Add(UkrainianNumberToWordsConverter.UnitsMap[number]);
				}
			}
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x0000A97C File Offset: 0x00008B7C
		private static string GetPrefix(int number)
		{
			List<string> parts = new List<string>();
			if (number >= 100)
			{
				int hundreds = number / 100;
				number %= 100;
				if (hundreds != 1)
				{
					parts.Add(UkrainianNumberToWordsConverter.UnitsOrdinalPrefixes[hundreds] + "сот");
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
				parts.Add(UkrainianNumberToWordsConverter.TensOrdinalPrefixes[tens]);
			}
			if (number > 0)
			{
				parts.Add((number == 1) ? "одно" : UkrainianNumberToWordsConverter.UnitsOrdinalPrefixes[number]);
			}
			return string.Join("", parts);
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x0000AA0C File Offset: 0x00008C0C
		private static void CollectParts(ICollection<string> parts, ref int number, int divisor, GrammaticalGender gender, params string[] forms)
		{
			if (number < divisor)
			{
				return;
			}
			int result = number / divisor;
			number %= divisor;
			UkrainianNumberToWordsConverter.CollectPartsUnderOneThousand(parts, result, gender);
			parts.Add(UkrainianNumberToWordsConverter.ChooseOneForGrammaticalNumber(result, forms));
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x0000AA40 File Offset: 0x00008C40
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
				UkrainianNumberToWordsConverter.CollectPartsUnderOneThousand(parts, result, gender);
				parts.Add(UkrainianNumberToWordsConverter.ChooseOneForGrammaticalNumber(result, forms));
				return;
			}
			if (result == 1)
			{
				parts.Add(prefixedForm);
				return;
			}
			parts.Add(UkrainianNumberToWordsConverter.GetPrefix(result) + prefixedForm);
		}

		// Token: 0x060001DA RID: 474 RVA: 0x0000AA99 File Offset: 0x00008C99
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

		// Token: 0x060001DB RID: 475 RVA: 0x0000AAA7 File Offset: 0x00008CA7
		private static string ChooseOneForGrammaticalNumber(int number, string[] forms)
		{
			return forms[UkrainianNumberToWordsConverter.GetIndex(RussianGrammaticalNumberDetector.Detect(number))];
		}

		// Token: 0x060001DC RID: 476 RVA: 0x0000AAB8 File Offset: 0x00008CB8
		private static string GetEndingForGender(GrammaticalGender gender, int number)
		{
			switch (gender)
			{
			case GrammaticalGender.Masculine:
				if (number == 3)
				{
					return "ій";
				}
				return "ий";
			case GrammaticalGender.Feminine:
				if (number == 3)
				{
					return "я";
				}
				return "а";
			case GrammaticalGender.Neuter:
				if (number == 3)
				{
					return "є";
				}
				return "е";
			default:
				throw new ArgumentOutOfRangeException("gender");
			}
		}

		// Token: 0x060001DD RID: 477 RVA: 0x0000AB13 File Offset: 0x00008D13
		public UkrainianNumberToWordsConverter() : base(GrammaticalGender.Masculine)
		{
		}

		// Token: 0x04000094 RID: 148
		private static readonly string[] HundredsMap = new string[]
		{
			"нуль",
			"сто",
			"двісті",
			"триста",
			"чотириста",
			"п'ятсот",
			"шістсот",
			"сімсот",
			"вісімсот",
			"дев'ятсот"
		};

		// Token: 0x04000095 RID: 149
		private static readonly string[] TensMap = new string[]
		{
			"нуль",
			"десять",
			"двадцять",
			"тридцять",
			"сорок",
			"п'ятдесят",
			"шістдесят",
			"сімдесят",
			"вісімдесят",
			"дев'яносто"
		};

		// Token: 0x04000096 RID: 150
		private static readonly string[] UnitsMap = new string[]
		{
			"нуль",
			"один",
			"два",
			"три",
			"чотири",
			"п'ять",
			"шість",
			"сім",
			"вісім",
			"дев'ять",
			"десять",
			"одинадцять",
			"дванадцять",
			"тринадцять",
			"чотирнадцять",
			"п'ятнадцять",
			"шістнадцять",
			"сімнадцять",
			"вісімнадцять",
			"дев'ятнадцять"
		};

		// Token: 0x04000097 RID: 151
		private static readonly string[] UnitsOrdinalPrefixes = new string[]
		{
			string.Empty,
			string.Empty,
			"двох",
			"трьох",
			"чотирьох",
			"п'яти",
			"шести",
			"семи",
			"восьми",
			"дев'яти",
			"десяти",
			"одинадцяти",
			"дванадцяти",
			"тринадцяти",
			"чотирнадцяти",
			"п'ятнадцяти",
			"шістнадцяти",
			"сімнадцяти",
			"вісімнадцяти",
			"дев'ятнадцяти",
			"двадцяти"
		};

		// Token: 0x04000098 RID: 152
		private static readonly string[] TensOrdinalPrefixes = new string[]
		{
			string.Empty,
			"десяти",
			"двадцяти",
			"тридцяти",
			"сорока",
			"п'ятдесяти",
			"шістдесяти",
			"сімдесяти",
			"вісімдесяти",
			"дев'яносто"
		};

		// Token: 0x04000099 RID: 153
		private static readonly string[] TensOrdinal = new string[]
		{
			string.Empty,
			"десят",
			"двадцят",
			"тридцят",
			"сороков",
			"п'ятдесят",
			"шістдесят",
			"сімдесят",
			"вісімдесят",
			"дев'яност"
		};

		// Token: 0x0400009A RID: 154
		private static readonly string[] UnitsOrdinal = new string[]
		{
			"нульов",
			"перш",
			"друг",
			"трет",
			"четверт",
			"п'ят",
			"шост",
			"сьом",
			"восьм",
			"дев'ят",
			"десят",
			"одинадцят",
			"дванадцят",
			"тринадцят",
			"чотирнадцят",
			"п'ятнадцят",
			"шістнадцят",
			"сімнадцят",
			"вісімнадцят",
			"дев'ятнадцят"
		};
	}
}
