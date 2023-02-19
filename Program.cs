using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using RadencyHT1;
using System.Text;
using Validate = RadencyHT1.Validate;
using Newtonsoft.Json;

class Program
{
    
    static void Main(string[] args)
    {
        string filePath = @"D:\fff.csv";//джерело
        string targetPath = @"D:\fff.json";//результат
        IEnumerable<FullRecords> records = new List<FullRecords>();
        File.Create(targetPath).Dispose();
        using (var stream = File.OpenRead(filePath))
           
        using (var parser = new CsvParser.CsvReader(stream, Encoding.UTF8, new CsvParser.CsvReader.Config() { WithQuotes = false }))
        {
            var sourseCollection = new List<FullRecords>(); 

            if (!parser.MoveNext())
                throw new InvalidDataException();

            var header = parser.Current.ToArray();
            
            while (parser.MoveNext())
            {                
                var parsedRow = parser.Current.ToArray();
                var preparedRow = Validate.ValidateParsedRow(filePath, parsedRow);
                
                if(preparedRow != null) 
                    sourseCollection.Add(preparedRow);
                Console.WriteLine(preparedRow);                
            }

            Console.WriteLine($"Parsed lines - {Validate.ParsedLines}");
            Console.WriteLine($"Lines with bad data - {Validate.LinesWithBadData}");

            var publishToJson = sourseCollection.GroupBy(r => r.City)
                   .Select(g => new
                   {
                       city = g.Key,
                       services = g.GroupBy(r => r.Service)
                                   .Select(s => new
                                   {
                                       name = s.Key,
                                       payers = s.Select(p => new
                                       {
                                           name = $"{p.FirstName} {p.LastName}",
                                           payment = p.Payment,
                                           date = p.Date,
                                           account_number = p.AccountNumber
                                       }),
                                       total = s.Sum(p => p.Payment)
                                   }),
                       total = g.Sum(p => p.Payment)
                   });

            var json = JsonConvert.SerializeObject(publishToJson, Formatting.Indented);

            File.WriteAllText(targetPath, json);
        }
    }   
}

