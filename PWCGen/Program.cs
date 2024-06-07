using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PWCGen
{
    internal class Program
    {
        // Główna metoda programu
        static void Main(string[] args)
        {

            bool exit = false;
            while (!exit)
            {
                
                DisplayMenu();
                Console.WriteLine();
            }

        }
        // Wyświetl Menu
        static void DisplayMenu()
        {
            // MainMenu 
            Console.WriteLine("================================");
            Console.WriteLine("PWCGen 1.0");
            Console.WriteLine("Twój konsolowy generator haseł");
            Console.WriteLine("================================");
            Console.WriteLine();

            Console.WriteLine("1. Hasło 15 znakowe");
            Console.WriteLine("2. Hasło 8 znakowe (zawiera znaki specjalne)");
            Console.WriteLine("3. Hasło 8 znakowe z pominięciem znaku '@' (STAFFWARE)");

            string userChoice = Console.ReadLine();

            // Wybór: Hasło 15 znakowe bez znaków specjalnych
            if (userChoice == "1")
            {
                // Domyślna długość hasła
                int passwordLength = 15;

                // Zestaw znaków używany do generowania hasła
                string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";


                // Generowanie hasła
                string password = GeneratePassword(passwordLength, chars);

                // Wyświetlenie hasła
                Console.WriteLine("Generated Password: " + password);
            }
            // Wybór: Hasło 8 znakowe ze znakami specjalnymi
            if (userChoice == "2")
            {
                // Domyślna długość hasła
                int passwordLength = 8;

                // Zestaw znaków używany do generowania hasła
                string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*";

                string specialChars = "!#$%^&*";

                // Generowanie hasła
                string password = GeneratePassword(passwordLength, chars, specialChars);

                // Wyświetlenie hasła
                Console.WriteLine("Generated Password: " + password);
            }
            // Wybór: Hasło 8 znakowe z pominięciem znaku '@'
            if (userChoice == "3")
            {
                // Domyślna długość hasła
                int passwordLength = 8;

                // Zestaw znaków używany do generowania hasła
                string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

                string specialChars = "!#$%^&*";

                // Generowanie hasła
                string password = GeneratePassword(passwordLength, chars, specialChars);

                // Wyświetlenie hasła
                Console.WriteLine("Generated Password: " + password);
            }

        }
        static void HighlightText(string text, ConsoleColor backgroundColor, ConsoleColor foregroundColor)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.Write(text);
            Console.ResetColor();
        }
        
        // Metoda generująca hasło
        private static string GeneratePassword(int length, string chars, string specialChars = "")
        {
            //  Generator
            Random random = new Random();

            // Zmieszaj znaki podstawowe i opcjonalne znaki specjalne
            string allChars = chars + specialChars;

            // Przechowywanie hasła
            char[] password = new char[length];

            // Generuje kolejne znaki hasła
            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);

                // Dodaje wylosowany znak do hasła
                password[i] = chars[index];
            }

            // Konwersja tablicy znaków na string i zwrócenie hasła
            return new string(password);
        }

    }
}
