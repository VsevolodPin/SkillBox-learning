using System;

// Задание 1.
// Метод разделения строки на слова.
// Что нужно сделать:
// Пользователь вводит в консольном приложении длинное предложение. Каждое слово в этом предложении отделено одним пробелом. 
// Необходимо создать метод, который в качестве входного параметра принимает строковую переменную, а в качестве возвращаемого значения — массив слов. 
// После вызова данного метода программа вызывает второй метод, который выводит каждое слово в отдельной строке.   

namespace SkillBoxTask5
{
    internal class Task1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст или нажмите Enter для текста по умолчанию");
            string text = Console.ReadLine();
            if (text == "" || text == null) text = "Съешь ещё этих мягких французских булок да выпей чаю"; // чтобы не вводить что-то постоянно

            // Вызываем метод разделения на слова
            string[] words = SplitSomeText(text);
            PrintText(words);
            Console.ReadKey();
        }

        static string[] SplitSomeText(string txt)
        {
            return txt.Split(' ');
        }

        static void PrintText(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "\n");
            }
        }
    }
}
