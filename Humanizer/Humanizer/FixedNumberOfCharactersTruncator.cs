using System;
using System.Linq;

namespace Humanizer
{
	// Token: 0x02000029 RID: 41
	internal class FixedNumberOfCharactersTruncator : ITruncator
	{
		// Token: 0x0600010E RID: 270 RVA: 0x00003C9C File Offset: 0x00001E9C
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
			if (truncationString == null)
			{
				truncationString = string.Empty;
			}
			if (truncationString.Length > length)
			{
				if (truncateFrom != TruncateFrom.Right)
				{
					return value.Substring(value.Length - length);
				}
				return value.Substring(0, length);
			}
			else
			{
				int alphaNumericalCharactersProcessed = 0;
				if (value.ToCharArray().Count(new Func<char, bool>(char.IsLetterOrDigit)) <= length)
				{
					return value;
				}
				if (truncateFrom == TruncateFrom.Left)
				{
					for (int i = value.Length - 1; i > 0; i--)
					{
						if (char.IsLetterOrDigit(value[i]))
						{
							alphaNumericalCharactersProcessed++;
						}
						if (alphaNumericalCharactersProcessed + truncationString.Length == length)
						{
							return truncationString + value.Substring(i);
						}
					}
				}
				for (int j = 0; j < value.Length - truncationString.Length; j++)
				{
					if (char.IsLetterOrDigit(value[j]))
					{
						alphaNumericalCharactersProcessed++;
					}
					if (alphaNumericalCharactersProcessed + truncationString.Length == length)
					{
						return value.Substring(0, j + 1) + truncationString;
					}
				}
				return value;
			}
		}
	}
}
