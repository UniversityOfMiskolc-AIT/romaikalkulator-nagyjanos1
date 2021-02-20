
namespace Roman.Calculator.Domain
{
    public class Number 
    { 
        public double Value { get; private set; }

        public Number(double value) 
        {
          Value = value;
        }

        public static Number operator +(Number a, Number b) => new Number(a.Value + b.Value);
        public static Number operator -(Number a, Number b) => new Number(a.Value - b.Value);
        public static Number operator *(Number a, Number b) => new Number(a.Value * b.Value);
        public static Number operator /(Number a, Number b) => new Number(a.Value / b.Value);
    }

}
