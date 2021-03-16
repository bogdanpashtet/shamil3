/*2.1. Написать программу для определения средней длины кодовых слов

2.2. Написать программу для определения является ли код префиксным.

2.3. Написать программу для кодирования и декодирования с помощью функции xor (исключающее или)*/

using System;

namespace lab3._2._1
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите количество кодовых слов: ");
            var array = new string[7] {"1010010", "10101", "1010", "001", "1011", "1", "11" };
            var array_of_probability = new double[7] {0.4, 0.2, 0.1, 0.1, 0.1, 0.05, 0.05 };
            //var array = new string[Convert.ToInt16(Console.ReadLine())];
            //var array_of_probability = new double[array.Length];
            double summ = 0;
            Console.WriteLine("Введите кодовые слово, а затем вероятность его появления: ");
            /*for (var i = 0; i < array.Length; ++i)
            {
                array[i] = Console.ReadLine();
                array_of_probability[i] = Convert.ToDouble(Console.ReadLine());
            }*/
            for (var i = 0; i < array.Length; ++i)
                summ += array[i].Length * array_of_probability[i];
            
            Console.WriteLine("Средняя длина введенных кодовых слов: " + summ);
        }
    }
}