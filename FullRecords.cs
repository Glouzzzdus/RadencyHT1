using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static Program;
using System.ComponentModel;

namespace RadencyHT1
{
    [Serializable]
    public class FullRecords
    {     

        public FullRecords()
        {
        }

        public FullRecords(string fName, string lName, string city, decimal payment, DateTime date, long accountId, string service)
        {
            FirstName= fName;
            LastName= lName;
            City= city;
            Payment= payment;
            Date = date;
            AccountNumber= accountId;
            Service= service;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public decimal Payment { get; set; }             
        public DateTime Date { get; set; }
        public long AccountNumber { get; set; }
        public string Service { get; set; }
               
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}\nCity: {City}\nPayment: {Payment:C}\nDate: {Date:d}\nAccount Number: {AccountNumber}\nService: {Service}";
        }


    }
}
