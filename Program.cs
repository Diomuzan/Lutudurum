using System;
class Program {
    static void Main() {
        bool exit = false;
        decimal averageValue = 0;
        do {
            Console.Write("Enter the lower bound: ");
            int lowerBound = int.Parse(Console.ReadLine());
            Console.Write("Enter the upper bound: ");
            int upperBound = int.Parse(Console.ReadLine());
            try {
                averageValue = AverageOfEvenNumbers(lowerBound, upperBound);
                Console.WriteLine($"The average of even numbers between {lowerBound} and {upperBound} is {averageValue}.");
                exit = true;
            } catch (ArgumentOutOfRangeException ex) {
                Console.WriteLine("An error has occurred.");
                Console.WriteLine(ex.Message);
                Console.WriteLine($"The upper bound must be greater than the lower bound.");
                Console.Write("Enter a new upper bound (or enter 'Exit' to quit): ");
                string userResponse = Console.ReadLine();
                if (userResponse.ToLower() == "exit") {
                    exit = true;
                } else {
                    upperBound = int.Parse(userResponse);
                }
            }
        }  while (!exit);
        Console.WriteLine("\n");
    }
    static decimal AverageOfEvenNumbers(int lowerBound, int upperBound) {
        if (lowerBound >= upperBound) {
            throw new ArgumentOutOfRangeException("upperBound", "ArgumentOutOfRangeException: upper bound must be greater than the lower bound.");
        }
        int sum = 0;
        int count = 0;
        decimal average = 0;
        for (int i = lowerBound; i <= upperBound; i++) {
            if (i % 2 == 0) {
                sum += i;
                count++;
            }
        }
        average = (decimal)sum / count;
        return average;
    }
    static void Workflow1(string[][] userEnteredValues) {
        foreach (string[] userEntries in userEnteredValues) {
            Process1(userEntries);
            Console.WriteLine("'Process1' completed successfully.");
            Console.WriteLine();
        }
    }
    static void Process1(string[] userEntries) {
        int valueEntered;
        foreach (string userValue in userEntries) {
            bool integerFormat = int.TryParse(userValue, out valueEntered);
            if (integerFormat == true) {
                if (valueEntered != 0)
                {
                    int calculatedValue = 0;
                    try {
                        calculatedValue = 4 / valueEntered;
                    } catch (DivideByZeroException) {
                        throw new DivideByZeroException("Invalid data. User input values must be non-zero values.");
                    }
                } else {
                    throw new DivideByZeroException("Invalid data. User input values must be non-zero values.");
                }
            } else {
                throw new FormatException("Invalid data. User input values must be valid integers.");
            }
        }
    }
}
