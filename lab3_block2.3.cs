using System;

namespace lab3._2._3
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите код:");
            var start_code = Console.ReadLine();
            Console.Write("Введите ключ:");
            var key = Convert.ToInt32(Console.ReadLine(), 2);
            var end_code=(Convert.ToInt32(start_code,2) ^ key);
            start_code = Convert.ToString(end_code,2);
            Console.WriteLine("Закодированный код: {0}", start_code);
            end_code = Convert.ToInt32(start_code, 2) ^ key;
            Console.WriteLine("Декодированный код: {0}", Convert.ToString(end_code, 2));
        }

    }
}