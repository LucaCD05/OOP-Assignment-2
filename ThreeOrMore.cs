using System.Linq;
using System.Text;

namespace OOP_Assignment_2
{
    // Three or more games class
    internal class ThreeOrMore
    {
        private Die[] dice; // array which will hold dice objects
        private const int NumDice = 5; // A constant for the number of dice
        private Statistics statistics; // instance for statistics 

        // initialising the game with statistics
        public ThreeOrMore(Statistics stats)
        {
            // Initialising the dice array and filling it with the new die objects
            dice = new Die[NumDice];
            for (int i = 0; i < NumDice; i++)
            {
                dice[i] = new Die();
            }
            statistics = stats; // initialising the statistics instance
        }

        // Method to play Three or more
        public void Play(bool againstComputer)
        {
            int totalScore = 0;

            Console.WriteLine("Playing Three or More...");
            Console.WriteLine("Rolling the dice...");

            while (totalScore < 20)
            {
                int[] rolls = new int[NumDice];
                int score = 0;

                // Roll all dice
                for (int i = 0; i < NumDice; i++)
                {
                    rolls[i] = dice[i].Roll();
                }

                // Display rolls
                Console.Write("Rolled: ");
                for (int i = 0; i < NumDice; i++)
                {
                    Console.Write(rolls[i] + " ");
                }
                Console.WriteLine();

                // Check for 2 of a kind
                bool twoOfAKind = false;
                for (int i = 0; i < NumDice - 1; i++)
                {
                    if (rolls[i] == rolls[i + 1])
                    {
                        twoOfAKind = true;
                        break;
                    }
                }

                // Prompting the user to rethrow the dice
                if (twoOfAKind)
                {
                    Console.WriteLine("You have rolled a 2 of a kind. You can either:");
                    Console.WriteLine("1. Rethrow all the Dice");
                    Console.WriteLine("2. Rethrow just the remaining dice");

                    int choice;
                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Invalid choice, Dice will now be rethrown");
                        choice = 1;
                    }

                    switch (choice)
                    {
                        case 1:
                            // Rethrowing all the dice
                            for (int i = 0; i < NumDice; i++)
                            {
                                rolls[i] = dice[i].Roll();
                            }
                            break;
                        case 2:
                            // Removing the dice that are part of the 2 of a kind and rerolling the remaining ones
                            rolls = rolls.Where((val, idx) => !(idx < NumDice - 1 && rolls[idx] == rolls[idx + 1])).ToArray();
                            int remainingDice = rolls.Length;

                            // Rerolling the remaining dice
                            for (int i = 0; i < NumDice - remainingDice; i++)
                            {
                                int rerollIndex = remainingDice + i;
                                rolls[rerollIndex] = dice[i].Roll();
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid choice. All dice will be rethrown");
                            break;
                    }
                }

                // Check for combinations
                Array.Sort(rolls);
                if (rolls.Length >= 3 && (rolls[0] == rolls[2] || rolls[1] == rolls[3] || rolls[2] == rolls[4]))
                {
                    if (rolls[0] == rolls[2] && rolls[2] == rolls[4])
                    {
                        score = 12;
                    }
                    else
                    {
                        score = 6;
                    }
                }

                // Update total score
                totalScore += score;

                Console.WriteLine($"Score for this roll: {score}");
                Console.WriteLine($"Total score: {totalScore}");

                if (!againstComputer)
                {
                    Console.WriteLine("Next player's turn.");
                }
                else
                {
                    Console.WriteLine("Computer's turn...");
                    System.Threading.Thread.Sleep(1000);
                }
            }

            Console.WriteLine("Game over!");
            statistics.UpdateThreeOrMoreStats(totalScore); // Updating statistics 
        }

    }
}
