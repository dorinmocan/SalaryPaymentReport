using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryPaymentReport
{
    internal class ConsoleDisplayer
    {
        public void Display(object sender, ReportHandlerEventArgs args)
        {
            Console.WriteLine(args.Report);
        }
    }
}
