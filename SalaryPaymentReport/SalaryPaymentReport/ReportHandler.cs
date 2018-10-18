using System;

namespace SalaryPaymentReport
{
    internal class ReportHandler : Handler<ReportHandlerEventArgs>
    {
        private readonly string _report;

        public override event EventHandler<ReportHandlerEventArgs> Handled;

        public ReportHandler(string report)
        {
            _report = report ?? throw new ArgumentException("Invalid value for parameter " + nameof(report));
        }

        public override void Handle()
        {
            if (Handled != null)
            {
                Handled(this, new ReportHandlerEventArgs(_report));
            }
        }
    }
}