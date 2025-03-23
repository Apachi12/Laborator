
using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string fileName = "plane.txt";
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"Файл {fileName} не знайдено!");
                return;
            }

            string[] fileData = File.ReadAllLines(fileName);
            if (fileData.Length < 4)
            {
                Console.WriteLine("Файл містить недостатньо даних!");
                return;
            }

            double tankCapacity = Convert.ToDouble(fileData[0]);
            double distanceAtoB = Convert.ToDouble(fileData[1]);
            double distanceBtoC = Convert.ToDouble(fileData[2]);
            double cargoLoad = Convert.ToDouble(fileData[3]);

            double fuelRate = CalculateFuelRate(cargoLoad);
            if (fuelRate == -1)
            {
                Console.WriteLine("Літак не може підняти такий вантаж.");
                return;
            }

            double fuelForAtoB = distanceAtoB * fuelRate;
            double fuelForBtoC = distanceBtoC * fuelRate;

            if (fuelForAtoB > tankCapacity)
            {
                Console.WriteLine("Неможливо долетіти до пункту B. Недостатньо пального.");
                return;
            }

            double remainingFuel = tankCapacity - fuelForAtoB;
            double refuelAmount = Math.Max(0, fuelForBtoC - remainingFuel);

            Console.WriteLine($"Мінімальна кількість палива для дозаправки в пункті B: {refuelAmount} літрів");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Помилка: {e.Message}");
        }
    }

    static double CalculateFuelRate(double weight)
    {
        if (weight <= 500) return 1;
        if (weight <= 1000) return 4;
        if (weight <= 1500) return 7;
        if (weight <= 2000) return 9;
        return -1; 
    }
}
