using System;

namespace Humanizer.Localisation.Ordinalizers
{
	// Token: 0x02000035 RID: 53
	public interface IOrdinalizer
	{
		// Token: 0x06000126 RID: 294
		string Convert(int number, string numberString);

		// Token: 0x06000127 RID: 295
		string Convert(int number, string numberString, GrammaticalGender gender);
	}
}
