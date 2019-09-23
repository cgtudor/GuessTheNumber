using System;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose gamemode:\n1. Player guessing\n2. Computer guessing");
            int choice = Int32.Parse(Console.ReadLine());
            if(choice == 1)
            {
                PlayerGuesses();
            }
            else if(choice == 2)
            {
                ComputerGuesses();
            }
        }
        static public void PlayerGuesses()
        {
            Random random = new Random();
            int randomNumber = 0;
            int attempts = 0;
            Console.WriteLine("Please select difficulty: 1 for easy, 2 for medium and 3 for hard");
            int choice = Int32.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    attempts = 20;
                    randomNumber = random.Next(100);
                    Console.WriteLine("Input a number between 0 and 100, you have " + attempts + " attempts.");
                    break;
                case 2:
                    attempts = 15;
                    randomNumber = random.Next(500);
                    Console.WriteLine("Input a number between 0 and 500, you have " + attempts + " attempts.");
                    break;
                case 3:
                    attempts = 7;
                    randomNumber = random.Next(-1000, 1000);
                    Console.WriteLine("Input a number between -1000 and 1000, you have " + attempts + " attempts.");
                    break;
            }
            int guess = Int32.Parse(Console.ReadLine());
            while (randomNumber != guess)
            {
                attempts--;
                if (attempts == 0)
                {
                    Console.WriteLine("Sorry, you lost");
                    return;
                }
                if (randomNumber > guess)
                    Console.WriteLine("Oops, wrong number, the number was too low. Try again! You have " + attempts + " attempts left.");
                else
                    Console.WriteLine("Oops, wrong number, the number was too high. Try again! You have " + attempts + " attempts left.");
                Console.WriteLine("Input a number between 0 and 100");
                guess = Int32.Parse(Console.ReadLine());
            }
            Console.WriteLine("Congrats! You got it");
        }
        static public void ComputerGuesses()
        {
            Console.WriteLine("Think of a number between 1 and 100 and I will try to guess it! I have 20 attempts");
            Random random = new Random();
            int attempts = 20;
            int guess = random.Next(0, 101);
            int minguess = 1;
            int maxguess = 100;
            Console.WriteLine("My guess is " + guess + ". Am I right?\n1. Correct!\n2. Too high!\n3. Too low!");
            int choice = Int32.Parse(Console.ReadLine());
            while(choice != 1)
            {
                attempts--;
                if(attempts == 0)
                {
                    Console.WriteLine("I lost :(");
                    return;
                }
                Console.WriteLine("I have " + attempts + " left");
                if (choice == 3)
                {
                    int tempGuess = guess;
                    guess = random.Next(guess + 1, maxguess-1);
                    if (guess > minguess)
                        minguess = tempGuess;
                    Console.WriteLine("My guess is " + guess + ". Am I right?\n1. Correct!\n2. Too high!\n3. Too low!");
                }
                else if(choice == 2)
                {
                    int tempGuess = guess;
                    guess = random.Next(minguess+1, guess - 1);
                    if (guess < maxguess)
                        maxguess = tempGuess;
                    Console.WriteLine("My guess is " + guess + ". Am I right?\n1. Correct!\n2. Too high!\n3. Too low!");
                }
                choice = Int32.Parse(Console.ReadLine());
            }
            Console.WriteLine("Yay! I won!!");
        }
    }
}
