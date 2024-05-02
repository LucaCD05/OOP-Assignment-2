using System.Linq;
using System.Text;

/*
 * *******  Instructions ********
 * The Die class should contain one property to hold the current die value,
 * and one method that rolls the die, returns and integer and takes no parameters.
 */


namespace OOP_Assignment_2

{
    internal class Die
    {
        private Random random;
        public int CurrentValue { get; private set; }  //Property holding the current value for the die

        public Die()
        {
            random = new Random(); // initialising the random object
            Roll();

        }

        public int Roll() //Method used to roll the die
        {
            CurrentValue = random.Next(1, 7); // generates a random inclusive number between 1 and 6
            return CurrentValue; // returns the value from the roll
        }

    }
}
