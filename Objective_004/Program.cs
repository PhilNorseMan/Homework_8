/*Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)*/

int[,,] Creation3DArray(int axis_X, int axis_Y, int axis_Z)
{
    int[,,] result = new int[axis_X, axis_Y, axis_Z];

    var random = new Random();
    var values = Enumerable.Range(10, 90).ToList();

    for (int i = 0; i < axis_X; i++)
    {
        for (int j = 0; j < axis_Y; j++)
        {
            for (int k = 0; k < axis_Z; k++)
            {
                var temp = random.Next(values.Count);
                result[i, j, k] = values[temp];
                values.RemoveAt(temp);
            }
        }
    }

    return result;
}

void Print3DArray(int[,,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            for (int k = 0; k < arr.GetLength(2); k++)
            {
                Console.Write(arr[i,j,k]);
                if(i != arr.GetLength(0))
                    Console.Write($" ({i},{j},{k})");
                Console.WriteLine();
            }
        }
    }
}

Console.WriteLine();
Console.WriteLine("First program will generate random 3D array, using your information."); //Стартовое сообщение
Console.WriteLine();

InputNumber1: // Ввод размера массива 1

Console.WriteLine("Please, set the first dimension size of 3D array:");
int firstDimension = int.Parse(Console.ReadLine()!);

if (firstDimension < 1)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"ERROR: Incorrect input! (The dimension size of array cannot be less than 1)");
    Console.ResetColor();
    goto InputNumber1;
}

InputNumber2: // Ввод размера массива 2

Console.WriteLine("Please, set the second dimension size of 3D array:");
int secondDimension = int.Parse(Console.ReadLine()!);

if (secondDimension < 1)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"ERROR: Incorrect input! (The dimension size of array cannot be less than 1)");
    Console.ResetColor();
    goto InputNumber2;
}

InputNumber3: // Ввод размера массива 3

Console.WriteLine("Please, set the third dimension size of 3D array:");
int thirdDimension = int.Parse(Console.ReadLine()!);

if (thirdDimension < 1)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"ERROR: Incorrect input! (The dimension size of array cannot be less than 1)");
    Console.ResetColor();
    goto InputNumber3;
}

Console.WriteLine();

int[,,] array3D = Creation3DArray(firstDimension, secondDimension, thirdDimension); // Инициализация 3D массива

Console.WriteLine("Generated 3D array is:");

Print3DArray(array3D); // Вывод 3D массива
Console.WriteLine();