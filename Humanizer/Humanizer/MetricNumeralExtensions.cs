using System;
using System.Collections.Generic;
using System.Linq;

namespace Humanizer
{
	// Token: 0x02000010 RID: 16
	public static class MetricNumeralExtensions
	{
		// Token: 0x0600006D RID: 109 RVA: 0x000029D0 File Offset: 0x00000BD0
		static MetricNumeralExtensions()
		{
			MetricNumeralExtensions.BigLimit = Math.Pow(10.0, 27.0);
			MetricNumeralExtensions.SmallLimit = Math.Pow(10.0, -27.0);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00002B90 File Offset: 0x00000D90
		public static double FromMetric(this string input)
		{
			input = MetricNumeralExtensions.CleanRepresentation(input);
			return MetricNumeralExtensions.BuildNumber(input, input[input.Length - 1]);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00002BAE File Offset: 0x00000DAE
		public static string ToMetric(this int input, bool hasSpace = false, bool useSymbol = true, int? decimals = null)
		{
			return ((double)input).ToMetric(hasSpace, useSymbol, decimals);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00002BBA File Offset: 0x00000DBA
		public static string ToMetric(this double input, bool hasSpace = false, bool useSymbol = true, int? decimals = null)
		{
			if (input.Equals(0.0))
			{
				return input.ToString();
			}
			if (input.IsOutOfRange())
			{
				throw new ArgumentOutOfRangeException("input");
			}
			return MetricNumeralExtensions.BuildRepresentation(input, hasSpace, useSymbol, decimals);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00002BF4 File Offset: 0x00000DF4
		private static string CleanRepresentation(string input)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}
			input = input.Trim();
			input = MetricNumeralExtensions.ReplaceNameBySymbol(input);
			if (input.Length == 0 || input.IsInvalidMetricNumeral())
			{
				throw new ArgumentException("Empty or invalid Metric string.", "input");
			}
			return input.Replace(" ", string.Empty);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00002C4F File Offset: 0x00000E4F
		private static double BuildNumber(string input, char last)
		{
			if (!char.IsLetter(last))
			{
				return double.Parse(input);
			}
			return MetricNumeralExtensions.BuildMetricNumber(input, last);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00002C68 File Offset: 0x00000E68
		private static double BuildMetricNumber(string input, char last)
		{
			Func<List<char>, double> getExponent = (List<char> symbols) => (double)((symbols.IndexOf(last) + 1) * 3);
			double num = double.Parse(input.Remove(input.Length - 1));
			double exponent = Math.Pow(10.0, MetricNumeralExtensions.Symbols[0].Contains(last) ? getExponent(MetricNumeralExtensions.Symbols[0]) : (-getExponent(MetricNumeralExtensions.Symbols[1])));
			return num * exponent;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00002CE4 File Offset: 0x00000EE4
		private static string ReplaceNameBySymbol(string input)
		{
			return MetricNumeralExtensions.Names.Aggregate(input, (string current, KeyValuePair<char, string> name) => current.Replace(name.Value, name.Key.ToString()));
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00002D10 File Offset: 0x00000F10
		private static string BuildRepresentation(double input, bool hasSpace, bool useSymbol, int? decimals)
		{
			int exponent = (int)Math.Floor(Math.Log10(Math.Abs(input)) / 3.0);
			if (!exponent.Equals(0))
			{
				return MetricNumeralExtensions.BuildMetricRepresentation(input, exponent, hasSpace, useSymbol, decimals);
			}
			return input.ToString();
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00002D58 File Offset: 0x00000F58
		private static string BuildMetricRepresentation(double input, int exponent, bool hasSpace, bool useSymbol, int? decimals)
		{
			double number = input * Math.Pow(1000.0, (double)(-(double)exponent));
			if (decimals != null)
			{
				number = Math.Round(number, decimals.Value);
			}
			char symbol = (Math.Sign(exponent) == 1) ? MetricNumeralExtensions.Symbols[0][exponent - 1] : MetricNumeralExtensions.Symbols[1][-exponent - 1];
			return number + (hasSpace ? " " : string.Empty) + MetricNumeralExtensions.GetUnit(symbol, useSymbol);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00002DDC File Offset: 0x00000FDC
		private static string GetUnit(char symbol, bool useSymbol)
		{
			if (!useSymbol)
			{
				return MetricNumeralExtensions.Names[symbol];
			}
			return symbol.ToString();
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00002DF4 File Offset: 0x00000FF4
		private static bool IsOutOfRange(this double input)
		{
			Func<double, double, bool> outside = (double min, double max) => max <= input || input <= min;
			return (Math.Sign(input) == 1 && outside(MetricNumeralExtensions.SmallLimit, MetricNumeralExtensions.BigLimit)) || (Math.Sign(input) == -1 && outside(-MetricNumeralExtensions.BigLimit, -MetricNumeralExtensions.SmallLimit));
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00002E60 File Offset: 0x00001060
		private static bool IsInvalidMetricNumeral(this string input)
		{
			int index = input.Length - 1;
			char last = input[index];
			double number;
			return !double.TryParse((MetricNumeralExtensions.Symbols[0].Contains(last) || MetricNumeralExtensions.Symbols[1].Contains(last)) ? input.Remove(index) : input, out number);
		}

		// Token: 0x04000015 RID: 21
		private static readonly double BigLimit;

		// Token: 0x04000016 RID: 22
		private static readonly double SmallLimit;

		// Token: 0x04000017 RID: 23
		private static readonly List<char>[] Symbols = new List<char>[]
		{
			new List<char>
			{
				'k',
				'M',
				'G',
				'T',
				'P',
				'E',
				'Z',
				'Y'
			},
			new List<char>
			{
				'm',
				'μ',
				'n',
				'p',
				'f',
				'a',
				'z',
				'y'
			}
		};

		// Token: 0x04000018 RID: 24
		private static readonly Dictionary<char, string> Names = new Dictionary<char, string>
		{
			{
				'Y',
				"yotta"
			},
			{
				'Z',
				"zetta"
			},
			{
				'E',
				"exa"
			},
			{
				'P',
				"peta"
			},
			{
				'T',
				"tera"
			},
			{
				'G',
				"giga"
			},
			{
				'M',
				"mega"
			},
			{
				'k',
				"kilo"
			},
			{
				'm',
				"milli"
			},
			{
				'μ',
				"micro"
			},
			{
				'n',
				"nano"
			},
			{
				'p',
				"pico"
			},
			{
				'f',
				"femto"
			},
			{
				'a',
				"atto"
			},
			{
				'z',
				"zepto"
			},
			{
				'y',
				"yocto"
			}
		};
	}
}
