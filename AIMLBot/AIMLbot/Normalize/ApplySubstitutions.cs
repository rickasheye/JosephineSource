using System;
using System.Text;
using System.Text.RegularExpressions;
using AIMLbot.Utils;

namespace AIMLbot.Normalize
{
	// Token: 0x02000016 RID: 22
	public class ApplySubstitutions : TextTransformer
	{
		// Token: 0x0600003F RID: 63 RVA: 0x000033D6 File Offset: 0x000023D6
		public ApplySubstitutions(Bot bot, string inputString) : base(bot, inputString)
		{
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000033E0 File Offset: 0x000023E0
		public ApplySubstitutions(Bot bot) : base(bot)
		{
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000033EC File Offset: 0x000023EC
		private static string getMarker(int len)
		{
			char[] array = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
			StringBuilder stringBuilder = new StringBuilder();
			Random random = new Random();
			for (int i = 0; i < len; i++)
			{
				stringBuilder.Append(array[random.Next(array.Length)]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00003434 File Offset: 0x00002434
		protected override string ProcessChange()
		{
			return ApplySubstitutions.Substitute(this.bot, this.bot.Substitutions, this.inputString);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003454 File Offset: 0x00002454
		public static string Substitute(Bot bot, SettingsDictionary dictionary, string target)
		{
			string marker = ApplySubstitutions.getMarker(5);
			string text = target;
			foreach (string text2 in dictionary.SettingNames)
			{
				string text3 = ApplySubstitutions.makeRegexSafe(text2);
				string pattern = "\\b" + text3.TrimEnd(new char[0]).TrimStart(new char[0]) + "\\b";
				string replacement = marker + dictionary.grabSetting(text2).Trim() + marker;
				text = Regex.Replace(text, pattern, replacement, RegexOptions.IgnoreCase);
			}
			return text.Replace(marker, "");
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000034E8 File Offset: 0x000024E8
		private static string makeRegexSafe(string input)
		{
			string text = input.Replace("\\", "");
			text = text.Replace(")", "\\)");
			text = text.Replace("(", "\\(");
			return text.Replace(".", "\\.");
		}
	}
}
