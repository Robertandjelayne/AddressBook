using System;

namespace AddressBook
{
    public class ConsoleReader : IGetInputFromUser
    {
        public string GetNonEmptyString()
        {
            string input = Console.ReadLine();
            while (input.Length == 0)
            {
                Console.WriteLine("That is not valid.");
                input = Console.ReadLine();
            }
            return input;
        }

        public int GetNumber()
        {
            int value;
            string input = Console.ReadLine();
            while (!int.TryParse(input, out value))
            {
                Console.WriteLine("You should type a number.");
                input = Console.ReadLine();
            }
            return value;
        }

        public void WaitForEnterkey()
        {
            Console.WriteLine("Press ENTER key to contine...");
            Console.ReadLine();
        }
    }




}