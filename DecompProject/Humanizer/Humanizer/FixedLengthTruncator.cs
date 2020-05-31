using System;

namespace Humanizer
{
	// Token: 0x02000028 RID: 40
	internal class FixedLengthTruncator : ITruncator
	{
		// Token: 0x0600010C RID: 268 RVA: 0x00003C04 File Offset: 0x00001E04
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
			if (truncationString == null || truncationString.Length > length)
			{
				if (truncateFrom != TruncateFrom.Right)
				{
					return value.Substring(value.Length - length);
				}
				return value.Substring(0, length);
			}
			else if (truncateFrom == TruncateFrom.Left)
			{
				if (value.Length <= length)
				{
					return value;
				}
				return truncationString + value.Substring(value.Length - length + truncationString.Length);
			}
			else
			{
				if (value.Length <= length)
				{
					return value;
				}
				return value.Substring(0, length - truncationString.Length) + truncationString;
			}
		}
	}
}
