using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Виберіть тип масиву:");
        Console.WriteLine("1. Прямокутний масив");
        Console.WriteLine("2. Ступінчастий масив");
        int arrayType = int.Parse(Console.ReadLine());

        int[,] rectangularArray = null;
        int[][] jaggedArray = null;

        if (arrayType == 1)
        {
            rectangularArray = CreateRectangularArray();
        }
        else if (arrayType == 2)
        {
            jaggedArray = CreateJaggedArray();
        }
        else
        {
            Console.WriteLine("Невірний вибір типу масиву.");
            return;
        }

        if (arrayType == 1 && rectangularArray != null)
        {
            ProcessRectangularArray(rectangularArray);
        }
        else if (arrayType == 2 && jaggedArray != null)
        {
            ProcessJaggedArray(jaggedArray);
        }
    }

    static int[,] CreateRectangularArray()
    {
        Console.WriteLine("Введіть кількість рядків:");
        int rows = int.Parse(Console.ReadLine());
        Console.WriteLine("Введіть кількість стовпців:");
        int cols = int.Parse(Console.ReadLine());

        int[,] array = new int[rows, cols];
        FillArray(array);
        return array;
    }

    static int[][] CreateJaggedArray()
    {
        Console.WriteLine("Введіть кількість рядків:");
        int rows = int.Parse(Console.ReadLine());

        int[][] array = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            Console.WriteLine($"Введіть кількість елементів у рядку {i + 1}:");
            int cols = int.Parse(Console.ReadLine());
            array[i] = new int[cols];
            FillArray(array[i]);
        }
        return array;
    }

    static void FillArray(int[,] array)
    {
        Console.WriteLine("Виберіть спосіб заповнення масиву:");
        Console.WriteLine("1. Введення вручну");
        Console.WriteLine("2. Зчитування з файлу");
        Console.WriteLine("3. Генерація випадкових значень");
        int choice = int.Parse(Console.ReadLine());

        Random random = new Random();

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (choice == 1)
                {
                    Console.Write($"Введіть значення для елемента [{i},{j}]: ");
                    array[i, j] = int.Parse(Console.ReadLine());
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Введіть шлях до файлу:");
                    string filePath = Console.ReadLine();
                    string[] lines = File.ReadAllLines(filePath);
                    int index = 0;
                    foreach (var line in lines)
                    {
                        var values = line.Split(' ').Select(int.Parse).ToArray();
                        for (int k = 0; k < values.Length && index < array.Length; k++)
                        {
                            array[i, j] = values[k];
                            index++;
                        }
                    }
                }
                else if (choice == 3)
                {
                    array[i, j] = random.Next(1, 100);
                }
            }
        }
    }

    static void FillArray(int[] array)
    {
        Console.WriteLine("Виберіть спосіб заповнення масиву:");
        Console.WriteLine("1. Введення вручну");
        Console.WriteLine("2. Зчитування з файлу");
        Console.WriteLine("3. Генерація випадкових значень");
        int choice = int.Parse(Console.ReadLine());

        Random random = new Random();

        if (choice == 1)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"Введіть значення для елемента [{i}]: ");
                array[i] = int.Parse(Console.ReadLine());
            }
        }
        else if (choice == 2)
        {
            Console.WriteLine("Введіть шлях до файлу:");
            string filePath = Console.ReadLine();
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length && i < array.Length; i++)
            {
                array[i] = int.Parse(lines[i]);
            }
        }
        else if (choice == 3)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 100);
            }
        }
    }

    static void ProcessRectangularArray(int[,] array)
    {
        int sum = 0;
        int product = 1;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                sum += array[i, j];
                product *= array[i, j];
            }
        }
        Console.WriteLine($"Різниця між сумою та добутком елементів: {sum - product}");

        for (int i = 0; i < array.GetLength(0); i++)
        {
            int max = int.MinValue;
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] > max)
                {
                    max = array[i, j];
                }
            }

            Console.WriteLine($"Найбільший елемент у рядку {i + 1}: {max}");
            Console.WriteLine("Впорядкований рядок:");
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write($"{array[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    static void ProcessJaggedArray(int[][] array)
    {
        int sum = 0;
        int product = 1;
        foreach (var row in array)
        {
            foreach (var element in row)
            {
                sum += element;
                product *= element;
            }
        }
        Console.WriteLine($"Різниця між сумою та добутком елементів: {sum - product}");

        for (int i = 0; i < array.Length; i++)
        {
            int max = array[i].Max();
            Console.WriteLine($"Найбільший елемент у рядку {i + 1}: {max}");
            Console.WriteLine("Впорядкований рядок:");
            Array.Sort(array[i]);
            foreach (var element in array[i])
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();
        }
    }
}