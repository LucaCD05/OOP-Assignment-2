using System.Linq;
using System.Text;

namespace  OOP_Assignment_2
{
    // class for Sevens Out Game
    internal class SevensOut : IGame
    {
        private Die die1;
        private Die die2;
        private Statistics statistics; // instance for statistics

        
        public SevensOut(Statistics stats) // accepting the statistics instamce
        {
            die1 = new Die();
            die2 = new Die();
            statistics = stats; // initialising the statistics instance
        }

        // Method which Plays the Sevens out game
        public void Play()
        {
            int total = 0;
            int rolls = 0;

            Console.WriteLine("Playing Sevens Out...");
            Console.WriteLine("Rolling the dice...");

            // main Game Loop
            while (true)
            {
                int roll1 = die1.Roll();
                int roll2 = die2.Roll();
                int sum = roll1 + roll2;

                // displays the results
                Console.WriteLine($"Roll {rolls + 1}: {roll1} + {roll2} = {sum}");

                // checking if the sum of the die is 7, if so game ends
                if (sum == 7)
                {
                    Console.WriteLine("You rolled a 7! Game over.");
                    break;
                }
                else
                {
                    // Updates the total score and increments the number of rolls
                    total += sum;
                    rolls++;
                }
            }
            // displays the total score
            Console.WriteLine($"Total score: {total}");
            // updating the statistics value
            statistics.UpdateSevensOutStats(total); 
        }
    }
}
