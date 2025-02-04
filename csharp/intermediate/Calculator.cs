using System;

namespace CIntermediate
{
    public class Calculator : ICalculator
    {
        private object Result { get; set; }

        protected void SetResult(object value)
        {
            Result = value;
        }

        public int Add(int a, int b)
        {
            Result = a + b;
            return (int)Result;
        }

        public int Add(int a, int b, int c)
        {
            Result = a + b + c;
            return (int)Result;
        }

        public float Add(float a, float b)
        {
            Result = a + b;
            return (float)Result;
        }

        public virtual double GetResult()
        {
            if (Result is int)
                return Convert.ToDouble(Result);
            if (Result is float)
                return Convert.ToDouble(Result);
            if (Result is double)
                return (double)Result;
            throw new InvalidOperationException("Result is not a numeric type");
        }
    }
}
