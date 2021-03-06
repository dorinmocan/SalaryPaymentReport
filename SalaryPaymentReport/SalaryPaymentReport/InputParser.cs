﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryPaymentReport
{
    internal class InputParser : IInputParseable<ParsedData>
    {
        private readonly string _input;
        private readonly ILogger _logger;

        public InputParser(string input, ILogger logger)
        {
            _input = input ?? throw new ArgumentException("Invalid value for parameter " + nameof(input));
            _logger = logger;
        }

        public ParsedData Parse()
        {
            var employees = new Dictionary<uint, string>();

            var result = new ParsedData(new List<Employee>(), new List<SalaryTransaction>());

            var transactions = _input.Split(new char[] { ';' });

            foreach (var transaction in transactions)
            {
                var fields = transaction.Split();

                try
                {
                    uint employeeId;
                    if (uint.TryParse(fields[0], out employeeId) == false)
                    {
                        throw new FormatException("Unable to parse employee id");
                    }

                    string firstName = fields[1];

                    string lastName = fields[2];

                    decimal amount;
                    if (decimal.TryParse(fields[3], out amount) == false)
                    {
                        throw new FormatException("Unable to parse amount");
                    }

                    DateTime date = DateTime.ParseExact(fields[4], "dd/mm/yyyy", CultureInfo.InvariantCulture);

                    if (!employees.ContainsKey(employeeId))
                    {
                        result.Item1.Add(new Employee(new EmployeeValidator(), employeeId, firstName, lastName));
                        employees[employeeId] = firstName + " " + lastName;
                    }
                    else if (employees[employeeId] != firstName + " " + lastName)
                    {
                        throw new ArgumentException("Employee id duplicate");
                    }

                    result.Item2.Add(new SalaryTransaction(new SalaryTransactionValidator(new EmployeeValidator()), amount, date, employeeId));
                }
                catch (Exception e)
                {
                    Log(e.Message
                        + Environment.NewLine
                        + e.StackTrace
                        + Environment.NewLine
                        + new string('-', 30)
                        + Environment.NewLine);
                }
            }

            return result;
        }

        private void Log(string message)
        {
            _logger?.Log(message);
        }
    }
}
