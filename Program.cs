using System;
class Program {
    static void Main() {
        Console.Write("Enter the lower bound: ");
        int lowerBound = int.Parse(Console.ReadLine());
        Console.Write("Enter the upper bound: ");
        int upperBound = int.Parse(Console.ReadLine());
        try {
            decimal averageValue = AverageOfEvenNumbers(lowerBound, upperBound);
            Console.WriteLine($"The average of even numbers between {lowerBound} and {upperBound} is {averageValue}.");
        } catch (ArgumentOutOfRangeException ex) {
            Console.WriteLine(ex.Message);
        }
    Console.ReadLine();
    }
    static decimal AverageOfEvenNumbers(int lowerBound, int upperBound) {
        if (lowerBound >= upperBound) {
            throw new ArgumentOutOfRangeException("upperBound", "ArgumentOutOfRangeException: upper bound must be greater than lower bound.");
        }
        int sum = 0;
        int count = 0;
        for (int i = lowerBound; i <= upperBound; i++) {
            if (i % 2 == 0) {
                sum += i;
                count++;
            }
        }
    decimal average = (decimal)sum / count;
        return average;
    }
}
