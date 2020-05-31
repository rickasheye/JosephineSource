using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords.Italian
{
	// Token: 0x0200005E RID: 94
	internal class ItalianCardinalNumberCruncher
	{
		// Token: 0x060001F8 RID: 504 RVA: 0x0000BD3F File Offset: 0x00009F3F
		public ItalianCardinalNumberCruncher(int number, GrammaticalGender gender)
		{
			this._fullNumber = number;
			this._threeDigitParts = ItalianCardinalNumberCruncher.SplitEveryThreeDigits(number);
			this._gender = gender;
			this._nextSet = ItalianCardinalNumberCruncher.ThreeDigitSets.Units;
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0000BD68 File Offset: 0x00009F68
		public string Convert()
		{
			if (this._fullNumber == 0)
			{
				return "zero";
			}
			string words = string.Empty;
			foreach (int part in this._threeDigitParts)
			{
				words = this.GetNextPartConverter()(part) + words;
			}
			return words.TrimEnd(new char[0]);
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0000BDE8 File Offset: 0x00009FE8
		protected static List<int> SplitEveryThreeDigits(int number)
		{
			List<int> parts = new List<int>();
			for (int rest = number; rest > 0; rest /= 1000)
			{
				int threeDigit = rest % 1000;
				parts.Add(threeDigit);
			}
			return parts;
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0000BE1C File Offset: 0x0000A01C
		public Func<int, string> GetNextPartConverter()
		{
			Func<int, string> converter;
			switch (this._nextSet)
			{
			case ItalianCardinalNumberCruncher.ThreeDigitSets.Units:
				converter = new Func<int, string>(this.UnitsConverter);
				this._nextSet = ItalianCardinalNumberCruncher.ThreeDigitSets.Thousands;
				break;
			case ItalianCardinalNumberCruncher.ThreeDigitSets.Thousands:
				converter = new Func<int, string>(ItalianCardinalNumberCruncher.ThousandsConverter);
				this._nextSet = ItalianCardinalNumberCruncher.ThreeDigitSets.Millions;
				break;
			case ItalianCardinalNumberCruncher.ThreeDigitSets.Millions:
				converter = new Func<int, string>(ItalianCardinalNumberCruncher.MillionsConverter);
				this._nextSet = ItalianCardinalNumberCruncher.ThreeDigitSets.Billions;
				break;
			case ItalianCardinalNumberCruncher.ThreeDigitSets.Billions:
				converter = new Func<int, string>(ItalianCardinalNumberCruncher.BillionsConverter);
				this._nextSet = ItalianCardinalNumberCruncher.ThreeDigitSets.More;
				break;
			case ItalianCardinalNumberCruncher.ThreeDigitSets.More:
				converter = null;
				break;
			default:
				throw new ArgumentOutOfRangeException("Unknow ThreeDigitSet: " + this._nextSet);
			}
			return converter;
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0000BEC4 File Offset: 0x0000A0C4
		protected static string ThreeDigitSetConverter(int number, bool thisIsLastSet = false)
		{
			if (number == 0)
			{
				return string.Empty;
			}
			int tensAndUnits = number % 100;
			int hundreds = number / 100;
			int units = tensAndUnits % 10;
			int tens = tensAndUnits / 10;
			string words = string.Empty;
			words += ItalianCardinalNumberCruncher._hundredNumberToText[hundreds];
			words += ItalianCardinalNumberCruncher._tensOver20NumberToText[tens];
			if (tensAndUnits <= 9)
			{
				words += ItalianCardinalNumberCruncher._unitsNumberToText[tensAndUnits];
			}
			else if (tensAndUnits <= 19)
			{
				words += ItalianCardinalNumberCruncher._teensUnder20NumberToText[tensAndUnits - 10];
			}
			else
			{
				if (units == 1 || units == 8)
				{
					words = words.Remove(words.Length - 1);
				}
				string unitsText = (thisIsLastSet && units == 3) ? "tré" : ItalianCardinalNumberCruncher._unitsNumberToText[units];
				words += unitsText;
			}
			return words;
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0000BF84 File Offset: 0x0000A184
		protected string UnitsConverter(int number)
		{
			if (this._gender == GrammaticalGender.Feminine && this._fullNumber == 1)
			{
				return "una";
			}
			return ItalianCardinalNumberCruncher.ThreeDigitSetConverter(number, true);
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0000BFA5 File Offset: 0x0000A1A5
		protected static string ThousandsConverter(int number)
		{
			if (number == 0)
			{
				return string.Empty;
			}
			if (number == 1)
			{
				return "mille";
			}
			return ItalianCardinalNumberCruncher.ThreeDigitSetConverter(number, false) + "mila";
		}

		// Token: 0x060001FF RID: 511 RVA: 0x0000BFCB File Offset: 0x0000A1CB
		protected static string MillionsConverter(int number)
		{
			if (number == 0)
			{
				return string.Empty;
			}
			if (number == 1)
			{
				return "un milione ";
			}
			return ItalianCardinalNumberCruncher.ThreeDigitSetConverter(number, true) + " milioni ";
		}

		// Token: 0x06000200 RID: 512 RVA: 0x0000BFF1 File Offset: 0x0000A1F1
		protected static string BillionsConverter(int number)
		{
			if (number == 1)
			{
				return "un miliardo ";
			}
			return ItalianCardinalNumberCruncher.ThreeDigitSetConverter(number, false) + " miliardi ";
		}

		// Token: 0x040000AE RID: 174
		protected readonly int _fullNumber;

		// Token: 0x040000AF RID: 175
		protected readonly List<int> _threeDigitParts;

		// Token: 0x040000B0 RID: 176
		protected readonly GrammaticalGender _gender;

		// Token: 0x040000B1 RID: 177
		protected ItalianCardinalNumberCruncher.ThreeDigitSets _nextSet;

		// Token: 0x040000B2 RID: 178
		protected static string[] _unitsNumberToText = new string[]
		{
			string.Empty,
			"uno",
			"due",
			"tre",
			"quattro",
			"cinque",
			"sei",
			"sette",
			"otto",
			"nove"
		};

		// Token: 0x040000B3 RID: 179
		protected static string[] _tensOver20NumberToText = new string[]
		{
			string.Empty,
			string.Empty,
			"venti",
			"trenta",
			"quaranta",
			"cinquanta",
			"sessanta",
			"settanta",
			"ottanta",
			"novanta"
		};

		// Token: 0x040000B4 RID: 180
		protected static string[] _teensUnder20NumberToText = new string[]
		{
			"dieci",
			"undici",
			"dodici",
			"tredici",
			"quattordici",
			"quindici",
			"sedici",
			"diciassette",
			"diciotto",
			"diciannove"
		};

		// Token: 0x040000B5 RID: 181
		protected static string[] _hundredNumberToText = new string[]
		{
			string.Empty,
			"cento",
			"duecento",
			"trecento",
			"quattrocento",
			"cinquecento",
			"seicento",
			"settecento",
			"ottocento",
			"novecento"
		};

		// Token: 0x020000B1 RID: 177
		protected enum ThreeDigitSets
		{
			// Token: 0x0400012C RID: 300
			Units,
			// Token: 0x0400012D RID: 301
			Thousands,
			// Token: 0x0400012E RID: 302
			Millions,
			// Token: 0x0400012F RID: 303
			Billions,
			// Token: 0x04000130 RID: 304
			More
		}
	}
}
