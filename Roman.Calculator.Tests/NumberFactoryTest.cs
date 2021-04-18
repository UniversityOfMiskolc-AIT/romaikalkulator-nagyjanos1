using NUnit.Framework;
using Roman.Calculator.Domain;

namespace Roman.Calculator.Tests
{
    public class NumberFactoryTest
    {
        [TestCase('i', 1)]
        [TestCase('v', 5)]
        [TestCase('x', 10)]
        [TestCase('l', 50)]
        [TestCase('c', 100)]
        [TestCase('d', 500)]
        [TestCase('m', 1000)]
        public void CreateNumbers(char character, int result) 
        {
            var numberFactory = new NumberFactory();

            var number = numberFactory.Create(character);

            Assert.IsNotNull(number);
            Assert.AreEqual(result, number.Value);
        }

        [TestCase("IX", 9)]
        [TestCase("XIX", 19)]
        [TestCase("XXIII", 23)]
        [TestCase("XL", 40)]
        [TestCase("LX", 60)]
        [TestCase("XLIX", 49)]
        [TestCase("XCIX", 99)]
        [TestCase("CCCXCIX", 399)]
        [TestCase("DXLIX", 549)]
        [TestCase("MMXX", 2020)]
        [TestCase("MCMXCVIII", 1998)]
        public void Create1000(string romanNumber, int result) 
        {
            var numberFactory = new NumberFactory();

            var number = numberFactory.Create(romanNumber);

            Assert.IsNotNull(number);
            Assert.AreEqual(result, number.Value);
        }

        [TestCase("X+X", 20)]
        [TestCase("X+X+X", 30)]
        [TestCase("X+X-X", 10)]
        [TestCase("X*X*X", 1000)]
        [TestCase("X/X", 1)]
        [TestCase("X*X/X", 10)]
        [TestCase("X*X+X", 110)]
        [TestCase("X*X-X", 90)]
        [TestCase("X*X+X*X", 200)]
        [TestCase("X*X-X*V", 10 * 10 - 10 * 5)]
        [TestCase("X*X+X/X", 10 * 10 + 10 / 10)]
        [TestCase("X*X+X-X", 10 * 10 + 10 - 10)]
        [TestCase("X+X*X", 10 + 10 * 10)]
        [TestCase("X-V+X*V", 10 - 5 + 10 * 5)]
        [TestCase("X*X-X*V-X*I", 10 * 10 - 10 * 5 - 10 * 1)]
        public void TestProcess(string romanNumer, int result)
        {
            var processor = new ProcessRomanNumbers(new NumberFactory());

            var expressions = processor.GetExprList(romanNumer);
            expressions.Reverse();
            var exprTree = processor.CreateRomanNumber(expressions.ToArray());
            var traversal = new RomanNumberExprTraversal();

            traversal.Sort(exprTree);

            Assert.IsNotNull(exprTree);
            Assert.AreEqual(expected: result, exprTree.Eval().Value);
        }

        [TestCase("X+X", "XX")]
        [TestCase("X+X+X", "XXX")]
        [TestCase("X+X-X", "X")]
        [TestCase("XX+XXX", "L")]
        [TestCase("XX+XX", "XL")]
        public void TestEvaulation(string romanNumer, string result)
        {
            var processor = new ProcessRomanNumbers(new NumberFactory());

            var expressions = processor.GetExprList(romanNumer);
            expressions.Reverse();
            var exprTree = processor.CreateRomanNumber(expressions.ToArray());
            var evalated = exprTree.Eval();
            var processedNumber = processor.GetRomanNumber(evalated);

            Assert.AreEqual(result, processedNumber);
        }
    }
}
