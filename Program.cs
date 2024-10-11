using System;

namespace Laboratory_work_1
{
    internal class Program
    {
        static double x;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to calculating program. Calculating formula (x^(x+3))+tag(x)");
            Console.WriteLine("Enter X value.");
            
            do
            {
                string xValue = Console.ReadLine();
                if (xValue == null || xValue == " " || !double.TryParse(xValue, out x)) // Check if input value is correct number.
                {
                    Console.WriteLine("Incorrect value, 'x' should be a number");
                }
                else break;
            }
            while (true);

            try
            {
                // Перевірка на валідність значення для tan(x)
                // Тангенс не визначений при x = pi/2 + n*pi
                if (IsUndefinedForTan(x))
                {
                    Console.WriteLine("Error: 'tan' undefined when x = pi/2 + n*pi.");
                    Console.WriteLine("Press any key to exit");
                    Console.ReadKey();
                    return;
                }

                // Підрахунок tan(x)
                double tanPart = Math.Tan(x);
                // Підрахунок x^(x+3)
                double powerPart = Math.Pow(x, x + 3);
                // Ітоговий підрахунок.
                double result = powerPart + tanPart;

                Console.WriteLine($"Calculation result: {result}");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Calculating error: {ex.Message}");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }

        // Метод для перевірки, чи є x кратним pi/2 + n*pi
        static bool IsUndefinedForTan(double x)
        {
            double piOver2 = Math.PI / 2;
            double epsilon = 1e-10;  // Похибка для роботи с плаваючими точками
            double mod = Math.Abs(x % Math.PI);  // Остаток від поділу на pi

            // Перевірка на близість до pi/2
            return Math.Abs(mod - piOver2) < epsilon;
        }
    }
}
