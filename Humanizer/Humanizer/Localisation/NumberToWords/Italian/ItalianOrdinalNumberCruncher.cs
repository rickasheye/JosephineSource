using System;

namespace Humanizer.Localisation.NumberToWords.Italian
{
	// Token: 0x0200005F RID: 95
	internal class ItalianOrdinalNumberCruncher
	{
		// Token: 0x06000202 RID: 514 RVA: 0x0000C191 File Offset: 0x0000A391
		public ItalianOrdinalNumberCruncher(int number, GrammaticalGender gender)
		{
			this._fullNumber = number;
			this._gender = gender;
			this._genderSuffix = ((gender == GrammaticalGender.Feminine) ? "a" : "o");
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0000C1C0 File Offset: 0x0000A3C0
		public string Convert()
		{
			if (this._fullNumber == 0)
			{
				return "zero";
			}
			if (this._fullNumber <= 9)
			{
				return ItalianOrdinalNumberCruncher._unitsUnder10NumberToText[this._fullNumber] + this._genderSuffix;
			}
			string words = new ItalianCardinalNumberCruncher(this._fullNumber, this._gender).Convert();
			if (this._fullNumber % 100 == 10)
			{
				words = words.Remove(words.Length - ItalianOrdinalNumberCruncher._lengthOf10AsCardinal) + "decim" + this._genderSuffix;
			}
			else
			{
				words = words.Remove(words.Length - 1);
				int units = this._fullNumber % 10;
				if (units == 3)
				{
					words += "e";
				}
				else if (units == 6)
				{
					words += "i";
				}
				int lowestThreeDigits = this._fullNumber % 1000;
				int lowestSixDigits = this._fullNumber % 1000000;
				if (this._fullNumber % 1000000000 == 0)
				{
					words = words.Replace(" miliard", "miliard");
					if (this._fullNumber == 1000000000)
					{
						words = words.Replace("un", string.Empty);
					}
				}
				else if (lowestSixDigits == 0)
				{
					words = words.Replace(" milion", "milion");
					if (this._fullNumber == 1000000)
					{
						words = words.Replace("un", string.Empty);
					}
				}
				else if (lowestThreeDigits == 0 && this._fullNumber > 1000)
				{
					words += "l";
				}
				words = words + "esim" + this._genderSuffix;
			}
			return words;
		}

		// Token: 0x040000B6 RID: 182
		protected readonly int _fullNumber;

		// Token: 0x040000B7 RID: 183
		protected readonly GrammaticalGender _gender;

		// Token: 0x040000B8 RID: 184
		private readonly string _genderSuffix;

		// Token: 0x040000B9 RID: 185
		protected static string[] _unitsUnder10NumberToText = new string[]
		{
			string.Empty,
			"prim",
			"second",
			"terz",
			"quart",
			"quint",
			"sest",
			"settim",
			"ottav",
			"non"
		};

		// Token: 0x040000BA RID: 186
		protected static int _lengthOf10AsCardinal = "dieci".Length;
	}
}
