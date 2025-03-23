using System;
using System.IO;

class Program
{
    static void Main()
    {
        double xMin = -1.0; 
        double xMax = 1.0;  
        int n = 8;          

        double deltaX = (xMax - xMin) / (n - 1);

        using (StreamWriter writer = new StreamWriter("LAB2.RES"))
        {
            writer.WriteLine("I-----------------------------------I");
            writer.WriteLine("I         X         I     Функція     I");
            writer.WriteLine("I-----------------------------------I");

            for (int i = 0; i < n; i++)
            {
                double x = xMin + i * deltaX;
                double y = CalculateFunction(x);
                writer.WriteLine($"I X={x:F3}       I Y={y:F3}       I");
            }

            writer.WriteLine("I-----------------------------------I");
            writer.WriteLine("Таблицу сформував <Дзюба. Д. А>");
        }

        Console.WriteLine("Результат записан в файл LAB2.RES.");
    }

    static double CalculateFunction(double x)
    {
        double numerator = Math.Exp(2 * x) + Math.Exp(-2 * x);
        double denominator = Math.Exp(x) + Math.Exp(-x);
        return 2 - (numerator / denominator);
    }
}