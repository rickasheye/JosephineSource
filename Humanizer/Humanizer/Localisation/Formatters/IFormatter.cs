using System;

namespace Humanizer.Localisation.Formatters
{
	// Token: 0x02000067 RID: 103
	public interface IFormatter
	{
		// Token: 0x0600021A RID: 538
		string DateHumanize_Now();

		// Token: 0x0600021B RID: 539
		string DateHumanize_Never();

		// Token: 0x0600021C RID: 540
		string DateHumanize(TimeUnit timeUnit, Tense timeUnitTense, int unit);

		// Token: 0x0600021D RID: 541
		string TimeSpanHumanize_Zero();

		// Token: 0x0600021E RID: 542
		string TimeSpanHumanize(TimeUnit timeUnit, int unit);
	}
}
