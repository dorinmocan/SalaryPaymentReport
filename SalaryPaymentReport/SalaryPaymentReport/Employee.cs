using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryPaymentReport
{
    internal class Employee
    {
        internal Employee(uint id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        internal readonly uint Id;
        internal readonly string FirstName;
        internal readonly string LastName;
    }
}
