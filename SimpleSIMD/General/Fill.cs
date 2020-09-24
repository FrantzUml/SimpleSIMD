﻿using System;
using System.Numerics;

namespace SimpleSimd
{
    public static partial class SimdOps<T>
    {
        public static void Fill(in Span<T> span, T value)
        {
            int i = 0;

            if (Vector.IsHardwareAccelerated)
            {
                var vValue = new Vector<T>(value);
                var vsSpan = AsVectors(span);

                for (; i < vsSpan.Length; i++)
                {
                    vsSpan[i] = vValue;
                }

                i *= Vector<T>.Count;
            }

            for (; i < span.Length; i++)
            {
                span[i] = value;
            }
        }


        public static void Fill<F1, F2>(in Span<T> span, F1 vFunc, F2 func)

            where F1 : struct, IFunc<Vector<T>>
            where F2 : struct, IFunc<T>

        {
            int i = 0;

            if (Vector.IsHardwareAccelerated)
            {
                var vsSpan = AsVectors(span);

                for (; i < vsSpan.Length; i++)
                {
                    vsSpan[i] = vFunc.Invoke();
                }

                i *= Vector<T>.Count;
            }

            for (; i < span.Length; i++)
            {
                span[i] = func.Invoke();
            }
        }
    }
}
