using System;
using System.Linq;
using System.Reflection;
using Humanizer.Configuration;

namespace Humanizer
{
	// Token: 0x02000008 RID: 8
	public static class EnumHumanizeExtensions
	{
		// Token: 0x06000040 RID: 64 RVA: 0x00002450 File Offset: 0x00000650
		public static string Humanize(this Enum input)
		{
			Type enumType = input.GetType();
			TypeInfo enumTypeInfo = enumType.GetTypeInfo();
			if (EnumHumanizeExtensions.IsBitFieldEnum(enumTypeInfo) && !Enum.IsDefined(enumType, input))
			{
				return (from Enum e in Enum.GetValues(enumType)
				where input.HasFlag(e)
				select e.Humanize()).Humanize<string>();
			}
			string caseName = input.ToString();
			FieldInfo memInfo = enumTypeInfo.GetDeclaredField(caseName);
			if (memInfo != null)
			{
				string customDescription = EnumHumanizeExtensions.GetCustomDescription(memInfo);
				if (customDescription != null)
				{
					return customDescription;
				}
			}
			return caseName.Humanize();
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002508 File Offset: 0x00000708
		private static bool IsBitFieldEnum(TypeInfo typeInfo)
		{
			return typeInfo.GetCustomAttribute(typeof(FlagsAttribute)) != null;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002520 File Offset: 0x00000720
		private static string GetCustomDescription(MemberInfo memberInfo)
		{
			foreach (Attribute attr in memberInfo.GetCustomAttributes(true))
			{
				Type attrType = attr.GetType();
				if (attrType.FullName == "System.ComponentModel.DataAnnotations.DisplayAttribute")
				{
					MethodInfo methodGetDescription = attrType.GetRuntimeMethod("GetDescription", new Type[0]);
					if (methodGetDescription != null)
					{
						object executedMethod = methodGetDescription.Invoke(attr, new object[0]);
						if (executedMethod != null)
						{
							return executedMethod.ToString();
						}
					}
					MethodInfo methodGetName = attrType.GetRuntimeMethod("GetName", new Type[0]);
					if (methodGetName != null)
					{
						object executedMethod2 = methodGetName.Invoke(attr, new object[0]);
						if (executedMethod2 != null)
						{
							return executedMethod2.ToString();
						}
					}
					return null;
				}
				PropertyInfo descriptionProperty = attrType.GetRuntimeProperties().Where(EnumHumanizeExtensions.StringTypedProperty).FirstOrDefault(Configurator.EnumDescriptionPropertyLocator);
				if (descriptionProperty != null)
				{
					return descriptionProperty.GetValue(attr, null).ToString();
				}
			}
			return null;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002630 File Offset: 0x00000830
		public static string Humanize(this Enum input, LetterCasing casing)
		{
			return input.Humanize().ApplyCase(casing);
		}

		// Token: 0x04000001 RID: 1
		private const string DisplayAttributeTypeName = "System.ComponentModel.DataAnnotations.DisplayAttribute";

		// Token: 0x04000002 RID: 2
		private const string DisplayAttributeGetDescriptionMethodName = "GetDescription";

		// Token: 0x04000003 RID: 3
		private const string DisplayAttributeGetNameMethodName = "GetName";

		// Token: 0x04000004 RID: 4
		private static readonly Func<PropertyInfo, bool> StringTypedProperty = (PropertyInfo p) => p.PropertyType == typeof(string);
	}
}
