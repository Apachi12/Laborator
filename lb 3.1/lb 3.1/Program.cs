using System;
using System.IO;

class Program
{
    static void Main()
    {
        GenerateRandomArrayToFile("input.txt");

        int[] array = ReadArrayFromFile("input.txt");

        int positiveSum = 0;
        int negativeSum = 0;
        foreach (int num in array)
        {
            if (num > 0)
                positiveSum += num;
            else if (num < 0)
                negativeSum += num;
        }

        Console.WriteLine("Початковий масив:");
        PrintArray(array);

        Console.WriteLine($"Сума додатніх елементів: {positiveSum}");
        Console.WriteLine($"Сума від'ємних елементів: {negativeSum}");

        if (Math.Abs(positiveSum) > Math.Abs(negativeSum))
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                    array[i] *= -2;
            }
        }

        Console.WriteLine("\nОстаточний масив після можливої корекції:");
        PrintArray(array);
    }

    static void GenerateRandomArrayToFile(string fileName)
    {
        Random random = new Random();
        int[] array = new int[20];

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            for (int i = 0; i < 20; i++)
            {
                array[i] = random.Next(-100, 101); 
                writer.WriteLine(array[i]);
            }
        }
    }

    static int[] ReadArrayFromFile(string fileName)
    {
        List<int> numbers = new List<int>();

        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (int.TryParse(line, out int number))
                {
                    numbers.Add(number);
                }
            }
        }

        return numbers.ToArray();
    }

    static void PrintArray(int[] array)
    {
        Console.WriteLine(string.Join(", ", array));
    }
}