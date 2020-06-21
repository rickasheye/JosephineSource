using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x0200003D RID: 61
	internal class AfrikaansNumberToWordsConverter : GenderlessNumberToWordsConverter
	{
		// Token: 0x0600013C RID: 316 RVA: 0x000041A1 File Offset: 0x000023A1
		public override string Convert(long number)
		{
			if (number > 2147483647L || number < -2147483648L)
			{
				throw new NotImplementedException();
			}
			return this.Convert((int)number, false);
		}

		// Token: 0x0600013D RID: 317 RVA: 0x000041C4 File Offset: 0x000023C4
		public override string ConvertToOrdinal(int number)
		{
			return this.Convert(number, true);
		}

		// Token: 0x0600013E RID: 318 RVA: 0x000041D0 File Offset: 0x000023D0
		private string Convert(int number, bool isOrdinal)
		{
			if (number == 0)
			{
				return AfrikaansNumberToWordsConverter.GetUnitValue(0, isOrdinal);
			}
			if (number < 0)
			{
				return string.Format("minus {0}", new object[]
				{
					this.Convert((long)(-(long)number))
				});
			}
			List<string> parts = new List<string>();
			if (number / 1000000000 > 0)
			{
				parts.Add(string.Format("{0} miljard", new object[]
				{
					this.Convert((long)(number / 1000000000))
				}));
				number %= 1000000000;
			}
			if (number / 1000000 > 0)
			{
				parts.Add(string.Format("{0} miljoen", new object[]
				{
					this.Convert((long)(number / 1000000))
				}));
				number %= 1000000;
			}
			if (number / 1000 > 0)
			{
				parts.Add(string.Format("{0} duisend", new object[]
				{
					this.Convert((long)(number / 1000))
				}));
				number %= 1000;
			}
			if (number / 100 > 0)
			{
				parts.Add(string.Format("{0} honderd", new object[]
				{
					this.Convert((long)(number / 100))
				}));
				number %= 100;
			}
			if (number > 0)
			{
				if (number < 20)
				{
					if (parts.Count > 0)
					{
						parts.Add("en");
					}
					parts.Add(AfrikaansNumberToWordsConverter.GetUnitValue(number, isOrdinal));
				}
				else
				{
					int lastPartValue = number / 10 * 10;
					string lastPart = AfrikaansNumberToWordsConverter.TensMap[number / 10];
					if (number % 10 > 0)
					{
						lastPart = string.Format("{0} en {1}", new object[]
						{
							AfrikaansNumberToWordsConverter.GetUnitValue(number % 10, false),
							isOrdinal ? AfrikaansNumberToWordsConverter.GetUnitValue(lastPartValue, isOrdinal) : lastPart
						});
					}
					else if (number % 10 == 0)
					{
						lastPart = string.Format("{0}{1}{2}", new object[]
						{
							(parts.Count > 0) ? "en " : "",
							lastPart,
							isOrdinal ? "ste" : ""
						});
					}
					else if (isOrdinal)
					{
						lastPart = lastPart.TrimEnd(new char[]
						{
							'~'
						}) + "ste";
					}
					parts.Add(lastPart);
				}
			}
			else if (isOrdinal)
			{
				List<string> list = parts;
				int index = parts.Count - 1;
				list[index] += "ste";
			}
			string toWords = string.Join(" ", parts.ToArray());
			if (isOrdinal)
			{
				toWords = AfrikaansNumberToWordsConverter.RemoveOnePrefix(toWords);
			}
			return toWords;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00004424 File Offset: 0x00002624
		private static string GetUnitValue(int number, bool isOrdinal)
		{
			if (!isOrdinal)
			{
				return AfrikaansNumberToWordsConverter.UnitsMap[number];
			}
			string exceptionString;
			if (AfrikaansNumberToWordsConverter.ExceptionNumbersToWords(number, out exceptionString))
			{
				return exceptionString;
			}
			if (number > 19)
			{
				return AfrikaansNumberToWordsConverter.TensMap[number / 10] + "ste";
			}
			return AfrikaansNumberToWordsConverter.UnitsMap[number] + "de";
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00004473 File Offset: 0x00002673
		private static string RemoveOnePrefix(string toWords)
		{
			if (toWords.IndexOf("een", StringComparison.Ordinal) == 0 && toWords.IndexOf("een en", StringComparison.Ordinal) != 0)
			{
				toWords = toWords.Remove(0, 4);
			}
			return toWords;
		}

		// Token: 0x06000141 RID: 321 RVA: 0x0000449C File Offset: 0x0000269C
		private static bool ExceptionNumbersToWords(int number, out string words)
		{
			return AfrikaansNumberToWordsConverter.OrdinalExceptions.TryGetValue(number, out words);
		}

		// Token: 0x0400003F RID: 63
		private static readonly string[] UnitsMap = new string[]
		{
			"nul",
			"een",
			"twee",
			"drie",
			"vier",
			"vyf",
			"ses",
			"sewe",
			"agt",
			"nege",
			"tien",
			"elf",
			"twaalf",
			"dertien",
			"veertien",
			"vyftien",
			"sestien",
			"sewentien",
			"agtien",
			"negentien"
		};

		// Token: 0x04000040 RID: 64
		private static readonly string[] TensMap = new string[]
		{
			"nul",
			"tien",
			"twintig",
			"dertig",
			"veertig",
			"vyftig",
			"sestig",
			"sewentig",
			"tagtig",
			"negentig"
		};

		// Token: 0x04000041 RID: 65
		private static readonly Dictionary<int, string> OrdinalExceptions = new Dictionary<int, string>
		{
			{
				0,
				"nulste"
			},
			{
				1,
				"eerste"
			},
			{
				3,
				"derde"
			},
			{
				7,
				"sewende"
			},
			{
				8,
				"agste"
			},
			{
				9,
				"negende"
			},
			{
				10,
				"tiende"
			},
			{
				14,
				"veertiende"
			},
			{
				17,
				"sewentiende"
			},
			{
				19,
				"negentiende"
			}
		};
	}
}
