using System;
using System.Collections.Generic;
using System.Globalization;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x02000055 RID: 85
	internal class SerbianNumberToWordsConverter : GenderlessNumberToWordsConverter
	{
		// Token: 0x060001C2 RID: 450 RVA: 0x000096B5 File Offset: 0x000078B5
		public SerbianNumberToWordsConverter(CultureInfo culture)
		{
			this._culture = culture;
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x000096C4 File Offset: 0x000078C4
		public override string Convert(long input)
		{
			if (input > 2147483647L || input < -2147483648L)
			{
				throw new NotImplementedException();
			}
			int number = (int)input;
			if (number == 0)
			{
				return "nula";
			}
			if (number < 0)
			{
				return string.Format("- {0}", new object[]
				{
					this.Convert((long)(-(long)number))
				});
			}
			List<string> parts = new List<string>();
			int billions = number / 1000000000;
			if (billions > 0)
			{
				parts.Add(this.Part("milijarda", "dve milijarde", "{0} milijarde", "{0} milijarda", billions));
				number %= 1000000000;
				if (number > 0)
				{
					parts.Add(" ");
				}
			}
			int millions = number / 1000000;
			if (millions > 0)
			{
				parts.Add(this.Part("milion", "dva miliona", "{0} miliona", "{0} miliona", millions));
				number %= 1000000;
				if (number > 0)
				{
					parts.Add(" ");
				}
			}
			int thousands = number / 1000;
			if (thousands > 0)
			{
				parts.Add(this.Part("hiljadu", "dve hiljade", "{0} hiljade", "{0} hiljada", thousands));
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
					parts.Add(SerbianNumberToWordsConverter.UnitsMap[number]);
				}
				else
				{
					parts.Add(SerbianNumberToWordsConverter.TensMap[number / 10]);
					int units = number % 10;
					if (units > 0)
					{
						parts.Add(string.Format(" {0}", new object[]
						{
							SerbianNumberToWordsConverter.UnitsMap[units]
						}));
					}
				}
			}
			return string.Join("", parts);
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x0000988B File Offset: 0x00007A8B
		public override string ConvertToOrdinal(int number)
		{
			return number.ToString(this._culture);
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x0000989C File Offset: 0x00007A9C
		private string Part(string singular, string dual, string trialQuadral, string plural, int number)
		{
			switch (number)
			{
			case 1:
				return singular;
			case 2:
				return dual;
			case 3:
			case 4:
				return string.Format(trialQuadral, new object[]
				{
					this.Convert((long)number)
				});
			default:
				return string.Format(plural, new object[]
				{
					this.Convert((long)number)
				});
			}
		}

		// Token: 0x04000084 RID: 132
		private static readonly string[] UnitsMap = new string[]
		{
			"nula",
			"jedan",
			"dva",
			"tri",
			"četiri",
			"pet",
			"šest",
			"sedam",
			"osam",
			"devet",
			"deset",
			"jedanaest",
			"dvanaest",
			"trinaest",
			"četrnaestt",
			"petnaest",
			"šestnaest",
			"sedemnaest",
			"osemnaest",
			"devetnaest"
		};

		// Token: 0x04000085 RID: 133
		private static readonly string[] TensMap = new string[]
		{
			"nula",
			"deset",
			"dvadeset",
			"trideset",
			"četrdeset",
			"petdeset",
			"šestdeset",
			"sedamdeset",
			"osamdeset",
			"devetdeset"
		};

		// Token: 0x04000086 RID: 134
		private readonly CultureInfo _culture;
	}
}
