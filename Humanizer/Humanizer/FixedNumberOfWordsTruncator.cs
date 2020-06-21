using System;
using System.Linq;

namespace Humanizer
{
	// Token: 0x0200002A RID: 42
	internal class FixedNumberOfWordsTruncator : ITruncator
	{
		// Token: 0x06000110 RID: 272 RVA: 0x00003D97 File Offset: 0x00001F97
		public string Truncate(string value, int length, string truncationString, TruncateFrom truncateFrom = TruncateFrom.Right)
		{
			if (value == null)
			{
				return null;
			}
			if (value.Length == 0)
			{
				return value;
			}
			if (value.Split(null, StringSplitOptions.RemoveEmptyEntries).Count<string>() <= length)
			{
				return value;
			}
			if (truncateFrom != TruncateFrom.Left)
			{
				return FixedNumberOfWordsTruncator.TruncateFromRight(value, length, truncationString);
			}
			return FixedNumberOfWordsTruncator.TruncateFromLeft(value, length, truncationString);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00003DD0 File Offset: 0x00001FD0
		private static string TruncateFromRight(string value, int length, string truncationString)
		{
			bool lastCharactersWasWhiteSpace = true;
			int numberOfWordsProcessed = 0;
			for (int i = 0; i < value.Length; i++)
			{
				if (char.IsWhiteSpace(value[i]))
				{
					if (!lastCharactersWasWhiteSpace)
					{
						numberOfWordsProcessed++;
					}
					lastCharactersWasWhiteSpace = true;
					if (numberOfWordsProcessed == length)
					{
						return value.Substring(0, i) + truncationString;
					}
				}
				else
				{
					lastCharactersWasWhiteSpace = false;
				}
			}
			return value + truncationString;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00003E28 File Offset: 0x00002028
		private static string TruncateFromLeft(string value, int length, string truncationString)
		{
			bool lastCharactersWasWhiteSpace = true;
			int numberOfWordsProcessed = 0;
			for (int i = value.Length - 1; i > 0; i--)
			{
				if (char.IsWhiteSpace(value[i]))
				{
					if (!lastCharactersWasWhiteSpace)
					{
						numberOfWordsProcessed++;
					}
					lastCharactersWasWhiteSpace = true;
					if (numberOfWordsProcessed == length)
					{
						return truncationString + value.Substring(i + 1).TrimEnd(new char[0]);
					}
				}
				else
				{
					lastCharactersWasWhiteSpace = false;
				}
			}
			return truncationString + value;
		}
	}
}
