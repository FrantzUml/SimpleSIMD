﻿using System;

namespace SimpleSimd
{
    [Serializable]
    public abstract class BaseOps<T> where T : unmanaged
    {
        public abstract T One { get; }
        public abstract T MinVal { get; }
        public abstract T MaxVal { get; }

        public abstract T Neg(T value);
        public abstract T FromInt(int value);

        public abstract T Add(T left, T right);
        public abstract T Sub(T left, T right);
        public abstract T Mul(T left, T right);
        public abstract T Div(T left, T right);
        public abstract T Mod(T left, T right);

        public abstract bool Equal(T left, T right);
        public abstract bool Less(T left, T right);
        public abstract bool Greater(T left, T right);
    }
}
