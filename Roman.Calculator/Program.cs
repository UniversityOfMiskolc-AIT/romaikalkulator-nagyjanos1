using System;
using Roman.Calculator.Domain;

namespace Roman.Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Római szám kalkulátor");
            Console.WriteLine("---------------------");              
            Console.WriteLine("Szóközökkel elválasztva írja be a kifejezéseket.");                
            Console.WriteLine("Példa: Roman.Calculator.exe X+X X*X");
            Console.WriteLine("Kifejezések eredményei: ");


            var processor = new ProcessRomanNumbers(new NumberFactory());
            var traversal = new RomanNumberExprTraversal();

            foreach (var arg in args)
            {
                var expressions = processor.GetExprList(arg);
                expressions.Reverse();
                var exprTree = processor.CreateRomanNumber(expressions.ToArray());
                traversal.Sort(exprTree);
                var romanNumber = exprTree.Eval();
                Console.WriteLine($"{arg} = {processor.GetRomanNumber(romanNumber)}");
            }

            Console.ReadKey();
        }
    }
}
