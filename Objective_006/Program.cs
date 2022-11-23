/*Дополнительная задача, оставшаяся с вебинара 8.
Задача 61: Вывести первые N строк треугольника Паскаля. Сделать вывод в виде равнобедренного треугольника*/

// Сначала сделал вообще без использования массивов, потом решил, что, наверное, лучше через массивы. 

// генерация с использованием массива массивов

void PascalTriangle(int rows)
{
    int[][] result = new int[rows][];

    result[0] = new int[] { 1 };

    for (int i = 1; i < rows; i++)
    {
        result[i] = new int[i + 1];

        int remain = 0;

        for (int j = 0; j < i; j++)
        {
            result[i][j] = result[i - 1][j] + remain;
            remain = result[i - 1][j];
        }
        result[i][i] = remain;
    }

    for (int i = 0; i < result.Length; i++)
    {
        for (int c = 0; c <= (rows - i); c++)
        {
            Console.Write("  ");
        }

        for (int j = 0; j < result[i].Length; j++)
        {
            Console.Write("{0,-3} ", result[i][j]);
        }

        Console.WriteLine();
    }
}

// Ниже первый вариант - без использования массивов.

/*void PascalTriangle(int rows)
{
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j <= (rows - i); j++) 
        {
            Console.Write(" ");
        }
        for (int j = 0; j <= i; j++)
        {
            Console.Write(" "); 
            Console.Write(factorial(i) / (factorial(j) * factorial(i - j))); 
        }
        Console.WriteLine();
    }
}

int factorial(int value)
{
    int result = 1;
    for (int i = 1; i <= value; i++)
    {
        result *= i;
    }
    return result;
}
*/

Console.WriteLine();
Console.WriteLine("Program will generate N rows of Pascal result."); //Стартовое сообщение
Console.WriteLine();

InputNumber1: // Ввод строк

Console.WriteLine("Please, set N (count of rows of result):");
int rows = int.Parse(Console.ReadLine()!);

if (rows < 1)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"ERROR: Incorrect input! (Number of rows cannot be less than 1)");
    Console.ResetColor();
    goto InputNumber1;
}

Console.WriteLine();
Console.WriteLine($"Generated {rows} rows of Pascal Triangle is:");
Console.WriteLine();

PascalTriangle(rows);