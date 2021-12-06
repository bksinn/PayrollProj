using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollProj
{
    class FileReader
    {
        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string path = "C:/Users/bksin/Desktop/Projects_Misc/PayrollProj/PayrollProj/StaffInfo/staff.txt";
            string[] seperator = { ", " };

            if (File.Exists(path))
            {
                using (var sr = new StreamReader(path))
                {
                    while(sr.EndOfStream != true)
                    {
                        string line = sr.ReadLine();
                        result = line.Split(seperator, StringSplitOptions.RemoveEmptyEntries);

                        if (result[1].ToLower() == "manager")
                        {
                            var manager = new Manager(result[0]);
                            myStaff.Add(manager);
                        }
                        else if (result[1].ToLower() == "admin")
                        {
                            var admin = new Admin(result[0]);
                            myStaff.Add(admin);
                        }
                    }

                    sr.Close();
                }
            }
            else
            {
                Console.WriteLine(new FileNotFoundException().Message);
            }

            return myStaff;
        }
    }
}
