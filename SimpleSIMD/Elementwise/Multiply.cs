﻿using System;
using System.Numerics;

namespace SimpleSimd
{
    public static partial class Extensions
    {
        public static void Multiply<T>(this T[] source, T value, T[] result) where T : unmanaged
        {
            if (result.Length != source.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(result));
            }

            var vVal = new Vector<T>(value);
            int vLen = Vector<T>.Count;
            int i;

            for (i = 0; i <= source.Length - vLen; i += vLen)
            {
                Vector.Multiply(new Vector<T>(source, i), vVal).CopyTo(result, i);
            }

            for (; i < source.Length; i++)
            {
                result[i] = Operations<T>.Multiply(source[i], value);
            }
        }

        public static void Multiply<T>(this T[] source, T[] other, T[] result) where T : unmanaged
        {
            if (other.Length != source.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(other));
            }

            if (result.Length != source.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(result));
            }

            int vLen = Vector<T>.Count;
            int i;

            for (i = 0; i <= source.Length - vLen; i += vLen)
            {
                Vector.Multiply(new Vector<T>(source, i), new Vector<T>(other, i)).CopyTo(result, i);
            }

            for (; i < source.Length; i++)
            {
                result[i] = Operations<T>.Multiply(source[i], other[i]);
            }
        }

        public static T[] Multiply<T>(this T[] source, T value) where T : unmanaged
        {
            var result = new T[source.Length];

            source.Multiply(value, result);

            return result;
        }

        public static T[] Multiply<T>(this T[] source, T[] other) where T : unmanaged
        {
            var result = new T[source.Length];

            source.Multiply(other, result);

            return result;
        }
    }
}