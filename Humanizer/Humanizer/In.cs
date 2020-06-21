using System;

namespace Humanizer
{
	// Token: 0x02000009 RID: 9
	public class In
	{
		// Token: 0x06000045 RID: 69 RVA: 0x00002655 File Offset: 0x00000855
		public static DateTime TheYear(int year)
		{
			return new DateTime(year, 1, 1);
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00002660 File Offset: 0x00000860
		public static DateTime January
		{
			get
			{
				return new DateTime(DateTime.UtcNow.Year, 1, 1);
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002681 File Offset: 0x00000881
		public static DateTime JanuaryOf(int year)
		{
			return new DateTime(year, 1, 1);
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000048 RID: 72 RVA: 0x0000268C File Offset: 0x0000088C
		public static DateTime February
		{
			get
			{
				return new DateTime(DateTime.UtcNow.Year, 2, 1);
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000026AD File Offset: 0x000008AD
		public static DateTime FebruaryOf(int year)
		{
			return new DateTime(year, 2, 1);
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600004A RID: 74 RVA: 0x000026B8 File Offset: 0x000008B8
		public static DateTime March
		{
			get
			{
				return new DateTime(DateTime.UtcNow.Year, 3, 1);
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000026D9 File Offset: 0x000008D9
		public static DateTime MarchOf(int year)
		{
			return new DateTime(year, 3, 1);
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600004C RID: 76 RVA: 0x000026E4 File Offset: 0x000008E4
		public static DateTime April
		{
			get
			{
				return new DateTime(DateTime.UtcNow.Year, 4, 1);
			}
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002705 File Offset: 0x00000905
		public static DateTime AprilOf(int year)
		{
			return new DateTime(year, 4, 1);
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600004E RID: 78 RVA: 0x00002710 File Offset: 0x00000910
		public static DateTime May
		{
			get
			{
				return new DateTime(DateTime.UtcNow.Year, 5, 1);
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002731 File Offset: 0x00000931
		public static DateTime MayOf(int year)
		{
			return new DateTime(year, 5, 1);
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000050 RID: 80 RVA: 0x0000273C File Offset: 0x0000093C
		public static DateTime June
		{
			get
			{
				return new DateTime(DateTime.UtcNow.Year, 6, 1);
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000275D File Offset: 0x0000095D
		public static DateTime JuneOf(int year)
		{
			return new DateTime(year, 6, 1);
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00002768 File Offset: 0x00000968
		public static DateTime July
		{
			get
			{
				return new DateTime(DateTime.UtcNow.Year, 7, 1);
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002789 File Offset: 0x00000989
		public static DateTime JulyOf(int year)
		{
			return new DateTime(year, 7, 1);
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00002794 File Offset: 0x00000994
		public static DateTime August
		{
			get
			{
				return new DateTime(DateTime.UtcNow.Year, 8, 1);
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x000027B5 File Offset: 0x000009B5
		public static DateTime AugustOf(int year)
		{
			return new DateTime(year, 8, 1);
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000056 RID: 86 RVA: 0x000027C0 File Offset: 0x000009C0
		public static DateTime September
		{
			get
			{
				return new DateTime(DateTime.UtcNow.Year, 9, 1);
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000027E2 File Offset: 0x000009E2
		public static DateTime SeptemberOf(int year)
		{
			return new DateTime(year, 9, 1);
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000058 RID: 88 RVA: 0x000027F0 File Offset: 0x000009F0
		public static DateTime October
		{
			get
			{
				return new DateTime(DateTime.UtcNow.Year, 10, 1);
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00002812 File Offset: 0x00000A12
		public static DateTime OctoberOf(int year)
		{
			return new DateTime(year, 10, 1);
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00002820 File Offset: 0x00000A20
		public static DateTime November
		{
			get
			{
				return new DateTime(DateTime.UtcNow.Year, 11, 1);
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00002842 File Offset: 0x00000A42
		public static DateTime NovemberOf(int year)
		{
			return new DateTime(year, 11, 1);
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00002850 File Offset: 0x00000A50
		public static DateTime December
		{
			get
			{
				return new DateTime(DateTime.UtcNow.Year, 12, 1);
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00002872 File Offset: 0x00000A72
		public static DateTime DecemberOf(int year)
		{
			return new DateTime(year, 12, 1);
		}

		// Token: 0x02000089 RID: 137
		public static class One
		{
			// Token: 0x1700002B RID: 43
			// (get) Token: 0x060002B7 RID: 695 RVA: 0x0000E860 File Offset: 0x0000CA60
			public static DateTime Second
			{
				get
				{
					return DateTime.UtcNow.AddSeconds(1.0);
				}
			}

			// Token: 0x060002B8 RID: 696 RVA: 0x0000E883 File Offset: 0x0000CA83
			public static DateTime SecondFrom(DateTime date)
			{
				return date.AddSeconds(1.0);
			}

			// Token: 0x1700002C RID: 44
			// (get) Token: 0x060002B9 RID: 697 RVA: 0x0000E898 File Offset: 0x0000CA98
			public static DateTime Minute
			{
				get
				{
					return DateTime.UtcNow.AddMinutes(1.0);
				}
			}

			// Token: 0x060002BA RID: 698 RVA: 0x0000E8BB File Offset: 0x0000CABB
			public static DateTime MinuteFrom(DateTime date)
			{
				return date.AddMinutes(1.0);
			}

			// Token: 0x1700002D RID: 45
			// (get) Token: 0x060002BB RID: 699 RVA: 0x0000E8D0 File Offset: 0x0000CAD0
			public static DateTime Hour
			{
				get
				{
					return DateTime.UtcNow.AddHours(1.0);
				}
			}

			// Token: 0x060002BC RID: 700 RVA: 0x0000E8F3 File Offset: 0x0000CAF3
			public static DateTime HourFrom(DateTime date)
			{
				return date.AddHours(1.0);
			}

			// Token: 0x1700002E RID: 46
			// (get) Token: 0x060002BD RID: 701 RVA: 0x0000E908 File Offset: 0x0000CB08
			public static DateTime Day
			{
				get
				{
					return DateTime.UtcNow.AddDays(1.0);
				}
			}

			// Token: 0x060002BE RID: 702 RVA: 0x0000E92B File Offset: 0x0000CB2B
			public static DateTime DayFrom(DateTime date)
			{
				return date.AddDays(1.0);
			}

			// Token: 0x1700002F RID: 47
			// (get) Token: 0x060002BF RID: 703 RVA: 0x0000E940 File Offset: 0x0000CB40
			public static DateTime Week
			{
				get
				{
					return DateTime.UtcNow.AddDays(7.0);
				}
			}

			// Token: 0x060002C0 RID: 704 RVA: 0x0000E963 File Offset: 0x0000CB63
			public static DateTime WeekFrom(DateTime date)
			{
				return date.AddDays(7.0);
			}

			// Token: 0x17000030 RID: 48
			// (get) Token: 0x060002C1 RID: 705 RVA: 0x0000E978 File Offset: 0x0000CB78
			public static DateTime Month
			{
				get
				{
					return DateTime.UtcNow.AddMonths(1);
				}
			}

			// Token: 0x060002C2 RID: 706 RVA: 0x0000E993 File Offset: 0x0000CB93
			public static DateTime MonthFrom(DateTime date)
			{
				return date.AddMonths(1);
			}

			// Token: 0x17000031 RID: 49
			// (get) Token: 0x060002C3 RID: 707 RVA: 0x0000E9A0 File Offset: 0x0000CBA0
			public static DateTime Year
			{
				get
				{
					return DateTime.UtcNow.AddYears(1);
				}
			}

			// Token: 0x060002C4 RID: 708 RVA: 0x0000E9BB File Offset: 0x0000CBBB
			public static DateTime YearFrom(DateTime date)
			{
				return date.AddYears(1);
			}
		}

		// Token: 0x0200008A RID: 138
		public static class Two
		{
			// Token: 0x17000032 RID: 50
			// (get) Token: 0x060002C5 RID: 709 RVA: 0x0000E9C8 File Offset: 0x0000CBC8
			public static DateTime Seconds
			{
				get
				{
					return DateTime.UtcNow.AddSeconds(2.0);
				}
			}

			// Token: 0x060002C6 RID: 710 RVA: 0x0000E9EB File Offset: 0x0000CBEB
			public static DateTime SecondsFrom(DateTime date)
			{
				return date.AddSeconds(2.0);
			}

			// Token: 0x17000033 RID: 51
			// (get) Token: 0x060002C7 RID: 711 RVA: 0x0000EA00 File Offset: 0x0000CC00
			public static DateTime Minutes
			{
				get
				{
					return DateTime.UtcNow.AddMinutes(2.0);
				}
			}

			// Token: 0x060002C8 RID: 712 RVA: 0x0000EA23 File Offset: 0x0000CC23
			public static DateTime MinutesFrom(DateTime date)
			{
				return date.AddMinutes(2.0);
			}

			// Token: 0x17000034 RID: 52
			// (get) Token: 0x060002C9 RID: 713 RVA: 0x0000EA38 File Offset: 0x0000CC38
			public static DateTime Hours
			{
				get
				{
					return DateTime.UtcNow.AddHours(2.0);
				}
			}

			// Token: 0x060002CA RID: 714 RVA: 0x0000EA5B File Offset: 0x0000CC5B
			public static DateTime HoursFrom(DateTime date)
			{
				return date.AddHours(2.0);
			}

			// Token: 0x17000035 RID: 53
			// (get) Token: 0x060002CB RID: 715 RVA: 0x0000EA70 File Offset: 0x0000CC70
			public static DateTime Days
			{
				get
				{
					return DateTime.UtcNow.AddDays(2.0);
				}
			}

			// Token: 0x060002CC RID: 716 RVA: 0x0000EA93 File Offset: 0x0000CC93
			public static DateTime DaysFrom(DateTime date)
			{
				return date.AddDays(2.0);
			}

			// Token: 0x17000036 RID: 54
			// (get) Token: 0x060002CD RID: 717 RVA: 0x0000EAA8 File Offset: 0x0000CCA8
			public static DateTime Weeks
			{
				get
				{
					return DateTime.UtcNow.AddDays(14.0);
				}
			}

			// Token: 0x060002CE RID: 718 RVA: 0x0000EACB File Offset: 0x0000CCCB
			public static DateTime WeeksFrom(DateTime date)
			{
				return date.AddDays(14.0);
			}

			// Token: 0x17000037 RID: 55
			// (get) Token: 0x060002CF RID: 719 RVA: 0x0000EAE0 File Offset: 0x0000CCE0
			public static DateTime Months
			{
				get
				{
					return DateTime.UtcNow.AddMonths(2);
				}
			}

			// Token: 0x060002D0 RID: 720 RVA: 0x0000EAFB File Offset: 0x0000CCFB
			public static DateTime MonthsFrom(DateTime date)
			{
				return date.AddMonths(2);
			}

			// Token: 0x17000038 RID: 56
			// (get) Token: 0x060002D1 RID: 721 RVA: 0x0000EB08 File Offset: 0x0000CD08
			public static DateTime Years
			{
				get
				{
					return DateTime.UtcNow.AddYears(2);
				}
			}

			// Token: 0x060002D2 RID: 722 RVA: 0x0000EB23 File Offset: 0x0000CD23
			public static DateTime YearsFrom(DateTime date)
			{
				return date.AddYears(2);
			}
		}

		// Token: 0x0200008B RID: 139
		public static class Three
		{
			// Token: 0x17000039 RID: 57
			// (get) Token: 0x060002D3 RID: 723 RVA: 0x0000EB30 File Offset: 0x0000CD30
			public static DateTime Seconds
			{
				get
				{
					return DateTime.UtcNow.AddSeconds(3.0);
				}
			}

			// Token: 0x060002D4 RID: 724 RVA: 0x0000EB53 File Offset: 0x0000CD53
			public static DateTime SecondsFrom(DateTime date)
			{
				return date.AddSeconds(3.0);
			}

			// Token: 0x1700003A RID: 58
			// (get) Token: 0x060002D5 RID: 725 RVA: 0x0000EB68 File Offset: 0x0000CD68
			public static DateTime Minutes
			{
				get
				{
					return DateTime.UtcNow.AddMinutes(3.0);
				}
			}

			// Token: 0x060002D6 RID: 726 RVA: 0x0000EB8B File Offset: 0x0000CD8B
			public static DateTime MinutesFrom(DateTime date)
			{
				return date.AddMinutes(3.0);
			}

			// Token: 0x1700003B RID: 59
			// (get) Token: 0x060002D7 RID: 727 RVA: 0x0000EBA0 File Offset: 0x0000CDA0
			public static DateTime Hours
			{
				get
				{
					return DateTime.UtcNow.AddHours(3.0);
				}
			}

			// Token: 0x060002D8 RID: 728 RVA: 0x0000EBC3 File Offset: 0x0000CDC3
			public static DateTime HoursFrom(DateTime date)
			{
				return date.AddHours(3.0);
			}

			// Token: 0x1700003C RID: 60
			// (get) Token: 0x060002D9 RID: 729 RVA: 0x0000EBD8 File Offset: 0x0000CDD8
			public static DateTime Days
			{
				get
				{
					return DateTime.UtcNow.AddDays(3.0);
				}
			}

			// Token: 0x060002DA RID: 730 RVA: 0x0000EBFB File Offset: 0x0000CDFB
			public static DateTime DaysFrom(DateTime date)
			{
				return date.AddDays(3.0);
			}

			// Token: 0x1700003D RID: 61
			// (get) Token: 0x060002DB RID: 731 RVA: 0x0000EC10 File Offset: 0x0000CE10
			public static DateTime Weeks
			{
				get
				{
					return DateTime.UtcNow.AddDays(21.0);
				}
			}

			// Token: 0x060002DC RID: 732 RVA: 0x0000EC33 File Offset: 0x0000CE33
			public static DateTime WeeksFrom(DateTime date)
			{
				return date.AddDays(21.0);
			}

			// Token: 0x1700003E RID: 62
			// (get) Token: 0x060002DD RID: 733 RVA: 0x0000EC48 File Offset: 0x0000CE48
			public static DateTime Months
			{
				get
				{
					return DateTime.UtcNow.AddMonths(3);
				}
			}

			// Token: 0x060002DE RID: 734 RVA: 0x0000EC63 File Offset: 0x0000CE63
			public static DateTime MonthsFrom(DateTime date)
			{
				return date.AddMonths(3);
			}

			// Token: 0x1700003F RID: 63
			// (get) Token: 0x060002DF RID: 735 RVA: 0x0000EC70 File Offset: 0x0000CE70
			public static DateTime Years
			{
				get
				{
					return DateTime.UtcNow.AddYears(3);
				}
			}

			// Token: 0x060002E0 RID: 736 RVA: 0x0000EC8B File Offset: 0x0000CE8B
			public static DateTime YearsFrom(DateTime date)
			{
				return date.AddYears(3);
			}
		}

		// Token: 0x0200008C RID: 140
		public static class Four
		{
			// Token: 0x17000040 RID: 64
			// (get) Token: 0x060002E1 RID: 737 RVA: 0x0000EC98 File Offset: 0x0000CE98
			public static DateTime Seconds
			{
				get
				{
					return DateTime.UtcNow.AddSeconds(4.0);
				}
			}

			// Token: 0x060002E2 RID: 738 RVA: 0x0000ECBB File Offset: 0x0000CEBB
			public static DateTime SecondsFrom(DateTime date)
			{
				return date.AddSeconds(4.0);
			}

			// Token: 0x17000041 RID: 65
			// (get) Token: 0x060002E3 RID: 739 RVA: 0x0000ECD0 File Offset: 0x0000CED0
			public static DateTime Minutes
			{
				get
				{
					return DateTime.UtcNow.AddMinutes(4.0);
				}
			}

			// Token: 0x060002E4 RID: 740 RVA: 0x0000ECF3 File Offset: 0x0000CEF3
			public static DateTime MinutesFrom(DateTime date)
			{
				return date.AddMinutes(4.0);
			}

			// Token: 0x17000042 RID: 66
			// (get) Token: 0x060002E5 RID: 741 RVA: 0x0000ED08 File Offset: 0x0000CF08
			public static DateTime Hours
			{
				get
				{
					return DateTime.UtcNow.AddHours(4.0);
				}
			}

			// Token: 0x060002E6 RID: 742 RVA: 0x0000ED2B File Offset: 0x0000CF2B
			public static DateTime HoursFrom(DateTime date)
			{
				return date.AddHours(4.0);
			}

			// Token: 0x17000043 RID: 67
			// (get) Token: 0x060002E7 RID: 743 RVA: 0x0000ED40 File Offset: 0x0000CF40
			public static DateTime Days
			{
				get
				{
					return DateTime.UtcNow.AddDays(4.0);
				}
			}

			// Token: 0x060002E8 RID: 744 RVA: 0x0000ED63 File Offset: 0x0000CF63
			public static DateTime DaysFrom(DateTime date)
			{
				return date.AddDays(4.0);
			}

			// Token: 0x17000044 RID: 68
			// (get) Token: 0x060002E9 RID: 745 RVA: 0x0000ED78 File Offset: 0x0000CF78
			public static DateTime Weeks
			{
				get
				{
					return DateTime.UtcNow.AddDays(28.0);
				}
			}

			// Token: 0x060002EA RID: 746 RVA: 0x0000ED9B File Offset: 0x0000CF9B
			public static DateTime WeeksFrom(DateTime date)
			{
				return date.AddDays(28.0);
			}

			// Token: 0x17000045 RID: 69
			// (get) Token: 0x060002EB RID: 747 RVA: 0x0000EDB0 File Offset: 0x0000CFB0
			public static DateTime Months
			{
				get
				{
					return DateTime.UtcNow.AddMonths(4);
				}
			}

			// Token: 0x060002EC RID: 748 RVA: 0x0000EDCB File Offset: 0x0000CFCB
			public static DateTime MonthsFrom(DateTime date)
			{
				return date.AddMonths(4);
			}

			// Token: 0x17000046 RID: 70
			// (get) Token: 0x060002ED RID: 749 RVA: 0x0000EDD8 File Offset: 0x0000CFD8
			public static DateTime Years
			{
				get
				{
					return DateTime.UtcNow.AddYears(4);
				}
			}

			// Token: 0x060002EE RID: 750 RVA: 0x0000EDF3 File Offset: 0x0000CFF3
			public static DateTime YearsFrom(DateTime date)
			{
				return date.AddYears(4);
			}
		}

		// Token: 0x0200008D RID: 141
		public static class Five
		{
			// Token: 0x17000047 RID: 71
			// (get) Token: 0x060002EF RID: 751 RVA: 0x0000EE00 File Offset: 0x0000D000
			public static DateTime Seconds
			{
				get
				{
					return DateTime.UtcNow.AddSeconds(5.0);
				}
			}

			// Token: 0x060002F0 RID: 752 RVA: 0x0000EE23 File Offset: 0x0000D023
			public static DateTime SecondsFrom(DateTime date)
			{
				return date.AddSeconds(5.0);
			}

			// Token: 0x17000048 RID: 72
			// (get) Token: 0x060002F1 RID: 753 RVA: 0x0000EE38 File Offset: 0x0000D038
			public static DateTime Minutes
			{
				get
				{
					return DateTime.UtcNow.AddMinutes(5.0);
				}
			}

			// Token: 0x060002F2 RID: 754 RVA: 0x0000EE5B File Offset: 0x0000D05B
			public static DateTime MinutesFrom(DateTime date)
			{
				return date.AddMinutes(5.0);
			}

			// Token: 0x17000049 RID: 73
			// (get) Token: 0x060002F3 RID: 755 RVA: 0x0000EE70 File Offset: 0x0000D070
			public static DateTime Hours
			{
				get
				{
					return DateTime.UtcNow.AddHours(5.0);
				}
			}

			// Token: 0x060002F4 RID: 756 RVA: 0x0000EE93 File Offset: 0x0000D093
			public static DateTime HoursFrom(DateTime date)
			{
				return date.AddHours(5.0);
			}

			// Token: 0x1700004A RID: 74
			// (get) Token: 0x060002F5 RID: 757 RVA: 0x0000EEA8 File Offset: 0x0000D0A8
			public static DateTime Days
			{
				get
				{
					return DateTime.UtcNow.AddDays(5.0);
				}
			}

			// Token: 0x060002F6 RID: 758 RVA: 0x0000EECB File Offset: 0x0000D0CB
			public static DateTime DaysFrom(DateTime date)
			{
				return date.AddDays(5.0);
			}

			// Token: 0x1700004B RID: 75
			// (get) Token: 0x060002F7 RID: 759 RVA: 0x0000EEE0 File Offset: 0x0000D0E0
			public static DateTime Weeks
			{
				get
				{
					return DateTime.UtcNow.AddDays(35.0);
				}
			}

			// Token: 0x060002F8 RID: 760 RVA: 0x0000EF03 File Offset: 0x0000D103
			public static DateTime WeeksFrom(DateTime date)
			{
				return date.AddDays(35.0);
			}

			// Token: 0x1700004C RID: 76
			// (get) Token: 0x060002F9 RID: 761 RVA: 0x0000EF18 File Offset: 0x0000D118
			public static DateTime Months
			{
				get
				{
					return DateTime.UtcNow.AddMonths(5);
				}
			}

			// Token: 0x060002FA RID: 762 RVA: 0x0000EF33 File Offset: 0x0000D133
			public static DateTime MonthsFrom(DateTime date)
			{
				return date.AddMonths(5);
			}

			// Token: 0x1700004D RID: 77
			// (get) Token: 0x060002FB RID: 763 RVA: 0x0000EF40 File Offset: 0x0000D140
			public static DateTime Years
			{
				get
				{
					return DateTime.UtcNow.AddYears(5);
				}
			}

			// Token: 0x060002FC RID: 764 RVA: 0x0000EF5B File Offset: 0x0000D15B
			public static DateTime YearsFrom(DateTime date)
			{
				return date.AddYears(5);
			}
		}

		// Token: 0x0200008E RID: 142
		public static class Six
		{
			// Token: 0x1700004E RID: 78
			// (get) Token: 0x060002FD RID: 765 RVA: 0x0000EF68 File Offset: 0x0000D168
			public static DateTime Seconds
			{
				get
				{
					return DateTime.UtcNow.AddSeconds(6.0);
				}
			}

			// Token: 0x060002FE RID: 766 RVA: 0x0000EF8B File Offset: 0x0000D18B
			public static DateTime SecondsFrom(DateTime date)
			{
				return date.AddSeconds(6.0);
			}

			// Token: 0x1700004F RID: 79
			// (get) Token: 0x060002FF RID: 767 RVA: 0x0000EFA0 File Offset: 0x0000D1A0
			public static DateTime Minutes
			{
				get
				{
					return DateTime.UtcNow.AddMinutes(6.0);
				}
			}

			// Token: 0x06000300 RID: 768 RVA: 0x0000EFC3 File Offset: 0x0000D1C3
			public static DateTime MinutesFrom(DateTime date)
			{
				return date.AddMinutes(6.0);
			}

			// Token: 0x17000050 RID: 80
			// (get) Token: 0x06000301 RID: 769 RVA: 0x0000EFD8 File Offset: 0x0000D1D8
			public static DateTime Hours
			{
				get
				{
					return DateTime.UtcNow.AddHours(6.0);
				}
			}

			// Token: 0x06000302 RID: 770 RVA: 0x0000EFFB File Offset: 0x0000D1FB
			public static DateTime HoursFrom(DateTime date)
			{
				return date.AddHours(6.0);
			}

			// Token: 0x17000051 RID: 81
			// (get) Token: 0x06000303 RID: 771 RVA: 0x0000F010 File Offset: 0x0000D210
			public static DateTime Days
			{
				get
				{
					return DateTime.UtcNow.AddDays(6.0);
				}
			}

			// Token: 0x06000304 RID: 772 RVA: 0x0000F033 File Offset: 0x0000D233
			public static DateTime DaysFrom(DateTime date)
			{
				return date.AddDays(6.0);
			}

			// Token: 0x17000052 RID: 82
			// (get) Token: 0x06000305 RID: 773 RVA: 0x0000F048 File Offset: 0x0000D248
			public static DateTime Weeks
			{
				get
				{
					return DateTime.UtcNow.AddDays(42.0);
				}
			}

			// Token: 0x06000306 RID: 774 RVA: 0x0000F06B File Offset: 0x0000D26B
			public static DateTime WeeksFrom(DateTime date)
			{
				return date.AddDays(42.0);
			}

			// Token: 0x17000053 RID: 83
			// (get) Token: 0x06000307 RID: 775 RVA: 0x0000F080 File Offset: 0x0000D280
			public static DateTime Months
			{
				get
				{
					return DateTime.UtcNow.AddMonths(6);
				}
			}

			// Token: 0x06000308 RID: 776 RVA: 0x0000F09B File Offset: 0x0000D29B
			public static DateTime MonthsFrom(DateTime date)
			{
				return date.AddMonths(6);
			}

			// Token: 0x17000054 RID: 84
			// (get) Token: 0x06000309 RID: 777 RVA: 0x0000F0A8 File Offset: 0x0000D2A8
			public static DateTime Years
			{
				get
				{
					return DateTime.UtcNow.AddYears(6);
				}
			}

			// Token: 0x0600030A RID: 778 RVA: 0x0000F0C3 File Offset: 0x0000D2C3
			public static DateTime YearsFrom(DateTime date)
			{
				return date.AddYears(6);
			}
		}

		// Token: 0x0200008F RID: 143
		public static class Seven
		{
			// Token: 0x17000055 RID: 85
			// (get) Token: 0x0600030B RID: 779 RVA: 0x0000F0D0 File Offset: 0x0000D2D0
			public static DateTime Seconds
			{
				get
				{
					return DateTime.UtcNow.AddSeconds(7.0);
				}
			}

			// Token: 0x0600030C RID: 780 RVA: 0x0000F0F3 File Offset: 0x0000D2F3
			public static DateTime SecondsFrom(DateTime date)
			{
				return date.AddSeconds(7.0);
			}

			// Token: 0x17000056 RID: 86
			// (get) Token: 0x0600030D RID: 781 RVA: 0x0000F108 File Offset: 0x0000D308
			public static DateTime Minutes
			{
				get
				{
					return DateTime.UtcNow.AddMinutes(7.0);
				}
			}

			// Token: 0x0600030E RID: 782 RVA: 0x0000F12B File Offset: 0x0000D32B
			public static DateTime MinutesFrom(DateTime date)
			{
				return date.AddMinutes(7.0);
			}

			// Token: 0x17000057 RID: 87
			// (get) Token: 0x0600030F RID: 783 RVA: 0x0000F140 File Offset: 0x0000D340
			public static DateTime Hours
			{
				get
				{
					return DateTime.UtcNow.AddHours(7.0);
				}
			}

			// Token: 0x06000310 RID: 784 RVA: 0x0000F163 File Offset: 0x0000D363
			public static DateTime HoursFrom(DateTime date)
			{
				return date.AddHours(7.0);
			}

			// Token: 0x17000058 RID: 88
			// (get) Token: 0x06000311 RID: 785 RVA: 0x0000F178 File Offset: 0x0000D378
			public static DateTime Days
			{
				get
				{
					return DateTime.UtcNow.AddDays(7.0);
				}
			}

			// Token: 0x06000312 RID: 786 RVA: 0x0000F19B File Offset: 0x0000D39B
			public static DateTime DaysFrom(DateTime date)
			{
				return date.AddDays(7.0);
			}

			// Token: 0x17000059 RID: 89
			// (get) Token: 0x06000313 RID: 787 RVA: 0x0000F1B0 File Offset: 0x0000D3B0
			public static DateTime Weeks
			{
				get
				{
					return DateTime.UtcNow.AddDays(49.0);
				}
			}

			// Token: 0x06000314 RID: 788 RVA: 0x0000F1D3 File Offset: 0x0000D3D3
			public static DateTime WeeksFrom(DateTime date)
			{
				return date.AddDays(49.0);
			}

			// Token: 0x1700005A RID: 90
			// (get) Token: 0x06000315 RID: 789 RVA: 0x0000F1E8 File Offset: 0x0000D3E8
			public static DateTime Months
			{
				get
				{
					return DateTime.UtcNow.AddMonths(7);
				}
			}

			// Token: 0x06000316 RID: 790 RVA: 0x0000F203 File Offset: 0x0000D403
			public static DateTime MonthsFrom(DateTime date)
			{
				return date.AddMonths(7);
			}

			// Token: 0x1700005B RID: 91
			// (get) Token: 0x06000317 RID: 791 RVA: 0x0000F210 File Offset: 0x0000D410
			public static DateTime Years
			{
				get
				{
					return DateTime.UtcNow.AddYears(7);
				}
			}

			// Token: 0x06000318 RID: 792 RVA: 0x0000F22B File Offset: 0x0000D42B
			public static DateTime YearsFrom(DateTime date)
			{
				return date.AddYears(7);
			}
		}

		// Token: 0x02000090 RID: 144
		public static class Eight
		{
			// Token: 0x1700005C RID: 92
			// (get) Token: 0x06000319 RID: 793 RVA: 0x0000F238 File Offset: 0x0000D438
			public static DateTime Seconds
			{
				get
				{
					return DateTime.UtcNow.AddSeconds(8.0);
				}
			}

			// Token: 0x0600031A RID: 794 RVA: 0x0000F25B File Offset: 0x0000D45B
			public static DateTime SecondsFrom(DateTime date)
			{
				return date.AddSeconds(8.0);
			}

			// Token: 0x1700005D RID: 93
			// (get) Token: 0x0600031B RID: 795 RVA: 0x0000F270 File Offset: 0x0000D470
			public static DateTime Minutes
			{
				get
				{
					return DateTime.UtcNow.AddMinutes(8.0);
				}
			}

			// Token: 0x0600031C RID: 796 RVA: 0x0000F293 File Offset: 0x0000D493
			public static DateTime MinutesFrom(DateTime date)
			{
				return date.AddMinutes(8.0);
			}

			// Token: 0x1700005E RID: 94
			// (get) Token: 0x0600031D RID: 797 RVA: 0x0000F2A8 File Offset: 0x0000D4A8
			public static DateTime Hours
			{
				get
				{
					return DateTime.UtcNow.AddHours(8.0);
				}
			}

			// Token: 0x0600031E RID: 798 RVA: 0x0000F2CB File Offset: 0x0000D4CB
			public static DateTime HoursFrom(DateTime date)
			{
				return date.AddHours(8.0);
			}

			// Token: 0x1700005F RID: 95
			// (get) Token: 0x0600031F RID: 799 RVA: 0x0000F2E0 File Offset: 0x0000D4E0
			public static DateTime Days
			{
				get
				{
					return DateTime.UtcNow.AddDays(8.0);
				}
			}

			// Token: 0x06000320 RID: 800 RVA: 0x0000F303 File Offset: 0x0000D503
			public static DateTime DaysFrom(DateTime date)
			{
				return date.AddDays(8.0);
			}

			// Token: 0x17000060 RID: 96
			// (get) Token: 0x06000321 RID: 801 RVA: 0x0000F318 File Offset: 0x0000D518
			public static DateTime Weeks
			{
				get
				{
					return DateTime.UtcNow.AddDays(56.0);
				}
			}

			// Token: 0x06000322 RID: 802 RVA: 0x0000F33B File Offset: 0x0000D53B
			public static DateTime WeeksFrom(DateTime date)
			{
				return date.AddDays(56.0);
			}

			// Token: 0x17000061 RID: 97
			// (get) Token: 0x06000323 RID: 803 RVA: 0x0000F350 File Offset: 0x0000D550
			public static DateTime Months
			{
				get
				{
					return DateTime.UtcNow.AddMonths(8);
				}
			}

			// Token: 0x06000324 RID: 804 RVA: 0x0000F36B File Offset: 0x0000D56B
			public static DateTime MonthsFrom(DateTime date)
			{
				return date.AddMonths(8);
			}

			// Token: 0x17000062 RID: 98
			// (get) Token: 0x06000325 RID: 805 RVA: 0x0000F378 File Offset: 0x0000D578
			public static DateTime Years
			{
				get
				{
					return DateTime.UtcNow.AddYears(8);
				}
			}

			// Token: 0x06000326 RID: 806 RVA: 0x0000F393 File Offset: 0x0000D593
			public static DateTime YearsFrom(DateTime date)
			{
				return date.AddYears(8);
			}
		}

		// Token: 0x02000091 RID: 145
		public static class Nine
		{
			// Token: 0x17000063 RID: 99
			// (get) Token: 0x06000327 RID: 807 RVA: 0x0000F3A0 File Offset: 0x0000D5A0
			public static DateTime Seconds
			{
				get
				{
					return DateTime.UtcNow.AddSeconds(9.0);
				}
			}

			// Token: 0x06000328 RID: 808 RVA: 0x0000F3C3 File Offset: 0x0000D5C3
			public static DateTime SecondsFrom(DateTime date)
			{
				return date.AddSeconds(9.0);
			}

			// Token: 0x17000064 RID: 100
			// (get) Token: 0x06000329 RID: 809 RVA: 0x0000F3D8 File Offset: 0x0000D5D8
			public static DateTime Minutes
			{
				get
				{
					return DateTime.UtcNow.AddMinutes(9.0);
				}
			}

			// Token: 0x0600032A RID: 810 RVA: 0x0000F3FB File Offset: 0x0000D5FB
			public static DateTime MinutesFrom(DateTime date)
			{
				return date.AddMinutes(9.0);
			}

			// Token: 0x17000065 RID: 101
			// (get) Token: 0x0600032B RID: 811 RVA: 0x0000F410 File Offset: 0x0000D610
			public static DateTime Hours
			{
				get
				{
					return DateTime.UtcNow.AddHours(9.0);
				}
			}

			// Token: 0x0600032C RID: 812 RVA: 0x0000F433 File Offset: 0x0000D633
			public static DateTime HoursFrom(DateTime date)
			{
				return date.AddHours(9.0);
			}

			// Token: 0x17000066 RID: 102
			// (get) Token: 0x0600032D RID: 813 RVA: 0x0000F448 File Offset: 0x0000D648
			public static DateTime Days
			{
				get
				{
					return DateTime.UtcNow.AddDays(9.0);
				}
			}

			// Token: 0x0600032E RID: 814 RVA: 0x0000F46B File Offset: 0x0000D66B
			public static DateTime DaysFrom(DateTime date)
			{
				return date.AddDays(9.0);
			}

			// Token: 0x17000067 RID: 103
			// (get) Token: 0x0600032F RID: 815 RVA: 0x0000F480 File Offset: 0x0000D680
			public static DateTime Weeks
			{
				get
				{
					return DateTime.UtcNow.AddDays(63.0);
				}
			}

			// Token: 0x06000330 RID: 816 RVA: 0x0000F4A3 File Offset: 0x0000D6A3
			public static DateTime WeeksFrom(DateTime date)
			{
				return date.AddDays(63.0);
			}

			// Token: 0x17000068 RID: 104
			// (get) Token: 0x06000331 RID: 817 RVA: 0x0000F4B8 File Offset: 0x0000D6B8
			public static DateTime Months
			{
				get
				{
					return DateTime.UtcNow.AddMonths(9);
				}
			}

			// Token: 0x06000332 RID: 818 RVA: 0x0000F4D4 File Offset: 0x0000D6D4
			public static DateTime MonthsFrom(DateTime date)
			{
				return date.AddMonths(9);
			}

			// Token: 0x17000069 RID: 105
			// (get) Token: 0x06000333 RID: 819 RVA: 0x0000F4E0 File Offset: 0x0000D6E0
			public static DateTime Years
			{
				get
				{
					return DateTime.UtcNow.AddYears(9);
				}
			}

			// Token: 0x06000334 RID: 820 RVA: 0x0000F4FC File Offset: 0x0000D6FC
			public static DateTime YearsFrom(DateTime date)
			{
				return date.AddYears(9);
			}
		}

		// Token: 0x02000092 RID: 146
		public static class Ten
		{
			// Token: 0x1700006A RID: 106
			// (get) Token: 0x06000335 RID: 821 RVA: 0x0000F508 File Offset: 0x0000D708
			public static DateTime Seconds
			{
				get
				{
					return DateTime.UtcNow.AddSeconds(10.0);
				}
			}

			// Token: 0x06000336 RID: 822 RVA: 0x0000F52B File Offset: 0x0000D72B
			public static DateTime SecondsFrom(DateTime date)
			{
				return date.AddSeconds(10.0);
			}

			// Token: 0x1700006B RID: 107
			// (get) Token: 0x06000337 RID: 823 RVA: 0x0000F540 File Offset: 0x0000D740
			public static DateTime Minutes
			{
				get
				{
					return DateTime.UtcNow.AddMinutes(10.0);
				}
			}

			// Token: 0x06000338 RID: 824 RVA: 0x0000F563 File Offset: 0x0000D763
			public static DateTime MinutesFrom(DateTime date)
			{
				return date.AddMinutes(10.0);
			}

			// Token: 0x1700006C RID: 108
			// (get) Token: 0x06000339 RID: 825 RVA: 0x0000F578 File Offset: 0x0000D778
			public static DateTime Hours
			{
				get
				{
					return DateTime.UtcNow.AddHours(10.0);
				}
			}

			// Token: 0x0600033A RID: 826 RVA: 0x0000F59B File Offset: 0x0000D79B
			public static DateTime HoursFrom(DateTime date)
			{
				return date.AddHours(10.0);
			}

			// Token: 0x1700006D RID: 109
			// (get) Token: 0x0600033B RID: 827 RVA: 0x0000F5B0 File Offset: 0x0000D7B0
			public static DateTime Days
			{
				get
				{
					return DateTime.UtcNow.AddDays(10.0);
				}
			}

			// Token: 0x0600033C RID: 828 RVA: 0x0000F5D3 File Offset: 0x0000D7D3
			public static DateTime DaysFrom(DateTime date)
			{
				return date.AddDays(10.0);
			}

			// Token: 0x1700006E RID: 110
			// (get) Token: 0x0600033D RID: 829 RVA: 0x0000F5E8 File Offset: 0x0000D7E8
			public static DateTime Weeks
			{
				get
				{
					return DateTime.UtcNow.AddDays(70.0);
				}
			}

			// Token: 0x0600033E RID: 830 RVA: 0x0000F60B File Offset: 0x0000D80B
			public static DateTime WeeksFrom(DateTime date)
			{
				return date.AddDays(70.0);
			}

			// Token: 0x1700006F RID: 111
			// (get) Token: 0x0600033F RID: 831 RVA: 0x0000F620 File Offset: 0x0000D820
			public static DateTime Months
			{
				get
				{
					return DateTime.UtcNow.AddMonths(10);
				}
			}

			// Token: 0x06000340 RID: 832 RVA: 0x0000F63C File Offset: 0x0000D83C
			public static DateTime MonthsFrom(DateTime date)
			{
				return date.AddMonths(10);
			}

			// Token: 0x17000070 RID: 112
			// (get) Token: 0x06000341 RID: 833 RVA: 0x0000F648 File Offset: 0x0000D848
			public static DateTime Years
			{
				get
				{
					return DateTime.UtcNow.AddYears(10);
				}
			}

			// Token: 0x06000342 RID: 834 RVA: 0x0000F664 File Offset: 0x0000D864
			public static DateTime YearsFrom(DateTime date)
			{
				return date.AddYears(10);
			}
		}
	}
}
