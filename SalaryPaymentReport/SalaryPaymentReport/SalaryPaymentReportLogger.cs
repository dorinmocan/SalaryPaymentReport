using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryPaymentReport
{
    class SalaryPaymentReportLogger : ILogger
    {
        private readonly string _filePath;

        public SalaryPaymentReportLogger(string filePath)
        {
            _filePath = filePath ?? throw new ArgumentException("Invalid value for parameter " + nameof(filePath));
        }

        public void Log(string logMessage)
        {
            System.IO.File.WriteAllText(_filePath, logMessage);
        }
    }
}
