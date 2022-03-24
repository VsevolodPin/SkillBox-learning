using System;

// Задание 2.
// Перестановка слов в предложении.
// Что нужно сделать...
// Пользователь вводит в программе длинное предложение. Каждое слово раздельно одним пробелом. После ввода пользователь нажимает клавишу Enter. Необходимо создать два метода:
// первый метод разделяет слова в предложении;
// второй метод меняет эти слова местами (в обратной последовательности). 

namespace SkillBoxTask5
{
    internal class Task2
    {
        static void Main()
        {
            Console.WriteLine("Введите текст или нажмите Enter для текста по умолчанию");
            string text = Console.ReadLine();
            if (text == "" || text == null) text = "Съешь ещё этих мягких французских булок да выпей чаю"; // чтобы не вводить что-то постоянно

            // Вызываем метод написания слов задом-наперед
            ReverseWords(text);
            Console.ReadKey();
        }

        static void ReverseWords(string txt)
        {
            string[] words = SplitSomeText(txt);
            for (int i = 0; i < words.Length / 2; i++)
            {
                string buf = words[i];
                words[i] = words[words.Length - 1 - i];
                words[words.Length - 1 - i] = buf;
            }
            PrintText(words);
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
