using System;
using System.Globalization;
using AuthenticationLib;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Calendar.v3;

namespace RemindersLib
{
    public class Reminders
    {
        public static void CreateReminder(string start, int duration, string title, string description, string location)
        {
            CalendarService service = Authentication.Authenticate();

            DateTime startTime = DateTime.Parse(start, CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal);
            DateTime endTime = startTime.AddMinutes(duration);

            Event newEvent = new Event()
            {
                Summary = title,
                Description = description,
                Location = location,
                Start = new EventDateTime()
                {
                    DateTime = startTime,
                },
                End = new EventDateTime()
                {
                    DateTime = endTime,
                },
                Reminders = new Event.RemindersData()
                {
                    UseDefault = false,
                    Overrides = new EventReminder[]{
                        new EventReminder() { Method = "email", Minutes = 24 * 60 },
                        new EventReminder() { Method = "popup", Minutes = 30 },                        
                    }
                }
            };

            string calendarID = "primary";
            EventsResource.InsertRequest request = service.Events.Insert(newEvent, calendarID);
            Event createdEvent = request.Execute();

            Console.WriteLine("Event created: {0}\n", createdEvent.HtmlLink);
        }
        
        public static void GetReminders(string date)
        {
            CalendarService service = Authentication.Authenticate();

            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.Parse(date, CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal);
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 5;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            Events events = request.Execute();
            if (events.Items != null && events.Items.Count > 0)
            {
                Console.WriteLine("Events on that date:\n");
                foreach (var eventItem in events.Items)
                {
                    int count = 0;
                    string when = eventItem.Start.DateTime.ToString();
                    if (string.IsNullOrEmpty(when))
                    {
                        when = eventItem.Start.Date;
                    }
                    Console.WriteLine("{0}-{1}  ({2})", ++count, eventItem.Summary, when);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No reminders found on that date.\n");
            }
        }
        
        public static void DeleteReminder(string date)
        {
            CalendarService service = Authentication.Authenticate();

            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.Parse(date, CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal);
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 5;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            Events events = request.Execute();
            if (events.Items != null && events.Items.Count > 0)
            {
                int count = 0;
                foreach (var eventItem in events.Items)
                {
                    string eventID = eventItem.Id;
                    service.Events.Delete("primary", eventID).Execute();
                    count++;
                }
                Console.WriteLine($"{count} reminder(s) deleted on that date.\n");
            }
            else
            {
                Console.WriteLine("No reminders found on that date.\n");
            }
        }
        
    }
}
