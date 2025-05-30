using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImperativeProgrammingTests
{
    public static class ExpressionFixer
    {
        public static string FixExpression(string input)
        {
            char[] chars = input.ToCharArray();

            if (chars[0] < chars[2])
            {
                chars[1] = '<';
            }
            else if (chars[0] > chars[2])
            {
                chars[1] = '>';
            }
            else
            {
                chars[1] = '=';
            }

            return new string(chars);
        }
    }
}
