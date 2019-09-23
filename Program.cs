using System;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int randomNumber = 0;
            int attempts = 0;
            Console.WriteLine("Please select difficulty: 1 for easy, 2 for medium and 3 for hard");
            int choice = Int32.Parse(Console.ReadLine());
            switch(choice)
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
            while(randomNumber != guess)
            {
                attempts--;
                if (attempts == 0)
                {
                    Console.WriteLine("Sorry, you lost");
                    return;
                }
                if(randomNumber > guess)
                    Console.WriteLine("Oops, wrong number, the number was too low. Try again! You have " + attempts + " attempts left.");
                else
                    Console.WriteLine("Oops, wrong number, the number was too high. Try again! You have " + attempts + " attempts left.");
                Console.WriteLine("Input a number between 0 and 100");
                guess = Int32.Parse(Console.ReadLine());
            }
            Console.WriteLine("Congrats! You got it");
        }
    }
}
