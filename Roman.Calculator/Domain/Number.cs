
namespace Roman.Calculator.Domain
{
    public class Number : RomanNumber
    {
        public Number(int value)
        {
            Value = value;
        }

        public override RomanNumber Eval()
        {
            return this;
        }
    }
}
