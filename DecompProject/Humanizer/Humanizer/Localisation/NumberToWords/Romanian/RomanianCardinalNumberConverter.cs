using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords.Romanian
{
	// Token: 0x0200005C RID: 92
	internal class RomanianCardinalNumberConverter
	{
		// Token: 0x060001E9 RID: 489 RVA: 0x0000B4B4 File Offset: 0x000096B4
		public string Convert(int number, GrammaticalGender gender)
		{
			if (number == 0)
			{
				return "zero";
			}
			string words = string.Empty;
			bool prefixMinusSign = false;
			if (number < 0)
			{
				prefixMinusSign = true;
				number = -number;
			}
			List<int> _threeDigitParts = this.SplitEveryThreeDigits(number);
			for (int i = 0; i < _threeDigitParts.Count; i++)
			{
				RomanianCardinalNumberConverter.ThreeDigitSets currentSet = (RomanianCardinalNumberConverter.ThreeDigitSets)Enum.ToObject(typeof(RomanianCardinalNumberConverter.ThreeDigitSets), i);
				words = this.GetNextPartConverter(currentSet)(_threeDigitParts[i], gender).Trim() + " " + words.Trim();
			}
			if (prefixMinusSign)
			{
				words = this._minusSign + " " + words;
			}
			return words.TrimEnd(new char[0]).Replace("  ", " ");
		}

		// Token: 0x060001EA RID: 490 RVA: 0x0000B56C File Offset: 0x0000976C
		private List<int> SplitEveryThreeDigits(int number)
		{
			List<int> parts = new List<int>();
			for (int rest = number; rest > 0; rest /= 1000)
			{
				int threeDigit = rest % 1000;
				parts.Add(threeDigit);
			}
			return parts;
		}

		// Token: 0x060001EB RID: 491 RVA: 0x0000B5A0 File Offset: 0x000097A0
		private Func<int, GrammaticalGender, string> GetNextPartConverter(RomanianCardinalNumberConverter.ThreeDigitSets currentSet)
		{
			Func<int, GrammaticalGender, string> converter;
			switch (currentSet)
			{
			case RomanianCardinalNumberConverter.ThreeDigitSets.Units:
				converter = new Func<int, GrammaticalGender, string>(this.UnitsConverter);
				break;
			case RomanianCardinalNumberConverter.ThreeDigitSets.Thousands:
				converter = new Func<int, GrammaticalGender, string>(this.ThousandsConverter);
				break;
			case RomanianCardinalNumberConverter.ThreeDigitSets.Millions:
				converter = new Func<int, GrammaticalGender, string>(this.MillionsConverter);
				break;
			case RomanianCardinalNumberConverter.ThreeDigitSets.Billions:
				converter = new Func<int, GrammaticalGender, string>(this.BillionsConverter);
				break;
			case RomanianCardinalNumberConverter.ThreeDigitSets.More:
				converter = null;
				break;
			default:
				throw new ArgumentOutOfRangeException("Unknow ThreeDigitSet: " + currentSet);
			}
			return converter;
		}

		// Token: 0x060001EC RID: 492 RVA: 0x0000B620 File Offset: 0x00009820
		private string ThreeDigitSetConverter(int number, GrammaticalGender gender, bool thisIsLastSet = false)
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
			words += this.HundredsToText(hundreds);
			words = words + ((tens >= 2) ? " " : string.Empty) + this._tensOver20NumberToText[tens];
			if (tensAndUnits <= 9)
			{
				words = words + " " + this.getPartByGender(this._units[tensAndUnits], gender);
			}
			else if (tensAndUnits <= 19)
			{
				words = words + " " + this.getPartByGender(this._teensUnder20NumberToText[tensAndUnits - 10], gender);
			}
			else
			{
				string unitsText = (units == 0) ? string.Empty : (" " + this._joinGroups + " " + this.getPartByGender(this._units[units], gender));
				words += unitsText;
			}
			return words;
		}

		// Token: 0x060001ED RID: 493 RVA: 0x0000B70C File Offset: 0x0000990C
		private string getPartByGender(string multiGenderPart, GrammaticalGender gender)
		{
			if (!multiGenderPart.Contains("|"))
			{
				return multiGenderPart;
			}
			string[] parts = multiGenderPart.Split(new char[]
			{
				'|'
			});
			if (gender == GrammaticalGender.Feminine)
			{
				return parts[1];
			}
			return parts[0];
		}

		// Token: 0x060001EE RID: 494 RVA: 0x0000B745 File Offset: 0x00009945
		private bool IsAbove20(int number)
		{
			return number >= 20;
		}

		// Token: 0x060001EF RID: 495 RVA: 0x0000B74F File Offset: 0x0000994F
		private string HundredsToText(int hundreds)
		{
			if (hundreds == 0)
			{
				return string.Empty;
			}
			if (hundreds == 1)
			{
				return this._feminineSingular + " sută";
			}
			return this.getPartByGender(this._units[hundreds], GrammaticalGender.Feminine) + " sute";
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x0000B788 File Offset: 0x00009988
		private string UnitsConverter(int number, GrammaticalGender gender)
		{
			return this.ThreeDigitSetConverter(number, gender, true);
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x0000B794 File Offset: 0x00009994
		private string ThousandsConverter(int number, GrammaticalGender gender)
		{
			if (number == 0)
			{
				return string.Empty;
			}
			if (number == 1)
			{
				return this._feminineSingular + " mie";
			}
			return this.ThreeDigitSetConverter(number, GrammaticalGender.Feminine, false) + (this.IsAbove20(number) ? (" " + this._joinAbove20) : string.Empty) + " mii";
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x0000B7F4 File Offset: 0x000099F4
		private string MillionsConverter(int number, GrammaticalGender gender)
		{
			if (number == 0)
			{
				return string.Empty;
			}
			if (number == 1)
			{
				return this._masculineSingular + " milion";
			}
			return this.ThreeDigitSetConverter(number, GrammaticalGender.Feminine, true) + (this.IsAbove20(number) ? (" " + this._joinAbove20) : string.Empty) + " milioane";
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x0000B854 File Offset: 0x00009A54
		private string BillionsConverter(int number, GrammaticalGender gender)
		{
			if (number == 1)
			{
				return this._masculineSingular + " miliard";
			}
			return this.ThreeDigitSetConverter(number, GrammaticalGender.Feminine, false) + (this.IsAbove20(number) ? (" " + this._joinAbove20) : string.Empty) + " miliarde";
		}

		// Token: 0x040000A1 RID: 161
		private readonly string[] _units = new string[]
		{
			string.Empty,
			"unu|una",
			"doi|două",
			"trei",
			"patru",
			"cinci",
			"șase",
			"șapte",
			"opt",
			"nouă"
		};

		// Token: 0x040000A2 RID: 162
		private readonly string[] _teensUnder20NumberToText = new string[]
		{
			"zece",
			"unsprezece",
			"doisprezece|douăsprezece",
			"treisprezece",
			"paisprezece",
			"cincisprezece",
			"șaisprezece",
			"șaptesprezece",
			"optsprezece",
			"nouăsprezece"
		};

		// Token: 0x040000A3 RID: 163
		private readonly string[] _tensOver20NumberToText = new string[]
		{
			string.Empty,
			string.Empty,
			"douăzeci",
			"treizeci",
			"patruzeci",
			"cincizeci",
			"șaizeci",
			"șaptezeci",
			"optzeci",
			"nouăzeci"
		};

		// Token: 0x040000A4 RID: 164
		private readonly string _feminineSingular = "o";

		// Token: 0x040000A5 RID: 165
		private readonly string _masculineSingular = "un";

		// Token: 0x040000A6 RID: 166
		private readonly string _joinGroups = "și";

		// Token: 0x040000A7 RID: 167
		private readonly string _joinAbove20 = "de";

		// Token: 0x040000A8 RID: 168
		private readonly string _minusSign = "minus";

		// Token: 0x020000B0 RID: 176
		private enum ThreeDigitSets
		{
			// Token: 0x04000126 RID: 294
			Units,
			// Token: 0x04000127 RID: 295
			Thousands,
			// Token: 0x04000128 RID: 296
			Millions,
			// Token: 0x04000129 RID: 297
			Billions,
			// Token: 0x0400012A RID: 298
			More
		}
	}
}
