using System;

namespace PWCGen
{
    internal class Program
    {
        // Main method
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                DisplayMenu();
                Console.WriteLine();
            }
        }

        // Displays Menu
        static void DisplayMenu()
        {
            // MainMenu 
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("PWCGen 1.0 PL");
            Console.WriteLine("PassWord Console Generator");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();  // New line!

            Console.WriteLine("1. Hasło 15 znakowe (bez znaków specjalnych)");
            Console.WriteLine("2. Hasło 8 znakowe");
            Console.WriteLine("3. Hasło 8 znakowe z pominięciem znaku '@' (STAFFWARE)");

            string userChoice = Console.ReadLine();

            // Option 1: 15-character password without special characters
            if (userChoice == "1")
            {
                Console.Clear();
                GenerateAndDisplayPassword(15, "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            }
            // Option 2: 15-character password without special characters
            else if (userChoice == "2")
            {
                Console.Clear();
                GenerateAndDisplayPassword(8, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*");                
            }
            // Wybór: 8-character password excluding the '@' character
            else if (userChoice == "3")
            {
                Console.Clear();
                GenerateAndDisplayPassword(8, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!#$%^&*");
            }
            else
            {
                Console.Clear();
                // Sets red background color for error message
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                // Shows error message
                Console.WriteLine(" " + "Musisz wybrać opcje od 1-3!!!" + " ");

                // Restores the default console background color
                Console.ResetColor();
            }
        }

        // A method for generating and displaying a password with a colored background
        static void GenerateAndDisplayPassword(int length, string chars, string specialChars = "")
        {
            // Generates Password
            string password = GeneratePassword(length, chars, specialChars);

            // sets background and foreground color
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;

            // Displays passwords
            Console.Write(" " + "Wygenerowane hasło: " + password + " ");

            // Restores the default console background color
            Console.ResetColor();
            Console.WriteLine(); // New line
        }

        // Generates Password
        private static string GeneratePassword(int length, string chars, string specialChars = "")
        {
            //  Generator
            Random random = new Random();

            // Mixes basic characters and optional special characters
            string allChars = chars + specialChars;

            // Stores password
            char[] password = new char[length];

            // Generates next password characters
            for (int i = 0; i < length; i++)
            {
                int index = random.Next(allChars.Length);

                // Adds a randomly selected character to the password
                password[i] = allChars[index];

            }

            // Converts a character array to a string and returns the password
            return new string(password);
        }       
    }
}