using System;
using System.Collections.Generic;

// Задание 2.Телефонная книга

// Пользователю итеративно предлагается вводить в программу номера телефонов и ФИО их владельцев. 
// В процессе ввода информация размещается в Dictionary, где ключом является номер телефона, а значением — ФИО владельца.
// Таким образом, у одного владельца может быть несколько номеров телефонов. Признаком того, что пользователь закончил вводить номера телефонов, является ввод пустой строки. 
// Далее программа предлагает найти владельца по введенному номеру телефона. Пользователь вводит номер телефона и ему выдаётся ФИО владельца.
// Если владельца по такому номеру телефона не зарегистрировано, программа выводит на экран соответствующее сообщение.

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Формирование телефонного справочника
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();
            do
            {
                Console.WriteLine("Введите номер телефона, затем введите имя контакта.");
                string number = Console.ReadLine();
                if (String.IsNullOrEmpty(number)) break;
                string name = Console.ReadLine();
                if (string.IsNullOrEmpty(name)) break;
                phoneBook.Add(number, name);
            } while (true);

            Console.WriteLine("Вы закончили формировать телефонную книгу.");
            #endregion

            #region Поиск в телефонном справочнике
            do
            {
                Console.WriteLine("Найдем контакт по номеру, для этого введите номер телефона.");
                string name;
                string number = Console.ReadLine();
                if (String.IsNullOrEmpty(number)) break;
                if (phoneBook.TryGetValue(number, out name))
                    Console.WriteLine($"По номеру {number} найден контакт с именем {name}.");
                else
                    Console.WriteLine("Контакт не найден. Введите пустую строку, чтобы закончить поиск.");

            } while (true);
            #endregion
            // Конец работы программы
            Console.WriteLine("Конец выполнения программы.");
            Console.ReadLine();
        }
    }
}
