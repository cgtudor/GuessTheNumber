using System;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose gamemode:\n1. Player guessing\n2. Computer guessing");
            int choice;
            bool done = false;
            while (!done)
            {
                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                    if (choice == 1 || choice == 2)
                        done = true;
                    else
                        Console.WriteLine("Please input a number between 1 and 2");
                    if (choice == 1)
                    {
                        PlayerGuesses();
                    }
                    else if (choice == 2)
                    {
                        ComputerGuesses();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please input a number between 1 and 2");
                }
            }
            
        }
        static public void PlayerGuesses()
        {
            Random random = new Random();
            int randomNumber = 0;
            int attempts = 0;
            Console.WriteLine("Please select difficulty: 1 for easy, 2 for medium and 3 for hard");
            int choice;
            int minRange = 0, maxRange = 0;
            bool done = false;
            while (!done)
            {
                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                    if (choice == 1 || choice == 2 || choice == 3)
                    {
                        done = true;
                        switch (choice)
                        {
                            case 1:
                                attempts = 20;
                                randomNumber = random.Next(100);
                                maxRange = 100;
                                Console.WriteLine("Input a number between 0 and 100, you have " + attempts + " attempts.");
                                break;
                            case 2:
                                attempts = 15;
                                randomNumber = random.Next(500);
                                maxRange = 500;
                                Console.WriteLine("Input a number between 0 and 500, you have " + attempts + " attempts.");
                                break;
                            case 3:
                                attempts = 7;
                                randomNumber = random.Next(-1000, 1000);
                                minRange = -1000;
                                maxRange = 1000;
                                Console.WriteLine("Input a number between -1000 and 1000, you have " + attempts + " attempts.");
                                break;
                        }
                    }
                    else
                        Console.WriteLine("Please input a number between 1 and 3");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please input a number between 1 and 3");
                }
            }
            int guess = -1;
            done = false;
            while (!done)
            {
                try
                {
                    guess = Int32.Parse(Console.ReadLine());
                    if (guess > minRange && guess < maxRange)
                        done = true;
                    else
                        Console.WriteLine("Please input a number between " + minRange + " and " + maxRange);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please input a number between " + minRange + " and " + maxRange);
                }
            }
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
                done = false;
                while (!done)
                {
                    try
                    {
                        guess = Int32.Parse(Console.ReadLine());
                        if (guess > minRange && guess < maxRange)
                            done = true;
                        else
                            Console.WriteLine("Please input a number between " + minRange + " and " + maxRange);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Please input a number between " + minRange + " and " + maxRange);
                    }
                }
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
            int choice = -1;
            while(!Int32.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2 && choice != 3))
            {
                Console.WriteLine("Please input a number between 1 and 3");
            }
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
                    if (maxguess - guess > 5)
                        guess = (maxguess + guess) / 2;
                    else
                    {
                        try
                        {
                            guess = random.Next(guess + 1, maxguess - 1);
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Fuck off I am right");
                            return;
                        }
                    }
                    if (guess > minguess)
                        minguess = tempGuess;
                    Console.WriteLine("My guess is " + guess + ". Am I right?\n1. Correct!\n2. Too high!\n3. Too low!");
                }
                else if(choice == 2)
                {
                    int tempGuess = guess;
                    if (maxguess - guess > 5)
                        guess = (minguess + guess) / 2;
                    else
                    {
                        try
                        {
                            guess = random.Next(minguess + 1, guess - 1);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Fuck off I am right");
                            return;
                        }
                    }
                    if (guess < maxguess)
                        maxguess = tempGuess;
                    Console.WriteLine("My guess is " + guess + ". Am I right?\n1. Correct!\n2. Too high!\n3. Too low!");
                }
                while (!Int32.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2 && choice != 3))
                {
                    Console.WriteLine("Please input a number between 1 and 3");
                }
            }
            Console.WriteLine("Yay! I won!!");
        }
    }
}
