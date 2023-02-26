using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadencyHT1
{
    internal class ParseFiles
    {
        public static List<FullRecords> ParsedList { get; set; }

        public static List<FullRecords> GetParsedList(string path)
        {
            using FileStream stream = File.OpenRead(path);
            using var parser = new CsvParser.CsvReader(stream, Encoding.UTF8, new CsvParser.CsvReader.Config() { WithQuotes = false });
            var sourseCollection = new List<FullRecords>();
            if (path.EndsWith(".csv"))
            {
                if (!parser.MoveNext())
                    throw new InvalidDataException();

                var header = parser.Current.ToArray();
            }

            while (parser.MoveNext())
            {
                var parsedRow = parser.Current.ToArray();
                var preparedRow = Validate.ValidateParsedRow(path, parsedRow);

                if (preparedRow != null)
                    sourseCollection.Add(preparedRow);
                Console.WriteLine(preparedRow);
            }
            return sourseCollection;
        }

    }
}
