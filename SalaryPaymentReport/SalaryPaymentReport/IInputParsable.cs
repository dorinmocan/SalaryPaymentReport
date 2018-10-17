using System.Collections.Generic;

namespace SalaryPaymentReport
{
    internal interface IInputParsable
    {
        ParsedData Parse();
    }
}