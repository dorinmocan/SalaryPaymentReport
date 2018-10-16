using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryPaymentReport
{
    internal class Employee
    {
        private readonly IEmployeeValidatable _employeeValidator;

        public uint Id { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public Employee(IEmployeeValidatable employeeValidator, uint id, string firstName, string lastName)
        {
            _employeeValidator = employeeValidator ?? throw new ArgumentException("Invalid value for parameter " + nameof(employeeValidator));

            if (!IsValidId(id)) throw new ArgumentException("Invalid value for parameter " + nameof(id));
            if (!IsValidFirstName(firstName)) throw new ArgumentException("Invalid value for parameter " + nameof(firstName));
            if (!IsValidLastName(lastName)) throw new ArgumentException("Invalid value for parameter " + nameof(lastName));

            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        private bool IsValidId(uint id)
        {
            return _employeeValidator.IsValidEmployeeId(id);
        }

        private bool IsValidFirstName(string firstName)
        {
            return _employeeValidator.IsValidFirstName(firstName);
        }

        private bool IsValidLastName(string lastName)
        {
            return _employeeValidator.IsValidLastName(lastName);
        }
    }
}
