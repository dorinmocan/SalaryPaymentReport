using System;

namespace SalaryPaymentReport
{
    public class ReportHandlerEventArgs : EventArgs
    {
        public string Report { get; set; }

        public ReportHandlerEventArgs(string report)
        {
            Report = report;
        }
    }
}