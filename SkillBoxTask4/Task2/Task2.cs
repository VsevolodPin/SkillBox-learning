/// Задание 2
/// Наименьший элемент в последовательности.
/// Программа выводит на экран наименьшее число из последовательности пользователя. 
/// 
Console.WriteLine("Введите длину последовательности");
int N = int.Parse(Console.ReadLine());

int[] sec = new int[N];
int min = int.MaxValue;
for (int i = 0; i < N; i++)
{
    Console.WriteLine("Введите элемент последовательности");
    sec[i] = int.Parse(Console.ReadLine());

    // сразу ищем минимальное число, не заводя в конце отдельный цикл
    if (sec[i] < min) min = sec[i];
}

Console.Write("Последовательность: ");
for (int i = 0; i < N; i++)
{
    Console.Write($"{sec[i]}, ");
}
Console.WriteLine();

Console.WriteLine($"Минимальный элемент последовательности: {min}");
Console.ReadKey();