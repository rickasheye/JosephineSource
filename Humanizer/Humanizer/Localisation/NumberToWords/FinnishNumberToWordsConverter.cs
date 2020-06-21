using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x02000045 RID: 69
	internal class FinnishNumberToWordsConverter : GenderlessNumberToWordsConverter
	{
		// Token: 0x0600016A RID: 362 RVA: 0x00006D04 File Offset: 0x00004F04
		public override string Convert(long input)
		{
			if (input > 2147483647L || input < -2147483648L)
			{
				throw new NotImplementedException();
			}
			int number = (int)input;
			if (number < 0)
			{
				return string.Format("miinus {0}", new object[]
				{
					this.Convert((long)(-(long)number))
				});
			}
			if (number == 0)
			{
				return FinnishNumberToWordsConverter.UnitsMap[0];
			}
			List<string> parts = new List<string>();
			if (number / 1000000000 > 0)
			{
				parts.Add((number / 1000000000 == 1) ? "miljardi " : string.Format("{0}miljardia ", new object[]
				{
					this.Convert((long)(number / 1000000000))
				}));
				number %= 1000000000;
			}
			if (number / 1000000 > 0)
			{
				parts.Add((number / 1000000 == 1) ? "miljoona " : string.Format("{0}miljoonaa ", new object[]
				{
					this.Convert((long)(number / 1000000))
				}));
				number %= 1000000;
			}
			if (number / 1000 > 0)
			{
				parts.Add((number / 1000 == 1) ? "tuhat " : string.Format("{0}tuhatta ", new object[]
				{
					this.Convert((long)(number / 1000))
				}));
				number %= 1000;
			}
			if (number / 100 > 0)
			{
				parts.Add((number / 100 == 1) ? "sata" : string.Format("{0}sataa", new object[]
				{
					this.Convert((long)(number / 100))
				}));
				number %= 100;
			}
			if (number >= 20 && number / 10 > 0)
			{
				parts.Add(string.Format("{0}kymmentä", new object[]
				{
					this.Convert((long)(number / 10))
				}));
				number %= 10;
			}
			else if (number > 10 && number < 20)
			{
				parts.Add(string.Format("{0}toista", new object[]
				{
					FinnishNumberToWordsConverter.UnitsMap[number % 10]
				}));
			}
			if (number > 0 && number <= 10)
			{
				parts.Add(FinnishNumberToWordsConverter.UnitsMap[number]);
			}
			return string.Join("", parts).Trim();
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00006F04 File Offset: 0x00005104
		private string GetOrdinalUnit(int number, bool useExceptions)
		{
			if (useExceptions && FinnishNumberToWordsConverter.OrdinalExceptions.ContainsKey(number))
			{
				return FinnishNumberToWordsConverter.OrdinalExceptions[number];
			}
			return FinnishNumberToWordsConverter.OrdinalUnitsMap[number];
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00006F2C File Offset: 0x0000512C
		private string ToOrdinal(int number, bool useExceptions)
		{
			if (number == 0)
			{
				return FinnishNumberToWordsConverter.OrdinalUnitsMap[0];
			}
			List<string> parts = new List<string>();
			if (number / 1000000000 > 0)
			{
				parts.Add(string.Format("{0}miljardis", new object[]
				{
					(number / 1000000000 == 1) ? "" : this.ToOrdinal(number / 1000000000, true)
				}));
				number %= 1000000000;
			}
			if (number / 1000000 > 0)
			{
				parts.Add(string.Format("{0}miljoonas", new object[]
				{
					(number / 1000000 == 1) ? "" : this.ToOrdinal(number / 1000000, true)
				}));
				number %= 1000000;
			}
			if (number / 1000 > 0)
			{
				parts.Add(string.Format("{0}tuhannes", new object[]
				{
					(number / 1000 == 1) ? "" : this.ToOrdinal(number / 1000, true)
				}));
				number %= 1000;
			}
			if (number / 100 > 0)
			{
				parts.Add(string.Format("{0}sadas", new object[]
				{
					(number / 100 == 1) ? "" : this.ToOrdinal(number / 100, true)
				}));
				number %= 100;
			}
			if (number >= 20 && number / 10 > 0)
			{
				parts.Add(string.Format("{0}kymmenes", new object[]
				{
					this.ToOrdinal(number / 10, true)
				}));
				number %= 10;
			}
			else if (number > 10 && number < 20)
			{
				parts.Add(string.Format("{0}toista", new object[]
				{
					this.GetOrdinalUnit(number % 10, true)
				}));
			}
			if (number > 0 && number <= 10)
			{
				parts.Add(this.GetOrdinalUnit(number, useExceptions));
			}
			return string.Join("", parts);
		}

		// Token: 0x0600016D RID: 365 RVA: 0x000070F2 File Offset: 0x000052F2
		public override string ConvertToOrdinal(int number)
		{
			return this.ToOrdinal(number, false);
		}

		// Token: 0x04000062 RID: 98
		private static readonly string[] UnitsMap = new string[]
		{
			"nolla",
			"yksi",
			"kaksi",
			"kolme",
			"neljä",
			"viisi",
			"kuusi",
			"seitsemän",
			"kahdeksan",
			"yhdeksän",
			"kymmenen"
		};

		// Token: 0x04000063 RID: 99
		private static readonly string[] OrdinalUnitsMap = new string[]
		{
			"nollas",
			"ensimmäinen",
			"toinen",
			"kolmas",
			"neljäs",
			"viides",
			"kuudes",
			"seitsemäs",
			"kahdeksas",
			"yhdeksäs",
			"kymmenes"
		};

		// Token: 0x04000064 RID: 100
		private static readonly Dictionary<int, string> OrdinalExceptions = new Dictionary<int, string>
		{
			{
				1,
				"yhdes"
			},
			{
				2,
				"kahdes"
			}
		};
	}
}
