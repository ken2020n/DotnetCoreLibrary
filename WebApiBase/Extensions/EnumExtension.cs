using System;
using System.ComponentModel;

namespace WebApiBase.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value)
        {
            var name = Enum.GetName(value.GetType(), value);

            var field = value.GetType().GetField(name ?? throw new InvalidOperationException());

            var customAttribute = Attribute.GetCustomAttribute(field ?? throw new InvalidOperationException(),
                typeof(DescriptionAttribute)) as DescriptionAttribute;

            return customAttribute?.Description;
        }
    }
}