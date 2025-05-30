using System;

class Program
{
    static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            string s = Console.ReadLine();
            char[] chars = s.ToCharArray();
            
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
            
            Console.WriteLine(new string(chars));
        }
    }
}