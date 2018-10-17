using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace SalaryPaymentReport
{
    internal class ReportGenerator : IReportGeneratable
    {
        private readonly ParsedData _parsedData;

        public ReportGenerator(ParsedData parsedData)
        {
            _parsedData = parsedData ?? throw new ArgumentException("Invalid value for parameter " + nameof(parsedData));
        }

        public string GenerateReport()
        {
            string reportData = "";

            var query = _parsedData.Item2.GroupBy(o => GetTrimester(o.Date));

            return reportData;
        }

        byte GetTrimester(DateTime date)
        {
            if (date.Month < 5) return 1;
            if (date.Month < 9) return 2;
            return 3;
        }
    }
}