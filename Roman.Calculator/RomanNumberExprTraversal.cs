namespace Roman.Calculator
{
    public class RomanNumberExprTraversal
    {
        public void Sort(RomanNumberBinaryExpression expr)
        {
            if (expr.Right == null)
            {
                return;
            }                

            if ((((RomanNumberBinaryExpression)expr.Right).OperationChar == '+' ||
                ((RomanNumberBinaryExpression)expr.Right).OperationChar == '-') &&
                (expr.OperationChar == '*' || expr.OperationChar == '/'))
            {
                expr.Left = expr.Operation.Compile().Invoke(expr.Left, ((RomanNumberBinaryExpression)expr.Right).Left);
                expr.Operation = ((RomanNumberBinaryExpression)expr.Right).Operation;
                expr.OperationChar = ((RomanNumberBinaryExpression)expr.Right).OperationChar;
                expr.Right = ((RomanNumberBinaryExpression)expr.Right).Right;

                Sort((RomanNumberBinaryExpression)expr.Right);
            }
            else if ((expr.OperationChar == '*' || expr.OperationChar == '/') && ((RomanNumberBinaryExpression)expr.Right).Right == null)
            {
                expr.Left = expr.Operation.Compile().Invoke(expr.Left, ((RomanNumberBinaryExpression)expr.Right).Left);
                expr.Operation = null;
                expr.OperationChar = null;
                expr.Right = null;
            }
            else
            {
                Sort((RomanNumberBinaryExpression)expr.Right);
            }
        }

    }

}
