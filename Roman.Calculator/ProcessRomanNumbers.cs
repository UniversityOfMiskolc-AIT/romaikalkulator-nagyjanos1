using Roman.Calculator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Roman.Calculator
{
    public class ProcessRomanNumbers 
    {
        private static readonly Dictionary<char, Expression<Func<RomanNumber, RomanNumber, RomanNumber>>> operations = new()
        {
            { '+', (a, b) => a + b },
            { '-', (a, b) => a - b },
            { '*', (a, b) => a * b },
            { '/', (a, b) => a / b },
        };

        private readonly char[] _domainValues;
        private readonly NumberFactory _factory;

        public ProcessRomanNumbers(NumberFactory factory)
        {
            _factory = factory;
        }

        public ProcessRomanNumbers(char[] domainValues)
        {
            _domainValues = domainValues;
        }

        public string Normalize(string romanExpression)
        {
            romanExpression = romanExpression.Trim().ToLower();
            return romanExpression.Where(ch => _domainValues.Contains(ch)).ToString();
        }

        public List<string> GetExprList(string romanExpression)
        {
            var result = new List<string>();
            var sb = new StringBuilder();
            foreach (var ch in romanExpression)
            {
                if (!operations.ContainsKey(ch))
                {
                    sb.Append(ch);
                } 
                else
                {
                    result.Add(sb.ToString());
                    result.Add($"{ch}");
                    sb.Clear();
                }
            }

            result.Add(sb.ToString());

            return result;
        }

        public RomanNumberBinaryExpression CreateRomanNumber(string[] romanExpr) 
        {
            if (romanExpr.Length == 0)
            {
                return null;
            }

            if (romanExpr.Length == 1)
            {
                return new RomanNumberBinaryExpression(_factory.Create(romanExpr[0]), null, null, null);
            }

            var rightExpr = CreateRomanNumber(romanExpr.Skip(2).ToArray());
            return new RomanNumberBinaryExpression(_factory.Create(romanExpr[0]), rightExpr, operations[romanExpr[1].ToCharArray().First()], romanExpr[1].ToCharArray().First());
        }

        private char[] GetNumber(char ch, int times)
        {
            var chArray = new List<char>();
            for (var i = 0; i < times; i++)
            {
                chArray.Add(ch);
            }
            return chArray.ToArray();
        }

        private char[] GetNumber(char ch, char underFive, char five, char ten)
        {
            var @char = int.Parse($"{ch}");
            if (ch <= 0)
            {
                return Array.Empty<char>();
            }               

            if (@char <= 3) 
            {
                return GetNumber(underFive, @char);
            }
            if (@char == 4)
            {
                return new char[] { underFive, five };
            }
            if (@char == 5)
            {
                return new char[] { five };
            } 
            if (@char > 5 && @char < 9)
            {
                var p = new List<char>(five);
                p.AddRange(GetNumber(underFive, @char - 5));
                return p.ToArray();
            }
            if (@char == 9)
            {
                return new char[] { underFive, ten };
            }

            throw new Exception("Impossible");
        }

        public string GetRomanNumber(RomanNumber romanNumber)
        {
            var stringBuilder = new StringBuilder();
            var value = $"{romanNumber.Value}";
            var length = value.Length;
            foreach (var num in value)
            {
                switch (length)
                {
                    case 4:                        
                        stringBuilder.Append(GetNumber('m', int.Parse($"{num}")));
                        break;
                    case 3:
                        stringBuilder.Append(GetNumber(num, 'c', 'd', 'm'));
                        break;
                    case 2:
                        stringBuilder.Append(GetNumber(num, 'x', 'l', 'c'));
                        break;
                    case 1:
                        stringBuilder.Append(GetNumber(num, 'i', 'v', 'x'));
                        break;
                    default:
                        break;
                }

                length--;
            }

            return stringBuilder.ToString().ToUpper();
        }
    }

}
