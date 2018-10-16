using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryPaymentReport
{
    internal class SalaryTransactionValidator : ISalaryTransactionValidatable
    {
        private readonly IEmployeeValidatable _employeeValidator;

        public SalaryTransactionValidator(IEmployeeValidatable employeeValidator)
        {
            _employeeValidator = employeeValidator ?? throw new ArgumentException("Invalid value for parameter " + nameof(employeeValidator));
        }

        public bool IsValidDate(DateTime date)
        {
            return true;
        }

        public bool IsValidAmount(decimal amount)
        {
            return true;
        }

        public bool IsValidEmployeeId(uint employeeId)
        {
            return _employeeValidator.IsValidEmployeeId(employeeId);
        }
    }
}
