using System;

class Program
{
    static void Main()
    {
        string[] questions = {
            "Професор ліг спати о 8 годині, а встав о 9 годині. Скільки годин проспав професор?",
            "На двох руках десять пальців. Скільки пальців на 10?",
            "Скільки цифр у дюжині?",
            "Скільки потрібно зробити розпилів, щоб розпиляти колоду на 12 частин?",
            "Лікар зробив три уколи в інтервалі 30 хвилин. Скільки часу він витратив?",
            "Скільки цифр 9 в інтервалі 1-100?",
            "Пастух мав 30 овець. Усі, окрім однієї, розбіглися. Скільки овець лишилося?"
        };

        int[] correctAnswers = { 1, 50, 2, 11, 30, 1, 1 };
        int score = 0;

        Console.WriteLine("Пройдіть жартівливий тест «Перевір свої можливості»!\n");

        for (int i = 0; i < questions.Length; i++)
        {
            Console.Write($"{i + 1}. {questions[i]} ");
            if (int.TryParse(Console.ReadLine(), out int userAnswer) && userAnswer == correctAnswers[i])
            {
                score++;
            }
        }

        Console.WriteLine($"\nВаш результат: {GetResultMessage(score)}");
    }

    static string GetResultMessage(int score)
    {
        if (score == 7)
            return "Геній!";
        else if (score == 6)
            return "Ерудит!";
        else if (score == 5)
            return "Нормальний.";
        else if (score == 4)
            return "Здібності середні.";
        else if (score == 3)
            return "Здібності нижче середнього.";
        else
            return "Вам треба відпочити!";
    }
}