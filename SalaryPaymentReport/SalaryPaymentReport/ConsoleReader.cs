using System;

namespace SalaryPaymentReport
{
    internal class ConsoleReader : IConsoleReadable
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}