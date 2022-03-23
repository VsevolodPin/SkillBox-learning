/// Задание 2
/// Наименьший элемент в последовательности.
/// Программа выводит на экран наименьшее число из последовательности пользователя. 
Console.WriteLine("Введите длину последовательности");
int N = int.Parse(Console.ReadLine());

int[] sec = new int[N];
int min = int.MaxValue;
for (int i = 0; i < N; i++)
{
    Console.WriteLine("Введите элемент последовательности");
    sec[i] = int.Parse(Console.ReadLine());

    // вариант 1
    if (sec[i] < min) min = sec[i];

    // вариант 2
    /*
    if (i == 0) 
        min = sec[i]; 
    else     
        if (sec[i]<min) 
            min = sec[i];
    */
}

/*
Предложенный вариант - долгий, если массив большой
min = int.MaxValue;
for (int i = 0; i < N; i++)
{
    if (sec[i] < min) min = sec[i];
}
*/

Console.WriteLine($"Минимальный элемент последовательности = {min}");
Console.ReadKey();