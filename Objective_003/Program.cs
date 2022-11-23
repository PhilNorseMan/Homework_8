/*Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18*/

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
            matr[i, j] = new Random().Next(1, 10);
        }
    }
}

int[,] MatrixMultiplication(int[,] matrix_A, int[,] matrix_B)
{
    var matrix_C = new int[matrix_A.GetLength(0), matrix_B.GetLength(1)];

    for (int i = 0; i < matrix_A.GetLength(0); i++)
    {
        for (int j = 0; j < matrix_B.GetLength(1); j++)
        {
            matrix_C[i, j] = 0;

            for (int k = 0; k < matrix_A.GetLength(1); k++)
            {
                matrix_C[i, j] += matrix_A[i, k] * matrix_B[k, j];
            }
        }
    }

    return matrix_C;
}

Console.WriteLine();
Console.WriteLine("The program will multiply two matrices, that you specify."); //Стартовое сообщение
Console.WriteLine();

InputNumber1: // Ввод размера матрицы 1

Console.WriteLine("Please, set number of rows for first matrix:");
int firstRow = int.Parse(Console.ReadLine()!);

if (firstRow < 1)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"ERROR: Incorrect input! (The dimension size of matrix cannot be less than 1)");
    Console.ResetColor();
    goto InputNumber1;
}

InputNumber2: // Ввод размера матрицы 2

Console.Write("Please, set number of columns for first matrix, ");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("and number of rows for second matrix");
Console.WriteLine("(For matrix multiplication, the number of columns of the first matrix must be equal to the number of rows of the second matrix):");
Console.ResetColor();
int firstColumn = int.Parse(Console.ReadLine()!);
int secondRow = firstColumn;

if (firstColumn < 1)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"ERROR: Incorrect input! (The dimension size of matrix cannot be less than 1)");
    Console.ResetColor();
    goto InputNumber2;
}

Console.WriteLine("Please, set number of columns for second matrix:");
int secondColumn = int.Parse(Console.ReadLine()!);

if (secondColumn < 1)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"ERROR: Incorrect input! (The dimension size of matrix cannot be less than 1)");
    Console.ResetColor();
    goto InputNumber1;
}

Console.WriteLine();

int[,] firstMatrix = new int[firstRow, firstColumn]; // Инициализация матрицы1

Console.WriteLine("First generated matrix is:");

FillMatrix(firstMatrix); // Заполнение матрицы рандомом
PrintMatrix(firstMatrix); // Вывод матрицы1
Console.WriteLine();

int[,] secondMatrix = new int[secondRow, secondColumn]; // Инициализация матрицы2

Console.WriteLine("Second generated matrix is:");

FillMatrix(secondMatrix); // Заполнение матрицы рандомом
PrintMatrix(secondMatrix); // Вывод матрицы2
Console.WriteLine();

Console.WriteLine("The multiply of matrices is:");

PrintMatrix(MatrixMultiplication(firstMatrix, secondMatrix)); // Вывод матрицы сумм
Console.WriteLine();