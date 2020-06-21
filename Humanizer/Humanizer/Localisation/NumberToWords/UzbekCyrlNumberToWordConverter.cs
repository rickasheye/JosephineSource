using System;
using System.Text;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x0200005A RID: 90
	internal class UzbekCyrlNumberToWordConverter : GenderlessNumberToWordsConverter
	{
		// Token: 0x060001DF RID: 479 RVA: 0x0000AECC File Offset: 0x000090CC
		public override string Convert(long input)
		{
			if (input > 2147483647L || input < -2147483648L)
			{
				throw new NotImplementedException();
			}
			int number = (int)input;
			if (number < 0)
			{
				return string.Format("минус {0}", new object[]
				{
					this.Convert(-number, true)
				});
			}
			return this.Convert(number, true);
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x0000AF20 File Offset: 0x00009120
		private string Convert(int number, bool checkForHoundredRule)
		{
			if (number == 0)
			{
				return UzbekCyrlNumberToWordConverter.UnitsMap[0];
			}
			if (checkForHoundredRule && number == 100)
			{
				return "юз";
			}
			StringBuilder sb = new StringBuilder();
			if (number / 1000000000 > 0)
			{
				sb.AppendFormat("{0} миллиард ", new object[]
				{
					this.Convert(number / 1000000000, false)
				});
				number %= 1000000000;
			}
			if (number / 1000000 > 0)
			{
				sb.AppendFormat("{0} миллион ", new object[]
				{
					this.Convert(number / 1000000, true)
				});
				number %= 1000000;
			}
			int thousand = number / 1000;
			if (thousand > 0)
			{
				sb.AppendFormat("{0} минг ", new object[]
				{
					this.Convert(thousand, true)
				});
				number %= 1000;
			}
			int hundred = number / 100;
			if (hundred > 0)
			{
				sb.AppendFormat("{0} юз ", new object[]
				{
					this.Convert(hundred, false)
				});
				number %= 100;
			}
			if (number / 10 > 0)
			{
				sb.AppendFormat("{0} ", new object[]
				{
					UzbekCyrlNumberToWordConverter.TensMap[number / 10]
				});
				number %= 10;
			}
			if (number > 0)
			{
				sb.AppendFormat("{0} ", new object[]
				{
					UzbekCyrlNumberToWordConverter.UnitsMap[number]
				});
			}
			return sb.ToString().Trim();
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x0000B070 File Offset: 0x00009270
		public override string ConvertToOrdinal(int number)
		{
			string word = this.Convert((long)number);
			int i = 0;
			if (string.IsNullOrEmpty(word))
			{
				return string.Empty;
			}
			char lastChar = word[word.Length - 1];
			if (lastChar == 'и' || lastChar == 'а')
			{
				i = 1;
			}
			return string.Format("{0}{1}", new object[]
			{
				word,
				UzbekCyrlNumberToWordConverter.OrdinalSuffixes[i]
			});
		}

		// Token: 0x0400009B RID: 155
		private static readonly string[] UnitsMap = new string[]
		{
			"нол",
			"бир",
			"икки",
			"уч",
			"тўрт",
			"беш",
			"олти",
			"етти",
			"саккиз",
			"тўққиз"
		};

		// Token: 0x0400009C RID: 156
		private static readonly string[] TensMap = new string[]
		{
			"нол",
			"ўн",
			"йигирма",
			"ўттиз",
			"қирқ",
			"эллик",
			"олтмиш",
			"етмиш",
			"саксон",
			"тўқсон"
		};

		// Token: 0x0400009D RID: 157
		private static readonly string[] OrdinalSuffixes = new string[]
		{
			"инчи",
			"нчи"
		};
	}
}
