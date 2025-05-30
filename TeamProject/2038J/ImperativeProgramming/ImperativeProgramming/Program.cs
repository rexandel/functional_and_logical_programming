using System;

class Program
{
    static void Main()
    {
        long w = 0;
        int t = int.Parse(Console.ReadLine());

        for (int i = 0; i < t; i++)
        {
            string[] input = Console.ReadLine().Split();
            string s = input[0];
            long x = long.Parse(input[1]);

            if (s == "B")
            {
                w -= x;
                Console.WriteLine(w < 0 ? "YES" : "NO");
                w = w > 0 ? w : 0;
            }
            else
            {
                w += x;
            }
        }
    }
}