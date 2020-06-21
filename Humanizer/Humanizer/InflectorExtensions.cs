using System;
using System.Text.RegularExpressions;
using Humanizer.Inflections;

namespace Humanizer
{
	// Token: 0x0200000E RID: 14
	public static class InflectorExtensions
	{
		// Token: 0x06000064 RID: 100 RVA: 0x000028F9 File Offset: 0x00000AF9
		public static string Pluralize(this string word, bool inputIsKnownToBeSingular = true)
		{
			return Vocabularies.Default.Pluralize(word, inputIsKnownToBeSingular);
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00002907 File Offset: 0x00000B07
		public static string Singularize(this string word, bool inputIsKnownToBePlural = true)
		{
			return Vocabularies.Default.Singularize(word, inputIsKnownToBePlural);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00002915 File Offset: 0x00000B15
		public static string Titleize(this string input)
		{
			return input.Humanize(LetterCasing.Title);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000291E File Offset: 0x00000B1E
		public static string Pascalize(this string input)
		{
			return Regex.Replace(input, "(?:^|_)(.)", (Match match) => match.Groups[1].Value.ToUpper());
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0000294C File Offset: 0x00000B4C
		public static string Camelize(this string input)
		{
			string word = input.Pascalize();
			return word.Substring(0, 1).ToLower() + word.Substring(1);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00002979 File Offset: 0x00000B79
		public static string Underscore(this string input)
		{
			return Regex.Replace(Regex.Replace(Regex.Replace(input, "([\\p{Lu}]+)([\\p{Lu}][\\p{Ll}])", "$1_$2"), "([\\p{Ll}\\d])([\\p{Lu}])", "$1_$2"), "[-\\s]", "_").ToLower();
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000029AE File Offset: 0x00000BAE
		public static string Dasherize(this string underscoredWord)
		{
			return underscoredWord.Replace('_', '-');
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000029BA File Offset: 0x00000BBA
		public static string Hyphenate(this string underscoredWord)
		{
			return underscoredWord.Dasherize();
		}

		// Token: 0x0600006C RID: 108 RVA: 0x000029C2 File Offset: 0x00000BC2
		public static string Kebaberize(this string input)
		{
			return input.Underscore().Dasherize();
		}
	}
}
