using System;
using System.Runtime.Remoting.Channels;

namespace SalaryPaymentReport
{
    internal class FileWriter
    {
        private readonly string _filePath;

        public FileWriter(string filePath)
        {
            _filePath = filePath ?? throw new ArgumentException("Invalid value for parameter " + nameof(filePath));
        }

        public void Write(object sender, ReportHandlerEventArgs args)
        {
            System.IO.File.WriteAllText(_filePath, args.Report);
        }
    }
}