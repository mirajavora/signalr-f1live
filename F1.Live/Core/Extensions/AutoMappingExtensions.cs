using System;

namespace F1.Live.Core.Extensions
{
    public static class AutoMappingExtensions
    {
        public static bool CanBeCastTo<T>(this Type type)
        {
            return typeof (T).CanBeCastTo(type);
        }

        public static bool CanBeCastTo(this Type type1, Type type)
        {
            return type1.IsAssignableFrom(type);
        }
    }
}