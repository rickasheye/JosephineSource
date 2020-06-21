using System;
using System.Collections.Generic;
using System.Linq;

namespace Humanizer
{
	// Token: 0x02000024 RID: 36
	internal class ToTitleCase : IStringTransformer
	{
		// Token: 0x06000103 RID: 259 RVA: 0x00003AE0 File Offset: 0x00001CE0
		public string Transform(string input)
		{
			string[] array = input.Split(new char[]
			{
				' '
			});
			List<string> result = new List<string>();
			foreach (string word in array)
			{
				if (word.Length == 0 || ToTitleCase.AllCapitals(word))
				{
					result.Add(word);
				}
				else if (word.Length == 1)
				{
					result.Add(word.ToUpper());
				}
				else
				{
					result.Add(char.ToUpper(word[0]).ToString() + word.Remove(0, 1).ToLower());
				}
			}
			return string.Join(" ", result);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00003B7F File Offset: 0x00001D7F
		private static bool AllCapitals(string input)
		{
			return input.ToCharArray().All(new Func<char, bool>(char.IsUpper));
		}
	}
}
