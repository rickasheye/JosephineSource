using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x02000058 RID: 88
	internal class TurkishNumberToWordConverter : GenderlessNumberToWordsConverter
	{
		// Token: 0x060001D0 RID: 464 RVA: 0x0000A2D8 File Offset: 0x000084D8
		public override string Convert(long input)
		{
			if (input > 2147483647L || input < -2147483648L)
			{
				throw new NotImplementedException();
			}
			int number = (int)input;
			if (number == 0)
			{
				return TurkishNumberToWordConverter.UnitsMap[0];
			}
			if (number < 0)
			{
				return string.Format("eksi {0}", new object[]
				{
					this.Convert((long)(-(long)number))
				});
			}
			List<string> parts = new List<string>();
			if (number / 1000000000 > 0)
			{
				parts.Add(string.Format("{0} milyar", new object[]
				{
					this.Convert((long)(number / 1000000000))
				}));
				number %= 1000000000;
			}
			if (number / 1000000 > 0)
			{
				parts.Add(string.Format("{0} milyon", new object[]
				{
					this.Convert((long)(number / 1000000))
				}));
				number %= 1000000;
			}
			int thousand = number / 1000;
			if (thousand > 0)
			{
				parts.Add(string.Format("{0} bin", new object[]
				{
					(thousand > 1) ? this.Convert((long)thousand) : ""
				}).Trim());
				number %= 1000;
			}
			int hundred = number / 100;
			if (hundred > 0)
			{
				parts.Add(string.Format("{0} yüz", new object[]
				{
					(hundred > 1) ? this.Convert((long)hundred) : ""
				}).Trim());
				number %= 100;
			}
			if (number / 10 > 0)
			{
				parts.Add(TurkishNumberToWordConverter.TensMap[number / 10]);
				number %= 10;
			}
			if (number > 0)
			{
				parts.Add(TurkishNumberToWordConverter.UnitsMap[number]);
			}
			return string.Join(" ", parts.ToArray());
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x0000A468 File Offset: 0x00008668
		public override string ConvertToOrdinal(int number)
		{
			string word = this.Convert((long)number);
			string wordSuffix = string.Empty;
			bool suffixFoundOnLastVowel = false;
			for (int i = word.Length - 1; i >= 0; i--)
			{
				if (TurkishNumberToWordConverter.OrdinalSuffix.TryGetValue(word[i], out wordSuffix))
				{
					suffixFoundOnLastVowel = (i == word.Length - 1);
					break;
				}
			}
			if (word[word.Length - 1] == 't')
			{
				word = word.Substring(0, word.Length - 1) + "d";
			}
			if (suffixFoundOnLastVowel)
			{
				word = word.Substring(0, word.Length - 1);
			}
			return string.Format("{0}{1}", new object[]
			{
				word,
				wordSuffix
			});
		}

		// Token: 0x04000091 RID: 145
		private static readonly string[] UnitsMap = new string[]
		{
			"sıfır",
			"bir",
			"iki",
			"üç",
			"dört",
			"beş",
			"altı",
			"yedi",
			"sekiz",
			"dokuz"
		};

		// Token: 0x04000092 RID: 146
		private static readonly string[] TensMap = new string[]
		{
			"sıfır",
			"on",
			"yirmi",
			"otuz",
			"kırk",
			"elli",
			"altmış",
			"yetmiş",
			"seksen",
			"doksan"
		};

		// Token: 0x04000093 RID: 147
		private static readonly Dictionary<char, string> OrdinalSuffix = new Dictionary<char, string>
		{
			{
				'ı',
				"ıncı"
			},
			{
				'i',
				"inci"
			},
			{
				'u',
				"uncu"
			},
			{
				'ü',
				"üncü"
			},
			{
				'o',
				"uncu"
			},
			{
				'ö',
				"üncü"
			},
			{
				'e',
				"inci"
			},
			{
				'a',
				"ıncı"
			}
		};
	}
}
