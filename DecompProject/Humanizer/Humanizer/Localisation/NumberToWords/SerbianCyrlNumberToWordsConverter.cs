using System;
using System.Collections.Generic;
using System.Globalization;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x02000054 RID: 84
	internal class SerbianCyrlNumberToWordsConverter : GenderlessNumberToWordsConverter
	{
		// Token: 0x060001BD RID: 445 RVA: 0x0000934A File Offset: 0x0000754A
		public SerbianCyrlNumberToWordsConverter(CultureInfo culture)
		{
			this._culture = culture;
		}

		// Token: 0x060001BE RID: 446 RVA: 0x0000935C File Offset: 0x0000755C
		public override string Convert(long input)
		{
			if (input > 2147483647L || input < -2147483648L)
			{
				throw new NotImplementedException();
			}
			int number = (int)input;
			if (number == 0)
			{
				return "нула";
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
				parts.Add(this.Part("милијарда", "две милијарде", "{0} милијарде", "{0} милијарда", billions));
				number %= 1000000000;
				if (number > 0)
				{
					parts.Add(" ");
				}
			}
			int millions = number / 1000000;
			if (millions > 0)
			{
				parts.Add(this.Part("милион", "два милиона", "{0} милиона", "{0} милиона", millions));
				number %= 1000000;
				if (number > 0)
				{
					parts.Add(" ");
				}
			}
			int thousands = number / 1000;
			if (thousands > 0)
			{
				parts.Add(this.Part("хиљаду", "две хиљаде", "{0} хиљаде", "{0} хиљада", thousands));
				number %= 1000;
				if (number > 0)
				{
					parts.Add(" ");
				}
			}
			int hundreds = number / 100;
			if (hundreds > 0)
			{
				parts.Add(this.Part("сто", "двесто", "{0}сто", "{0}сто", hundreds));
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
					parts.Add(SerbianCyrlNumberToWordsConverter.UnitsMap[number]);
				}
				else
				{
					parts.Add(SerbianCyrlNumberToWordsConverter.TensMap[number / 10]);
					int units = number % 10;
					if (units > 0)
					{
						parts.Add(string.Format(" {0}", new object[]
						{
							SerbianCyrlNumberToWordsConverter.UnitsMap[units]
						}));
					}
				}
			}
			return string.Join("", parts);
		}

		// Token: 0x060001BF RID: 447 RVA: 0x00009523 File Offset: 0x00007723
		public override string ConvertToOrdinal(int number)
		{
			return number.ToString(this._culture);
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00009534 File Offset: 0x00007734
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

		// Token: 0x04000081 RID: 129
		private static readonly string[] UnitsMap = new string[]
		{
			"нула",
			"један",
			"два",
			"три",
			"четири",
			"пет",
			"шест",
			"седам",
			"осам",
			"девет",
			"десет",
			"једанест",
			"дванаест",
			"тринаест",
			"четрнаест",
			"петнаест",
			"шеснаест",
			"седамнаест",
			"осамнаест",
			"деветнаест"
		};

		// Token: 0x04000082 RID: 130
		private static readonly string[] TensMap = new string[]
		{
			"нула",
			"десет",
			"двадесет",
			"тридесет",
			"четрдесет",
			"петдесет",
			"шестдесет",
			"седамдесет",
			"осамдесет",
			"деветдесет"
		};

		// Token: 0x04000083 RID: 131
		private readonly CultureInfo _culture;
	}
}
