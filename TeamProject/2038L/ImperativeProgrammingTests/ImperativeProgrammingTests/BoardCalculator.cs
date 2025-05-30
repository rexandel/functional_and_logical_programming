using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImperativeProgrammingTests
{
    public static class BoardCalculator
    {
        public static int CalculateBoards(int n)
        {
            if (n == 1)
            {
                return 2;
            }

            int result = n / 2;
            int remaining18 = n - (n / 2);

            if (n % 2 != 0)
            {
                result++;
                remaining18 -= 2;
            }

            if (remaining18 > 0)
            {
                result += remaining18 / 3;
                remaining18 %= 3;
            }

            result += (remaining18 + n + 1) / 2;

            return result;
        }
    }
}
