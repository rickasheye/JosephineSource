using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x0200004C RID: 76
	internal class GermanNumberToWordsConverter : GenderedNumberToWordsConverter
	{
		// Token: 0x0600018C RID: 396 RVA: 0x000077BC File Offset: 0x000059BC
		public override string Convert(long input, GrammaticalGender gender)
		{
			if (input > 2147483647L || input < -2147483648L)
			{
				throw new NotImplementedException();
			}
			int number = (int)input;
			if (number == 0)
			{
				return "null";
			}
			if (number < 0)
			{
				return string.Format("minus {0}", new object[]
				{
					base.Convert((long)(-(long)number))
				});
			}
			List<string> parts = new List<string>();
			int billions = number / 1000000000;
			if (billions > 0)
			{
				parts.Add(this.Part("{0} Milliarden", "eine Milliarde", billions));
				number %= 1000000000;
				if (number > 0)
				{
					parts.Add(" ");
				}
			}
			int millions = number / 1000000;
			if (millions > 0)
			{
				parts.Add(this.Part("{0} Millionen", "eine Million", millions));
				number %= 1000000;
				if (number > 0)
				{
					parts.Add(" ");
				}
			}
			int thousands = number / 1000;
			if (thousands > 0)
			{
				parts.Add(this.Part("{0}tausend", "eintausend", thousands));
				number %= 1000;
			}
			int hundreds = number / 100;
			if (hundreds > 0)
			{
				parts.Add(this.Part("{0}hundert", "einhundert", hundreds));
				number %= 100;
			}
			if (number > 0)
			{
				if (number < 20)
				{
					if (number > 1)
					{
						parts.Add(GermanNumberToWordsConverter.UnitsMap[number]);
					}
					else
					{
						parts.Add("eins");
					}
				}
				else
				{
					int units = number % 10;
					if (units > 0)
					{
						parts.Add(string.Format("{0}und", new object[]
						{
							GermanNumberToWordsConverter.UnitsMap[units]
						}));
					}
					parts.Add(GermanNumberToWordsConverter.TensMap[number / 10]);
				}
			}
			return string.Join("", parts);
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00007950 File Offset: 0x00005B50
		public override string ConvertToOrdinal(int number, GrammaticalGender gender)
		{
			if (number == 0)
			{
				return "null" + GermanNumberToWordsConverter.GetEndingForGender(gender);
			}
			List<string> parts = new List<string>();
			if (number < 0)
			{
				parts.Add("minus ");
				number = -number;
			}
			int billions = number / 1000000000;
			if (billions > 0)
			{
				number %= 1000000000;
				int noRest = GermanNumberToWordsConverter.NoRestIndex(number);
				parts.Add(this.Part(GermanNumberToWordsConverter.BillionOrdinalPlural[noRest], GermanNumberToWordsConverter.BillionOrdinalSingular[noRest], billions));
			}
			int millions = number / 1000000;
			if (millions > 0)
			{
				number %= 1000000;
				int noRest2 = GermanNumberToWordsConverter.NoRestIndex(number);
				parts.Add(this.Part(GermanNumberToWordsConverter.MillionOrdinalPlural[noRest2], GermanNumberToWordsConverter.MillionOrdinalSingular[noRest2], millions));
			}
			int thousands = number / 1000;
			if (thousands > 0)
			{
				parts.Add(this.Part("{0}tausend", "eintausend", thousands));
				number %= 1000;
			}
			int hundreds = number / 100;
			if (hundreds > 0)
			{
				parts.Add(this.Part("{0}hundert", "einhundert", hundreds));
				number %= 100;
			}
			if (number > 0)
			{
				parts.Add((number < 20) ? GermanNumberToWordsConverter.UnitsOrdinal[number] : base.Convert((long)number));
			}
			if (number == 0 || number >= 20)
			{
				parts.Add("s");
			}
			parts.Add(GermanNumberToWordsConverter.GetEndingForGender(gender));
			return string.Join("", parts);
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00007A9D File Offset: 0x00005C9D
		private string Part(string pluralFormat, string singular, int number)
		{
			if (number == 1)
			{
				return singular;
			}
			return string.Format(pluralFormat, new object[]
			{
				base.Convert((long)number)
			});
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00007ABC File Offset: 0x00005CBC
		private static int NoRestIndex(int number)
		{
			if (number != 0)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00007AC4 File Offset: 0x00005CC4
		private static string GetEndingForGender(GrammaticalGender gender)
		{
			switch (gender)
			{
			case GrammaticalGender.Masculine:
				return "ter";
			case GrammaticalGender.Feminine:
				return "te";
			case GrammaticalGender.Neuter:
				return "tes";
			default:
				throw new ArgumentOutOfRangeException("gender");
			}
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00007AF6 File Offset: 0x00005CF6
		public GermanNumberToWordsConverter() : base(GrammaticalGender.Masculine)
		{
		}

		// Token: 0x04000068 RID: 104
		private static readonly string[] UnitsMap = new string[]
		{
			"null",
			"ein",
			"zwei",
			"drei",
			"vier",
			"fünf",
			"sechs",
			"sieben",
			"acht",
			"neun",
			"zehn",
			"elf",
			"zwölf",
			"dreizehn",
			"vierzehn",
			"fünfzehn",
			"sechzehn",
			"siebzehn",
			"achtzehn",
			"neunzehn"
		};

		// Token: 0x04000069 RID: 105
		private static readonly string[] TensMap = new string[]
		{
			"null",
			"zehn",
			"zwanzig",
			"dreißig",
			"vierzig",
			"fünfzig",
			"sechzig",
			"siebzig",
			"achtzig",
			"neunzig"
		};

		// Token: 0x0400006A RID: 106
		private static readonly string[] UnitsOrdinal = new string[]
		{
			string.Empty,
			"ers",
			"zwei",
			"drit",
			"vier",
			"fünf",
			"sechs",
			"sieb",
			"ach",
			"neun",
			"zehn",
			"elf",
			"zwölf",
			"dreizehn",
			"vierzehn",
			"fünfzehn",
			"sechzehn",
			"siebzehn",
			"achtzehn",
			"neunzehn"
		};

		// Token: 0x0400006B RID: 107
		private static readonly string[] MillionOrdinalSingular = new string[]
		{
			"einmillion",
			"einemillion"
		};

		// Token: 0x0400006C RID: 108
		private static readonly string[] MillionOrdinalPlural = new string[]
		{
			"{0}million",
			"{0}millionen"
		};

		// Token: 0x0400006D RID: 109
		private static readonly string[] BillionOrdinalSingular = new string[]
		{
			"einmilliard",
			"einemilliarde"
		};

		// Token: 0x0400006E RID: 110
		private static readonly string[] BillionOrdinalPlural = new string[]
		{
			"{0}milliard",
			"{0}milliarden"
		};
	}
}
