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
                Console.WriteLine($"The upper bound must be greater than {lowerBound}");
                Console.Write("Enter a new upper bound (or enter 'Exit' to quit): ");
                string userResponse = Console.ReadLine();
                if (userResponse.ToLower() == "exit") {
                    exit = true;
                } else {
                    upperBound = int.Parse(userResponse);
                }
            }
        }
        while (!exit);
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
    static string Workflow1(string[][] userEnteredValues) {
        string operationStatusMessage = "good";
        string processStatusMessage = "";
        foreach (string[] userEntries in userEnteredValues) {
            processStatusMessage = Process1(userEntries);
            if (processStatusMessage == "process complete") {
                Console.WriteLine("'Process1' completed successfully.");
                Console.WriteLine();
            } else {
                Console.WriteLine("'Process1' encountered an issue, process aborted.");
                Console.WriteLine(processStatusMessage);
                Console.WriteLine();
                operationStatusMessage = processStatusMessage;
            }
        }
        if (operationStatusMessage == "good") {
            operationStatusMessage = "operating procedure complete";
        }
        return operationStatusMessage;
    }
    static string Process1(string[] userEntries) {
        string processStatus = "clean";
        string returnMessage = "";
        int valueEntered;
        foreach (string userValue in userEntries) {
            bool integerFormat = int.TryParse(userValue, out valueEntered);
            if (integerFormat == true) {
                if (valueEntered != 0) {
                    checked {
                        int calculatedValue = 4 / valueEntered;
                    }
                } else {
                    returnMessage = "Invalid data. User input values must be non-zero values.";
                    processStatus = "error";
                }
            } else {
                returnMessage = "Invalid data. User input values must be valid integers.";
                processStatus = "error";
            }
        }
        if (processStatus == "clean") {
            returnMessage = "process complete";
        }
        return returnMessage;
    }
}
