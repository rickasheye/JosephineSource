using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Humanizer
{
	// Token: 0x02000019 RID: 25
	public static class RomanNumeralExtensions
	{
		// Token: 0x060000D8 RID: 216 RVA: 0x00003280 File Offset: 0x00001480
		public static int FromRoman(this string input)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}
			input = input.Trim().ToUpperInvariant();
			int length = input.Length;
			if (length == 0 || RomanNumeralExtensions.IsInvalidRomanNumeral(input))
			{
				throw new ArgumentException("Empty or invalid Roman numeral string.", "input");
			}
			int total = 0;
			int i = length;
			while (i > 0)
			{
				int digit = RomanNumeralExtensions.RomanNumerals[input[--i].ToString()];
				if (i > 0)
				{
					int previousDigit = RomanNumeralExtensions.RomanNumerals[input[i - 1].ToString()];
					if (previousDigit < digit)
					{
						digit -= previousDigit;
						i--;
					}
				}
				total += digit;
			}
			return total;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00003324 File Offset: 0x00001524
		public static string ToRoman(this int input)
		{
			if (input < 1 || input > 3999)
			{
				throw new ArgumentOutOfRangeException();
			}
			StringBuilder sb = new StringBuilder(15);
			foreach (KeyValuePair<string, int> pair in RomanNumeralExtensions.RomanNumerals)
			{
				while (input / pair.Value > 0)
				{
					sb.Append(pair.Key);
					input -= pair.Value;
				}
			}
			return sb.ToString();
		}

		// Token: 0x060000DA RID: 218 RVA: 0x000033B0 File Offset: 0x000015B0
		private static bool IsInvalidRomanNumeral(string input)
		{
			return !RomanNumeralExtensions.ValidRomanNumeral.IsMatch(input);
		}

		// Token: 0x04000021 RID: 33
		private const int NumberOfRomanNumeralMaps = 13;

		// Token: 0x04000022 RID: 34
		private static readonly IDictionary<string, int> RomanNumerals = new Dictionary<string, int>(13)
		{
			{
				"M",
				1000
			},
			{
				"CM",
				900
			},
			{
				"D",
				500
			},
			{
				"CD",
				400
			},
			{
				"C",
				100
			},
			{
				"XC",
				90
			},
			{
				"L",
				50
			},
			{
				"XL",
				40
			},
			{
				"X",
				10
			},
			{
				"IX",
				9
			},
			{
				"V",
				5
			},
			{
				"IV",
				4
			},
			{
				"I",
				1
			}
		};

		// Token: 0x04000023 RID: 35
		private static readonly Regex ValidRomanNumeral = new Regex("^(?i:(?=[MDCLXVI])((M{0,3})((C[DM])|(D?C{0,3}))?((X[LC])|(L?XX{0,2})|L)?((I[VX])|(V?(II{0,2}))|V)?))$", RegexOptionsUtil.Compiled);
	}
}
