using System.Collections;
using System.Text;

namespace Raccoonlang.Utils;

public static class ObjectExtensions
{
    public static string AutoToString(this object? o, bool b = true)
    {
        if (o == null) return "null";
        var sb = new StringBuilder();

        if (!b) sb.Append($"\"{o.GetType().Name}\": ");
        sb.Append('{');

        var properties = o.GetType().GetProperties();
        for (var index = 0; index < properties.Length; index++)
        {
            var propertyInfo = properties[index];
            var propertyValue = propertyInfo.GetValue(o);
            sb.Append($"\"{propertyInfo.Name}\": ");
            if (propertyInfo.PropertyType.IsPrimitive())
            {
                if (propertyInfo.PropertyType.IsAssignableTo(typeof(string))) sb.Append('"');
                sb.Append(propertyValue?.ToString() ?? "null");
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
                sb.Append(propertyValue.AutoToString(false));
                sb.Append('}');
            }

            if (index + 1 < properties.Length) sb.Append(',');
        }

        sb.Append('}');
        return sb.ToString();
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