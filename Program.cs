using System;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int randomNumber = random.Next(100);
            Console.WriteLine("Input a number between 0 and 100");
            int guess = Int32.Parse(Console.ReadLine());
            while(randomNumber != guess)
            {
                Console.WriteLine("Oops, wrong number, the number was " + randomNumber + ". Try again!");
                randomNumber = random.Next(100);
                Console.WriteLine("Input a number between 0 and 100");
                guess = Int32.Parse(Console.ReadLine());
            }
            Console.WriteLine("Congrats! You got it");
        }
    }
}
