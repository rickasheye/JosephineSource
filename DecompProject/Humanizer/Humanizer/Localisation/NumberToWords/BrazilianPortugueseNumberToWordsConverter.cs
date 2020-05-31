using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x02000040 RID: 64
	internal class BrazilianPortugueseNumberToWordsConverter : GenderedNumberToWordsConverter
	{
		// Token: 0x0600014E RID: 334 RVA: 0x000057E8 File Offset: 0x000039E8
		public override string Convert(long input, GrammaticalGender gender)
		{
			if (input > 2147483647L || input < -2147483648L)
			{
				throw new NotImplementedException();
			}
			int number = (int)input;
			if (number == 0)
			{
				return "zero";
			}
			if (number < 0)
			{
				return string.Format("menos {0}", new object[]
				{
					this.Convert((long)Math.Abs(number), gender)
				});
			}
			List<string> parts = new List<string>();
			if (number / 1000000000 > 0)
			{
				parts.Add((number / 1000000000 > 2) ? string.Format("{0} bilhões", new object[]
				{
					this.Convert((long)(number / 1000000000), GrammaticalGender.Masculine)
				}) : string.Format("{0} bilhão", new object[]
				{
					this.Convert((long)(number / 1000000000), GrammaticalGender.Masculine)
				}));
				number %= 1000000000;
			}
			if (number / 1000000 > 0)
			{
				parts.Add((number / 1000000 > 2) ? string.Format("{0} milhões", new object[]
				{
					this.Convert((long)(number / 1000000), GrammaticalGender.Masculine)
				}) : string.Format("{0} milhão", new object[]
				{
					this.Convert((long)(number / 1000000), GrammaticalGender.Masculine)
				}));
				number %= 1000000;
			}
			if (number / 1000 > 0)
			{
				parts.Add((number / 1000 == 1) ? "mil" : string.Format("{0} mil", new object[]
				{
					this.Convert((long)(number / 1000), GrammaticalGender.Masculine)
				}));
				number %= 1000;
			}
			if (number / 100 > 0)
			{
				if (number == 100)
				{
					parts.Add((parts.Count > 0) ? "e cem" : "cem");
				}
				else
				{
					parts.Add(BrazilianPortugueseNumberToWordsConverter.ApplyGender(BrazilianPortugueseNumberToWordsConverter.PortugueseHundredsMap[number / 100], gender));
				}
				number %= 100;
			}
			if (number > 0)
			{
				if (parts.Count != 0)
				{
					parts.Add("e");
				}
				if (number < 20)
				{
					parts.Add(BrazilianPortugueseNumberToWordsConverter.ApplyGender(BrazilianPortugueseNumberToWordsConverter.PortugueseUnitsMap[number], gender));
				}
				else
				{
					string lastPart = BrazilianPortugueseNumberToWordsConverter.PortugueseTensMap[number / 10];
					if (number % 10 > 0)
					{
						lastPart += string.Format(" e {0}", new object[]
						{
							BrazilianPortugueseNumberToWordsConverter.ApplyGender(BrazilianPortugueseNumberToWordsConverter.PortugueseUnitsMap[number % 10], gender)
						});
					}
					parts.Add(lastPart);
				}
			}
			return string.Join(" ", parts.ToArray());
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00005A28 File Offset: 0x00003C28
		public override string ConvertToOrdinal(int number, GrammaticalGender gender)
		{
			if (number == 0)
			{
				return "zero";
			}
			List<string> parts = new List<string>();
			if (number / 1000000000 > 0)
			{
				parts.Add((number / 1000000000 == 1) ? BrazilianPortugueseNumberToWordsConverter.ApplyOrdinalGender("bilionésimo", gender) : string.Format("{0} " + BrazilianPortugueseNumberToWordsConverter.ApplyOrdinalGender("bilionésimo", gender), new object[]
				{
					this.ConvertToOrdinal(number / 1000000000, gender)
				}));
				number %= 1000000000;
			}
			if (number / 1000000 > 0)
			{
				parts.Add((number / 1000000 == 1) ? BrazilianPortugueseNumberToWordsConverter.ApplyOrdinalGender("milionésimo", gender) : string.Format("{0}" + BrazilianPortugueseNumberToWordsConverter.ApplyOrdinalGender("milionésimo", gender), new object[]
				{
					this.ConvertToOrdinal(number / 1000000000, gender)
				}));
				number %= 1000000;
			}
			if (number / 1000 > 0)
			{
				parts.Add((number / 1000 == 1) ? BrazilianPortugueseNumberToWordsConverter.ApplyOrdinalGender("milésimo", gender) : string.Format("{0} " + BrazilianPortugueseNumberToWordsConverter.ApplyOrdinalGender("milésimo", gender), new object[]
				{
					this.ConvertToOrdinal(number / 1000, gender)
				}));
				number %= 1000;
			}
			if (number / 100 > 0)
			{
				parts.Add(BrazilianPortugueseNumberToWordsConverter.ApplyOrdinalGender(BrazilianPortugueseNumberToWordsConverter.PortugueseOrdinalHundredsMap[number / 100], gender));
				number %= 100;
			}
			if (number / 10 > 0)
			{
				parts.Add(BrazilianPortugueseNumberToWordsConverter.ApplyOrdinalGender(BrazilianPortugueseNumberToWordsConverter.PortugueseOrdinalTensMap[number / 10], gender));
				number %= 10;
			}
			if (number > 0)
			{
				parts.Add(BrazilianPortugueseNumberToWordsConverter.ApplyOrdinalGender(BrazilianPortugueseNumberToWordsConverter.PortugueseOrdinalUnitsMap[number], gender));
			}
			return string.Join(" ", parts.ToArray());
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00005BD4 File Offset: 0x00003DD4
		private static string ApplyGender(string toWords, GrammaticalGender gender)
		{
			if (gender != GrammaticalGender.Feminine)
			{
				return toWords;
			}
			if (toWords.EndsWith("os"))
			{
				return toWords.Substring(0, toWords.Length - 2) + "as";
			}
			if (toWords.EndsWith("um"))
			{
				return toWords.Substring(0, toWords.Length - 2) + "uma";
			}
			if (toWords.EndsWith("dois"))
			{
				return toWords.Substring(0, toWords.Length - 4) + "duas";
			}
			return toWords;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00005C5D File Offset: 0x00003E5D
		private static string ApplyOrdinalGender(string toWords, GrammaticalGender gender)
		{
			if (gender == GrammaticalGender.Feminine)
			{
				return toWords.TrimEnd(new char[]
				{
					'o'
				}) + "a";
			}
			return toWords;
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00005C80 File Offset: 0x00003E80
		public BrazilianPortugueseNumberToWordsConverter() : base(GrammaticalGender.Masculine)
		{
		}

		// Token: 0x04000050 RID: 80
		private static readonly string[] PortugueseUnitsMap = new string[]
		{
			"zero",
			"um",
			"dois",
			"três",
			"quatro",
			"cinco",
			"seis",
			"sete",
			"oito",
			"nove",
			"dez",
			"onze",
			"doze",
			"treze",
			"quatorze",
			"quinze",
			"dezesseis",
			"dezessete",
			"dezoito",
			"dezenove"
		};

		// Token: 0x04000051 RID: 81
		private static readonly string[] PortugueseTensMap = new string[]
		{
			"zero",
			"dez",
			"vinte",
			"trinta",
			"quarenta",
			"cinquenta",
			"sessenta",
			"setenta",
			"oitenta",
			"noventa"
		};

		// Token: 0x04000052 RID: 82
		private static readonly string[] PortugueseHundredsMap = new string[]
		{
			"zero",
			"cento",
			"duzentos",
			"trezentos",
			"quatrocentos",
			"quinhentos",
			"seiscentos",
			"setecentos",
			"oitocentos",
			"novecentos"
		};

		// Token: 0x04000053 RID: 83
		private static readonly string[] PortugueseOrdinalUnitsMap = new string[]
		{
			"zero",
			"primeiro",
			"segundo",
			"terceiro",
			"quarto",
			"quinto",
			"sexto",
			"sétimo",
			"oitavo",
			"nono"
		};

		// Token: 0x04000054 RID: 84
		private static readonly string[] PortugueseOrdinalTensMap = new string[]
		{
			"zero",
			"décimo",
			"vigésimo",
			"trigésimo",
			"quadragésimo",
			"quinquagésimo",
			"sexagésimo",
			"septuagésimo",
			"octogésimo",
			"nonagésimo"
		};

		// Token: 0x04000055 RID: 85
		private static readonly string[] PortugueseOrdinalHundredsMap = new string[]
		{
			"zero",
			"centésimo",
			"ducentésimo",
			"trecentésimo",
			"quadringentésimo",
			"quingentésimo",
			"sexcentésimo",
			"septingentésimo",
			"octingentésimo",
			"noningentésimo"
		};
	}
}
