﻿using System;
using System.Numerics;

namespace SimpleSimd
{
    public static partial class Extensions
    {
        public static T Aggregate<T>(this T[] source, T seed, Func<Vector<T>, Vector<T>, Vector<T>> vAccumulator, Func<T, T, T> accumulator) where T : unmanaged
        {
            var vRes = new Vector<T>(seed);
            T res = seed;

            int vLen = Vector<T>.Count;
            int i;

            for (i = 0; i <= source.Length - vLen; i += vLen)
            {
                vRes = vAccumulator(vRes, new Vector<T>(source[i]));
            }

            for (int j = 0; j < vLen; j++)
            {
                res = accumulator(res, vRes[j]);
            }

            for (; i < source.Length; i++)
            {
                res = accumulator(res, source[i]);
            }

            return res;
        }
    }
}