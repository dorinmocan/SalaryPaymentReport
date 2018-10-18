using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

namespace SalaryPaymentReport
{
    public class Program
    {
        public enum InputType
        {
            File = 1,
            Args = 2,
            Console = 3
        }

        static void Main(string[] args)
        {
            InputType inputType = GetInputType(args);

            string input = GetInput(inputType, args);

            string logFilePath = ConfigurationManager.AppSettings["logFilePath"];
            ParsedData parsedData = ParseInput(new InputParser(input, new Logger(logFilePath)));

            string report = GenerateReport(new ReportGenerator(parsedData));

            EventHandler<ReportHandlerEventArgs> listeners = null;
            listeners += new ConsoleDisplayer().Display;
            string outputFilePath = ConfigurationManager.AppSettings["outputFilePath"];
            listeners += new FileWriter(outputFilePath).Write;

            HandleReport(new ReportHandler(report), listeners);

            Console.WriteLine("Press any key to exit the program...");
            Console.ReadLine();
        }

        private static InputType GetInputType(string[] args)
        {
            
            if (args.Length == 0)
            {
               return InputType.Console;
            }

            switch (args[0])
            {
                case "F":
                    return InputType.File;

                case "I":
                    return InputType.Args;

                default:
                    throw new ArgumentException("Invalid console arguments");
            }
        }

        private static string GetInput(InputType inputType, string[] args)
        {
            switch (inputType)
            {
                case InputType.File:
                    string filePath = args[1].Trim(new char[] { '"' });
                    return GetInputFromFile(new FileReader(filePath));

                case InputType.Args:
                    return GetInputFromArgs(args);

                case InputType.Console:
                    return GetInputFromConsole(new ConsoleReader());

                default:
                    throw new ArgumentException("Invalid value for parameter " + nameof(inputType));
            }
        }

        private static string GetInputFromFile(IFileReadable fileReader)
        {
            return fileReader.Read();
        }

        private static string GetInputFromConsole(IConsoleReadable consoleReader)
        {
            return consoleReader.Read();
        }

        private static string GetInputFromArgs(string[] args)
        {
            return args[1].Trim(new char[] { '"' });
        }

        private static T ParseInput<T>(IInputParseable<T> inputParser)
        {
            return inputParser.Parse();
        }

        private static string GenerateReport(IReportGeneratable reportGenerator)
        {
            return reportGenerator.GenerateReport();
        }

        private static void HandleReport<T>(Handler<T> reportHandler, params EventHandler<T>[] listeners)
        {
            foreach (var listener in listeners)
            {
                reportHandler.Handled += listener;
            }

            reportHandler.Handle();
        }
    }
}
