﻿/// Задание 3.
/// Игра «Угадай число».
/// Программа опрашивает пользователя и просит вводить числа. 
/// Реализована возможность выхода из бесконечного цикла, когда пользователь устал.
/// Демонстрируется загаданный результат.  

Console.WriteLine("Введите максимальное целое число (минимальное всегда 0)");
int max = int.Parse(Console.ReadLine());
int value = new Random().Next(max + 1);

int turns = 1;
Console.WriteLine("Число выбрано, игра начинается. Чтобы прекратить ее, введите -1 вместо очередной гипотезы.");
do
{
    Console.WriteLine("Угадайте выбранное число. Введите свою догадку:");

    int hyp_val = int.Parse(Console.ReadLine());
    if (hyp_val < 0)
    {
        Console.WriteLine($"Очень жаль, что вы сдаетесь. Загадано было число {value}");
        break;
    }
    if (hyp_val == value)
    {
        Console.WriteLine($"Вы отгадали число - победа ваша. \nХодов потрачено: {turns}. \nЗагаданное число: {value}.");
        break;
    }
    if (hyp_val < value)
    {
        Console.WriteLine("Загаданное число больше, попробуйте еще раз.");
    }
    if (hyp_val > value)
    {
        Console.WriteLine("Загаданное число меньше, попробуйте еще раз.");
    }
    turns++;
} while (true);
Console.ReadKey();