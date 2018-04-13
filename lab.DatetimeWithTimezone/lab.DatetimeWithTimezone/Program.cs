using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab.DatetimeWithTimezone
{
    class Program
    {
        static void Main(string[] args)
        {
            //string inputString = "02-14-1970";
            string inputString = "02-14";
            DateTime dDate;

            //if (DateTime.TryParse(inputString, out dDate))
            if (DateTime.TryParseExact(inputString, "MM/dd/yyyy", null, DateTimeStyles.None, out dDate) == true)
            {
                //string.Format("{0:MM/dd/yyyy}", dDate);
                string.Format("{0:d/MM/yyyy}", dDate);
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine("Invalid"); // <-- Control flow goes here
            }

            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("Current Date Time: " + DateTime.Now.ToString());

            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("UTC Date Time: " + DateTime.UtcNow.ToString());

            Console.WriteLine("------------------------------------------------");

            TimeZoneInfo systemTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            DateTime usCSTDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, systemTimeZone);

            Console.WriteLine("US(Central Standard Time) Date Time: " + usCSTDateTime.ToString());

            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("UTC(dd/MMM/yyyy) Date Time: " + DateTime.UtcNow.ToString("dd/MMM/yyyy"));

            Console.WriteLine("------------------------------------------------");

            DateTime surgeryDateTime = DateTime.Parse((new DateTime(2018, 05, 02)).ToString("dd/MMM/yyyy") + " " + (new TimeSpan(9,00,00).ToString()));

            Console.WriteLine("Surgery Date Time: " + surgeryDateTime);

            Console.WriteLine("------------------------------------------------");

            DateTime surgeryDateTimeUtcByTimeZoneInfo = TimeZoneInfo.ConvertTimeToUtc(surgeryDateTime);

            Console.WriteLine("Surgery Date Time(UTC) By TimeZone: " + surgeryDateTimeUtcByTimeZoneInfo);

            Console.WriteLine("------------------------------------------------");

            DateTime surgeryDateTimeUtcByDateTimeOffSet = DateTimeOffset.Parse(surgeryDateTime.ToString()).UtcDateTime;

            Console.WriteLine("Surgery Date Time(UTC) By DateTimeOffset: " + surgeryDateTimeUtcByDateTimeOffSet);

            Console.WriteLine("------------------------------------------------");

            //3/18/2018 3:25:05 PM
            DateTime registrationDateTime = TimeZoneInfo.ConvertTimeFromUtc((DateTime.Parse("3/18/2018 3:25:05 PM")), systemTimeZone);

            Console.WriteLine("Registration(Central Standard Time) Date Time: " + registrationDateTime.ToString());

            Console.WriteLine("------------------------------------------------");

            Console.ReadLine();
        }
    }
}
