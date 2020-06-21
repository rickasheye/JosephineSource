using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x02000044 RID: 68
	internal class FarsiNumberToWordsConverter : GenderlessNumberToWordsConverter
	{
		// Token: 0x06000163 RID: 355 RVA: 0x000068F0 File Offset: 0x00004AF0
		public override string Convert(long input)
		{
			if (input > 2147483647L || input < -2147483648L)
			{
				throw new NotImplementedException();
			}
			int number = (int)input;
			if (number < 0)
			{
				return string.Format("منفی {0}", new object[]
				{
					this.Convert((long)(-(long)number))
				});
			}
			if (number == 0)
			{
				return "صفر";
			}
			Dictionary<int, Func<int, string>> dictionary = new Dictionary<int, Func<int, string>>();
			dictionary.Add((int)Math.Pow(10.0, 9.0), (int n) => string.Format("{0} میلیارد", new object[]
			{
				this.Convert((long)n)
			}));
			dictionary.Add((int)Math.Pow(10.0, 6.0), (int n) => string.Format("{0} میلیون", new object[]
			{
				this.Convert((long)n)
			}));
			dictionary.Add((int)Math.Pow(10.0, 3.0), (int n) => string.Format("{0} هزار", new object[]
			{
				this.Convert((long)n)
			}));
			dictionary.Add((int)Math.Pow(10.0, 2.0), (int n) => FarsiNumberToWordsConverter.FarsiHundredsMap[n]);
			Dictionary<int, Func<int, string>> farsiGroupsMap = dictionary;
			List<string> parts = new List<string>();
			foreach (int group in farsiGroupsMap.Keys)
			{
				if (number / group > 0)
				{
					parts.Add(farsiGroupsMap[group](number / group));
					number %= group;
				}
			}
			if (number >= 20)
			{
				parts.Add(FarsiNumberToWordsConverter.FarsiTensMap[number / 10]);
				number %= 10;
			}
			if (number > 0)
			{
				parts.Add(FarsiNumberToWordsConverter.FarsiUnitsMap[number]);
			}
			return string.Join(" و ", parts);
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00006AA4 File Offset: 0x00004CA4
		public override string ConvertToOrdinal(int number)
		{
			if (number == 1)
			{
				return "اول";
			}
			if (number == 3)
			{
				return "سوم";
			}
			if (number % 10 == 3 && number != 13)
			{
				return this.Convert((long)(number / 10 * 10)) + " و سوم";
			}
			string word = this.Convert((long)number);
			return string.Format("{0}{1}", new object[]
			{
				word,
				word.EndsWith("ی") ? " ام" : "م"
			});
		}

		// Token: 0x0400005F RID: 95
		private static readonly string[] FarsiHundredsMap = new string[]
		{
			"صفر",
			"صد",
			"دویست",
			"سیصد",
			"چهارصد",
			"پانصد",
			"ششصد",
			"هفتصد",
			"هشتصد",
			"نهصد"
		};

		// Token: 0x04000060 RID: 96
		private static readonly string[] FarsiTensMap = new string[]
		{
			"صفر",
			"ده",
			"بیست",
			"سی",
			"چهل",
			"پنجاه",
			"شصت",
			"هفتاد",
			"هشتاد",
			"نود"
		};

		// Token: 0x04000061 RID: 97
		private static readonly string[] FarsiUnitsMap = new string[]
		{
			"صفر",
			"یک",
			"دو",
			"سه",
			"چهار",
			"پنج",
			"شش",
			"هفت",
			"هشت",
			"نه",
			"ده",
			"یازده",
			"دوازده",
			"سیزده",
			"چهارده",
			"پانزده",
			"شانزده",
			"هفده",
			"هجده",
			"نوزده"
		};
	}
}
