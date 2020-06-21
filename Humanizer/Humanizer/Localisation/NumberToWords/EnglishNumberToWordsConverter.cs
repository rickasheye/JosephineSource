using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x02000043 RID: 67
	internal class EnglishNumberToWordsConverter : GenderlessNumberToWordsConverter
	{
		// Token: 0x0600015B RID: 347 RVA: 0x000063FD File Offset: 0x000045FD
		public override string Convert(long number)
		{
			return this.Convert(number, false);
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00006407 File Offset: 0x00004607
		public override string ConvertToOrdinal(int number)
		{
			return this.Convert((long)number, true);
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00006414 File Offset: 0x00004614
		private string Convert(long number, bool isOrdinal)
		{
			if (number == 0L)
			{
				return EnglishNumberToWordsConverter.GetUnitValue(0L, isOrdinal);
			}
			if (number < 0L)
			{
				return string.Format("minus {0}", new object[]
				{
					this.Convert(-number)
				});
			}
			List<string> parts = new List<string>();
			if (number / 1000000000000000000L > 0L)
			{
				parts.Add(string.Format("{0} quintillion", new object[]
				{
					this.Convert(number / 1000000000000000000L)
				}));
				number %= 1000000000000000000L;
			}
			if (number / 1000000000000000L > 0L)
			{
				parts.Add(string.Format("{0} quadrillion", new object[]
				{
					this.Convert(number / 1000000000000000L)
				}));
				number %= 1000000000000000L;
			}
			if (number / 1000000000000L > 0L)
			{
				parts.Add(string.Format("{0} trillion", new object[]
				{
					this.Convert(number / 1000000000000L)
				}));
				number %= 1000000000000L;
			}
			if (number / 1000000000L > 0L)
			{
				parts.Add(string.Format("{0} billion", new object[]
				{
					this.Convert(number / 1000000000L)
				}));
				number %= 1000000000L;
			}
			if (number / 1000000L > 0L)
			{
				parts.Add(string.Format("{0} million", new object[]
				{
					this.Convert(number / 1000000L)
				}));
				number %= 1000000L;
			}
			if (number / 1000L > 0L)
			{
				parts.Add(string.Format("{0} thousand", new object[]
				{
					this.Convert(number / 1000L)
				}));
				number %= 1000L;
			}
			if (number / 100L > 0L)
			{
				parts.Add(string.Format("{0} hundred", new object[]
				{
					this.Convert(number / 100L)
				}));
				number %= 100L;
			}
			if (number > 0L)
			{
				if (parts.Count != 0)
				{
					parts.Add("and");
				}
				if (number < 20L)
				{
					parts.Add(EnglishNumberToWordsConverter.GetUnitValue(number, isOrdinal));
				}
				else
				{
					string lastPart = EnglishNumberToWordsConverter.TensMap[(int)(checked((IntPtr)(number / 10L)))];
					if (number % 10L > 0L)
					{
						lastPart += string.Format("-{0}", new object[]
						{
							EnglishNumberToWordsConverter.GetUnitValue(number % 10L, isOrdinal)
						});
					}
					else if (isOrdinal)
					{
						lastPart = lastPart.TrimEnd(new char[]
						{
							'y'
						}) + "ieth";
					}
					parts.Add(lastPart);
				}
			}
			else if (isOrdinal)
			{
				List<string> list = parts;
				int index = parts.Count - 1;
				list[index] += "th";
			}
			string toWords = string.Join(" ", parts.ToArray());
			if (isOrdinal)
			{
				toWords = EnglishNumberToWordsConverter.RemoveOnePrefix(toWords);
			}
			return toWords;
		}

		// Token: 0x0600015E RID: 350 RVA: 0x000066F0 File Offset: 0x000048F0
		private static string GetUnitValue(long number, bool isOrdinal)
		{
			checked
			{
				if (!isOrdinal)
				{
					return EnglishNumberToWordsConverter.UnitsMap[(int)((IntPtr)number)];
				}
				string exceptionString;
				if (EnglishNumberToWordsConverter.ExceptionNumbersToWords(number, out exceptionString))
				{
					return exceptionString;
				}
				return EnglishNumberToWordsConverter.UnitsMap[(int)((IntPtr)number)] + "th";
			}
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00006727 File Offset: 0x00004927
		private static string RemoveOnePrefix(string toWords)
		{
			if (toWords.IndexOf("one", StringComparison.Ordinal) == 0)
			{
				toWords = toWords.Remove(0, 4);
			}
			return toWords;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00006742 File Offset: 0x00004942
		private static bool ExceptionNumbersToWords(long number, out string words)
		{
			return EnglishNumberToWordsConverter.OrdinalExceptions.TryGetValue(number, out words);
		}

		// Token: 0x0400005C RID: 92
		private static readonly string[] UnitsMap = new string[]
		{
			"zero",
			"one",
			"two",
			"three",
			"four",
			"five",
			"six",
			"seven",
			"eight",
			"nine",
			"ten",
			"eleven",
			"twelve",
			"thirteen",
			"fourteen",
			"fifteen",
			"sixteen",
			"seventeen",
			"eighteen",
			"nineteen"
		};

		// Token: 0x0400005D RID: 93
		private static readonly string[] TensMap = new string[]
		{
			"zero",
			"ten",
			"twenty",
			"thirty",
			"forty",
			"fifty",
			"sixty",
			"seventy",
			"eighty",
			"ninety"
		};

		// Token: 0x0400005E RID: 94
		private static readonly Dictionary<long, string> OrdinalExceptions = new Dictionary<long, string>
		{
			{
				1L,
				"first"
			},
			{
				2L,
				"second"
			},
			{
				3L,
				"third"
			},
			{
				4L,
				"fourth"
			},
			{
				5L,
				"fifth"
			},
			{
				8L,
				"eighth"
			},
			{
				9L,
				"ninth"
			},
			{
				12L,
				"twelfth"
			}
		};
	}
}
