using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть значення x:");
        double x = Convert.ToDouble(Console.ReadLine());
        if (double.TryParse(Console.ReadLine(), out x))
        {
           x = 0.1722;
        }

        Console.WriteLine("Введіть значення y:");
        double y = Convert.ToDouble(Console.ReadLine());
       if(double.TryParse(Console.ReadLine(),out y))
        {
            y = 6.33;
        }
                

        Console.WriteLine("Введіть значення z:");
        double z = Convert.ToDouble(Console.ReadLine());

        double gamma = 5 * Math.Atan(x) - (1.0 / 4) * Math.Acos(x) *
                       ((x + 3) * Math.Abs(x - y) + Math.Pow(x, 2)) /
                       (Math.Abs(x - y) * (z + Math.Pow(x, 2)));

        Console.WriteLine($"Результат: γ = {gamma}");
    }
}