using System;
using System.Collections.Generic;
using System.Linq;

namespace Roman.Calculator.Domain
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
          { 'm', typeof(CharThousand) }
        };

        public Number CreateFlyWeight(char character)
        {
          if (romanNumbersDomain.Any(x => x.Key == character)) {
            return Activator.CreateInstance(romanNumbersDomain[character]) as Number;
          }

          return null;
        }
    }

}
