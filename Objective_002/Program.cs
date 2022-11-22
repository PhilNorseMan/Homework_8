/*Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка*/

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

int RowLessSummDetection(int[,] matr)
{
    int[,] tempArray = new int[matr.GetLength(0), 2];
    int tempIndex = 0;
    int stringNumber = 1;

    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            tempArray[tempIndex, 0] += matr[i, j];
        }

        tempArray[tempIndex, 1] = stringNumber++;
        tempIndex++;
    }

    tempIndex = 0;
    int min = tempArray[tempIndex, 0];
    int minRow = tempArray[tempIndex,1];

    for (tempIndex = 0; tempIndex < tempArray.GetLength(0); tempIndex++)
    {
        if (tempArray[tempIndex, 0] < min)
        {
            min = tempArray[tempIndex, 0];
            minRow = tempArray[tempIndex,1];
        }
    }

    return minRow;
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

Console.WriteLine("Now the program will find the row with the smallest value of the sum of elements.");
Console.WriteLine();
Console.WriteLine($"The row with the smallest sum value is: {RowLessSummDetection(matrix)}.");

Console.WriteLine();