namespace Roman.Calculator.Domain
{
    public abstract class RomanNumber
    {
        public int Value { get; protected set; }
        public abstract RomanNumber Eval();

        public static RomanNumber operator +(RomanNumber a, RomanNumber b) => new Number(a.Value + b.Value);
        public static RomanNumber operator -(RomanNumber a, RomanNumber b) => new Number(a.Value - b.Value);
        public static RomanNumber operator *(RomanNumber a, RomanNumber b) => new Number(a.Value * b.Value);
        public static RomanNumber operator /(RomanNumber a, RomanNumber b) => new Number(a.Value / b.Value);
    }

}
