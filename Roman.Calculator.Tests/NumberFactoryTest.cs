using System.Reflection;
using System;
using Roman.Calculator.Domain;
using NUnit.Framework;

namespace Roman.Calculator.Tests
{
    public class NumberFactoryTest
    {
        [TestCase('I', 1)]
        [TestCase('V', 5)]
        [TestCase('X', 10)]
        [TestCase('L', 50)]
        [TestCase('C', 100)]
        [TestCase('D', 500)]
        [TestCase('M', 1000)]
        public void Create1000(string character, double result) 
        {
            var numberFactory = new NumberFactory();

            var number = numberFactory.CreateFlyWeight(character);

            Assert.Equal(result, number.Value);
        }
    }
}
