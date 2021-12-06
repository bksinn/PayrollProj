using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollProj
{
    class Staff
    {
        private float hourlyRate;
        private int hWorked;
        public float TotalPay {get; protected set;}
        public float BasicPay { get; private set; }
        public string NameOfStaff { get; private set; }
        public int HoursWorked
        {
            get 
            {
                return hWorked;
            }
            set
            {
                if (value > 0)
                    hWorked = value;
                else
                    hWorked = 0;
            }
        }
        public Staff(string name, float rate)
        {
            hourlyRate = rate;
            NameOfStaff = name;
        }
        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay...");
            BasicPay = hWorked * hourlyRate;
            TotalPay = BasicPay;
        }

        public override string ToString()
        {
            return $"Name: {NameOfStaff}\n hourlyRate: {hourlyRate}, hWorked: {hWorked}\n Basic Pay: {BasicPay}, TotalPay: {TotalPay}\n----------------";
        }
    }
}
