using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryPaymentReport
{
    internal class SalaryTransaction
    {
        private readonly ISalaryTransactionValidatable _salaryTransactionValidator;

        public decimal Amount { get; }
        public DateTime Date { get; }
        public uint EmployeeId { get; }

        public SalaryTransaction(ISalaryTransactionValidatable salaryTransactionValidator, decimal amount, DateTime date, uint employeeId)
        {
            _salaryTransactionValidator = salaryTransactionValidator ?? throw new ArgumentException("Invalid value for parameter " + nameof(salaryTransactionValidator));

            if (!IsValidAmount(amount)) throw new ArgumentException("Invalid value for parameter " + nameof(amount));
            if (!IsValidDate(date)) throw new ArgumentException("Invalid value for parameter " + nameof(date));
            if (!IsValidEmployeeId(employeeId)) throw new ArgumentException("Invalid value for parameter " + nameof(employeeId));

            Amount = amount;
            Date = date;
            EmployeeId = employeeId;
        }

        private bool IsValidAmount(decimal amount)
        {
            return _salaryTransactionValidator.IsValidAmount(amount);
        }

        private bool IsValidDate(DateTime date)
        {
            return _salaryTransactionValidator.IsValidDate(date);
        }

        private bool IsValidEmployeeId(uint employeeId)
        {
            return _salaryTransactionValidator.IsValidEmployeeId(employeeId);
        }
    }
}
