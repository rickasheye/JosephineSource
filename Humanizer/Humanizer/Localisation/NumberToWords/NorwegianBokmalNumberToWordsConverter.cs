using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x02000050 RID: 80
	internal class NorwegianBokmalNumberToWordsConverter : GenderedNumberToWordsConverter
	{
		// Token: 0x060001A1 RID: 417 RVA: 0x000081C0 File Offset: 0x000063C0
		public override string Convert(long number, GrammaticalGender gender)
		{
			if (number > 2147483647L || number < -2147483648L)
			{
				throw new NotImplementedException();
			}
			return this.Convert((int)number, false, gender);
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x000081E4 File Offset: 0x000063E4
		public override string ConvertToOrdinal(int number, GrammaticalGender gender)
		{
			return this.Convert(number, true, gender);
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x000081F0 File Offset: 0x000063F0
		private string Convert(int number, bool isOrdinal, GrammaticalGender gender)
		{
			if (number == 0)
			{
				return NorwegianBokmalNumberToWordsConverter.GetUnitValue(0, isOrdinal);
			}
			if (number < 0)
			{
				return string.Format("minus {0}", new object[]
				{
					this.Convert(-number, isOrdinal, gender)
				});
			}
			if (number == 1)
			{
				if (gender == GrammaticalGender.Feminine)
				{
					return "ei";
				}
				if (gender == GrammaticalGender.Neuter)
				{
					return "et";
				}
			}
			List<string> parts = new List<string>();
			bool millionOrMore = false;
			if (number / 1000000000 > 0)
			{
				millionOrMore = true;
				bool isExactOrdinal = isOrdinal && number % 1000000000 == 0;
				parts.Add(this.Part("{0} milliard" + (isExactOrdinal ? "" : "er"), (isExactOrdinal ? "" : "en ") + "milliard", number / 1000000000, !isExactOrdinal));
				number %= 1000000000;
			}
			if (number / 1000000 > 0)
			{
				millionOrMore = true;
				bool isExactOrdinal2 = isOrdinal && number % 1000000 == 0;
				parts.Add(this.Part("{0} million" + (isExactOrdinal2 ? "" : "er"), (isExactOrdinal2 ? "" : "en ") + "million", number / 1000000, !isExactOrdinal2));
				number %= 1000000;
			}
			bool thousand = false;
			if (number / 1000 > 0)
			{
				thousand = true;
				parts.Add(this.Part("{0}tusen", (number % 1000 < 100) ? "tusen" : "ettusen", number / 1000, false));
				number %= 1000;
			}
			bool hundred = false;
			if (number / 100 > 0)
			{
				hundred = true;
				parts.Add(this.Part("{0}hundre", (thousand || millionOrMore) ? "ethundre" : "hundre", number / 100, false));
				number %= 100;
			}
			if (number > 0)
			{
				if (parts.Count != 0)
				{
					if (millionOrMore && !hundred && !thousand)
					{
						parts.Add("og ");
					}
					else
					{
						parts.Add("og");
					}
				}
				if (number < 20)
				{
					parts.Add(NorwegianBokmalNumberToWordsConverter.GetUnitValue(number, isOrdinal));
				}
				else
				{
					string lastPart = NorwegianBokmalNumberToWordsConverter.TensMap[number / 10];
					if (number % 10 > 0)
					{
						lastPart += string.Format("{0}", new object[]
						{
							NorwegianBokmalNumberToWordsConverter.GetUnitValue(number % 10, isOrdinal)
						});
					}
					else if (isOrdinal)
					{
						lastPart = lastPart.TrimEnd(new char[]
						{
							'e'
						}) + "ende";
					}
					parts.Add(lastPart);
				}
			}
			else if (isOrdinal)
			{
				List<string> list = parts;
				int index = parts.Count - 1;
				list[index] = list[index] + ((number == 0) ? "" : "en") + (millionOrMore ? "te" : "de");
			}
			return string.Join("", parts.ToArray()).Trim();
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x000084B8 File Offset: 0x000066B8
		private static string GetUnitValue(int number, bool isOrdinal)
		{
			if (!isOrdinal)
			{
				return NorwegianBokmalNumberToWordsConverter.UnitsMap[number];
			}
			string exceptionString;
			if (NorwegianBokmalNumberToWordsConverter.ExceptionNumbersToWords(number, out exceptionString))
			{
				return exceptionString;
			}
			if (number < 13)
			{
				return NorwegianBokmalNumberToWordsConverter.UnitsMap[number].TrimEnd(new char[]
				{
					'e'
				}) + "ende";
			}
			return NorwegianBokmalNumberToWordsConverter.UnitsMap[number] + "de";
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00008514 File Offset: 0x00006714
		private static bool ExceptionNumbersToWords(int number, out string words)
		{
			return NorwegianBokmalNumberToWordsConverter.OrdinalExceptions.TryGetValue(number, out words);
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00008524 File Offset: 0x00006724
		private string Part(string pluralFormat, string singular, int number, bool postfixSpace = false)
		{
			string postfix = postfixSpace ? " " : "";
			if (number == 1)
			{
				return singular + postfix;
			}
			return string.Format(pluralFormat, new object[]
			{
				base.Convert((long)number)
			}) + postfix;
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x0000856B File Offset: 0x0000676B
		public NorwegianBokmalNumberToWordsConverter() : base(GrammaticalGender.Masculine)
		{
		}

		// Token: 0x04000073 RID: 115
		private static readonly string[] UnitsMap = new string[]
		{
			"null",
			"en",
			"to",
			"tre",
			"fire",
			"fem",
			"seks",
			"sju",
			"åtte",
			"ni",
			"ti",
			"elleve",
			"tolv",
			"tretten",
			"fjorten",
			"femten",
			"seksten",
			"sytten",
			"atten",
			"nitten"
		};

		// Token: 0x04000074 RID: 116
		private static readonly string[] TensMap = new string[]
		{
			"null",
			"ti",
			"tjue",
			"tretti",
			"førti",
			"femti",
			"seksti",
			"sytti",
			"åtti",
			"nitti"
		};

		// Token: 0x04000075 RID: 117
		private static readonly Dictionary<int, string> OrdinalExceptions = new Dictionary<int, string>
		{
			{
				0,
				"nullte"
			},
			{
				1,
				"første"
			},
			{
				2,
				"andre"
			},
			{
				3,
				"tredje"
			},
			{
				4,
				"fjerde"
			},
			{
				5,
				"femte"
			},
			{
				6,
				"sjette"
			},
			{
				11,
				"ellevte"
			},
			{
				12,
				"tolvte"
			}
		};
	}
}
