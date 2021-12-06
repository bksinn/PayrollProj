using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollProj
{
    class Payslip
    {
        private int month;
        private int year;
        enum MonthsOfYear
        {
            JAN = 1,
            FEB = 2,
            MAR = 3,
            APR = 4,
            MAY = 5,
            JUN = 6,
            JUL = 7,
            AUG = 8,
            SEP = 9,
            OCT = 10,
            NOV = 11,
            DEC = 12,
        }
        public Payslip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }
        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path = "C:/Users/bksin/Desktop/Projects_Misc/PayrollProj/PayrollProj/StaffInfo/";

            foreach(Staff f in myStaff)
            {
                var staffPath = $"{f.NameOfStaff}.txt";
                using (var sw = new StreamWriter(path + staffPath))
                {
                    sw.WriteLine($"PAYSLIP FOR {(MonthsOfYear)month} {year}");
                    sw.WriteLine("====================");
                    sw.WriteLine($"Name of Staff: {f.NameOfStaff}");
                    sw.WriteLine($"Hours Worked: {f.HoursWorked}");
                    sw.WriteLine("");
                    sw.WriteLine($"Basic Pay: {f.BasicPay:C}");

                    if (f.GetType() == typeof (Manager))
                        sw.WriteLine($"Allowance: {((Manager)f).Allowance:C}");

                    if (f.GetType()== typeof (Admin))
                        sw.WriteLine($"Overtime: {((Admin)f).Overtime:C}");

                    sw.WriteLine("");
                    sw.WriteLine("====================");
                    sw.WriteLine($"Total Pay: {f.TotalPay:C}");
                    sw.WriteLine("====================");
                    sw.Close();
                }
            }
        }
        public void GenerateSummary(List<Staff> myStaff)
        {
            //var slackers = from f in myStaff
            //               where (f.HoursWorked < 10)
            //               select f;

            string path = "C:/Users/bksin/Desktop/Projects_Misc/PayrollProj/PayrollProj/StaffInfo/summary.txt";

            var slackers = myStaff
                .Where(s => s.HoursWorked < 10)
                .OrderBy(s => s.NameOfStaff);

            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine("Staff  with less than 10 working hours");
                sw.WriteLine("");

                foreach (Staff slacker in slackers)
                {
                    sw.WriteLine($"Name of Staff: {slacker.NameOfStaff}, Hours Worked: {slacker.HoursWorked}");
                }
                sw.Close();
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
