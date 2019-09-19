using System;

namespace tändstickspel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my game.");


            int sticks = randomNumSticks();

            int opponent = GameOpponent();
            int userInput = 0;

            while (sticks > 0)
            {

                
                Console.WriteLine("Choose how many sticks you want to take away");
                Printsticks(sticks);
                Console.WriteLine("\n1 or 2");

                try
                {
                    userInput = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error");
                }
                if (userInput == 1 && sticks - 1 <= 0 || userInput == 2 && sticks - 2 <= 0)
                {

                    Console.WriteLine("You win!");
                    break;
                }
                else if (userInput == 1 || userInput == 2)
                {

                    if (userInput == 1)
                    {
                        sticks -= 1;
                        Console.WriteLine("You took 1 stick");
                    }
                    else if (userInput == 2)
                    {

                        sticks -= 2;
                        Console.WriteLine("You took 2 sticks");
                    }
                    opponent = GameOpponent();

                    printGameSticks(sticks);
                    Console.WriteLine("Computer takes away " + opponent + " sticks.");
                    if (sticks - opponent <= 0)
                    {
                        Console.WriteLine("Computer win! you lose.");
                        break;
                    }
                    sticks -= opponent;
                }
                else
                {
                    Console.WriteLine("please try");
                }
            }
        }
        static int randomSticks()
        {
            Random rnd = new Random();
            int roll = rnd.Next(15, 26);
            return roll;
        }
        static void printGameSticks(int sticks)
        {
            int roll = 0;
            for (int i = 0; i < sticks; i++)
            {

                roll++;
                Console.Write("|");
                if (roll >= 5)
                {
                    Console.Write(" ");
                    roll = 0;
                }

            }
            Console.WriteLine("\n");

        }
        static int randomNumSticks()
        {
            Random rnd = new Random();
            int roll = rnd.Next(15, 26);
            return roll;
        }
        static int GameOpponent()
        {
            Random rnd = new Random();
            int roll = rnd.Next(1, 3);
            return roll;
        }
        static void Printsticks(int sticks)
        {
            int roll = 0;


            for (int i = 0; i < sticks; i++)
            {

                roll++;
                Console.Write("|");
                if (roll >= 5)
                {
                    Console.Write(" ");
                    roll = 0;
                }

            }
        }
    }
}
