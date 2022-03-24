

/// ----------------------------------------- Задание 1 -----------------------------------------
Console.WriteLine("Задание 1");
Console.WriteLine("Введите произвольное целое число");
int value = int.Parse(Console.ReadLine());
if (value % 2 == 0)
    Console.WriteLine($"Число {value} четное");
else
    Console.WriteLine($"Число {value} нечетное");


/// ----------------------------------------- Задание 2 -----------------------------------------
Console.WriteLine("\n\nЗадание 2");
Console.WriteLine("Введите количество карт у вас на руках");
int n = int.Parse(Console.ReadLine());
int sum = 0;
for (int i = 0; i < n; i++)
{
    Console.WriteLine($"Введите карту №{i + 1}");
    string line = Console.ReadLine();
    switch (line)
    {
        case "J":
            sum += 2;
            break;
        case "Q":
            sum += 3;
            break;
        case "K":
            sum += 4;
            break;
        case "A":
            sum += 5;
            break;
        default:
            sum += int.Parse(line);
            break;
    }
}
Console.WriteLine($"Сумма ваших карт = {sum}");

/// ----------------------------------------- Задание 3 -----------------------------------------
Console.WriteLine("\n\nЗадание 3");
Console.WriteLine("Введите число, которое будет проверено на простоту.");
value = int.Parse(Console.ReadLine());

/// Поскольку простое число делится только на 1 и само на себя, в действительности нет 
/// смысла проверять все число от 2 до N-1, досаточно проверить числа до sqtr(N)+1

for (int i = 2; i < Math.Sqrt(value) + 1; i++)
{
    if (value % i == 0)
    {
        Console.WriteLine($"Число {value} непростое, как минимум оно делится на {i} без остатка.");
        break;
    }
    if (i == (int)Math.Sqrt(value))
    {
        Console.WriteLine($"Число {value} - простое.");
    }
}
Console.WriteLine("Для завершения работы программы нажмите любую кнопку.");
Console.ReadKey();