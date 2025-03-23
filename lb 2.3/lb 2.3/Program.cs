using System;

class GuessMyNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ласкаво просимо до гри 'Guess My Number'!");

        int totalScore = 0; 
        bool continueToNextLevel = false; 

        Console.WriteLine("\nРівень 1: Вгадайте число від 1 до 10.");
        totalScore += PlayLevel(1, 10, 3); 

        if (totalScore > 0)
        {
            Console.WriteLine("\nВаш загальний счёт на першому рівні: " + totalScore);
            Console.Write("Хочете продовжити до другого рівня? (y/n): ");
            string choice = Console.ReadLine().ToLower();
            if (choice == "y")
            {
                continueToNextLevel = true;
            }
        }

        if (continueToNextLevel)
        {
            Console.WriteLine("\nРівень 2: Вгадайте число від 10 до 100.");
            totalScore += PlayLevel(10, 100, 2); 
        }

        Console.WriteLine("\nГра завершена!");
        Console.WriteLine("Загальний счёт: " + totalScore);
        Console.WriteLine(totalScore > 0 ? "Ви перемогли!" : "Ви програли.");
    }

    static int PlayLevel(int min, int max, int rounds)
    {
        int levelScore = 0; 
        Random random = new Random();

        for (int round = 1; round <= rounds; round++)
        {
            Console.WriteLine($"\nРаунд {round}:");

            int lives = (max - min + 1) / 2; 
            int initialLives = lives; 

            int targetNumber = random.Next(min, max + 1); 
            bool guessed = false;

            while (lives > 0 && !guessed)
            {
                Console.WriteLine($"У вас є {lives} життів. Введіть число:");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Введено порожню строку. Спробуйте ще раз.");
                    continue;
                }

                if (!int.TryParse(input, out int guess))
                {
                    Console.WriteLine("Неправильний формат введення. Введіть число.");
                    continue;
                }

                if (guess < min || guess > max)
                {
                    Console.WriteLine($"Число повинно бути в діапазоні від {min} до {max}.");
                    continue;
                }

                if (guess == targetNumber)
                {
                    guessed = true;
                    Console.WriteLine("Вітаю! Ви вгадали число!");
                }
                else
                {
                    lives--;
                    Console.WriteLine(guess < targetNumber ? "Загадане число більше." : "Загадане число менше.");

                    if (lives > 0)
                    {
                        Console.Write("Хочете отримати підказку? (y/n): ");
                        string hintChoice = Console.ReadLine().ToLower();
                        if (hintChoice == "y")
                        {
                            lives--; 
                            Console.WriteLine("Підказка: " + (guess < targetNumber ? "більше" : "менше"));
                        }
                    }
                }
            }

            if (guessed)
            {
                int score = lives * ((max == 10) ? 5 : 10); 
                Console.WriteLine($"Ви заробили {score} очок у цьому раунді.");
                levelScore += score;
            }
            else
            {
                int computerScore = initialLives * ((max == 10) ? 5 : 10); 
                Console.WriteLine($"Ви програли цей раунд. Комп'ютер заробив {computerScore} очок.");
                levelScore -= computerScore;
            }
        }

        return levelScore;
    }
}