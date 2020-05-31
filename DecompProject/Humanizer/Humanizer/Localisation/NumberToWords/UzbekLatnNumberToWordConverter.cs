using System;
using System.Text;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x0200005B RID: 91
	internal class UzbekLatnNumberToWordConverter : GenderlessNumberToWordsConverter
	{
		// Token: 0x060001E4 RID: 484 RVA: 0x0000B1C4 File Offset: 0x000093C4
		public override string Convert(long input)
		{
			if (input > 2147483647L || input < -2147483648L)
			{
				throw new NotImplementedException();
			}
			int number = (int)input;
			if (number < 0)
			{
				return string.Format("minus {0}", new object[]
				{
					this.Convert(-number, true)
				});
			}
			return this.Convert(number, true);
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x0000B218 File Offset: 0x00009418
		private string Convert(int number, bool checkForHoundredRule)
		{
			if (number == 0)
			{
				return UzbekLatnNumberToWordConverter.UnitsMap[0];
			}
			if (checkForHoundredRule && number == 100)
			{
				return "yuz";
			}
			StringBuilder sb = new StringBuilder();
			if (number / 1000000000 > 0)
			{
				sb.AppendFormat("{0} milliard ", new object[]
				{
					this.Convert(number / 1000000000, false)
				});
				number %= 1000000000;
			}
			if (number / 1000000 > 0)
			{
				sb.AppendFormat("{0} million ", new object[]
				{
					this.Convert(number / 1000000, true)
				});
				number %= 1000000;
			}
			int thousand = number / 1000;
			if (thousand > 0)
			{
				sb.AppendFormat("{0} ming ", new object[]
				{
					this.Convert(thousand, true)
				});
				number %= 1000;
			}
			int hundred = number / 100;
			if (hundred > 0)
			{
				sb.AppendFormat("{0} yuz ", new object[]
				{
					this.Convert(hundred, false)
				});
				number %= 100;
			}
			if (number / 10 > 0)
			{
				sb.AppendFormat("{0} ", new object[]
				{
					UzbekLatnNumberToWordConverter.TensMap[number / 10]
				});
				number %= 10;
			}
			if (number > 0)
			{
				sb.AppendFormat("{0} ", new object[]
				{
					UzbekLatnNumberToWordConverter.UnitsMap[number]
				});
			}
			return sb.ToString().Trim();
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x0000B368 File Offset: 0x00009568
		public override string ConvertToOrdinal(int number)
		{
			string word = this.Convert((long)number);
			int i = 0;
			if (string.IsNullOrEmpty(word))
			{
				return string.Empty;
			}
			char lastChar = word[word.Length - 1];
			if (lastChar == 'i' || lastChar == 'a')
			{
				i = 1;
			}
			return string.Format("{0}{1}", new object[]
			{
				word,
				UzbekLatnNumberToWordConverter.OrdinalSuffixes[i]
			});
		}

		// Token: 0x0400009E RID: 158
		private static readonly string[] UnitsMap = new string[]
		{
			"nol",
			"bir",
			"ikki",
			"uch",
			"to`rt",
			"besh",
			"olti",
			"yetti",
			"sakkiz",
			"to`qqiz"
		};

		// Token: 0x0400009F RID: 159
		private static readonly string[] TensMap = new string[]
		{
			"nol",
			"o`n",
			"yigirma",
			"o`ttiz",
			"qirq",
			"ellik",
			"oltmish",
			"yetmish",
			"sakson",
			"to`qson"
		};

		// Token: 0x040000A0 RID: 160
		private static readonly string[] OrdinalSuffixes = new string[]
		{
			"inchi",
			"nchi"
		};
	}
}
