using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImperativeProgramming
{
    internal class Codeforces
    {
        static void Main()
        {
            int t = int.Parse(Console.ReadLine());  // Получение количества тестовых случаев

            for (int i = 0; i < t; i++)  // Прохождение всех тестовых случаев
            {
                string s = Console.ReadLine();  // Получение входной строки

                char[] chars = s.ToCharArray();  // Разбиение входной строки на массив: chars[0] - число, chars[1] - знак, chars[2] - число

                if (chars[0] < chars[2])  // Если первое число меньше второго, ставим '<'
                {
                    chars[1] = '<';
                }
                else if (chars[0] > chars[2])  // Если первое число больше второго, ставим '>'
                {
                    chars[1] = '>';
                }
                else  // Если числа равны ставим '='
                {
                    chars[1] = '=';
                }

                Console.WriteLine(new string(chars));  // Собираем строку заново. Выводим в консоль
            }
        }
    }
}
