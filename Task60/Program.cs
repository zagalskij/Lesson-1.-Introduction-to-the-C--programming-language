﻿// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

/// <summary>
/// Метод который заполняет массив не повторяющимися числами друг за другом
/// </summary>
/// <param name="lists">количество листов</param>
/// <param name="rows">количество строк</param>
/// <param name="columns">количество столбцов</param>
/// <returns></returns>
int[,,] FillArray(int lists, int rows, int columns)
{
    Random random = new Random();
    int temp1 = random.Next(10, 100);
    int temp2 = 0;
    int[,,] array = new int[lists, rows, columns];
    for (int i = 0; i < lists; i++)
    {
        for (int j = 0; j < rows; j++)
        {
            for (int k = 0; k < columns; k++)
            {
                temp2 = random.Next(10, 13);
                while (temp1 == temp2)
                    temp2 = random.Next(10, 13);
                array[i, j, k] = temp2;
                temp1 = temp2;
            }
        }
    }
    return array;
}

/// <summary>
/// Метод который заполняет массив уникальными значениями
/// </summary>
/// <param name="lists">количество листов</param>
/// <param name="rows">количество строк</param>
/// <param name="columns">количество столбцов</param>
/// <returns></returns>
int[,,] FillArray2(int lists, int rows, int columns)
{
    if ((90 < lists * rows * columns))
        throw new Exception("The range of numbers is less than, the dimension of the array");
    Random random = new Random();

    int num = 0;
    int[,,] array = new int[lists, rows, columns];
    for (int i = 0; i < lists; i++)
    {
        for (int j = 0; j < rows; j++)
        {
            for (int k = 0; k < columns; k++)
            {
                while (true)
                {
                    num = random.Next(10, 100);
                    if (!Contains(array, num))
                        break;
                }
                array[i, j, k] = num;
            }
        }
    }
    return array;
}

/// <summary>
/// Проверка существует ли число в массиве
/// </summary>
/// <param name="array">массив</param>
/// <param name="value">значение на проверку, есть ли в массиве</param>
/// <returns></returns>
bool Contains(int[,,] array, int value)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                if (array[i, j, k] == value) return true;
            }
        }
    }
    return false;
}
/// <summary>
/// печать массива
/// </summary>
/// <param name="array">массив</param>
void PrintArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.Write(array[i, j, k] + "(" + i + "," + j + "," + k + ")\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine();
    }
}
Console.WriteLine("enter the number of lists");
int lists = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("enter the number of rows");
int rows = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("enter the number of columns");
int columns = Convert.ToInt32(Console.ReadLine());
int[,,] array = FillArray2(lists, rows, columns);
PrintArray(array);
