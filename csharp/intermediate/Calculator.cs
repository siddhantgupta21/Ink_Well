using System;

namespace CIntermediate
{
    public class Calculator : ICalculator
    {
        private double Result { get; set; }
        protected void SetResult(double value)
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
            return Result;
        }
    }
}
