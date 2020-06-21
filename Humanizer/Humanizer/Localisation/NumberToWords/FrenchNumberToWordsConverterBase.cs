using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x02000048 RID: 72
	internal abstract class FrenchNumberToWordsConverterBase : GenderedNumberToWordsConverter
	{
		// Token: 0x06000176 RID: 374 RVA: 0x0000731C File Offset: 0x0000551C
		public override string Convert(long input, GrammaticalGender gender)
		{
			if (input > 2147483647L || input < -2147483648L)
			{
				throw new NotImplementedException();
			}
			int number = (int)input;
			if (number == 0)
			{
				return FrenchNumberToWordsConverterBase.UnitsMap[0];
			}
			List<string> parts = new List<string>();
			if (number < 0)
			{
				parts.Add("moins");
				number = -number;
			}
			this.CollectParts(parts, ref number, 1000000000, "milliard");
			this.CollectParts(parts, ref number, 1000000, "million");
			this.CollectThousands(parts, ref number, 1000, "mille");
			this.CollectPartsUnderAThousand(parts, number, gender, true);
			return string.Join(" ", parts);
		}

		// Token: 0x06000177 RID: 375 RVA: 0x000073B8 File Offset: 0x000055B8
		public override string ConvertToOrdinal(int number, GrammaticalGender gender)
		{
			if (number != 1)
			{
				string convertedNumber = base.Convert((long)number);
				if (convertedNumber.EndsWith("s") && !convertedNumber.EndsWith("trois"))
				{
					convertedNumber = convertedNumber.TrimEnd(new char[]
					{
						's'
					});
				}
				else if (convertedNumber.EndsWith("cinq"))
				{
					convertedNumber += "u";
				}
				else if (convertedNumber.EndsWith("neuf"))
				{
					convertedNumber = convertedNumber.TrimEnd(new char[]
					{
						'f'
					}) + "v";
				}
				if (convertedNumber.StartsWith("un "))
				{
					convertedNumber = convertedNumber.Remove(0, 3);
				}
				if (number == 0)
				{
					convertedNumber += "t";
				}
				convertedNumber = convertedNumber.TrimEnd(new char[]
				{
					'e'
				});
				return convertedNumber + "ième";
			}
			if (gender != GrammaticalGender.Feminine)
			{
				return "premier";
			}
			return "première";
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00007498 File Offset: 0x00005698
		protected static string GetUnits(int number, GrammaticalGender gender)
		{
			if (number == 1 && gender == GrammaticalGender.Feminine)
			{
				return "une";
			}
			return FrenchNumberToWordsConverterBase.UnitsMap[number];
		}

		// Token: 0x06000179 RID: 377 RVA: 0x000074B0 File Offset: 0x000056B0
		private static void CollectHundreds(ICollection<string> parts, ref int number, int d, string form, bool pluralize)
		{
			if (number < d)
			{
				return;
			}
			int result = number / d;
			if (result == 1)
			{
				parts.Add(form);
			}
			else
			{
				parts.Add(FrenchNumberToWordsConverterBase.GetUnits(result, GrammaticalGender.Masculine));
				if (number % d == 0 && pluralize)
				{
					parts.Add(form + "s");
				}
				else
				{
					parts.Add(form);
				}
			}
			number %= d;
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00007510 File Offset: 0x00005710
		private void CollectParts(ICollection<string> parts, ref int number, int d, string form)
		{
			if (number < d)
			{
				return;
			}
			int result = number / d;
			this.CollectPartsUnderAThousand(parts, result, GrammaticalGender.Masculine, true);
			if (result == 1)
			{
				parts.Add(form);
			}
			else
			{
				parts.Add(form + "s");
			}
			number %= d;
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00007558 File Offset: 0x00005758
		private void CollectPartsUnderAThousand(ICollection<string> parts, int number, GrammaticalGender gender, bool pluralize)
		{
			FrenchNumberToWordsConverterBase.CollectHundreds(parts, ref number, 100, "cent", pluralize);
			if (number > 0)
			{
				this.CollectPartsUnderAHundred(parts, ref number, gender, pluralize);
			}
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000757C File Offset: 0x0000577C
		private void CollectThousands(ICollection<string> parts, ref int number, int d, string form)
		{
			if (number < d)
			{
				return;
			}
			int result = number / d;
			if (result > 1)
			{
				this.CollectPartsUnderAThousand(parts, result, GrammaticalGender.Masculine, false);
			}
			parts.Add(form);
			number %= d;
		}

		// Token: 0x0600017D RID: 381 RVA: 0x000075B0 File Offset: 0x000057B0
		protected virtual void CollectPartsUnderAHundred(ICollection<string> parts, ref int number, GrammaticalGender gender, bool pluralize)
		{
			if (number < 20)
			{
				parts.Add(FrenchNumberToWordsConverterBase.GetUnits(number, gender));
				return;
			}
			int units = number % 10;
			string tens = this.GetTens(number / 10);
			if (units == 0)
			{
				parts.Add(tens);
				return;
			}
			if (units == 1)
			{
				parts.Add(tens);
				parts.Add("et");
				parts.Add(FrenchNumberToWordsConverterBase.GetUnits(1, gender));
				return;
			}
			parts.Add(string.Format("{0}-{1}", new object[]
			{
				tens,
				FrenchNumberToWordsConverterBase.GetUnits(units, gender)
			}));
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00007637 File Offset: 0x00005837
		protected virtual string GetTens(int tens)
		{
			return FrenchNumberToWordsConverterBase.TensMap[tens];
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00007640 File Offset: 0x00005840
		protected FrenchNumberToWordsConverterBase() : base(GrammaticalGender.Masculine)
		{
		}

		// Token: 0x04000065 RID: 101
		private static readonly string[] UnitsMap = new string[]
		{
			"zéro",
			"un",
			"deux",
			"trois",
			"quatre",
			"cinq",
			"six",
			"sept",
			"huit",
			"neuf",
			"dix",
			"onze",
			"douze",
			"treize",
			"quatorze",
			"quinze",
			"seize",
			"dix-sept",
			"dix-huit",
			"dix-neuf"
		};

		// Token: 0x04000066 RID: 102
		private static readonly string[] TensMap = new string[]
		{
			"zéro",
			"dix",
			"vingt",
			"trente",
			"quarante",
			"cinquante",
			"soixante",
			"septante",
			"octante",
			"nonante"
		};
	}
}
