using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace RadencyHT1
{
    public class Validate
    {
        public static int ParsedLines { get; set; } = 0;
        public static int ParsedFiles { get; set; } = 0;
        public static int LinesWithBadData { get; set; } = 0;
        public static FullRecords ValidateParsedRow(string fileName, string[] parsedRow)
        {
            try
            {
                var fName = parsedRow[0].Trim();
                var lName = parsedRow[1].Trim();
                var city = parsedRow[2].Split(',')[0].Trim();
                var payment = decimal.Parse(parsedRow[3].Trim(), CultureInfo.InvariantCulture);
                var date = DateTime.ParseExact(parsedRow[4].Trim(), "yyyy-dd-MM", CultureInfo.InvariantCulture);
                var accountId = long.Parse(parsedRow[5].Trim(), CultureInfo.InvariantCulture);
                var service = parsedRow[6].Trim();

                ParsedLines++;
                return new FullRecords(fName, lName, city, payment, date, accountId, service);                
            }
            catch 
            {
                LinesWithBadData++;
                return null;
            }            
        }
    }
}