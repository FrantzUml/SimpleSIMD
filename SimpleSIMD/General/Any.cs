﻿using System;
using System.Numerics;

namespace SimpleSimd
{
    public static partial class SimdOps<T>
    {
        public static bool Any<F1, F2>(in Span<T> span, F1 vPredicate, F2 predicate)

            where F1 : struct, IFunc<Vector<T>, bool>
            where F2 : struct, IFunc<T, bool>

        {
            int i;

            var vsSpan = AsVectors(span);

            for (i = 0; i < vsSpan.Length; i++)
            {
                if (vPredicate.Invoke(vsSpan[i]))
                {
                    return true;
                }
            }

            i *= Vector<T>.Count;

            for (; i < span.Length; i++)
            {
                if (predicate.Invoke(span[i]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
