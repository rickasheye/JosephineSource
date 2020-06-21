using System;
using System.Globalization;

namespace Humanizer.Localisation.Formatters
{
	// Token: 0x02000068 RID: 104
	internal class RomanianFormatter : DefaultFormatter
	{
		// Token: 0x0600021F RID: 543 RVA: 0x0000C604 File Offset: 0x0000A804
		public RomanianFormatter() : base("ro")
		{
			this._romanianCulture = new CultureInfo("ro");
		}

		// Token: 0x06000220 RID: 544 RVA: 0x0000C624 File Offset: 0x0000A824
		protected override string Format(string resourceKey, int number)
		{
			string resource = Resources.GetResource(this.GetResourceKey(resourceKey, number), this._romanianCulture);
			string preposition = RomanianFormatter.ShouldUsePreposition(number) ? " de" : string.Empty;
			return resource.FormatWith(new object[]
			{
				number,
				preposition
			});
		}

		// Token: 0x06000221 RID: 545 RVA: 0x0000C674 File Offset: 0x0000A874
		private static bool ShouldUsePreposition(int number)
		{
			double prepositionIndicatingNumeral = Math.Abs((double)number % RomanianFormatter.Divider);
			return prepositionIndicatingNumeral < 1.0 || prepositionIndicatingNumeral > 19.0;
		}

		// Token: 0x040000C6 RID: 198
		private const int PrepositionIndicatingDecimals = 2;

		// Token: 0x040000C7 RID: 199
		private const int MaxNumeralWithNoPreposition = 19;

		// Token: 0x040000C8 RID: 200
		private const int MinNumeralWithNoPreposition = 1;

		// Token: 0x040000C9 RID: 201
		private const string UnitPreposition = " de";

		// Token: 0x040000CA RID: 202
		private const string RomanianCultureCode = "ro";

		// Token: 0x040000CB RID: 203
		private static readonly double Divider = Math.Pow(10.0, 2.0);

		// Token: 0x040000CC RID: 204
		private readonly CultureInfo _romanianCulture;
	}
}
