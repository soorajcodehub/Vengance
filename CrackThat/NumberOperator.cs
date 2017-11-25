using System;
using System.Collections;
using System.Collections.Generic;

namespace CrackThat
{
    public class NumberOperator
    {
        public static List<string> AddOperators(string num, long target)
        {
            return _addOperators(target, 0, num, 0, 0, new List<string>(), "");
        }

        private static List<string> _addOperators(long target, int position, string num, long evaulationSoFar, long multiplication, List<string> results, string resultSoFar)
        {
            if (position == num.Length)
            {
                if (target == evaulationSoFar)
                {
                    results.Add(resultSoFar);
                }
            }

            for (int i = position; i < num.Length; i++)
            {
                if ( i != position && num[i] == '0')
                {
                    break;
                }

                long currentNumber = long.Parse(num.Substring(position, i + 1 - position));

                if (position == 0)
                {
                    _addOperators(target, position + 1, num, currentNumber, currentNumber, results, resultSoFar + currentNumber);
                }
                else 
                {
                    _addOperators(target, position + 1, num, currentNumber + evaulationSoFar, currentNumber, results, resultSoFar + " + " + currentNumber);
                    _addOperators(target, position + 1, num, evaulationSoFar - currentNumber, -currentNumber, results, resultSoFar + " - " + currentNumber);
                    _addOperators(target, position + 1, num, evaulationSoFar - multiplication + multiplication * currentNumber, multiplication * currentNumber, results, resultSoFar + " * " + currentNumber);
                }
            }


            return results;
        }
    }
}
