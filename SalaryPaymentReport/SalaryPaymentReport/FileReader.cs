namespace SalaryPaymentReport
{
    internal class FileReader : IFileReadable
    {
        private readonly string _filePath;

        public FileReader(string filePath)
        {
            _filePath = filePath ?? throw new System.ArgumentException("Invalid value for parameter " + nameof(filePath));
        }

        public string Read()
        {
            return System.IO.File.ReadAllText(_filePath);
        }
    }
}