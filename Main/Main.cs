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
            Console.Clear();
            // Console.WriteLine("Hello");

            // CalendarService service = Authentication.Authenticate();
            // string[] date = DateTime.Now.ToString("dd.MM.yyyy").Split('.');
            // string fileName = date[0] + date[1] + date[2];
            // Console.Write("Enter the Note: ");
            // string note = Console.ReadLine();
            // Notebook.CreateNote(note, fileName);

            // /////////////////////////

            // Console.Write("Enter the Date (DD.MM.YYYY): ");
            // string[] date2 = Console.ReadLine().Split('.');
            // string fileName2 = date2[0] + date2[1] + date2[2];
            // string note2 = Notebook.GetNote(fileName2);
            // Console.WriteLine(note2);

            // /////////////////////////

            // Console.Write("Enter the Date (DD.MM.YYYY): ");
            // string[] date3 = Console.ReadLine().Split('.');
            // string fileName3 = date3[0] + date3[1] + date3[2];
            // Notebook.DeleteNote(fileName3);


            // string startTime = "1.4.2020" + " " + "8:30" + " " + "+05:30";
            // int duration = 60;
            // string location = "Kolkata";
            // string description = "Celebrations for the New Year 2020";
            // string title = "NEW YEAR 2020";

            
            
            // Reminders.CreateReminder(startTime, duration, title, description, location);
            // Reminders.GetReminders(startTime);
            // Reminders.DeleteReminder(startTime);



            // string startTime = "12.31.2019" + " " + "8:30" + " " + "+05:30";
            // int duration = 60;
            // DateTime start1 = Convert.ToDateTime(startTime, CultureInfo.CurrentCulture);
            // DateTime start2 = DateTime.Parse(startTime, CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal);
            // DateTime end1 = start1.AddMinutes(duration);
            // DateTime end2 = start2.AddMinutes(duration);
            // Console.WriteLine(end1.ToString());
            // Console.WriteLine(end2.ToString());

            // char[] separators = {' ', '.', ':', '/'};
            // string[] str  = end1.ToString().Split(separators);
            // string date4 = string.Join("", str, 0, 3);
            // Console.WriteLine(date4);

            
        }
    }
}
