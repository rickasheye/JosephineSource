using System;
using System.Collections.Generic;
using System.Globalization;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x02000056 RID: 86
	internal class SlovenianNumberToWordsConverter : GenderlessNumberToWordsConverter
	{
		// Token: 0x060001C7 RID: 455 RVA: 0x00009A1D File Offset: 0x00007C1D
		public SlovenianNumberToWordsConverter(CultureInfo culture)
		{
			this._culture = culture;
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x00009A2C File Offset: 0x00007C2C
		public override string Convert(long input)
		{
			if (input > 2147483647L || input < -2147483648L)
			{
				throw new NotImplementedException();
			}
			int number = (int)input;
			if (number == 0)
			{
				return "nič";
			}
			if (number < 0)
			{
				return string.Format("minus {0}", new object[]
				{
					this.Convert((long)(-(long)number))
				});
			}
			List<string> parts = new List<string>();
			int billions = number / 1000000000;
			if (billions > 0)
			{
				parts.Add(this.Part("milijarda", "dve milijardi", "{0} milijarde", "{0} milijard", billions));
				number %= 1000000000;
				if (number > 0)
				{
					parts.Add(" ");
				}
			}
			int millions = number / 1000000;
			if (millions > 0)
			{
				parts.Add(this.Part("milijon", "dva milijona", "{0} milijone", "{0} milijonov", millions));
				number %= 1000000;
				if (number > 0)
				{
					parts.Add(" ");
				}
			}
			int thousands = number / 1000;
			if (thousands > 0)
			{
				parts.Add(this.Part("tisoč", "dva tisoč", "{0} tisoč", "{0} tisoč", thousands));
				number %= 1000;
				if (number > 0)
				{
					parts.Add(" ");
				}
			}
			int hundreds = number / 100;
			if (hundreds > 0)
			{
				parts.Add(this.Part("sto", "dvesto", "{0}sto", "{0}sto", hundreds));
				number %= 100;
				if (number > 0)
				{
					parts.Add(" ");
				}
			}
			if (number > 0)
			{
				if (number < 20)
				{
					if (number > 1)
					{
						parts.Add(SlovenianNumberToWordsConverter.UnitsMap[number]);
					}
					else
					{
						parts.Add("ena");
					}
				}
				else
				{
					int units = number % 10;
					if (units > 0)
					{
						parts.Add(string.Format("{0}in", new object[]
						{
							SlovenianNumberToWordsConverter.UnitsMap[units]
						}));
					}
					parts.Add(SlovenianNumberToWordsConverter.TensMap[number / 10]);
				}
			}
			return string.Join("", parts);
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x00009C04 File Offset: 0x00007E04
		public override string ConvertToOrdinal(int number)
		{
			return number.ToString(this._culture);
		}

		// Token: 0x060001CA RID: 458 RVA: 0x00009C14 File Offset: 0x00007E14
		private string Part(string singular, string dual, string trialQuadral, string plural, int number)
		{
			if (number == 1)
			{
				return singular;
			}
			if (number == 2)
			{
				return dual;
			}
			if (number == 3 || number == 4)
			{
				return string.Format(trialQuadral, new object[]
				{
					this.Convert((long)number)
				});
			}
			return string.Format(plural, new object[]
			{
				this.Convert((long)number)
			});
		}

		// Token: 0x04000087 RID: 135
		private static readonly string[] UnitsMap = new string[]
		{
			"nič",
			"ena",
			"dva",
			"tri",
			"štiri",
			"pet",
			"šest",
			"sedem",
			"osem",
			"devet",
			"deset",
			"enajst",
			"dvanajst",
			"trinajst",
			"štirinajst",
			"petnajst",
			"šestnajst",
			"sedemnajst",
			"osemnajst",
			"devetnajst"
		};

		// Token: 0x04000088 RID: 136
		private static readonly string[] TensMap = new string[]
		{
			"nič",
			"deset",
			"dvajset",
			"trideset",
			"štirideset",
			"petdeset",
			"šestdeset",
			"sedemdeset",
			"osemdeset",
			"devetdeset"
		};

		// Token: 0x04000089 RID: 137
		private readonly CultureInfo _culture;
	}
}
