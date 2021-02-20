
namespace Roman.Calculator.Domain
{
    public class Number 
    { 
        public int Value { get; private set; }

        public Number(int value) 
        {
          Value = value;
        }

        public static Number operator +(Number a, Number b) => new Number(a.Value + b.Value);
        public static Number operator -(Number a, Number b) => new Number(a.Value - b.Value);
        public static Number operator *(Number a, Number b) => new Number(a.Value * b.Value);
        public static Number operator /(Number a, Number b) => new Number(a.Value % b.Value);
    }

}
