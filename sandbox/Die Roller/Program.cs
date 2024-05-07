using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> tallies = new();

        for (int i=0; i<=12; i++);
        {
            tallies.Add(0);
        }
        Console.WriteLine("Now rolling 2d6 1 billion times...");

        Random randomGenerator = new();
        for (int roll=0; roll<1000000000; roll++)
        {
            int die1 = randomGenerator.Next(1,7);
            int die2 = randomGenerator.Next(1,7);
            int total = die1 + die2;
            tallies[total]++;
        }
        
    }
}