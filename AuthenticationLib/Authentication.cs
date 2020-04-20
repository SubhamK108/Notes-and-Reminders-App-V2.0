using System;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;


namespace AuthenticationLib
{
    public class Authentication
    {
        public static CalendarService Authenticate()
        {
            string[] Scopes = { CalendarService.Scope.Calendar };
            string ApplicationName = "My Google Calendar App v3";

            UserCredential credential;
            string path = Directory.GetCurrentDirectory() + "/../AuthenticationLib/client_secret.json";

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "admin",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                // Console.WriteLine("Credential file saved to: " + credPath);
                // Console.WriteLine("You have already verified your application.");
            }

            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            return service;
        }
    }
}
