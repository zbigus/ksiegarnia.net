using System;
using System.Linq;

namespace BookStore.Logic.Extensions
{
    public static class AttributeExtension
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum value)
            where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }

        public static TAttribute GetAttribute<T, TAttribute>(this T value)
            where TAttribute : Attribute
            where T : new()
        {
            var type = value.GetType();
            return type.GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }
    }
}
