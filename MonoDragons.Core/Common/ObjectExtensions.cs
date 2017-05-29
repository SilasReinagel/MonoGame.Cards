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
    }
}
