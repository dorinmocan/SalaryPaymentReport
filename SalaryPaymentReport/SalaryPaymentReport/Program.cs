using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

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
            ParsedData parsedData = ParseInput(new InputParser<ParsedData>(input, new Logger(logFilePath)));

            Console.ReadLine();
        }

        private static InputType GetInputType(string[] args)
        {
            switch (args[0])
            {
                case "F":
                    return InputType.File;

                case "I":
                    return InputType.Args;

                case "":
                    return InputType.Console;

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

        private static T ParseInput<T>(IInputParsable<T> inputParser)
        {
            return inputParser.Parse();
        }
    }
}
