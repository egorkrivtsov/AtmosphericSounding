using System;

namespace WpfUI.Common
{
    public static class ArrayExtension
    {
        public static T[] Add<T>(this T[] source, T element)
        {
            Array.Resize(ref source, source.Length + 1);
            source[source.Length - 1] = element;
            return source;
        }

    }
}
