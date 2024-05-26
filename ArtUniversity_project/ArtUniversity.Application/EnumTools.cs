using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ArtUniversity.Application
{
    public static class EnumTools
    {
        /// <summary>
        /// Get display name of enum
        /// </summary>
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()!
                            .GetName()!;
        }

        /// <summary>
        /// Get enum items by enum type
        /// </summary>
        public static List<(int Id, string Name)> GetEnumsDataByType<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
                       .Cast<T>()
                       .Select(x => ((int)(object)x, x.ToString()))
                       .ToList();
        }

        /// <summary>
        /// Get enum items by enum type as list
        /// </summary>
        public static List<T> GetEnumsListByType<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
                       .Cast<T>()
                       .ToList();
        }

        public static string GetDescription(this Enum enumValue)
        {
            object[] attr = enumValue.GetType().GetField(enumValue.ToString())!
                .GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attr.Length > 0)
                return ((DescriptionAttribute)attr[0]).Description;
            string result = enumValue.ToString();
            result = Regex.Replace(result, "([a-z])([A-Z])", "$1 $2");
            result = Regex.Replace(result, "([A-Za-z])([0-9])", "$1 $2");
            result = Regex.Replace(result, "([0-9])([A-Za-z])", "$1 $2");
            result = Regex.Replace(result, "(?<!^)(?<! )([A-Z][a-z])", " $1");
            return result;
        }

        public static List<string> GetDescriptionList(this Enum enumValue)
        {
            string result = enumValue.GetDescription();
            return result.Split(',').ToList();
        }
    }
}
