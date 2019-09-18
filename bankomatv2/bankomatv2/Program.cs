using System;

namespace Bankomat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello and welcome to my cash dispenser");
            Console.WriteLine("Choose your pin code! 4 Numbers!!");
            int pinCode = 0;
            int accountBalance = 0;
            while (true)
            {
                string inputPinCode = Console.ReadLine();

                if (inputPinCode.Length == 4)
                {
                    try
                    {
                        pinCode = int.Parse(inputPinCode);
                        accountBalance = 1000;
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid pinCode try again!");
                        Console.WriteLine("Choose your pin code! 4 Numbers!!");
                    }
                }
                else
                {
                    Console.WriteLine("---=error=---(please type in 4 numbers)");
                }
            }
            while (true)
            {
                Console.WriteLine("Type (Deposit) to deposit money..\n");
                Console.WriteLine("Type (Withdraw) to withdraw money..\n");
                Console.WriteLine("Type (Balance) to view account balance..\n");
                Console.WriteLine("Type (Exit) to exit application..\n");

                string menuChoiceInput = Console.ReadLine();
                menuChoiceInput = menuChoiceInput.ToLower();

                if (menuChoiceInput == "deposit")
                {
                    while (true)
                    {
                        Console.WriteLine("Current balance (" + accountBalance + ")");
                        Console.WriteLine("How much do you want to deposit? Type menu to go back");
                        string input = Console.ReadLine();
                        if (input == "menu")
                        {
                            break;
                        }
                        else
                        {
                            try
                            {
                                int depositAmount = int.Parse(input);
                                accountBalance += depositAmount;
                                Console.WriteLine("Added " + depositAmount + " to your balance\nCurrent balance:" + accountBalance);
                            }
                            catch
                            {
                                Console.WriteLine("Please type exit or enter ammount you want to deposit");
                            }
                        }
                    }
                }
                else if (menuChoiceInput == "withdraw")
                {
                    PinUnlock(pinCode, "Withdraw", accountBalance);
                    while (true)
                    {
                        Console.WriteLine("Current balance (" + accountBalance + ")");
                        Console.WriteLine("How much do you want to withdraw? Type menu to go back");
                        string input = Console.ReadLine();
                        if (input == "menu")
                        {
                            break;
                        }
                        else
                        {
                            int withDrawAmount = 0;
                            try
                            {
                                withDrawAmount = int.Parse(input);

                            }
                            catch
                            {
                                Console.WriteLine("Error");
                            }
                            if (withDrawAmount > accountBalance)
                            {

                                Console.WriteLine("You cant withdraw more than you account balance!");
                            }

                            else if (withDrawAmount <= accountBalance)
                            {
                                Console.WriteLine("Withdrawing " + withDrawAmount + " from your balance");
                                accountBalance = accountBalance - withDrawAmount;
                                Console.WriteLine("Current account balance is " + accountBalance);
                            }
                            else
                            {
                                Console.WriteLine("Please type in the amount you want to deposit");
                            }

                        }
                    }
                }


                else if (menuChoiceInput == "balance")
                {

                    PinUnlock(pinCode, "Balance", accountBalance);

                }
                else if (menuChoiceInput == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("(" + menuChoiceInput + ") Is not a valid option!");
                }
            }
        }
        /// <summary>
        /// Unlcoks menu options
        /// </summary>
        /// <param name="pin">UserPinCode</param>
        /// <param name="option">Name of Option</param>
        static void PinUnlock(int pin, string option, int bankBalance)
        {
            Console.WriteLine("Type in Pin to access or exit \n (" + option + ")");
            int numOfTries = 3;
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    string input = Console.ReadLine();

                    if (input == "exit")
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        numOfTries--;
                        Console.WriteLine("Type in pin code... you have " + numOfTries + " tries left!");

                        int trypin = int.Parse(input);

                        if (trypin == pin)
                        {
                            Console.WriteLine("Pin code correct!");
                            Console.WriteLine("Bank balance is:" + bankBalance);
                            break;
                        }
                        else if (i == 2 && trypin != pin)
                        {
                            Console.WriteLine("You typed in wrong number 3 times!\napplication will close");
                        }
                        else if (trypin != pin)
                        {
                            Console.WriteLine("Wrong pin number! try again!");
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input");
                }
            }
            System.Environment.Exit(0);


        }


    }
}
