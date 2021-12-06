using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollProj
{
    class Admin : Staff
    {
        private const float overtimeRate = 15.5F;
        private const float adminHourlyRate = 30;
        public float Overtime { get; private set; }
        public Admin(string adminName) : base(adminName, adminHourlyRate)
        {

        }
        public override void CalculatePay()
        {
            base.CalculatePay();

            Overtime = overtimeRate * (HoursWorked - 160);

            if (HoursWorked > 160)
                TotalPay = TotalPay + Overtime;
        }
        public override string ToString()
        {
            var staffDetails = base.ToString();
            return $"Admin \n {staffDetails}";
        }
    }
}
