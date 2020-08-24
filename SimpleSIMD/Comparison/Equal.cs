﻿using System.Numerics;

namespace SimpleSimd.Comparison
{
    public static partial class ComparisonExt
    {
        public static bool Equal<T>(this T[] source, T value) where T : unmanaged
        {
            var vVal = new Vector<T>(value);
            int vLength = Vector<T>.Count;
            int i;

            for (i = 0; i < source.Length - vLength; i += vLength)
            {
                if (new Vector<T>(source, i) != vVal)
                {
                    return false;
                }
            }

            for (; i < source.Length; i++)
            {
                if (Ops<T>.Equal(source[i], value) == false)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Equal<T>(this T[] source, T[] other) where T : unmanaged
        {
            if (ReferenceEquals(source, other))
            {
                return true;
            }

            if (other.Length != source.Length)
            {
                return false;
            }

            int vLength = Vector<T>.Count;
            int i;

            for (i = 0; i < source.Length - vLength; i += vLength)
            {
                if (new Vector<T>(source, i) != new Vector<T>(other, i))
                {
                    return false;
                }
            }

            for (; i < source.Length; i++)
            {
                if (Ops<T>.Equal(source[i], other[i]) == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
