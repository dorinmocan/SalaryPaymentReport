using System;

namespace SalaryPaymentReport
{
    internal class Logger : ILogger
    {
        private readonly string _filePath;

        public Logger(string filePath)
        {
            _filePath = filePath ?? throw new ArgumentException("Invalid value for parameter " + nameof(filePath));
        }

        public void Log(string logMessage)
        {
            System.IO.File.AppendAllText(_filePath, logMessage);
        }
    }
}
