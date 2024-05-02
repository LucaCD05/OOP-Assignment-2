using System.Linq;
using System.Text;


namespace OOP_Assignment_2
{
    // class which tracks the game statistics
    internal class Statistics
    {
        // Properties to access statistics for Sevens Out game
        public Dictionary<string, int> SevensOutStats { get; private set; }

        // Properties to access statistics for Three Or More game
        public Dictionary<string, int> ThreeOrMoreStats { get; private set; }

        // initialises the statistics dictionaries
        public Statistics()
        {
            SevensOutStats = new Dictionary<string, int>();
            ThreeOrMoreStats = new Dictionary<string, int>();
        }

        // Method which will update the statistics for Sevens Out
        public void UpdateSevensOutStats(int totalScore)
        {
            // Updates the total plays count
            SevensOutStats["Total Plays"] = SevensOutStats.ContainsKey("Total Plays") ? SevensOutStats["Total Plays"] + 1 : 1;
            // Updates the highscore if the new score is higher
            if (!SevensOutStats.ContainsKey("High Score") || totalScore > SevensOutStats["High Score"])
            {
                SevensOutStats["High Score"] = totalScore;
            }
        }

        // Method to update the statistics for the three or more game
        public void UpdateThreeOrMoreStats(int score)
        {
            // Updates the total plays count
            ThreeOrMoreStats["Total Plays"] = ThreeOrMoreStats.ContainsKey("Total Plays") ? ThreeOrMoreStats["Total Plays"] + 1 : 1;
            // Updates the high score if the new score is higher
            if (!ThreeOrMoreStats.ContainsKey("High Score") || score > ThreeOrMoreStats["High Score"])
            {
                ThreeOrMoreStats["High Score"] = score;
            }
        }

        // Method to display Statistics
        public void DisplayStatistics()
        {
            // displays sevens out statistics
            Console.WriteLine("Sevens Out Statistics:");
            foreach (var stat in SevensOutStats)
            {
                Console.WriteLine($"{stat.Key}: {stat.Value}");
            }
            // Displays 3 or more statistics
            Console.WriteLine("Three or More Statistics:");
            foreach (var stat in ThreeOrMoreStats)
            {
                Console.WriteLine($"{stat.Key}: {stat.Value}");
            }
        }
    }
}
