using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryPaymentReport
{
    internal class EmployeeValidator : IEmployeeValidatable
    {
        public bool IsValidEmployeeId(uint id)
        {
            if (id == 0) return false;

            return true;
        }

        public bool IsValidFirstName(string firstName)
        {
            return IsValidName(firstName);
        }

        public bool IsValidLastName(string lastName)
        {
            return IsValidName(lastName);
        }

        private bool IsValidName(string name)
        {
            foreach (char letter in name)
            {
                if (!char.IsLetter(letter)) return false;
            }

            return true;
        }
    }
}
