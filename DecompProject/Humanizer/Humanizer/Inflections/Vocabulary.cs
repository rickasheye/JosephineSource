using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Humanizer.Inflections
{
	// Token: 0x02000074 RID: 116
	public class Vocabulary
	{
		// Token: 0x06000243 RID: 579 RVA: 0x0000CF4F File Offset: 0x0000B14F
		internal Vocabulary()
		{
		}

		// Token: 0x06000244 RID: 580 RVA: 0x0000CF78 File Offset: 0x0000B178
		public void AddIrregular(string singular, string plural, bool matchEnding = true)
		{
			if (matchEnding)
			{
				this.AddPlural(string.Concat(new string[]
				{
					"(",
					singular[0].ToString(),
					")",
					singular.Substring(1),
					"$"
				}), "$1" + plural.Substring(1));
				this.AddSingular(string.Concat(new string[]
				{
					"(",
					plural[0].ToString(),
					")",
					plural.Substring(1),
					"$"
				}), "$1" + singular.Substring(1));
				return;
			}
			this.AddPlural(string.Format("^{0}$", new object[]
			{
				singular
			}), plural);
			this.AddSingular(string.Format("^{0}$", new object[]
			{
				plural
			}), singular);
		}

		// Token: 0x06000245 RID: 581 RVA: 0x0000D06E File Offset: 0x0000B26E
		public void AddUncountable(string word)
		{
			this._uncountables.Add(word.ToLower());
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0000D081 File Offset: 0x0000B281
		public void AddPlural(string rule, string replacement)
		{
			this._plurals.Add(new Vocabulary.Rule(rule, replacement));
		}

		// Token: 0x06000247 RID: 583 RVA: 0x0000D095 File Offset: 0x0000B295
		public void AddSingular(string rule, string replacement)
		{
			this._singulars.Add(new Vocabulary.Rule(rule, replacement));
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000D0AC File Offset: 0x0000B2AC
		public string Pluralize(string word, bool inputIsKnownToBeSingular = true)
		{
			string result = this.ApplyRules(this._plurals, word);
			if (inputIsKnownToBeSingular)
			{
				return result;
			}
			string asSingular = this.ApplyRules(this._singulars, word);
			string asSingularAsPlural = this.ApplyRules(this._plurals, asSingular);
			if (asSingular != null && asSingular != word && asSingular + "s" != word && asSingularAsPlural == word && result != word)
			{
				return word;
			}
			return result;
		}

		// Token: 0x06000249 RID: 585 RVA: 0x0000D11C File Offset: 0x0000B31C
		public string Singularize(string word, bool inputIsKnownToBePlural = true)
		{
			string result = this.ApplyRules(this._singulars, word);
			if (inputIsKnownToBePlural)
			{
				return result;
			}
			string asPlural = this.ApplyRules(this._plurals, word);
			string asPluralAsSingular = this.ApplyRules(this._singulars, asPlural);
			if (asPlural != word && word + "s" != asPlural && asPluralAsSingular == word && result != word)
			{
				return word;
			}
			return result ?? word;
		}

		// Token: 0x0600024A RID: 586 RVA: 0x0000D190 File Offset: 0x0000B390
		private string ApplyRules(IList<Vocabulary.Rule> rules, string word)
		{
			if (word == null)
			{
				return null;
			}
			if (this.IsUncountable(word))
			{
				return word;
			}
			string result = word;
			int i = rules.Count - 1;
			while (i >= 0 && (result = rules[i].Apply(word)) == null)
			{
				i--;
			}
			return result;
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0000D1D4 File Offset: 0x0000B3D4
		private bool IsUncountable(string word)
		{
			return this._uncountables.Contains(word.ToLower());
		}

		// Token: 0x040000D2 RID: 210
		private readonly List<Vocabulary.Rule> _plurals = new List<Vocabulary.Rule>();

		// Token: 0x040000D3 RID: 211
		private readonly List<Vocabulary.Rule> _singulars = new List<Vocabulary.Rule>();

		// Token: 0x040000D4 RID: 212
		private readonly List<string> _uncountables = new List<string>();

		// Token: 0x020000B5 RID: 181
		private class Rule
		{
			// Token: 0x06000503 RID: 1283 RVA: 0x00012FC7 File Offset: 0x000111C7
			public Rule(string pattern, string replacement)
			{
				this._regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptionsUtil.Compiled);
				this._replacement = replacement;
			}

			// Token: 0x06000504 RID: 1284 RVA: 0x00012FE9 File Offset: 0x000111E9
			public string Apply(string word)
			{
				if (!this._regex.IsMatch(word))
				{
					return null;
				}
				return this._regex.Replace(word, this._replacement);
			}

			// Token: 0x04000138 RID: 312
			private readonly Regex _regex;

			// Token: 0x04000139 RID: 313
			private readonly string _replacement;
		}
	}
}
