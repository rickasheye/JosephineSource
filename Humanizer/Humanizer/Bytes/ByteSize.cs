using System;
using System.Globalization;

namespace Humanizer.Bytes
{
	// Token: 0x02000084 RID: 132
	public struct ByteSize : IComparable<ByteSize>, IEquatable<ByteSize>, IComparable
	{
		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600027E RID: 638 RVA: 0x0000E004 File Offset: 0x0000C204
		// (set) Token: 0x0600027F RID: 639 RVA: 0x0000E00C File Offset: 0x0000C20C
		public long Bits { get; private set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000280 RID: 640 RVA: 0x0000E015 File Offset: 0x0000C215
		// (set) Token: 0x06000281 RID: 641 RVA: 0x0000E01D File Offset: 0x0000C21D
		public double Bytes { get; private set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000282 RID: 642 RVA: 0x0000E026 File Offset: 0x0000C226
		// (set) Token: 0x06000283 RID: 643 RVA: 0x0000E02E File Offset: 0x0000C22E
		public double Kilobytes { get; private set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000284 RID: 644 RVA: 0x0000E037 File Offset: 0x0000C237
		// (set) Token: 0x06000285 RID: 645 RVA: 0x0000E03F File Offset: 0x0000C23F
		public double Megabytes { get; private set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000286 RID: 646 RVA: 0x0000E048 File Offset: 0x0000C248
		// (set) Token: 0x06000287 RID: 647 RVA: 0x0000E050 File Offset: 0x0000C250
		public double Gigabytes { get; private set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000288 RID: 648 RVA: 0x0000E059 File Offset: 0x0000C259
		// (set) Token: 0x06000289 RID: 649 RVA: 0x0000E061 File Offset: 0x0000C261
		public double Terabytes { get; private set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600028A RID: 650 RVA: 0x0000E06C File Offset: 0x0000C26C
		public string LargestWholeNumberSymbol
		{
			get
			{
				if (Math.Abs(this.Terabytes) >= 1.0)
				{
					return "TB";
				}
				if (Math.Abs(this.Gigabytes) >= 1.0)
				{
					return "GB";
				}
				if (Math.Abs(this.Megabytes) >= 1.0)
				{
					return "MB";
				}
				if (Math.Abs(this.Kilobytes) >= 1.0)
				{
					return "KB";
				}
				if (Math.Abs(this.Bytes) >= 1.0)
				{
					return "B";
				}
				return "b";
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600028B RID: 651 RVA: 0x0000E10C File Offset: 0x0000C30C
		public double LargestWholeNumberValue
		{
			get
			{
				if (Math.Abs(this.Terabytes) >= 1.0)
				{
					return this.Terabytes;
				}
				if (Math.Abs(this.Gigabytes) >= 1.0)
				{
					return this.Gigabytes;
				}
				if (Math.Abs(this.Megabytes) >= 1.0)
				{
					return this.Megabytes;
				}
				if (Math.Abs(this.Kilobytes) >= 1.0)
				{
					return this.Kilobytes;
				}
				if (Math.Abs(this.Bytes) >= 1.0)
				{
					return this.Bytes;
				}
				return (double)this.Bits;
			}
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0000E1B4 File Offset: 0x0000C3B4
		public ByteSize(double byteSize)
		{
			this = default(ByteSize);
			this.Bits = (long)Math.Ceiling(byteSize * 8.0);
			this.Bytes = byteSize;
			this.Kilobytes = byteSize / 1024.0;
			this.Megabytes = byteSize / 1048576.0;
			this.Gigabytes = byteSize / 1073741824.0;
			this.Terabytes = byteSize / 1099511627776.0;
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0000E22A File Offset: 0x0000C42A
		public static ByteSize FromBits(long value)
		{
			return new ByteSize((double)value / 8.0);
		}

		// Token: 0x0600028E RID: 654 RVA: 0x0000E23D File Offset: 0x0000C43D
		public static ByteSize FromBytes(double value)
		{
			return new ByteSize(value);
		}

		// Token: 0x0600028F RID: 655 RVA: 0x0000E245 File Offset: 0x0000C445
		public static ByteSize FromKilobytes(double value)
		{
			return new ByteSize(value * 1024.0);
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0000E257 File Offset: 0x0000C457
		public static ByteSize FromMegabytes(double value)
		{
			return new ByteSize(value * 1048576.0);
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0000E269 File Offset: 0x0000C469
		public static ByteSize FromGigabytes(double value)
		{
			return new ByteSize(value * 1073741824.0);
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0000E27B File Offset: 0x0000C47B
		public static ByteSize FromTerabytes(double value)
		{
			return new ByteSize(value * 1099511627776.0);
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0000E28D File Offset: 0x0000C48D
		public override string ToString()
		{
			return string.Format("{0} {1}", new object[]
			{
				this.LargestWholeNumberValue,
				this.LargestWholeNumberSymbol
			});
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0000E2B8 File Offset: 0x0000C4B8
		public string ToString(string format)
		{
			if (!format.Contains("#") && !format.Contains("0"))
			{
				format = "0.## " + format;
			}
			Func<string, bool> has = (string s) => format.IndexOf(s, StringComparison.CurrentCultureIgnoreCase) != -1;
			Func<double, string> output = (double n) => n.ToString(format);
			if (has("TB"))
			{
				return output(this.Terabytes);
			}
			if (has("GB"))
			{
				return output(this.Gigabytes);
			}
			if (has("MB"))
			{
				return output(this.Megabytes);
			}
			if (has("KB"))
			{
				return output(this.Kilobytes);
			}
			if (format.IndexOf("B", StringComparison.Ordinal) != -1)
			{
				return output(this.Bytes);
			}
			if (format.IndexOf("b", StringComparison.Ordinal) != -1)
			{
				return output((double)this.Bits);
			}
			string formattedLargeWholeNumberValue = this.LargestWholeNumberValue.ToString(format);
			formattedLargeWholeNumberValue = (formattedLargeWholeNumberValue.Equals(string.Empty) ? "0" : formattedLargeWholeNumberValue);
			return string.Format("{0} {1}", new object[]
			{
				formattedLargeWholeNumberValue,
				this.LargestWholeNumberSymbol
			});
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0000E41C File Offset: 0x0000C61C
		public override bool Equals(object value)
		{
			if (value == null)
			{
				return false;
			}
			if (value is ByteSize)
			{
				ByteSize other = (ByteSize)value;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0000E448 File Offset: 0x0000C648
		public bool Equals(ByteSize value)
		{
			return this.Bits == value.Bits;
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0000E45C File Offset: 0x0000C65C
		public override int GetHashCode()
		{
			return this.Bits.GetHashCode();
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0000E477 File Offset: 0x0000C677
		public int CompareTo(object obj)
		{
			if (obj == null)
			{
				return 1;
			}
			if (!(obj is ByteSize))
			{
				throw new ArgumentException("Object is not a ByteSize");
			}
			return this.CompareTo((ByteSize)obj);
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0000E4A0 File Offset: 0x0000C6A0
		public int CompareTo(ByteSize other)
		{
			return this.Bits.CompareTo(other.Bits);
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0000E4C2 File Offset: 0x0000C6C2
		public ByteSize Add(ByteSize bs)
		{
			return new ByteSize(this.Bytes + bs.Bytes);
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0000E4D7 File Offset: 0x0000C6D7
		public ByteSize AddBits(long value)
		{
			return this + ByteSize.FromBits(value);
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0000E4EA File Offset: 0x0000C6EA
		public ByteSize AddBytes(double value)
		{
			return this + ByteSize.FromBytes(value);
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0000E4FD File Offset: 0x0000C6FD
		public ByteSize AddKilobytes(double value)
		{
			return this + ByteSize.FromKilobytes(value);
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0000E510 File Offset: 0x0000C710
		public ByteSize AddMegabytes(double value)
		{
			return this + ByteSize.FromMegabytes(value);
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000E523 File Offset: 0x0000C723
		public ByteSize AddGigabytes(double value)
		{
			return this + ByteSize.FromGigabytes(value);
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0000E536 File Offset: 0x0000C736
		public ByteSize AddTerabytes(double value)
		{
			return this + ByteSize.FromTerabytes(value);
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0000E549 File Offset: 0x0000C749
		public ByteSize Subtract(ByteSize bs)
		{
			return new ByteSize(this.Bytes - bs.Bytes);
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0000E55E File Offset: 0x0000C75E
		public static ByteSize operator +(ByteSize b1, ByteSize b2)
		{
			return new ByteSize(b1.Bytes + b2.Bytes);
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0000E574 File Offset: 0x0000C774
		public static ByteSize operator ++(ByteSize b)
		{
			return new ByteSize(b.Bytes + 1.0);
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000E58C File Offset: 0x0000C78C
		public static ByteSize operator -(ByteSize b)
		{
			return new ByteSize(-b.Bytes);
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0000E59B File Offset: 0x0000C79B
		public static ByteSize operator --(ByteSize b)
		{
			return new ByteSize(b.Bytes - 1.0);
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0000E5B3 File Offset: 0x0000C7B3
		public static bool operator ==(ByteSize b1, ByteSize b2)
		{
			return b1.Bits == b2.Bits;
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0000E5C5 File Offset: 0x0000C7C5
		public static bool operator !=(ByteSize b1, ByteSize b2)
		{
			return b1.Bits != b2.Bits;
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000E5DA File Offset: 0x0000C7DA
		public static bool operator <(ByteSize b1, ByteSize b2)
		{
			return b1.Bits < b2.Bits;
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0000E5EC File Offset: 0x0000C7EC
		public static bool operator <=(ByteSize b1, ByteSize b2)
		{
			return b1.Bits <= b2.Bits;
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0000E601 File Offset: 0x0000C801
		public static bool operator >(ByteSize b1, ByteSize b2)
		{
			return b1.Bits > b2.Bits;
		}

		// Token: 0x060002AB RID: 683 RVA: 0x0000E613 File Offset: 0x0000C813
		public static bool operator >=(ByteSize b1, ByteSize b2)
		{
			return b1.Bits >= b2.Bits;
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0000E628 File Offset: 0x0000C828
		public static bool TryParse(string s, out ByteSize result)
		{
			if (string.IsNullOrWhiteSpace(s))
			{
				throw new ArgumentNullException("s", "String is null or whitespace");
			}
			result = default(ByteSize);
			s = s.TrimStart(new char[0]);
			bool found = false;
			char decSep = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
			int num;
			for (num = 0; num < s.Length; num++)
			{
				if (!char.IsDigit(s[num]) && s[num] != decSep)
				{
					found = true;
					break;
				}
			}
			if (!found)
			{
				return false;
			}
			int lastNumber = num;
			string s2 = s.Substring(0, lastNumber).Trim();
			string sizePart = s.Substring(lastNumber, s.Length - lastNumber).Trim();
			double number;
			if (!double.TryParse(s2, out number))
			{
				return false;
			}
			string a = sizePart.ToUpper();
			if (!(a == "B"))
			{
				if (!(a == "KB"))
				{
					if (!(a == "MB"))
					{
						if (!(a == "GB"))
						{
							if (a == "TB")
							{
								result = ByteSize.FromTerabytes(number);
							}
						}
						else
						{
							result = ByteSize.FromGigabytes(number);
						}
					}
					else
					{
						result = ByteSize.FromMegabytes(number);
					}
				}
				else
				{
					result = ByteSize.FromKilobytes(number);
				}
			}
			else if (sizePart == "b")
			{
				if (number % 1.0 != 0.0)
				{
					return false;
				}
				result = ByteSize.FromBits((long)number);
			}
			else
			{
				result = ByteSize.FromBytes(number);
			}
			return true;
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0000E7B0 File Offset: 0x0000C9B0
		public static ByteSize Parse(string s)
		{
			ByteSize result;
			if (ByteSize.TryParse(s, out result))
			{
				return result;
			}
			throw new FormatException("Value is not in the correct format");
		}

		// Token: 0x040000E4 RID: 228
		public static readonly ByteSize MinValue = ByteSize.FromBits(long.MinValue);

		// Token: 0x040000E5 RID: 229
		public static readonly ByteSize MaxValue = ByteSize.FromBits(long.MaxValue);

		// Token: 0x040000E6 RID: 230
		public const long BitsInByte = 8L;

		// Token: 0x040000E7 RID: 231
		public const long BytesInKilobyte = 1024L;

		// Token: 0x040000E8 RID: 232
		public const long BytesInMegabyte = 1048576L;

		// Token: 0x040000E9 RID: 233
		public const long BytesInGigabyte = 1073741824L;

		// Token: 0x040000EA RID: 234
		public const long BytesInTerabyte = 1099511627776L;

		// Token: 0x040000EB RID: 235
		public const string BitSymbol = "b";

		// Token: 0x040000EC RID: 236
		public const string ByteSymbol = "B";

		// Token: 0x040000ED RID: 237
		public const string KilobyteSymbol = "KB";

		// Token: 0x040000EE RID: 238
		public const string MegabyteSymbol = "MB";

		// Token: 0x040000EF RID: 239
		public const string GigabyteSymbol = "GB";

		// Token: 0x040000F0 RID: 240
		public const string TerabyteSymbol = "TB";
	}
}
