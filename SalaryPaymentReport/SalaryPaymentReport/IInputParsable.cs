using System.Collections.Generic;

namespace SalaryPaymentReport
{
    internal interface IInputParsable<out T>
    {
        T Parse();
    }
}