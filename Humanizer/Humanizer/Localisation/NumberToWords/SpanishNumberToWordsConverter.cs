using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	// Token: 0x02000057 RID: 87
	internal class SpanishNumberToWordsConverter : GenderedNumberToWordsConverter
	{
		// Token: 0x060001CC RID: 460 RVA: 0x00009D90 File Offset: 0x00007F90
		public override string Convert(long input, GrammaticalGender gender)
		{
			if (input > 2147483647L || input < -2147483648L)
			{
				throw new NotImplementedException();
			}
			int number = (int)input;
			if (number == 0)
			{
				return "cero";
			}
			if (number < 0)
			{
				return string.Format("menos {0}", new object[]
				{
					base.Convert((long)Math.Abs(number))
				});
			}
			List<string> parts = new List<string>();
			if (number / 1000000000 > 0)
			{
				parts.Add((number / 1000000000 == 1) ? "mil millones" : string.Format("{0} mil millones", new object[]
				{
					base.Convert((long)(number / 1000000000))
				}));
				number %= 1000000000;
			}
			if (number / 1000000 > 0)
			{
				parts.Add((number / 1000000 == 1) ? "un millón" : string.Format("{0} millones", new object[]
				{
					base.Convert((long)(number / 1000000))
				}));
				number %= 1000000;
			}
			if (number / 1000 > 0)
			{
				parts.Add((number / 1000 == 1) ? "mil" : string.Format("{0} mil", new object[]
				{
					this.Convert((long)(number / 1000), gender)
				}));
				number %= 1000;
			}
			if (number / 100 > 0)
			{
				parts.Add((number == 100) ? "cien" : ((gender == GrammaticalGender.Feminine) ? SpanishNumberToWordsConverter.FeminineHundredsMap[number / 100] : SpanishNumberToWordsConverter.HundredsMap[number / 100]));
				number %= 100;
			}
			if (number > 0)
			{
				if (number < 30)
				{
					if (gender == GrammaticalGender.Feminine && (number == 1 || number == 21))
					{
						parts.Add((number == 1) ? "una" : "veintiuna");
					}
					else
					{
						parts.Add(SpanishNumberToWordsConverter.UnitsMap[number]);
					}
				}
				else
				{
					string lastPart = SpanishNumberToWordsConverter.TensMap[number / 10];
					int units = number % 10;
					if (units == 1 && gender == GrammaticalGender.Feminine)
					{
						lastPart += " y una";
					}
					else if (units > 0)
					{
						lastPart += string.Format(" y {0}", new object[]
						{
							SpanishNumberToWordsConverter.UnitsMap[number % 10]
						});
					}
					parts.Add(lastPart);
				}
			}
			return string.Join(" ", parts.ToArray());
		}

		// Token: 0x060001CD RID: 461 RVA: 0x00009FA8 File Offset: 0x000081A8
		public override string ConvertToOrdinal(int number, GrammaticalGender gender)
		{
			string towords;
			if (!SpanishNumberToWordsConverter.Ordinals.TryGetValue(number, out towords))
			{
				towords = base.Convert((long)number);
			}
			if (gender == GrammaticalGender.Feminine)
			{
				towords = towords.TrimEnd(new char[]
				{
					'o'
				}) + "a";
			}
			else if (number % 10 == 1 || number % 10 == 3)
			{
				towords = towords.TrimEnd(new char[]
				{
					'o'
				});
			}
			return towords;
		}

		// Token: 0x060001CE RID: 462 RVA: 0x0000A010 File Offset: 0x00008210
		public SpanishNumberToWordsConverter() : base(GrammaticalGender.Masculine)
		{
		}

		// Token: 0x0400008A RID: 138
		private static readonly string[] UnitsMap = new string[]
		{
			"cero",
			"uno",
			"dos",
			"tres",
			"cuatro",
			"cinco",
			"seis",
			"siete",
			"ocho",
			"nueve",
			"diez",
			"once",
			"doce",
			"trece",
			"catorce",
			"quince",
			"dieciséis",
			"diecisiete",
			"dieciocho",
			"diecinueve",
			"veinte",
			"veintiuno",
			"veintidós",
			"veintitrés",
			"veinticuatro",
			"veinticinco",
			"veintiséis",
			"veintisiete",
			"veintiocho",
			"veintinueve"
		};

		// Token: 0x0400008B RID: 139
		private const string Feminine1 = "una";

		// Token: 0x0400008C RID: 140
		private const string Feminine21 = "veintiuna";

		// Token: 0x0400008D RID: 141
		private static readonly string[] TensMap = new string[]
		{
			"cero",
			"diez",
			"veinte",
			"treinta",
			"cuarenta",
			"cincuenta",
			"sesenta",
			"setenta",
			"ochenta",
			"noventa"
		};

		// Token: 0x0400008E RID: 142
		private static readonly string[] HundredsMap = new string[]
		{
			"cero",
			"ciento",
			"doscientos",
			"trescientos",
			"cuatrocientos",
			"quinientos",
			"seiscientos",
			"setecientos",
			"ochocientos",
			"novecientos"
		};

		// Token: 0x0400008F RID: 143
		private static readonly string[] FeminineHundredsMap = new string[]
		{
			"cero",
			"ciento",
			"doscientas",
			"trescientas",
			"cuatrocientas",
			"quinientas",
			"seiscientas",
			"setecientas",
			"ochocientas",
			"novecientas"
		};

		// Token: 0x04000090 RID: 144
		private static readonly Dictionary<int, string> Ordinals = new Dictionary<int, string>
		{
			{
				1,
				"primero"
			},
			{
				2,
				"segundo"
			},
			{
				3,
				"tercero"
			},
			{
				4,
				"quarto"
			},
			{
				5,
				"quinto"
			},
			{
				6,
				"sexto"
			},
			{
				7,
				"séptimo"
			},
			{
				8,
				"octavo"
			},
			{
				9,
				"noveno"
			},
			{
				10,
				"décimo"
			}
		};
	}
}
