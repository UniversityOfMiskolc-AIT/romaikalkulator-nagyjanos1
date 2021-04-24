using Roman.Calculator.Domain;
using System;
using System.Linq.Expressions;

namespace Roman.Calculator
{

    public class RomanNumberBinaryExpression : RomanNumber
    {
        public RomanNumber Left { get; set; }
        public RomanNumber Right { get; set; }
        public Expression<Func<RomanNumber, RomanNumber, RomanNumber>> Operation { get; set; }
        public char? OperationChar { get; set; }

        public RomanNumberBinaryExpression(
            RomanNumber left, 
            RomanNumber right, 
            Expression<Func<RomanNumber, RomanNumber, RomanNumber>> operation,
            char? op)
        {
            Left = left;
            Right = right;
            Operation = operation;
            OperationChar = op;
        }

        public override RomanNumber Eval()
        {
            if (Right == null)
                return Left;

            var left = Left.Eval();
            var right = Right.Eval();

            if (OperationChar == '-' || OperationChar == '/')
            {
                return Operation.Compile().Invoke(right, left);
            }

            return Operation.Compile().Invoke(left, right);
        }
    }

}
