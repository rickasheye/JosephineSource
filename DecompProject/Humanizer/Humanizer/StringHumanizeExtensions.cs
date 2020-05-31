using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Humanizer
{
	// Token: 0x0200001C RID: 28
	public static class StringHumanizeExtensions
	{
		// Token: 0x060000E0 RID: 224 RVA: 0x0000353D File Offset: 0x0000173D
		private static string FromUnderscoreDashSeparatedWords(string input)
		{
			return string.Join(" ", input.Split(new char[]
			{
				'_',
				'-'
			}));
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00003560 File Offset: 0x00001760
		private static string FromPascalCase(string input)
		{
			string result = string.Join(" ", StringHumanizeExtensions.PascalCaseWordPartsRegex.Matches(input).Cast<Match>().Select(delegate(Match match)
			{
				if (!match.Value.ToCharArray().All(new Func<char, bool>(char.IsUpper)) || (match.Value.Length <= 1 && (match.Index <= 0 || input[match.Index - 1] != ' ') && !(match.Value == "I")))
				{
					return match.Value.ToLower();
				}
				return match.Value;
			}));
			if (result.Length <= 0)
			{
				return result;
			}
			return char.ToUpper(result[0]).ToString() + result.Substring(1, result.Length - 1);
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x000035E0 File Offset: 0x000017E0
		public static string Humanize(this string input)
		{
			if (input.ToCharArray().All(new Func<char, bool>(char.IsUpper)))
			{
				return input;
			}
			if (StringHumanizeExtensions.FreestandingSpacingCharRegex.IsMatch(input))
			{
				return StringHumanizeExtensions.FromPascalCase(StringHumanizeExtensions.FromUnderscoreDashSeparatedWords(input));
			}
			if (input.Contains("_") || input.Contains("-"))
			{
				return StringHumanizeExtensions.FromUnderscoreDashSeparatedWords(input);
			}
			return StringHumanizeExtensions.FromPascalCase(input);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00003648 File Offset: 0x00001848
		public static string Humanize(this string input, LetterCasing casing)
		{
			return input.Humanize().ApplyCase(casing);
		}

		// Token: 0x04000024 RID: 36
		private static readonly Regex PascalCaseWordPartsRegex = new Regex("[\\p{Lu}]?[\\p{Ll}]+|[0-9]+[\\p{Ll}]*|[\\p{Lu}]+(?=[\\p{Lu}][\\p{Ll}]|[0-9]|\\b)|[\\p{Lo}]+", RegexOptions.ExplicitCapture | RegexOptions.IgnorePatternWhitespace | RegexOptionsUtil.Compiled);

		// Token: 0x04000025 RID: 37
		private static readonly Regex FreestandingSpacingCharRegex = new Regex("\\s[-_]|[-_]\\s", RegexOptionsUtil.Compiled);
	}
}
