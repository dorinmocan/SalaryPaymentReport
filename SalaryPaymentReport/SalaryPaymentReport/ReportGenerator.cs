using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

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
            StringBuilder report = new StringBuilder("");

            var reportData = _parsedData.Item2
                .GroupBy(o => o.Date.Year)
                .OrderBy(g => g.Key)
                .Select(g => new
                {
                    Year = g.Key,
                    Trimesters = g.GroupBy(e => GetTrimester(e.Date))
                                  .OrderBy(e => e.Key)
                });

            foreach (var yearData in reportData)
            {
                report.Append(yearData.Year)
                      .Append(Environment.NewLine);

                foreach (var trimester in yearData.Trimesters)
                {
                    report.Append("Trimester ")
                          .Append(trimester.Key)
                          .Append(": ")
                          .Append(trimester.Average(t => t.Amount))
                          .Append(Environment.NewLine);
                }

                report.Append(Environment.NewLine);
            }

            return report.ToString();
        }

        private static byte GetTrimester(DateTime date)
        {
            if (date.Month < 5) return 1;
            if (date.Month < 9) return 2;
            return 3;
        }
    }
}