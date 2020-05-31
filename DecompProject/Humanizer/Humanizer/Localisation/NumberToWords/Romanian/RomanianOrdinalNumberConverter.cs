using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords.Romanian
{
	// Token: 0x0200005D RID: 93
	internal class RomanianOrdinalNumberConverter
	{
		// Token: 0x060001F5 RID: 501 RVA: 0x0000BA10 File Offset: 0x00009C10
		public string Convert(int number, GrammaticalGender gender)
		{
			if (number == 0)
			{
				return "zero";
			}
			if (number == 1)
			{
				return this.getPartByGender(this._ordinalsUnder10[number], gender);
			}
			if (number <= 9)
			{
				return string.Format("{0} {1}", new object[]
				{
					(gender == GrammaticalGender.Feminine) ? this._femininePrefix : this._masculinePrefix,
					this.getPartByGender(this._ordinalsUnder10[number], gender)
				});
			}
			string words = new RomanianCardinalNumberConverter().Convert(number, gender);
			words = words.Replace(" de ", " ");
			if (gender == GrammaticalGender.Feminine && words.EndsWith("zeci"))
			{
				words = words.Substring(0, words.Length - 4) + "zece";
			}
			else if (gender == GrammaticalGender.Feminine && words.Contains("zeci") && (words.Contains("milioane") || words.Contains("miliarde")))
			{
				words = words.Replace("zeci", "zecea");
			}
			if (gender == GrammaticalGender.Feminine && words.StartsWith("un "))
			{
				words = words.Substring(2).TrimStart(new char[0]);
			}
			if (words.EndsWith("milioane") && gender == GrammaticalGender.Feminine)
			{
				words = words.Substring(0, words.Length - 8) + "milioana";
			}
			string customMasculineSuffix = this._masculineSuffix;
			if (words.EndsWith("milion"))
			{
				if (gender == GrammaticalGender.Feminine)
				{
					words = words.Substring(0, words.Length - 6) + "milioana";
				}
				else
				{
					customMasculineSuffix = "u" + this._masculineSuffix;
				}
			}
			else if (words.EndsWith("miliard") && gender == GrammaticalGender.Masculine)
			{
				customMasculineSuffix = "u" + this._masculineSuffix;
			}
			if (gender == GrammaticalGender.Feminine && !words.EndsWith("zece") && (words.EndsWith("a") || words.EndsWith("ă") || words.EndsWith("e") || words.EndsWith("i")))
			{
				words = words.Substring(0, words.Length - 1);
			}
			return string.Format("{0} {1}{2}", new object[]
			{
				(gender == GrammaticalGender.Feminine) ? this._femininePrefix : this._masculinePrefix,
				words,
				(gender == GrammaticalGender.Feminine) ? this._feminineSuffix : customMasculineSuffix
			});
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x0000BC4C File Offset: 0x00009E4C
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

		// Token: 0x040000A9 RID: 169
		private readonly Dictionary<int, string> _ordinalsUnder10 = new Dictionary<int, string>
		{
			{
				1,
				"primul|prima"
			},
			{
				2,
				"doilea|doua"
			},
			{
				3,
				"treilea|treia"
			},
			{
				4,
				"patrulea|patra"
			},
			{
				5,
				"cincilea|cincea"
			},
			{
				6,
				"șaselea|șasea"
			},
			{
				7,
				"șaptelea|șaptea"
			},
			{
				8,
				"optulea|opta"
			},
			{
				9,
				"nouălea|noua"
			}
		};

		// Token: 0x040000AA RID: 170
		private readonly string _femininePrefix = "a";

		// Token: 0x040000AB RID: 171
		private readonly string _masculinePrefix = "al";

		// Token: 0x040000AC RID: 172
		private readonly string _feminineSuffix = "a";

		// Token: 0x040000AD RID: 173
		private readonly string _masculineSuffix = "lea";
	}
}
