using System;
using System.Collections.Generic;

// Задание 3.Проверка повторов

// Пользователь вводит число. Число сохраняется в HashSet коллекцию. Если такое число уже присутствует в коллекции,
// то пользователю на экран выводится сообщение, что число уже вводилось ранее.
// Если числа нет, то появляется сообщение о том, что число успешно сохранено. 

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> hs = new HashSet<int>();
            do
            {
                try
                {
                    Console.WriteLine("Введите число:");
                    string strValue = Console.ReadLine();
                    if (String.IsNullOrEmpty(strValue)) break;
                    int intValue = int.Parse(strValue);
                    if (hs.Add(intValue))
                        Console.WriteLine($"Число {intValue} успешно добавлено!");
                    else
                        Console.WriteLine($"Число {intValue} уже присутствует в множестве.");
                }
                catch
                {
                    Console.WriteLine("Введено неправильное значение!");
                    Console.WriteLine("Введите пустую строку, чтобы завершить ввод чисел.");
                }
            } while (true);
            // Конец работы программы
            Console.WriteLine("Конец выполнения программы.");
            Console.ReadLine();
        }
    }
}
