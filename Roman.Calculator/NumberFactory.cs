using Roman.Calculator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Roman.Calculator
{
    public class NumberFactory
    {
        private readonly Dictionary<char, Type> romanNumbersDomain = new Dictionary<char, Type>
        {
          { 'i', typeof(CharOne) },
          { 'v', typeof(CharFive) },
          { 'x', typeof(CharTen) },
          { 'l', typeof(CharFifty) },
          { 'c', typeof(CharHundred) },
          { 'd', typeof(CharFiveHundred) },
          { 'm', typeof(CharThousand) }
        };
        
        public RomanNumber Create(char character)
        {
          if (romanNumbersDomain.Any(x => x.Key == character)) {
            return Activator.CreateInstance(romanNumbersDomain[character]) as Number;
          }

          return new Number(0);
        }

        public RomanNumber Create(char[] romanNumber)
        {
            var prevNumber = Create(romanNumber[0]);
            var sum = prevNumber;
            for (var i = 1; i < romanNumber.Length; i++)
            {
                var num = Create(romanNumber[i]);
                if (num == null)
                    continue;

                if (num.Value > prevNumber.Value)
                {
                    sum += ((num - prevNumber) - prevNumber);
                }
                else
                {
                    sum += num;
                }

                prevNumber = num;
            }

            return sum;
        }

        public RomanNumber Create(string romanNumber) 
        {
            if (string.IsNullOrWhiteSpace(romanNumber))
            {
                throw new ArgumentNullException(nameof(romanNumber));
            }

            var romanNumbers = romanNumber.ToLower().ToCharArray();            
            var prevNumber = Create(romanNumbers[0]);            
            var sum = prevNumber;
            for (var i = 1; i < romanNumbers.Length; i++) 
            {
                var num = Create(romanNumbers[i]);
                if (num == null)
                    continue;

                if (num.Value > prevNumber.Value)
                {
                    sum += ((num - prevNumber) - prevNumber);                    
                } 
                else 
                {
                    sum += num;
                }

                prevNumber = num;
            }

            return sum;
        }
    }

}
