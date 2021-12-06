using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollProj
{
    class Manager : Staff
    {
        private const float managerHourlyRate = 50;
        public int Allowance { get; private set; }
        public Manager(string managerName) : base(managerName, managerHourlyRate)
        {

        }
        public override void CalculatePay()
        {
            base.CalculatePay();

            Allowance = 1000;

            if (HoursWorked > 160)
                TotalPay = TotalPay + Allowance;
        }
        public override string ToString()
        {
            var staffDetails = base.ToString();
            return $"Manager \n {staffDetails}";
        }
    }
}
