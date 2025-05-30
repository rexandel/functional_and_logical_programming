using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        
        if (n == 1)
        {
            Console.WriteLine(2);
            return;
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
        
        Console.WriteLine(result);
    }
}