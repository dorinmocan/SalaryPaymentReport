using System;

namespace SalaryPaymentReport
{
    internal class SalaryPaymentReportHandler : ReportHandler<SalaryPaymentReportHandlerEventArgs>
    {
        private readonly string _report;

        public override event EventHandler<SalaryPaymentReportHandlerEventArgs> ReportHandled;

        public SalaryPaymentReportHandler(string report)
        {
            _report = report ?? throw new ArgumentException("Invalid value for parameter " + nameof(report));
        }

        public override void HandleReport()
        {
            if (ReportHandled != null)
            {
                ReportHandled(this, new SalaryPaymentReportHandlerEventArgs(_report));
            }
        }
    }
}