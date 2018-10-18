using System;

namespace SalaryPaymentReport
{
    internal class Handler<T>
    {
        public virtual event EventHandler<T> Handled;

        public virtual void Handle()
        {
            if (Handled != null)
            {
                Handled(this, default(T));
            }
        }
    }
}