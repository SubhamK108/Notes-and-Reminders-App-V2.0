using System;
using System.IO;
using System.Text;


namespace NotebookLib
{
    public class Notebook
    {
        public static void CreateNote(string note, string filename)
        {
            string date = DateTime.Now.ToString("dd/MMMM/yyyy");
            string time = DateTime.Now.ToString("hh:mm:ss");
            string heading = $"Date: {date}\t\t\tTime: {time}";

            string path = Directory.GetCurrentDirectory() + $"/../Notes/{filename}.txt";

            if (! File.Exists(path))
            {
                using (StreamWriter file = new StreamWriter(path, false, Encoding.UTF8))
                {
                    file.WriteLine(heading);
                    file.Write("\n");
                    file.WriteLine(note);
                    file.WriteLine("\n\n");
                }
            }
            else
            {
                using (StreamWriter file = new StreamWriter(path, true, Encoding.UTF8))
                {
                    file.WriteLine(heading);
                    file.Write("\n");
                    file.WriteLine(note);
                    file.WriteLine("\n\n");
                }
            }
        }

        public static string GetNote(string filename)
        {
            string path = Directory.GetCurrentDirectory() + $"/../Notes/{filename}.txt";

            if (! File.Exists(path))
            {
                string note = "\nSorry, no notes found on that date !\n\n";
                return note;
            }
            else
            {
                using (StreamReader file = new StreamReader(path, Encoding.UTF8))
                {
                    Console.WriteLine("Note Found");
                    Console.WriteLine("----------------------------------------------------------------------------\n");
                    string note = file.ReadToEnd();
                    return note;
                }
            }
        }

        public static void DeleteNote(string filename)
        {
            string path = Directory.GetCurrentDirectory() + $"/../Notes/{filename}.txt";

            if (! File.Exists(path))
            {
                Console.WriteLine("\nSorry, no notes found on that date !\n\n");
            }
            else
            {
                File.Delete(path);
                Console.WriteLine("\nNote Deleted.\n\n");
            }
        }
        
    }
}
