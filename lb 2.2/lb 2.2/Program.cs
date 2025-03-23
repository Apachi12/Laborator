using System;

class Program
{
    static void Main()
    {
        double[] xValues = { 1 / Math.Sqrt(3), -1 / Math.Sqrt(3), 1 };

        foreach (double x in xValues)
        {
            double sum = One(x);

            double exactValue = Math.Atan(x);

            Console.WriteLine($"x = {x:F4}");
            Console.WriteLine($"Сума ряду S(x): {sum:F8}");
            Console.WriteLine($"Точне значення arctan(x): {exactValue:F8}");
            Console.WriteLine($"Різниця: {Math.Abs(sum - exactValue):E}");
            Console.WriteLine(new string('-', 40));
        }
    }

    static double One(double x)
    {
        double sum = 0.0; 
        double term = x;  
        int n = 1;        

        while (Math.Abs(term) >= 1e-6)
        {
            sum += term; 

            term *= -x * x / (2 * n + 1);
            n++;
        }

        return sum;
    }
}