using System;
using System.Collections.Generic;

namespace PayrollProj
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Staff> myStaff = new List<Staff>();
            FileReader fr = new FileReader();
            int month = 0;
            int year = 0;

            while (year == 0)
            {
                Console.WriteLine("\nPlease enter  a year: ");

                try
                {
                    //Code to convert input to an integer
                    var userInput = Console.ReadLine();
                    year = Convert.ToInt32(userInput);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            while (month == 0)
            {
                Console.WriteLine("\n Please enter a month (1-12)");
                try
                {
                    var userInput = Console.ReadLine();
                    int entry = Convert.ToInt32(userInput);
                    if (entry >= 1 && entry <= 12)
                        month = entry;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            //Add staff from file
            myStaff = fr.ReadFile();

            for (int i = 0; i < myStaff.Count; i++)
            {
                try
                {
                    Console.WriteLine($"Enter hours workeed for {myStaff[i].NameOfStaff}: ");

                    var userInput = Console.ReadLine();
                    int entry = Convert.ToInt32(userInput);

                    myStaff[i].HoursWorked = entry;
                    myStaff[i].CalculatePay();

                    Console.WriteLine(myStaff[i].ToString());
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
            }

            Payslip ps = new Payslip(month, year);
            ps.GeneratePaySlip(myStaff);
            ps.GenerateSummary(myStaff);

            Console.Read();
        }
    }
}
