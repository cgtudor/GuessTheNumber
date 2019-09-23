using System;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int attempts = 20;
            Random random = new Random();
            int randomNumber = random.Next(100);
            Console.WriteLine("Input a number between 0 and 100, you have " + attempts + " attempts.");
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
                randomNumber = random.Next(100);
                Console.WriteLine("Input a number between 0 and 100");
                guess = Int32.Parse(Console.ReadLine());
            }
            Console.WriteLine("Congrats! You got it");
        }
    }
}
