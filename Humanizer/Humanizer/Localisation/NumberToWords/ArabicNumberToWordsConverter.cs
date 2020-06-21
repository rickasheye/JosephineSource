using System;
using System.Collections.Generic;
using System.Linq;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x0200003E RID: 62
	internal class ArabicNumberToWordsConverter : GenderedNumberToWordsConverter
	{
		// Token: 0x06000144 RID: 324 RVA: 0x0000465C File Offset: 0x0000285C
		public override string Convert(long input, GrammaticalGender gender)
		{
			if (input > 2147483647L || input < -2147483648L)
			{
				throw new NotImplementedException();
			}
			int number = (int)input;
			if (number == 0)
			{
				return "صفر";
			}
			string result = string.Empty;
			int groupLevel = 0;
			while (number >= 1)
			{
				int groupNumber = number % 1000;
				number /= 1000;
				int tens = groupNumber % 100;
				int hundreds = groupNumber / 100;
				string process = string.Empty;
				if (hundreds > 0)
				{
					if (tens == 0 && hundreds == 2)
					{
						process = ArabicNumberToWordsConverter.AppendedTwos[0];
					}
					else
					{
						process = ArabicNumberToWordsConverter.HundredsGroup[hundreds];
					}
				}
				if (tens > 0)
				{
					if (tens < 20)
					{
						if (tens == 2 && hundreds == 0 && groupLevel > 0)
						{
							if (number == 2000 || number == 2000000 || number == 2000000000)
							{
								process = ArabicNumberToWordsConverter.AppendedTwos[groupLevel];
							}
							else
							{
								process = ArabicNumberToWordsConverter.Twos[groupLevel];
							}
						}
						else
						{
							if (process != string.Empty)
							{
								process += " و ";
							}
							if (tens == 1 && groupLevel > 0 && hundreds == 0)
							{
								process += " ";
							}
							else
							{
								process += ((gender == GrammaticalGender.Feminine && groupLevel == 0) ? ArabicNumberToWordsConverter.FeminineOnesGroup[tens] : ArabicNumberToWordsConverter.OnesGroup[tens]);
							}
						}
					}
					else
					{
						int ones = tens % 10;
						tens /= 10;
						if (ones > 0)
						{
							if (process != string.Empty)
							{
								process += " و ";
							}
							process += ((gender == GrammaticalGender.Feminine) ? ArabicNumberToWordsConverter.FeminineOnesGroup[ones] : ArabicNumberToWordsConverter.OnesGroup[ones]);
						}
						if (process != string.Empty)
						{
							process += " و ";
						}
						process += ArabicNumberToWordsConverter.TensGroup[tens];
					}
				}
				if (process != string.Empty)
				{
					if (groupLevel > 0)
					{
						if (result != string.Empty)
						{
							result = string.Format("{0} {1}", new object[]
							{
								"و",
								result
							});
						}
						if (groupNumber != 2)
						{
							if (groupNumber % 100 != 1)
							{
								if (groupNumber >= 3 && groupNumber <= 10)
								{
									result = string.Format("{0} {1}", new object[]
									{
										ArabicNumberToWordsConverter.PluralGroups[groupLevel],
										result
									});
								}
								else
								{
									result = string.Format("{0} {1}", new object[]
									{
										(result != string.Empty) ? ArabicNumberToWordsConverter.AppendedGroups[groupLevel] : ArabicNumberToWordsConverter.Groups[groupLevel],
										result
									});
								}
							}
							else
							{
								result = string.Format("{0} {1}", new object[]
								{
									ArabicNumberToWordsConverter.Groups[groupLevel],
									result
								});
							}
						}
					}
					result = string.Format("{0} {1}", new object[]
					{
						process,
						result
					});
				}
				groupLevel++;
			}
			return result.Trim();
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00004908 File Offset: 0x00002B08
		public override string ConvertToOrdinal(int number, GrammaticalGender gender)
		{
			if (number == 0)
			{
				return "الصفر";
			}
			int beforeOneHundredNumber = number % 100;
			int overTensPart = number / 100 * 100;
			string beforeOneHundredWord = string.Empty;
			string overTensWord = string.Empty;
			if (beforeOneHundredNumber > 0)
			{
				beforeOneHundredWord = this.Convert((long)beforeOneHundredNumber, gender);
				beforeOneHundredWord = ArabicNumberToWordsConverter.ParseNumber(beforeOneHundredWord, beforeOneHundredNumber, gender);
			}
			if (overTensPart > 0)
			{
				overTensWord = base.Convert((long)overTensPart);
				overTensWord = ArabicNumberToWordsConverter.ParseNumber(overTensWord, overTensPart, gender);
			}
			return (beforeOneHundredWord + ((overTensPart > 0) ? ((string.IsNullOrWhiteSpace(beforeOneHundredWord) ? string.Empty : " بعد ") + overTensWord) : string.Empty)).Trim();
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00004994 File Offset: 0x00002B94
		private static string ParseNumber(string word, int number, GrammaticalGender gender)
		{
			if (number != 1)
			{
				if (number <= 10)
				{
					IEnumerable<KeyValuePair<string, string>> source = (gender == GrammaticalGender.Feminine) ? ArabicNumberToWordsConverter.FeminineOrdinalExceptions : ArabicNumberToWordsConverter.OrdinalExceptions;
					Func<KeyValuePair<string, string>, bool> <>9__0;
					Func<KeyValuePair<string, string>, bool> predicate;
					if ((predicate = <>9__0) == null)
					{
						predicate = (<>9__0 = ((KeyValuePair<string, string> kv) => word.EndsWith(kv.Key)));
					}
					using (IEnumerator<KeyValuePair<string, string>> enumerator = source.Where(predicate).GetEnumerator())
					{
						if (!enumerator.MoveNext())
						{
							goto IL_21F;
						}
						KeyValuePair<string, string> kv3 = enumerator.Current;
						return word.Substring(0, word.Length - kv3.Key.Length) + kv3.Value;
					}
				}
				if (number > 10 && number < 100)
				{
					string[] array = word.Split(new char[]
					{
						' '
					});
					string[] newParts = new string[array.Length];
					int count = 0;
					string[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						string part = array2[i];
						string newPart = part;
						string oldPart = part;
						IEnumerable<KeyValuePair<string, string>> source2 = (gender == GrammaticalGender.Feminine) ? ArabicNumberToWordsConverter.FeminineOrdinalExceptions : ArabicNumberToWordsConverter.OrdinalExceptions;
						Func<KeyValuePair<string, string>, bool> predicate2;
						Func<KeyValuePair<string, string>, bool> <>9__1;
						if ((predicate2 = <>9__1) == null)
						{
							predicate2 = (<>9__1 = ((KeyValuePair<string, string> kv) => oldPart.EndsWith(kv.Key)));
						}
						foreach (KeyValuePair<string, string> kv2 in source2.Where(predicate2))
						{
							newPart = oldPart.Substring(0, oldPart.Length - kv2.Key.Length) + kv2.Value;
						}
						if (number > 19 && newPart == oldPart && oldPart.Length > 1)
						{
							newPart = "ال" + oldPart;
						}
						newParts[count++] = newPart;
					}
					word = string.Join(" ", newParts);
				}
				else
				{
					word = "ال" + word;
				}
				IL_21F:
				return word;
			}
			if (gender != GrammaticalGender.Feminine)
			{
				return "الأول";
			}
			return "الأولى";
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00004BE8 File Offset: 0x00002DE8
		public ArabicNumberToWordsConverter() : base(GrammaticalGender.Masculine)
		{
		}

		// Token: 0x04000042 RID: 66
		private static readonly string[] Groups = new string[]
		{
			"مئة",
			"ألف",
			"مليون",
			"مليار",
			"تريليون",
			"كوادريليون",
			"كوينتليون",
			"سكستيليون"
		};

		// Token: 0x04000043 RID: 67
		private static readonly string[] AppendedGroups = new string[]
		{
			"",
			"ألفاً",
			"مليوناً",
			"ملياراً",
			"تريليوناً",
			"كوادريليوناً",
			"كوينتليوناً",
			"سكستيليوناً"
		};

		// Token: 0x04000044 RID: 68
		private static readonly string[] PluralGroups = new string[]
		{
			"",
			"آلاف",
			"ملايين",
			"مليارات",
			"تريليونات",
			"كوادريليونات",
			"كوينتليونات",
			"سكستيليونات"
		};

		// Token: 0x04000045 RID: 69
		private static readonly string[] OnesGroup = new string[]
		{
			"",
			"واحد",
			"اثنان",
			"ثلاثة",
			"أربعة",
			"خمسة",
			"ستة",
			"سبعة",
			"ثمانية",
			"تسعة",
			"عشرة",
			"أحد عشر",
			"اثنا عشر",
			"ثلاثة عشر",
			"أربعة عشر",
			"خمسة عشر",
			"ستة عشر",
			"سبعة عشر",
			"ثمانية عشر",
			"تسعة عشر"
		};

		// Token: 0x04000046 RID: 70
		private static readonly string[] TensGroup = new string[]
		{
			"",
			"عشرة",
			"عشرون",
			"ثلاثون",
			"أربعون",
			"خمسون",
			"ستون",
			"سبعون",
			"ثمانون",
			"تسعون"
		};

		// Token: 0x04000047 RID: 71
		private static readonly string[] HundredsGroup = new string[]
		{
			"",
			"مئة",
			"مئتان",
			"ثلاث مئة",
			"أربع مئة",
			"خمس مئة",
			"ست مئة",
			"سبع مئة",
			"ثمان مئة",
			"تسع مئة"
		};

		// Token: 0x04000048 RID: 72
		private static readonly string[] AppendedTwos = new string[]
		{
			"مئتان",
			"ألفان",
			"مليونان",
			"ملياران",
			"تريليونان",
			"كوادريليونان",
			"كوينتليونان",
			"سكستيليونلن"
		};

		// Token: 0x04000049 RID: 73
		private static readonly string[] Twos = new string[]
		{
			"مئتان",
			"ألفان",
			"مليونان",
			"ملياران",
			"تريليونان",
			"كوادريليونان",
			"كوينتليونان",
			"سكستيليونان"
		};

		// Token: 0x0400004A RID: 74
		private static readonly string[] FeminineOnesGroup = new string[]
		{
			"",
			"واحدة",
			"اثنتان",
			"ثلاث",
			"أربع",
			"خمس",
			"ست",
			"سبع",
			"ثمان",
			"تسع",
			"عشر",
			"إحدى عشرة",
			"اثنتا عشرة",
			"ثلاث عشرة",
			"أربع عشرة",
			"خمس عشرة",
			"ست عشرة",
			"سبع عشرة",
			"ثمان عشرة",
			"تسع عشرة"
		};

		// Token: 0x0400004B RID: 75
		private static readonly Dictionary<string, string> OrdinalExceptions = new Dictionary<string, string>
		{
			{
				"واحد",
				"الحادي"
			},
			{
				"أحد",
				"الحادي"
			},
			{
				"اثنان",
				"الثاني"
			},
			{
				"اثنا",
				"الثاني"
			},
			{
				"ثلاثة",
				"الثالث"
			},
			{
				"أربعة",
				"الرابع"
			},
			{
				"خمسة",
				"الخامس"
			},
			{
				"ستة",
				"السادس"
			},
			{
				"سبعة",
				"السابع"
			},
			{
				"ثمانية",
				"الثامن"
			},
			{
				"تسعة",
				"التاسع"
			},
			{
				"عشرة",
				"العاشر"
			}
		};

		// Token: 0x0400004C RID: 76
		private static readonly Dictionary<string, string> FeminineOrdinalExceptions = new Dictionary<string, string>
		{
			{
				"واحدة",
				"الحادية"
			},
			{
				"إحدى",
				"الحادية"
			},
			{
				"اثنتان",
				"الثانية"
			},
			{
				"اثنتا",
				"الثانية"
			},
			{
				"ثلاث",
				"الثالثة"
			},
			{
				"أربع",
				"الرابعة"
			},
			{
				"خمس",
				"الخامسة"
			},
			{
				"ست",
				"السادسة"
			},
			{
				"سبع",
				"السابعة"
			},
			{
				"ثمان",
				"الثامنة"
			},
			{
				"تسع",
				"التاسعة"
			},
			{
				"عشر",
				"العاشرة"
			}
		};
	}
}
