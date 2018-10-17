using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryPaymentReport
{
    internal class YearData
    {
        public ushort Year { get; }
        public decimal[] TrimesterSalary { get; }

        public YearData(ushort year, decimal trimester1Salary, decimal trimester2Salary, decimal trimester3Salary)
        {
            Year = year;

            TrimesterSalary = new decimal[3];
            TrimesterSalary[0] = trimester1Salary;
            TrimesterSalary[1] = trimester2Salary;
            TrimesterSalary[2] = trimester3Salary;
        }
    }
}
