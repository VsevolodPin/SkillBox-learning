/// Задание 1
/// Случайная матрица.
/// Программа выводит на экран случайно созданную матрицу предварительно заданного размера, а также сумму всех элементов в ней.

Console.WriteLine("Введите количество строк N");
int N = int.Parse(Console.ReadLine());

Console.WriteLine("Введите число столбцов M");
int M = int.Parse(Console.ReadLine());

Console.WriteLine("Введите минимально допустимое значение");
double min = int.Parse(Console.ReadLine());

Console.WriteLine("Введите максимально допустимое значение");
double max = int.Parse(Console.ReadLine());

Random rand = new Random();
double sum = 0;
// не совсем матрица, все-таки это массив массивов, а матрица будет double[,] matr = new double[N, M];
// иногда удобнее работать с массивом массивов (например, очень легко вырезать из них отдельные строки)
double[][] matr = new double[N][]; 
for (int i = 0; i < N; i++)
{
    matr[i] = new double[M];
    for (int j = 0; j < M; j++)
    {
        matr[i][j] = (-0.5 + rand.NextDouble()) * (max - min);
        // либо, если double числа не нужны, то можно matr[i][j] = rand.Next((int)min, (int)max+1);
        sum += matr[i][j];
        Console.Write($"{matr[i][j].ToString("f2")} ");
    }
    Console.Write("\n");
}
Console.WriteLine($"Сумма всех значений = {sum.ToString("f2")}");
Console.ReadKey();


