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
            if (!IsValidId(id)) throw new ArgumentException("Invalid value for parameter " + @id);
            if (!IsValidFirstName(firstName)) throw new ArgumentException("Invalid value for parameter " + @firstName);
            if (!IsValidLastName(lastName)) throw new ArgumentException("Invalid value for parameter " + @lastName);

            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        internal bool IsValidId(uint id)
        {
            if (id == 0) return false;

            return true;
        }

        private bool IsValidFirstName(string firstName)
        {
            return IsValidName(firstName);
        }

        private bool IsValidLastName(string lastName)
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

        internal uint Id { get; }
        internal string FirstName { get; }
        internal string LastName { get; }
    }
}
