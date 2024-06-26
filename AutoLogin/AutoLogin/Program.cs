using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace AutoLogin
{
    internal class Program
    {
        private static readonly string _directoryPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\", "userinput");
        private static readonly string _registrationLogPath = Path.Combine(_directoryPath, "Reg.txt");

        private static void CheckFilesExist()
        {
            try
            {
                if (!Directory.Exists(_directoryPath))
                {
                    Directory.CreateDirectory(_directoryPath);
                }

                if (!File.Exists(_registrationLogPath))
                {
                    File.Create(_registrationLogPath).Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating directory or files: {ex.Message}");
            }
        }

        private static string GenerateRandomEmail()
        {
            Random random = new Random();
            string email = $"Aniket{random.Next(1, 1000)}@gmail.com";
            return email;
        }

        private static string GenerateRandomPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            string password = new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return password;
        }

        private static void AutoLogin()
        {
            CheckFilesExist();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***********************************");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Auto Login Form:");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("************************************");
            Console.ResetColor();

            Console.WriteLine("Press 1: Login again \nPress 2: Create New User");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string[] lines = File.ReadAllLines(_registrationLogPath);
                    if (lines.Length > 0)
                    {
                        string lastUser = lines.Last();
                        Console.WriteLine($"Welcome {lastUser.Split(',')[0]}");
                        Console.WriteLine("Press 1: Logout");
                        string logoutChoice = Console.ReadLine();
                        if (logoutChoice == "1")
                        {
                            File.WriteAllLines(_registrationLogPath, lines.Take(lines.Length - 1).ToArray());
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Logged out successfully.");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No user logged in.");
                    }
                    break;

                case "2":
                    string newEmail = GenerateRandomEmail();
                    string newPassword = GenerateRandomPassword();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("______Welcome _______");
                    Console.ResetColor();
                    Console.WriteLine($" {newEmail}");
                    //Console.WriteLine($"Your generated password is: {newPassword}");
                    Console.WriteLine("Press any key to continue...");

                    Console.ReadKey();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Logged out successfully.");
                    Console.ResetColor();

                    File.AppendAllText(_registrationLogPath, $"{newEmail},{newPassword}{Environment.NewLine}");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        static void Main(string[] args)
        {
            Thread loginThread = new Thread(AutoLogin);
            loginThread.Start();
            loginThread.Join();

            Thread registerThread = new Thread(AutoLogin);

            registerThread.Start();

            
            registerThread.Join();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
