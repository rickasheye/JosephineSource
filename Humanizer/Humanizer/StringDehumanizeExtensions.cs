using System;
using System.Collections.Generic;
using System.Linq;

namespace Humanizer
{
	// Token: 0x0200001A RID: 26
	public static class StringDehumanizeExtensions
	{
		// Token: 0x060000DC RID: 220 RVA: 0x000034A0 File Offset: 0x000016A0
		public static string Dehumanize(this string input)
		{
			IEnumerable<string> titlizedWords = from word in input.Split(new char[]
			{
				' '
			})
			select word.Humanize(LetterCasing.Title);
			return string.Join("", titlizedWords).Replace(" ", "");
		}
	}
}
