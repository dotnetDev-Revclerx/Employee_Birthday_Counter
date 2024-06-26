using System;
using System.IO;

namespace AutoLogin
{
    internal partial class Program
    {
        private static void DisplayUpcomingBirthdays(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                Console.WriteLine("\nUpcoming Birthdays within the next 10 days:");

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    string name = parts[0].Trim();
                    DateTime dob = DateTime.ParseExact(parts[1].Trim(), "dd-MM-yyyy", null);
                    DateTime today = DateTime.Today;

                    DateTime nextBirthday = new DateTime(today.Year, dob.Month, dob.Day);
                    if (nextBirthday < today)
                        nextBirthday = nextBirthday.AddYears(1);

                    int daysUntilBirthday = (nextBirthday - today).Days;

                    if (daysUntilBirthday <= 10 && daysUntilBirthday >= 0)
                    {
                        Console.WriteLine($"{name} - {dob.Day} {dob.ToString("MMMM")}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }
    }
}
