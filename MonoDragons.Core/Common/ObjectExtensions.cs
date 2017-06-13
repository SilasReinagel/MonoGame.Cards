using System;

namespace MonoDragons.Core.Common
{
    public static class ObjectExtensions
    {
        public static void If(this object obj, bool condition, Action action)
        {
            if (condition)
                action();
        }

        public static void If<T>(this T obj, Predicate<T> condition, Action action)
        {
            if (condition(obj))
                action();
        }

        public static void If<T>(this T obj, Predicate<T> condition, Action<T> action)
        {
            if (condition(obj))
                action(obj);
        }
    }
}
