using System;
using System.Collections.Generic;
using System.Globalization;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x0200004D RID: 77
	internal class HebrewNumberToWordsConverter : GenderedNumberToWordsConverter
	{
		// Token: 0x06000193 RID: 403 RVA: 0x00007D44 File Offset: 0x00005F44
		public HebrewNumberToWordsConverter(CultureInfo culture) : base(GrammaticalGender.Feminine)
		{
			this._culture = culture;
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00007D54 File Offset: 0x00005F54
		public override string Convert(long input, GrammaticalGender gender)
		{
			if (input > 2147483647L || input < -2147483648L)
			{
				throw new NotImplementedException();
			}
			int number = (int)input;
			if (number < 0)
			{
				return string.Format("מינוס {0}", new object[]
				{
					this.Convert((long)(-(long)number), gender)
				});
			}
			if (number == 0)
			{
				return HebrewNumberToWordsConverter.UnitsFeminine[0];
			}
			List<string> parts = new List<string>();
			if (number >= 1000000000)
			{
				this.ToBigNumber(number, HebrewNumberToWordsConverter.Group.Billions, parts);
				number %= 1000000000;
			}
			if (number >= 1000000)
			{
				this.ToBigNumber(number, HebrewNumberToWordsConverter.Group.Millions, parts);
				number %= 1000000;
			}
			if (number >= 1000)
			{
				this.ToThousands(number, parts);
				number %= 1000;
			}
			if (number >= 100)
			{
				HebrewNumberToWordsConverter.ToHundreds(number, parts);
				number %= 100;
			}
			if (number > 0)
			{
				bool appendAnd = parts.Count != 0;
				if (number <= 10)
				{
					string unit = (gender == GrammaticalGender.Masculine) ? HebrewNumberToWordsConverter.UnitsMasculine[number] : HebrewNumberToWordsConverter.UnitsFeminine[number];
					if (appendAnd)
					{
						unit = "ו" + unit;
					}
					parts.Add(unit);
				}
				else if (number < 20)
				{
					string unit2 = this.Convert((long)(number % 10), gender);
					unit2 = unit2.Replace("יי", "י");
					unit2 = string.Format("{0} {1}", new object[]
					{
						unit2,
						(gender == GrammaticalGender.Masculine) ? "עשר" : "עשרה"
					});
					if (appendAnd)
					{
						unit2 = "ו" + unit2;
					}
					parts.Add(unit2);
				}
				else
				{
					string tenUnit = HebrewNumberToWordsConverter.TensUnit[number / 10 - 1];
					if (number % 10 == 0)
					{
						parts.Add(tenUnit);
					}
					else
					{
						string unit3 = this.Convert((long)(number % 10), gender);
						parts.Add(string.Format("{0} ו{1}", new object[]
						{
							tenUnit,
							unit3
						}));
					}
				}
			}
			return string.Join(" ", parts);
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00007F18 File Offset: 0x00006118
		public override string ConvertToOrdinal(int number, GrammaticalGender gender)
		{
			return number.ToString(this._culture);
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00007F28 File Offset: 0x00006128
		private void ToBigNumber(int number, HebrewNumberToWordsConverter.Group group, List<string> parts)
		{
			int digits = number / (int)group;
			if (digits == 2)
			{
				parts.Add("שני");
			}
			else if (digits > 2)
			{
				parts.Add(this.Convert((long)digits, GrammaticalGender.Masculine));
			}
			parts.Add(group.Humanize());
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00007F70 File Offset: 0x00006170
		private void ToThousands(int number, List<string> parts)
		{
			int thousands = number / 1000;
			if (thousands == 1)
			{
				parts.Add("אלף");
				return;
			}
			if (thousands == 2)
			{
				parts.Add("אלפיים");
				return;
			}
			if (thousands <= 10)
			{
				parts.Add(HebrewNumberToWordsConverter.UnitsFeminine[thousands] + "ת אלפים");
				return;
			}
			parts.Add(base.Convert((long)thousands) + " אלף");
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00007FDC File Offset: 0x000061DC
		private static void ToHundreds(int number, List<string> parts)
		{
			int hundreds = number / 100;
			if (hundreds == 1)
			{
				parts.Add("מאה");
				return;
			}
			if (hundreds == 2)
			{
				parts.Add("מאתיים");
				return;
			}
			parts.Add(HebrewNumberToWordsConverter.UnitsFeminine[hundreds] + " מאות");
		}

		// Token: 0x0400006F RID: 111
		private static readonly string[] UnitsFeminine = new string[]
		{
			"אפס",
			"אחת",
			"שתיים",
			"שלוש",
			"ארבע",
			"חמש",
			"שש",
			"שבע",
			"שמונה",
			"תשע",
			"עשר"
		};

		// Token: 0x04000070 RID: 112
		private static readonly string[] UnitsMasculine = new string[]
		{
			"אפס",
			"אחד",
			"שניים",
			"שלושה",
			"ארבעה",
			"חמישה",
			"שישה",
			"שבעה",
			"שמונה",
			"תשעה",
			"עשרה"
		};

		// Token: 0x04000071 RID: 113
		private static readonly string[] TensUnit = new string[]
		{
			"עשר",
			"עשרים",
			"שלושים",
			"ארבעים",
			"חמישים",
			"שישים",
			"שבעים",
			"שמונים",
			"תשעים"
		};

		// Token: 0x04000072 RID: 114
		private readonly CultureInfo _culture;

		// Token: 0x020000AE RID: 174
		private class DescriptionAttribute : Attribute
		{
			// Token: 0x170001E4 RID: 484
			// (get) Token: 0x060004F6 RID: 1270 RVA: 0x00012F1D File Offset: 0x0001111D
			// (set) Token: 0x060004F7 RID: 1271 RVA: 0x00012F25 File Offset: 0x00011125
			public string Description { get; set; }

			// Token: 0x060004F8 RID: 1272 RVA: 0x00012F2E File Offset: 0x0001112E
			public DescriptionAttribute(string description)
			{
				this.Description = description;
			}
		}

		// Token: 0x020000AF RID: 175
		private enum Group
		{
			// Token: 0x04000121 RID: 289
			Hundreds = 100,
			// Token: 0x04000122 RID: 290
			Thousands = 1000,
			// Token: 0x04000123 RID: 291
			[HebrewNumberToWordsConverter.DescriptionAttribute("מיליון")]
			Millions = 1000000,
			// Token: 0x04000124 RID: 292
			[HebrewNumberToWordsConverter.DescriptionAttribute("מיליארד")]
			Billions = 1000000000
		}
	}
}
