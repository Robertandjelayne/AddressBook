﻿using System;
using System.Configuration;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString;
            connectionString = ConfigurationManager.ConnectionStrings["AddressBook"].ConnectionString;

            string contactsFileName = ConfigurationManager.AppSettings["ContactsDatabaseFileName"];

            string name = ConfigurationManager.AppSettings["ApplicationName"];
            Console.WriteLine("WELCOME TO:");
            Console.WriteLine(name);
            Console.WriteLine(new string('-', Console.WindowWidth - 4));
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();

            ContactsRepository contactsRepro 
                = new ContactsRepository(contactsFileName);
            RecipesRepository recipesRepro
                = new RecipesRepository(connectionString);

            ConsoleReader consoleReader = new ConsoleReader();
            Rolodex rolodex 

                = new Rolodex(contactsRepro, recipesRepro, consoleReader);
            rolodex.DoStuff();
        }
    }
}
