﻿using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x0200003F RID: 63
	internal class BanglaNumberToWordsConverter : GenderlessNumberToWordsConverter
	{
		// Token: 0x06000149 RID: 329 RVA: 0x00005134 File Offset: 0x00003334
		public override string ConvertToOrdinal(int number)
		{
			string exceptionString;
			if (BanglaNumberToWordsConverter.ExceptionNumbersToWords(number, out exceptionString))
			{
				return exceptionString;
			}
			return this.Convert((long)number) + " তম";
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00005160 File Offset: 0x00003360
		public override string Convert(long input)
		{
			if (input > 2147483647L || input < -2147483648L)
			{
				throw new NotImplementedException();
			}
			int number = (int)input;
			if (number == 0)
			{
				return BanglaNumberToWordsConverter.UnitsMap[0];
			}
			if (number < 0)
			{
				return string.Format("ঋণাত্মক {0}", new object[]
				{
					this.Convert((long)(-(long)number))
				});
			}
			List<string> parts = new List<string>();
			if (number / 10000000 > 0)
			{
				parts.Add(string.Format("{0} কোটি", new object[]
				{
					this.Convert((long)(number / 10000000))
				}));
				number %= 10000000;
			}
			if (number / 100000 > 0)
			{
				parts.Add(string.Format("{0} লক্ষ", new object[]
				{
					this.Convert((long)(number / 100000))
				}));
				number %= 100000;
			}
			if (number / 1000 > 0)
			{
				parts.Add(string.Format("{0} হাজার", new object[]
				{
					this.Convert((long)(number / 1000))
				}));
				number %= 1000;
			}
			if (number / 100 > 0)
			{
				parts.Add(string.Format("{0}", new object[]
				{
					BanglaNumberToWordsConverter.HundredsMap[number / 100]
				}));
				number %= 100;
			}
			if (number > 0)
			{
				parts.Add(BanglaNumberToWordsConverter.UnitsMap[number]);
			}
			return string.Join(" ", parts.ToArray());
		}

		// Token: 0x0600014B RID: 331 RVA: 0x000052B5 File Offset: 0x000034B5
		private static bool ExceptionNumbersToWords(int number, out string words)
		{
			return BanglaNumberToWordsConverter.OrdinalExceptions.TryGetValue(number, out words);
		}

		// Token: 0x0400004D RID: 77
		private static readonly string[] UnitsMap = new string[]
		{
			"শূন্য",
			"এক",
			"দুই",
			"তিন",
			"চার",
			"পাঁচ",
			"ছয়",
			"সাত",
			"আট",
			"নয়",
			"দশ",
			"এগারো",
			"বারো",
			"তেরো",
			"চোদ্দ",
			"পনেরো",
			"ষোল",
			"সতেরো",
			"আঠারো",
			"উনিশ",
			"বিশ",
			"একুশ",
			"বাইশ",
			"তেইশ",
			"চব্বিশ",
			"পঁচিশ",
			"ছাব্বিশ",
			"সাতাশ",
			"আঠাশ",
			"উনতিরিশ",
			"তিরিশ",
			"একতিরিশ",
			"বত্রিশ",
			"তেত্রিশ",
			"চৌঁতিরিশ",
			"পঁয়তিরিশ",
			"ছত্রিশ",
			"সাঁইতিরিশ",
			"আটতিরিশ",
			"উনচল্লিশ",
			"চল্লিশ",
			"একচল্লিশ",
			"বিয়াল্লিশ",
			"তেতাল্লিশ",
			"চুয়াল্লিশ",
			"পঁয়তাল্লিশ",
			"ছেচাল্লিশ",
			"সাতচল্লিশ",
			"আটচল্লিশ",
			"উনপঞ্চাশ",
			"পঞ্চাশ",
			"একান্ন",
			"বাহান্ন",
			"তিপ্পান্ন",
			"চুয়ান্ন",
			"পঞ্চান্ন",
			"ছাপ্পান্ন",
			"সাতান্ন",
			"আটান্ন",
			"উনষাট",
			"ষাট",
			"একষট্টি",
			"বাষট্টি",
			"তেষট্টি",
			"চৌষট্টি",
			"পঁয়ষট্টি",
			"ছেষট্টি",
			"সাতষট্টি",
			"আটষট্টি",
			"উনসত্তর",
			"সত্তর",
			"একাত্তর",
			"বাহাত্তর",
			"তিয়াত্তর",
			"চুয়াত্তর",
			"পঁচাত্তর",
			"ছিয়াত্তর",
			"সাতাত্তর",
			"আটাত্তর",
			"উনআশি",
			"আশি",
			"একাশি",
			"বিরাশি",
			"তিরাশি",
			"চুরাশি",
			"পঁচাশি",
			"ছিয়াশি",
			"সাতাশি",
			"আটাশি",
			"উননব্বই",
			"নব্বই",
			"একানব্বই",
			"বিরানব্বই",
			"তিরানব্বিই",
			"চুরানব্বই",
			"পঁচানব্বই",
			"ছিয়ানব্বই",
			"সাতানব্বই",
			"আটানব্বই",
			"নিরানব্বই"
		};

		// Token: 0x0400004E RID: 78
		private static readonly string[] HundredsMap = new string[]
		{
			"শূন্য",
			"একশ",
			"দুইশ",
			"তিনশ",
			"চারশ",
			"পাঁচশ",
			"ছয়শ",
			"সাতশ",
			"আটশ",
			"নয়শ"
		};

		// Token: 0x0400004F RID: 79
		private static readonly Dictionary<int, string> OrdinalExceptions = new Dictionary<int, string>
		{
			{
				1,
				"প্রথম"
			},
			{
				2,
				"দ্বিতীয়"
			},
			{
				3,
				"তৃতীয়"
			},
			{
				4,
				"চতুর্থ"
			},
			{
				5,
				"পঞ্চম"
			},
			{
				6,
				"ষষ্ট"
			},
			{
				7,
				"সপ্তম"
			},
			{
				8,
				"অষ্টম"
			},
			{
				9,
				"নবম"
			},
			{
				10,
				"দশম"
			},
			{
				11,
				"একাদশ"
			},
			{
				12,
				"দ্বাদশ"
			},
			{
				13,
				"ত্রয়োদশ"
			},
			{
				14,
				"চতুর্দশ"
			},
			{
				15,
				"পঞ্চদশ"
			},
			{
				16,
				"ষোড়শ"
			},
			{
				17,
				"সপ্তদশ"
			},
			{
				18,
				"অষ্টাদশ"
			},
			{
				100,
				"শত তম"
			},
			{
				1000,
				"হাজার তম"
			},
			{
				100000,
				"লক্ষ তম"
			},
			{
				10000000,
				"কোটি তম"
			}
		};
	}
}
