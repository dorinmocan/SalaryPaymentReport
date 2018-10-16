using System;

namespace SalaryPaymentReport
{
    internal interface ISalaryTransactionValidatable
    {
        bool IsValidDate(DateTime date);
        bool IsValidAmount(decimal amount);
        bool IsValidEmployeeId(uint employeeId);
    }
}