using OOP_Assignment_2;
using System;

namespace OOP_Assignment_2
{
    interface IGame
    {
        void Play();
    }
    class Program
    {
        static void Main(string[] args)
        {
            //creating the statistics object to track the games statistics
            Statistics statistics = new Statistics();
            // game Object to manage the games
            Game game = new Game(statistics);



            // Loop for the main menu
            while (true)
            {
                // Code to display the main menu options
                Console.WriteLine("Welcome to the Dice Games!");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Play Sevens Out");
                Console.WriteLine("2. Play Three or More          ***** Against a friend *****");
                Console.WriteLine("3. Play Three or More          ***** Against the computer *****");
                Console.WriteLine("4. View Statistics");
                Console.WriteLine("5. Perform Tests");
                Console.WriteLine("6. Exit");

                // Reads the users input for menu choice
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("WRONG! Please select a VALID choice, numbers 1-6 only");
                    continue;
                }

                // executes the option chosen by the user
                switch (choice)
                {
                    case 1:
                        game.PlaySevensOut();
                        break;
                    case 2:
                        game.PlayThreeOrMore(againstComputer: false);
                        break;
                    case 3:
                        game.PlayThreeOrMore(againstComputer: true);
                        break;
                    case 4:
                        game.ViewStatistics();
                        break;
                    case 5:
                        Testing.TestSevensOut(statistics);
                        Testing.TestThreeOrMore(statistics);
                        break;
                    case 6:
                        Console.WriteLine("Goodbye :( ");
                        return;
                    default:
                        Console.WriteLine("WRONG! Please select a VALID choice, numbers 1-6 only");
                        break;
                }

                // Exits the loop if the user wants to perform testing
                if (choice == 5) // Added condition to break the loop after performing tests
                {
                    break;
                }
            }
        }
    }

    // Games class to manage the games
    internal class Game
    {
        private SevensOut sevensOutGame;
        private ThreeOrMore threeOrMoreGame;
        private Statistics statistics;

        // initialises the game with statistics
        public Game(Statistics stats) // accepting the Statistics instance
        {
            sevensOutGame = new SevensOut(stats);
            threeOrMoreGame = new ThreeOrMore(stats);
            statistics = stats; // allows for statistics to be updated
        }

        // method which starts the main game loop
        public void Start()
        {
            Console.WriteLine("Welcome to the Dice Games!");
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Play Sevens Out");
                Console.WriteLine("2. Play Three or More          ***** Against a friend *****");
                Console.WriteLine("3. Play Three or More          ***** Against the computer *****");
                Console.WriteLine("4. View Statistics");
                Console.WriteLine("5. Perform Tests");
                Console.WriteLine("6. Exit");

                // reads the users inout for their menu choice
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("WRONG! Please select a VALID choice, numbers 1-6 only");
                    continue;
                }
                // executes the chosen option
                switch (choice)
                {
                    case 1:
                        PlaySevensOut();
                        break;
                    case 2:
                        PlayThreeOrMore(againstComputer: false);
                        break;
                    case 3:
                        PlayThreeOrMore(againstComputer: true);
                        break;
                    case 4:
                        ViewStatistics();
                        break;
                    case 5:
                        Testing.TestSevensOut(statistics);
                        Testing.TestThreeOrMore(statistics);
                        break;
                    case 6:
                        Console.WriteLine("Goodbye :( ");
                        return;
                    default:
                        Console.WriteLine("WRONG! Please select a VALID choice, numbers 1-6 only");
                        break;
                }
            }
        }

        // methid to plau the sevens out game
        public void PlaySevensOut()
        {
            Console.WriteLine("Sevens out starting NOW");
            sevensOutGame.Play();
            Console.WriteLine("Sevens out finished, Thank you for playing");
        }

        // Method to play the Three or More game
        public void PlayThreeOrMore(bool againstComputer)
        {
            Console.WriteLine("Three or More starting NOW");
            threeOrMoreGame.Play(againstComputer);
            Console.WriteLine("Three or More finished, Thank you for playing.");
        }

        // Method to view game statistics
        public void ViewStatistics()
        {
            Console.WriteLine("Viewing Statistics:");
            statistics.DisplayStatistics();
        }
    }
}
