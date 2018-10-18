using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryPaymentReport
{
    class SalaryPaymentReportParsedData : Tuple<List<Employee>, List<SalaryTransaction>>
    {
        public SalaryPaymentReportParsedData(List<Employee> item1, List<SalaryTransaction> item2) : base(item1, item2)
        {
        }
    }
}
