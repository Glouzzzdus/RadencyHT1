using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using RadencyHT1;
using System.Text;
using Validate = RadencyHT1.Validate;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

class Program
{
    
    static void Main(string[] args)
    {   
        string filePath = @"D:\fff.csv";//джерело
        string targetPath = @"D:\fff.json";//результат
        string sourceDir = @"D:\payprocessing\input";
        var FilesWithBadData = new HashSet<string>();

        FileSystemWatcher watcher = new FileSystemWatcher(sourceDir);
        watcher.NotifyFilter = (NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.CreationTime);
        watcher.Created += new FileSystemEventHandler(OnCreate);
        watcher.EnableRaisingEvents = true;
        
       

        Console.ReadLine();

        //var publishToJson = sourseCollection.GroupBy(r => r.City)
        //       .Select(g => new
        //       {
        //           city = g.Key,
        //           services = g.GroupBy(r => r.Service)
        //                       .Select(s => new
        //                       {
        //                           name = s.Key,
        //                           payers = s.Select(p => new
        //                           {
        //                               name = $"{p.FirstName} {p.LastName}",
        //                               payment = p.Payment,
        //                               date = p.Date,
        //                               account_number = p.AccountNumber
        //                           }),
        //                           total = s.Sum(p => p.Payment)
        //                       }),
        //           total = g.Sum(p => p.Payment)
        //       });

        //var json = JsonConvert.SerializeObject(publishToJson, Formatting.Indented);

        //File.WriteAllText(targetPath, json);
    }
    static void OnCreate(object sender, FileSystemEventArgs e)
    {
        if(e.FullPath.EndsWith(".csv") || e.FullPath.EndsWith(".txt"))
        {
            if (File.Exists(e.FullPath))
            {
                FileStream stream = null;
                try
                {
                    stream = File.Open(e.FullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    Console.WriteLine(e.FullPath);
                    // использование файла
                }
                finally
                {
                    stream?.Close();
                }
            }

            //ParseFiles.ParsedList = ParseFiles.GetParsedList(e.FullPath);           
        }
        
        //File.Create(targetPath).Dispose();

        //Validate.ParsedFiles++;
        //if (Validate.LinesWithBadData > 0)
        //{
        //    FilesWithBadData.Add(e.FullPath);
        //}
        //Console.WriteLine($"Parsed lines - {Validate.ParsedLines}");
        //Console.WriteLine($"Lines with bad data - {Validate.LinesWithBadData}");
        //foreach (var fName in FilesWithBadData)
        //{
        //    Console.WriteLine($"Files wiht bad data - {fName}");
        //}
    }   
}

