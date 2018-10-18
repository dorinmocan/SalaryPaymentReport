using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryPaymentReport
{
    internal class SalaryPaymentReportConsoleDisplayer
    {
        public void DisplayOnConsole(object obj, SalaryPaymentReportHandlerEventArgs args)
        {
            Console.WriteLine(args.Report);
        }
    }
}
