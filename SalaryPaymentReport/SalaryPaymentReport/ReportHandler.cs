using System;

namespace SalaryPaymentReport
{
    class ReportHandler<T>
    {
        public virtual event EventHandler<T> ReportHandled;

        public virtual void HandleReport()
        {
            if (ReportHandled != null)
            {
                ReportHandled(this, default(T));
            }
        }
    }
}