using System;
using System.Linq;

namespace Humanizer
{
	// Token: 0x02000007 RID: 7
	public static class EnumDehumanizeExtensions
	{
		// Token: 0x0600003D RID: 61 RVA: 0x000023D4 File Offset: 0x000005D4
		public static TTargetEnum DehumanizeTo<TTargetEnum>(this string input) where TTargetEnum : struct, IComparable, IFormattable
		{
			return (TTargetEnum)((object)EnumDehumanizeExtensions.DehumanizeToPrivate(input, typeof(TTargetEnum), OnNoMatch.ThrowsException));
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000023EC File Offset: 0x000005EC
		public static Enum DehumanizeTo(this string input, Type targetEnum, OnNoMatch onNoMatch = OnNoMatch.ThrowsException)
		{
			return (Enum)EnumDehumanizeExtensions.DehumanizeToPrivate(input, targetEnum, onNoMatch);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000023FC File Offset: 0x000005FC
		private static object DehumanizeToPrivate(string input, Type targetEnum, OnNoMatch onNoMatch)
		{
			Enum @enum = Enum.GetValues(targetEnum).Cast<Enum>().FirstOrDefault((Enum value) => string.Equals(value.Humanize(), input, StringComparison.OrdinalIgnoreCase));
			if (@enum == null && onNoMatch == OnNoMatch.ThrowsException)
			{
				throw new NoMatchFoundException("Couldn't find any enum member that matches the string " + input);
			}
			return @enum;
		}
	}
}
