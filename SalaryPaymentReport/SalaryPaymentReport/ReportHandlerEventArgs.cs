using System;

namespace SalaryPaymentReport
{
    public class SalaryPaymentReportHandlerEventArgs : EventArgs
    {
        public string Report { get; set; }

        public SalaryPaymentReportHandlerEventArgs(string report)
        {
            Report = report;
        }
    }
}