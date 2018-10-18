using System.Collections.Generic;

namespace SalaryPaymentReport
{
    internal interface IInputParseable<out T>
    {
        T Parse();
    }
}