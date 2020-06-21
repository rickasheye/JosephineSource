using System;
using System.Globalization;
using System.Reflection;
using Humanizer.DateTimeHumanizeStrategy;
using Humanizer.Localisation.CollectionFormatters;
using Humanizer.Localisation.DateToOrdinalWords;
using Humanizer.Localisation.Formatters;
using Humanizer.Localisation.NumberToWords;
using Humanizer.Localisation.Ordinalizers;

namespace Humanizer.Configuration
{
	// Token: 0x0200007D RID: 125
	public static class Configurator
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000259 RID: 601 RVA: 0x0000D79B File Offset: 0x0000B99B
		public static LocaliserRegistry<ICollectionFormatter> CollectionFormatters
		{
			get
			{
				return Configurator._collectionFormatters;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600025A RID: 602 RVA: 0x0000D7A2 File Offset: 0x0000B9A2
		public static LocaliserRegistry<IFormatter> Formatters
		{
			get
			{
				return Configurator._formatters;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600025B RID: 603 RVA: 0x0000D7A9 File Offset: 0x0000B9A9
		public static LocaliserRegistry<INumberToWordsConverter> NumberToWordsConverters
		{
			get
			{
				return Configurator._numberToWordsConverters;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600025C RID: 604 RVA: 0x0000D7B0 File Offset: 0x0000B9B0
		public static LocaliserRegistry<IOrdinalizer> Ordinalizers
		{
			get
			{
				return Configurator._ordinalizers;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600025D RID: 605 RVA: 0x0000D7B7 File Offset: 0x0000B9B7
		public static LocaliserRegistry<IDateToOrdinalWordConverter> DateToOrdinalWordsConverters
		{
			get
			{
				return Configurator._dateToOrdinalWordConverters;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600025E RID: 606 RVA: 0x0000D7BE File Offset: 0x0000B9BE
		internal static ICollectionFormatter CollectionFormatter
		{
			get
			{
				return Configurator.CollectionFormatters.ResolveForUiCulture();
			}
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0000D7CA File Offset: 0x0000B9CA
		internal static IFormatter GetFormatter(CultureInfo culture)
		{
			return Configurator.Formatters.ResolveForCulture(culture);
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0000D7D7 File Offset: 0x0000B9D7
		internal static INumberToWordsConverter GetNumberToWordsConverter(CultureInfo culture)
		{
			return Configurator.NumberToWordsConverters.ResolveForCulture(culture);
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000261 RID: 609 RVA: 0x0000D7E4 File Offset: 0x0000B9E4
		internal static IOrdinalizer Ordinalizer
		{
			get
			{
				return Configurator.Ordinalizers.ResolveForUiCulture();
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000262 RID: 610 RVA: 0x0000D7F0 File Offset: 0x0000B9F0
		internal static IDateToOrdinalWordConverter DateToOrdinalWordsConverter
		{
			get
			{
				return Configurator.DateToOrdinalWordsConverters.ResolveForUiCulture();
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000263 RID: 611 RVA: 0x0000D7FC File Offset: 0x0000B9FC
		// (set) Token: 0x06000264 RID: 612 RVA: 0x0000D803 File Offset: 0x0000BA03
		public static IDateTimeHumanizeStrategy DateTimeHumanizeStrategy
		{
			get
			{
				return Configurator._dateTimeHumanizeStrategy;
			}
			set
			{
				Configurator._dateTimeHumanizeStrategy = value;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000265 RID: 613 RVA: 0x0000D80B File Offset: 0x0000BA0B
		// (set) Token: 0x06000266 RID: 614 RVA: 0x0000D812 File Offset: 0x0000BA12
		public static IDateTimeOffsetHumanizeStrategy DateTimeOffsetHumanizeStrategy
		{
			get
			{
				return Configurator._dateTimeOffsetHumanizeStrategy;
			}
			set
			{
				Configurator._dateTimeOffsetHumanizeStrategy = value;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000267 RID: 615 RVA: 0x0000D81A File Offset: 0x0000BA1A
		// (set) Token: 0x06000268 RID: 616 RVA: 0x0000D821 File Offset: 0x0000BA21
		public static Func<PropertyInfo, bool> EnumDescriptionPropertyLocator
		{
			get
			{
				return Configurator._enumDescriptionPropertyLocator;
			}
			set
			{
				Configurator._enumDescriptionPropertyLocator = (value ?? Configurator.DefaultEnumDescriptionPropertyLocator);
			}
		}

		// Token: 0x040000D7 RID: 215
		private static readonly LocaliserRegistry<ICollectionFormatter> _collectionFormatters = new CollectionFormatterRegistry();

		// Token: 0x040000D8 RID: 216
		private static readonly LocaliserRegistry<IFormatter> _formatters = new FormatterRegistry();

		// Token: 0x040000D9 RID: 217
		private static readonly LocaliserRegistry<INumberToWordsConverter> _numberToWordsConverters = new NumberToWordsConverterRegistry();

		// Token: 0x040000DA RID: 218
		private static readonly LocaliserRegistry<IOrdinalizer> _ordinalizers = new OrdinalizerRegistry();

		// Token: 0x040000DB RID: 219
		private static readonly LocaliserRegistry<IDateToOrdinalWordConverter> _dateToOrdinalWordConverters = new DateToOrdinalWordsConverterRegistry();

		// Token: 0x040000DC RID: 220
		private static IDateTimeHumanizeStrategy _dateTimeHumanizeStrategy = new DefaultDateTimeHumanizeStrategy();

		// Token: 0x040000DD RID: 221
		private static IDateTimeOffsetHumanizeStrategy _dateTimeOffsetHumanizeStrategy = new DefaultDateTimeOffsetHumanizeStrategy();

		// Token: 0x040000DE RID: 222
		private static readonly Func<PropertyInfo, bool> DefaultEnumDescriptionPropertyLocator = (PropertyInfo p) => p.Name == "Description";

		// Token: 0x040000DF RID: 223
		private static Func<PropertyInfo, bool> _enumDescriptionPropertyLocator = Configurator.DefaultEnumDescriptionPropertyLocator;
	}
}
