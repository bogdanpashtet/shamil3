/*2.2. Написать программу для определения является ли код префиксным.*/

using System;

namespace lab3._2._2
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Введите количество символов, которое необходимо закодировать: ");
            var array = new string[Convert.ToInt16(Console.ReadLine())];
            Console.WriteLine("Введите коды, которыми зашифрован данный алфавит: ");
            for (var i = 0; i < array.Length; ++i)
                array[i] = Console.ReadLine();

            var flag = true;
            for(int i = 0; (i < array.Length)&&(flag); i++)
            {
                for (int j = i+1; (j < array.Length) && (flag); j++)
                    if (array[j].StartsWith(array[i])||array[i].StartsWith(array[j])) flag = false;
            }
            
            Console.WriteLine(!flag ? "Не является префиксным." : "Является префиксным.");
        }
    }
}