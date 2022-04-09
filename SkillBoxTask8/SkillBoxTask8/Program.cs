using System;
using System.Collections.Generic;

// Задание 1.Работа с листом
// Создайте лист целых чисел. 
// Заполните лист 100 случайными числами в диапазоне от 0 до 100. 
// Выведите коллекцию чисел на экран. 
// Удалите из листа числа, которые больше 25, но меньше 50. 
// Снова выведите числа на экран. 

namespace SkillBoxTask8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            List<int> arr = new List<int>();
            int
                n = 100,        // размер листа
                min = 0,        // минимальное число 
                max = 100;      // максимальное число
            Console.WriteLine("Введите количество случайных чисел n:");
            try { n = int.Parse(Console.ReadLine()); }
            catch { Console.WriteLine(n); };
            Console.WriteLine("Введите минимальное случайное число");
            try { min = int.Parse(Console.ReadLine()); }
            catch { Console.WriteLine(min); };
            Console.WriteLine("Введите максимальное случайное число");
            try { max = int.Parse(Console.ReadLine()); }
            catch { Console.WriteLine(max); };

            // Создаем лист
            Console.WriteLine("Полученный лист:");
            for (int i = 0; i < n; i++)
            {
                arr.Add(rand.Next(min, max + 1));
                Console.Write($"{arr[i], 4}, ");
            }

            // Редактируем лист
            Console.WriteLine();
            Console.WriteLine($"Удалим числа, меньше {(int)(min + (max - min) * 0.25), 4} и больше {(int)(min + (max - min) * 0.5), 4}");
            Console.WriteLine($"Полученный лист:");
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] < min + (max - min) * 0.25 || arr[i] > min + (max - min) * 0.5)
                {
                    arr.RemoveAt(i);
                    i--;
                }
                else
                {
                    Console.Write($"{arr[i], 4}, ");
                }
            }
            Console.ReadLine();
        }
    }
}
