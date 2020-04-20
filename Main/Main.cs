using System;
using System.IO;
using System.Globalization;
using AuthenticationLib;
using NotebookLib;
using RemindersLib;
using System.Linq;
using System.Collections.Generic;
using Google.Apis.Calendar.v3;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            CalendarService service = Authentication.Authenticate();
            string path = Directory.GetCurrentDirectory() + "/../Notes";
            if (! Directory.Exists(path))
                Directory.CreateDirectory(path);
            string[] date;
            string date1, time1, startTime;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("... Personal Notes & Reminders ...\n");
                Console.WriteLine("1. Enter a note.");
                Console.WriteLine("2. View a note");
                Console.WriteLine("3. Delete a note");
                Console.WriteLine("4. Create a reminder");
                Console.WriteLine("5. View a reminder");
                Console.WriteLine("6. Delete a reminder");
                Console.WriteLine("7. Exit\n");
                Console.Write("Enter your option: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        date = DateTime.Now.ToString("dd.MM.yyyy").Split('.');
                        string fileName = date[0] + date[1] + date[2];
                        Console.Write("Enter the Note: ");
                        string note = Console.ReadLine();
                        Notebook.CreateNote(note, fileName);
                        Console.WriteLine("Note created\n");
                        Console.Write("Press any Key to continue... ");
                        Console.ReadKey();
                        break;
                    
                    case 2:
                        Console.Clear();
                        Console.Write("Enter the Date (DD.MM.YYYY): ");
                        date = Console.ReadLine().Split('.');
                        string fileName2 = date[0] + date[1] + date[2];
                        string note1 = Notebook.GetNote(fileName2);
                        Console.WriteLine(note1);
                        Console.Write("Press any Key to continue... ");
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Clear();
                        Console.Write("Enter the Date (DD.MM.YYYY): ");
                        date = Console.ReadLine().Split('.');
                        string fileName3 = date[0] + date[1] + date[2];
                        Notebook.DeleteNote(fileName3);
                        Console.Write("Press any Key to continue... ");
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Clear();
                        Console.Write("Enter the date (DD.MM.YYYY): ");
                        date1 = Console.ReadLine();
                        Console.Write("Enter the date (DD.MM.YYYY): ");
                        time1 = Console.ReadLine();
                        startTime = date1 + " " + time1 + " " + "+05:30";
                        Console.Write("Enter the duration: ");
                        int duration = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the location: ");
                        string location = Console.ReadLine();
                        Console.Write("Enter the description: ");
                        string description = Console.ReadLine();
                        Console.Write("Enter the title: ");
                        string title = Console.ReadLine();
                        Reminders.CreateReminder(startTime, duration, title, description, location);
                        Console.Write("Press any Key to continue... ");
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.Clear();
                        Console.Write("Enter the date (DD.MM.YYYY): ");
                        date1 = Console.ReadLine();
                        Console.Write("Enter the date (DD.MM.YYYY): ");
                        time1 = Console.ReadLine();
                        startTime = date1 + " " + time1 + " " + "+05:30";
                        Reminders.GetReminder(startTime);
                        Console.Write("Press any Key to continue... ");
                        Console.ReadKey();
                        break;

                    case 6:
                        Console.Clear();
                        Console.Write("Enter the date (DD.MM.YYYY): ");
                        date1 = Console.ReadLine();
                        Console.Write("Enter the date (DD.MM.YYYY): ");
                        time1 = Console.ReadLine();
                        startTime = date1 + " " + time1 + " " + "+05:30";
                        Reminders.DeleteReminder(startTime);
                        Console.Write("Press any Key to continue... ");
                        Console.ReadKey();
                        break;

                    case 7:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Option !\n");
                        Console.Write("Press any Key to continue... ");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
