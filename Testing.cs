using System.Diagnostics;
using OOP_Assignment_2;

namespace OOP_Assignment_2
{
    internal class Testing
    {
        public static void TestSevensOut(Statistics testStatistics)
        {
            // Create a Game object
            Game game = new Game(testStatistics);

            // Run Sevens Out game
            game.PlaySevensOut();

            // Ensures that the total sum is always 7
            Console.WriteLine("Test Sevens Out:");
            Console.WriteLine($"Total plays should be greater than 0. [{(testStatistics.SevensOutStats["Total Plays"] > 0 ? "Passed" : "Failed")}]");
            Console.WriteLine($"High score should be less than or equal to 7. [{(testStatistics.SevensOutStats["High Score"] <= 7 ? "Passed" : "Failed")}]");
            Console.WriteLine();
        }

        public static void TestThreeOrMore(Statistics testStatistics)
        {
            // Create a Game objects
            Game game = new Game(testStatistics);

            // Run Three Or More game against a computer opponent
            game.PlayThreeOrMore(againstComputer: true);

            // Ensures that the total score is at least 20
            Console.WriteLine("Test Three Or More:");
            Console.WriteLine($"Total plays should be greater than 0. [{(testStatistics.ThreeOrMoreStats["Total Plays"] > 0 ? "Passed" : "Failed")}]");
            Console.WriteLine($"High score should be greater than or equal to 20. [{(testStatistics.ThreeOrMoreStats["High Score"] >= 20 ? "Passed" : "Failed")}]");
            Console.WriteLine();
        }
    }
}
