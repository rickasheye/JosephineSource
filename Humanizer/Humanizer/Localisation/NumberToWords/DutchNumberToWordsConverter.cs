using System;
using System.Collections.Generic;
using System.Linq;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x02000042 RID: 66
	internal class DutchNumberToWordsConverter : GenderlessNumberToWordsConverter
	{
		// Token: 0x06000157 RID: 343 RVA: 0x00005F50 File Offset: 0x00004150
		public override string Convert(long input)
		{
			if (input > 2147483647L || input < -2147483648L)
			{
				throw new NotImplementedException();
			}
			int number = (int)input;
			if (number == 0)
			{
				return DutchNumberToWordsConverter.UnitsMap[0];
			}
			if (number < 0)
			{
				return string.Format("min {0}", new object[]
				{
					this.Convert((long)(-(long)number))
				});
			}
			string word = "";
			foreach (DutchNumberToWordsConverter.Fact i in DutchNumberToWordsConverter.Hunderds)
			{
				int divided = number / i.Value;
				if (divided > 0)
				{
					if (divided == 1 && !i.DisplayOneUnit)
					{
						word += i.Name;
					}
					else
					{
						word = word + this.Convert((long)divided) + i.Prefix + i.Name;
					}
					number %= i.Value;
					if (number > 0)
					{
						word += i.Postfix;
					}
				}
			}
			if (number > 0)
			{
				if (number < 20)
				{
					word += DutchNumberToWordsConverter.UnitsMap[number];
				}
				else
				{
					string tens = DutchNumberToWordsConverter.TensMap[number / 10];
					int unit = number % 10;
					if (unit > 0)
					{
						string units = DutchNumberToWordsConverter.UnitsMap[unit];
						bool trema = units.EndsWith("e");
						word = word + units + (trema ? "ën" : "en") + tens;
					}
					else
					{
						word += tens;
					}
				}
			}
			return word;
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0000609C File Offset: 0x0000429C
		public override string ConvertToOrdinal(int number)
		{
			string word = this.Convert((long)number);
			IEnumerable<KeyValuePair<string, string>> ordinalExceptions = DutchNumberToWordsConverter.OrdinalExceptions;
			Func<KeyValuePair<string, string>, bool> <>9__0;
			Func<KeyValuePair<string, string>, bool> predicate;
			if ((predicate = <>9__0) == null)
			{
				predicate = (<>9__0 = ((KeyValuePair<string, string> kv) => word.EndsWith(kv.Key)));
			}
			using (IEnumerator<KeyValuePair<string, string>> enumerator = ordinalExceptions.Where(predicate).GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					KeyValuePair<string, string> kv2 = enumerator.Current;
					return word.Substring(0, word.Length - kv2.Key.Length) + kv2.Value;
				}
			}
			if (word.LastIndexOfAny(DutchNumberToWordsConverter.EndingCharForSte) == word.Length - 1)
			{
				return word + "ste";
			}
			return word + "de";
		}

		// Token: 0x04000057 RID: 87
		private static readonly string[] UnitsMap = new string[]
		{
			"nul",
			"een",
			"twee",
			"drie",
			"vier",
			"vijf",
			"zes",
			"zeven",
			"acht",
			"negen",
			"tien",
			"elf",
			"twaalf",
			"dertien",
			"veertien",
			"vijftien",
			"zestien",
			"zeventien",
			"achttien",
			"negentien"
		};

		// Token: 0x04000058 RID: 88
		private static readonly string[] TensMap = new string[]
		{
			"nul",
			"tien",
			"twintig",
			"dertig",
			"veertig",
			"vijftig",
			"zestig",
			"zeventig",
			"tachtig",
			"negentig"
		};

		// Token: 0x04000059 RID: 89
		private static readonly DutchNumberToWordsConverter.Fact[] Hunderds = new DutchNumberToWordsConverter.Fact[]
		{
			new DutchNumberToWordsConverter.Fact
			{
				Value = 1000000000,
				Name = "miljard",
				Prefix = " ",
				Postfix = " ",
				DisplayOneUnit = true
			},
			new DutchNumberToWordsConverter.Fact
			{
				Value = 1000000,
				Name = "miljoen",
				Prefix = " ",
				Postfix = " ",
				DisplayOneUnit = true
			},
			new DutchNumberToWordsConverter.Fact
			{
				Value = 1000,
				Name = "duizend",
				Prefix = "",
				Postfix = " ",
				DisplayOneUnit = false
			},
			new DutchNumberToWordsConverter.Fact
			{
				Value = 100,
				Name = "honderd",
				Prefix = "",
				Postfix = "",
				DisplayOneUnit = false
			}
		};

		// Token: 0x0400005A RID: 90
		private static readonly Dictionary<string, string> OrdinalExceptions = new Dictionary<string, string>
		{
			{
				"een",
				"eerste"
			},
			{
				"drie",
				"derde"
			},
			{
				"miljoen",
				"miljoenste"
			}
		};

		// Token: 0x0400005B RID: 91
		private static readonly char[] EndingCharForSte = new char[]
		{
			't',
			'g',
			'd'
		};

		// Token: 0x020000AB RID: 171
		private class Fact
		{
			// Token: 0x170001DF RID: 479
			// (get) Token: 0x060004E6 RID: 1254 RVA: 0x00012E87 File Offset: 0x00011087
			// (set) Token: 0x060004E7 RID: 1255 RVA: 0x00012E8F File Offset: 0x0001108F
			public int Value { get; set; }

			// Token: 0x170001E0 RID: 480
			// (get) Token: 0x060004E8 RID: 1256 RVA: 0x00012E98 File Offset: 0x00011098
			// (set) Token: 0x060004E9 RID: 1257 RVA: 0x00012EA0 File Offset: 0x000110A0
			public string Name { get; set; }

			// Token: 0x170001E1 RID: 481
			// (get) Token: 0x060004EA RID: 1258 RVA: 0x00012EA9 File Offset: 0x000110A9
			// (set) Token: 0x060004EB RID: 1259 RVA: 0x00012EB1 File Offset: 0x000110B1
			public string Prefix { get; set; }

			// Token: 0x170001E2 RID: 482
			// (get) Token: 0x060004EC RID: 1260 RVA: 0x00012EBA File Offset: 0x000110BA
			// (set) Token: 0x060004ED RID: 1261 RVA: 0x00012EC2 File Offset: 0x000110C2
			public string Postfix { get; set; }

			// Token: 0x170001E3 RID: 483
			// (get) Token: 0x060004EE RID: 1262 RVA: 0x00012ECB File Offset: 0x000110CB
			// (set) Token: 0x060004EF RID: 1263 RVA: 0x00012ED3 File Offset: 0x000110D3
			public bool DisplayOneUnit { get; set; }
		}
	}
}
