using System;
using System.Collections.Generic;
using System.Reflection;
using NAppUpdate.Framework.Common;
using NAppUpdate.Framework.Conditions;
using NAppUpdate.Framework.Tasks;

namespace NAppUpdate.Framework.Utils;

public static class Reflection
{
	internal static void FindTasksAndConditionsInAssembly(Assembly assembly, Dictionary<string, Type> updateTasks, Dictionary<string, Type> updateConditions)
	{
		Type[] types = assembly.GetTypes();
		foreach (Type type in types)
		{
			if (typeof(IUpdateTask).IsAssignableFrom(type))
			{
				updateTasks.Add(type.Name, type);
				UpdateTaskAliasAttribute[] array = (UpdateTaskAliasAttribute[])type.GetCustomAttributes(typeof(UpdateTaskAliasAttribute), inherit: false);
				UpdateTaskAliasAttribute[] array2 = array;
				foreach (UpdateTaskAliasAttribute updateTaskAliasAttribute in array2)
				{
					updateTasks.Add(updateTaskAliasAttribute.Alias, type);
				}
			}
			else if (typeof(IUpdateCondition).IsAssignableFrom(type))
			{
				updateConditions.Add(type.Name, type);
				UpdateConditionAliasAttribute[] array3 = (UpdateConditionAliasAttribute[])type.GetCustomAttributes(typeof(UpdateConditionAliasAttribute), inherit: false);
				UpdateConditionAliasAttribute[] array4 = array3;
				foreach (UpdateConditionAliasAttribute updateConditionAliasAttribute in array4)
				{
					updateConditions.Add(updateConditionAliasAttribute.Alias, type);
				}
			}
		}
	}

	internal static void SetNauAttributes(INauFieldsHolder fieldsHolder, Dictionary<string, string> attributes)
	{
		PropertyInfo[] properties = fieldsHolder.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
		string value = string.Empty;
		PropertyInfo[] array = properties;
		foreach (PropertyInfo propertyInfo in array)
		{
			object[] customAttributes = propertyInfo.GetCustomAttributes(typeof(NauFieldAttribute), inherit: false);
			if (customAttributes.Length != 1)
			{
				continue;
			}
			NauFieldAttribute nauFieldAttribute = (NauFieldAttribute)customAttributes[0];
			if (!attributes.TryGetValue(nauFieldAttribute.Alias, out value))
			{
				continue;
			}
			if (propertyInfo.PropertyType == typeof(string))
			{
				propertyInfo.SetValue(fieldsHolder, value, null);
				continue;
			}
			if (propertyInfo.PropertyType == typeof(DateTime))
			{
				DateTime result = DateTime.MaxValue;
				long result2 = long.MaxValue;
				if (DateTime.TryParse(value, out result))
				{
					propertyInfo.SetValue(fieldsHolder, result, null);
				}
				else if (long.TryParse(value, out result2))
				{
					try
					{
						result = DateTime.FromFileTime(result2);
						propertyInfo.SetValue(fieldsHolder, result, null);
					}
					catch
					{
					}
				}
				continue;
			}
			if (propertyInfo.PropertyType.IsEnum)
			{
				object obj2 = Enum.Parse(propertyInfo.PropertyType, value);
				if (obj2 != null)
				{
					propertyInfo.SetValue(fieldsHolder, obj2, null);
				}
				continue;
			}
			MethodInfo method = propertyInfo.PropertyType.GetMethod("Parse", new Type[1] { typeof(string) });
			if (method != null)
			{
				object obj3 = method.Invoke(null, new object[1] { value });
				if (obj3 != null)
				{
					propertyInfo.SetValue(fieldsHolder, obj3, null);
				}
			}
		}
	}

	internal static object GetNauAttribute(INauFieldsHolder fieldsHolder, string attributeName)
	{
		return fieldsHolder.GetType().GetProperty(attributeName, BindingFlags.Instance | BindingFlags.Public)?.GetValue(fieldsHolder, null);
	}
}
