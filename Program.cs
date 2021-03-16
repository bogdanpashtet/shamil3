using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace lab3._1
{
    internal static class Program
    {
        private struct Elem
        {
            public char Letter;
            public decimal Probability;
            //public float Probability;
            public string Code;
        }
        
        public static void Main(string[] args)
        {
            /*Console.WriteLine("Введите текст ");
            var strLetter = Console.ReadLine();*/
            /*var strLetter = "qqqqqqqqqwwwwweerrtty";
            decimal[] pr = {0.36m, 0.18m, 0.18m, 0.12m, 0.09m, 0.07m};*/
            
            var strLetter = "qqqqqqqqqwwwwweerrttyu";
            decimal[] pr = {0.4m, 0.2m, 0.1m, 0.1m, 0.1m, 0.05m, 0.05m};
            
            #region Fill & Sort

            var letterProbability = new Dictionary<char, float>();

            foreach (var t in strLetter) // find unique symbols
            {
                if (!letterProbability.ContainsKey(t)) letterProbability.Add(t, 1);
                else letterProbability[t] += 1;
            }

            foreach (var elem in letterProbability) // count probability
                letterProbability[elem.Key] /= strLetter.Length;

            var array = new Elem[letterProbability.Count + 1]; // new array of structures
            //array[0].Probability = -0.5f;
            array[0].Probability = 0.5m;
            for (var i = 1; i < letterProbability.Count+1; i++) // fill array of structures
            { 
                array[i].Letter = letterProbability.ElementAt(i-1).Key;
                array[i].Probability = pr[i-1];
                //array[i].Probability = letterProbability.ElementAt(i-1).Value;
            }
            
            Array.Sort(array, new Comparison<Elem>((b, a) => a.Probability.CompareTo(b.Probability))); // array sort
            
            #endregion
            
            Fano(array, 1, array.Length - 1);
            
            for(var j = 1; j < array.Length; j++)
                Console.WriteLine($"\'{array[j].Letter}\' - {array[j].Probability}  -  {array[j].Code}");
            
        }
        
        private static void Fano(Elem[] array, int start, int end)
        {
            /*float summ1 = 0;
            float summ = 0;
            float min = 0;*/
            decimal summ1 = 0;
            decimal summ = 0;
            decimal min = 1;
            decimal summ_of_pr = 0;
            var i = start;
            //var i = end;
            
            
            if (start < end)
            {
                for (var j = start; j <= end; j++)
                    summ += array[j].Probability;
                summ_of_pr = summ;
                do
                {
                    summ1 += array[i].Probability;
                    summ -= array[i].Probability;
                    i++;
                    if (Math.Abs(summ - summ1) < min) min = Math.Abs(summ - summ1);
                } while (summ >= summ1);

                i = start;
                summ1 = 0;
                do
                {
                    summ1 += array[i].Probability;
                    summ_of_pr -= array[i].Probability;
                    i++;
                } while (Math.Abs(summ_of_pr - summ1) != min);

                i--;

                for (var j = start; j <= end; j++)
                {
                    var code = j <= i ? array[j].Code += '0' : array[j].Code += '1';
                }

                Fano(array, start, i);
                Fano(array, i + 1, end);
            }
        }
    }
}
