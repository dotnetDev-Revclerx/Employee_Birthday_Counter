using System;

using System.IO;

using System.Reflection;

namespace AutoLogin
{
    internal partial class Program
    {
        private static readonly string _directoryPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\", "userinput");
        private static readonly string _registrationLogPath = Path.Combine(_directoryPath, "Reg.txt");
        private static readonly string _BirthdayPath = Path.Combine(_directoryPath, "Birthday.txt");

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
                if (!File.Exists(_BirthdayPath))
                {
                    File.Create(_BirthdayPath).Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating directory or files: {ex.Message}");
            }
        }


    }
}
