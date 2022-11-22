/*Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2*/

void PrintMatrix(int[,] matr) // Принтер матрицы
{
    int count_x = matr.GetLength(0);
    int count_y = matr.GetLength(1);

    for (int i = 0; i < count_x; i++)
    {
        for (int j = 0; j < count_y; j++)
            Console.Write(matr[i, j] + "    ");
        Console.WriteLine();
    }
}

void FillMatrix(int[,] matr) // Рандомайзер
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            matr[i, j] = new Random().Next(0, 10);
        }
    }
}

int[,] StringsSortDescending(int[,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        int temp;
        for (int k = 0; k < matr.GetLength(1); k++)
        {
            for (int j = k + 1; j < matr.GetLength(1); j++)
            {
                if (matr[i,k] < matr[i,j])
                {
                    temp = matr[i,k];
                    matr[i,k] = matr[i,j];
                    matr[i,j] = temp;
                }
            }
        }
    }


    return matr;
}



Console.WriteLine();
Console.WriteLine("First program will generate random matrix, using your information."); //Стартовое сообщение
Console.WriteLine();

InputNumber1: // Ввод размера матрицы 1

Console.WriteLine("Please, set the first dimension size of matrix:");
int firstDimension = int.Parse(Console.ReadLine()!);

if (firstDimension < 1)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"ERROR: Incorrect input! (The dimension size of matrix cannot be less than 1)");
    Console.ResetColor();
    goto InputNumber1;
}

InputNumber2: // Ввод размера матрицы 2

Console.WriteLine("Please, set the second dimension size of matrix:");
int secondDimension = int.Parse(Console.ReadLine()!);

if (secondDimension < 1)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"ERROR: Incorrect input! (The dimension size of matrix cannot be less than 1)");
    Console.ResetColor();
    goto InputNumber2;
}

Console.WriteLine();

int[,] matrix = new int[firstDimension, secondDimension]; // Инициализация матрицы

Console.WriteLine("Generated matrix is:");

FillMatrix(matrix); // Заполнение матрицы рандомом
PrintMatrix(matrix); // Вывод матрицы
Console.WriteLine();

Console.WriteLine("Now program will sort matrix strings in descending order.");
Console.WriteLine("Sorted lines matrix is:");

PrintMatrix(StringsSortDescending(matrix)); // Вывод матрицы
Console.WriteLine();