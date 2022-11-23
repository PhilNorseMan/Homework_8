/*Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07*/

int[,] GenerateSquareSpiralArray(int size1, int size2)  // генерация спиральной матрицы
{
    int value = 01;

    int[,] matrix = new int[size1, size2];

    for (int y = 0; y < size2; y++)  // заполнение внешнего контура по часовой
    {
        matrix[0, y] = value;
        value++;
    }
    for (int x = 1; x < size1; x++)
    {
        matrix[x, size2 - 1] = value;
        value++;
    }
    for (int y = size2 - 2; y >= 0; y--)
    {
        matrix[size1 - 1, y] = value;
        value++;
    }
    for (int x = size1 - 2; x > 0; x--)
    {
        matrix[x, 0] = value;
        value++;
    }

    int c = 1; // объявление позиции начала второго ряда
    int d = 1;

    while (value < size1 * size2)
    {
        while (matrix[c, d + 1] == 0)
        {
            matrix[c, d] = value;
            value++;
            d++;
        }

        while (matrix[c + 1, d] == 0)
        {
            matrix[c, d] = value;
            value++;
            c++;
        }

        while (matrix[c, d - 1] == 0)
        {
            matrix[c, d] = value;
            value++;
            d--;
        }

        while (matrix[c - 1, d] == 0)
        {
            matrix[c, d] = value;
            value++;
            c--;
        }
    }

    for (int x = 0; x < size1; x++)  // заполнение центра
    {
        for (int y = 0; y < size2; y++)
        {
            if (matrix[x, y] == 0)
            {
                matrix[x, y] = value;
            }
        }
    }

    return matrix;
}

void PrintMatrix(int[,] matr) // Принтер матрицы
{
    int count_x = matr.GetLength(0);
    int count_y = matr.GetLength(1);

    for (int i = 0; i < count_x; i++)
    {
        for (int j = 0; j < count_y; j++)
            if (matr[i, j] < 10)
            {
                Console.Write(matr[i, j] + "  ");
            }
            else
            {
                Console.Write(matr[i, j] + " ");
            }
        Console.WriteLine();
    }
}

Console.WriteLine();
Console.WriteLine("Program will generate spiral matrix, using your information."); //Стартовое сообщение
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

Console.WriteLine("Generated matrix is:");

PrintMatrix(GenerateSquareSpiralArray(firstDimension, secondDimension)); // Вывод матрицы
Console.WriteLine();