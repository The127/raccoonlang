using System.Collections;
using System.Text;

namespace Raccoonlang.Utils;

public static class ObjectExtensions
{
    public static string AutoToString(this object? o, bool prettyPrint = true, bool encapsulate = true)
    {
        if (o == null) return "";
        var sb = new StringBuilder();

        if (encapsulate) sb.Append('{');

        var properties = o.GetType().GetProperties();
        for (var index = 0; index < properties.Length; index++)
        {
            var propertyInfo = properties[index];
            var propertyValue = propertyInfo.GetValue(o);
            sb.Append($"\"{propertyInfo.Name}\": ");
            if (propertyInfo.PropertyType.IsPrimitive())
            {
                if (propertyInfo.PropertyType.IsAssignableTo(typeof(string))) sb.Append('"');
                if (propertyInfo.PropertyType.IsAssignableTo(typeof(bool)))
                {
                    sb.Append((propertyValue?.ToString() ?? "null").ToLower());
                }
                else
                {
                    sb.Append(propertyValue?.ToString() ?? "null");
                }
                if (propertyInfo.PropertyType.IsAssignableTo(typeof(string))) sb.Append('"');
            }
            else if (propertyInfo.PropertyType.IsEnumerable())
            {
                var enumerable = (propertyValue as IEnumerable)!.Cast<object>();
                sb.Append('[').Append(string.Join(", ", enumerable.Select(x => x.AutoToString(false)))).Append(']');
            }
            else if (propertyInfo.PropertyType.IsEnum)
            {
                sb.Append($"\"{Enum.GetName(propertyInfo.PropertyType, propertyValue!)}\"");
            }
            else
            {
                sb.Append('{');
                sb.Append(propertyValue.AutoToString(false, false));
                sb.Append('}');
            }

            if (index + 1 < properties.Length) sb.Append(',');
        }


        if (encapsulate) sb.Append('}');
        var result = sb.ToString();
        if (prettyPrint)
        {
            var temp = Newtonsoft.Json.JsonConvert.DeserializeObject(result); 
            result = Newtonsoft.Json.JsonConvert.SerializeObject(temp, Newtonsoft.Json.Formatting.Indented);
        }
        return result;
    }

    public static bool IsEnumerable(this Type type)
    {
        return type.IsAssignableTo(typeof(IEnumerable));
    }

    public static bool IsPrimitive(this Type type)
    {
        return type.IsPrimitive || type.IsAssignableTo(typeof(string));
    }
}