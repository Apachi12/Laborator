using System;

class Program
{
    static void Main()
    {
        double xStart = -4;
        double xEnd = 4;
        double dx = 0.2;

        int[] aValues = { 1, 2, 3, 4 };

        Console.WriteLine("Значення функції y(x):");
        Console.WriteLine("a\t\tx\t\ty(x)");

        for (int i = 0; i < aValues.Length; i++)
        {
            int a = aValues[i];

            for (double x = xStart; x <= xEnd; x += dx)
            {
                double y = ((Math.Pow(x + a, 2.0 / 3) - Math.Pow(x - a, 2.0 / 3)) / a);

                Console.WriteLine($"{a}\t\t{x:F2}\t\t{y:F6}");
            }

            Console.WriteLine(new string('-', 30));
        }
    }
}