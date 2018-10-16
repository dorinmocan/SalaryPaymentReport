using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryPaymentReport
{
    class InputParser<T> : IInputParsable<Tuple<List<Employee>, List<SalaryTransaction>>>
    {
        private readonly string _input;
        private readonly ILogger _logger;

        public InputParser(string input, ILogger logger)
        {
            _input = input ?? throw new ArgumentException("Invalid value for parameter " + nameof(input));
            _logger = logger;
        }

        public Tuple<List<Employee>, List<SalaryTransaction>> Parse()
        {
            var employees = new Dictionary<uint, string>();

            var result = new Tuple<List<Employee>, List<SalaryTransaction>>
            (
                new List<Employee>(),
                new List<SalaryTransaction>()
            );

            var transactions = _input.Split(new char[] { ';' });

            foreach (var transaction in transactions)
            {
                var fields = transaction.Split();

                uint employeeId;
                if (uint.TryParse(fields[0], out employeeId) == false) continue;

                string firstName = fields[1];

                string lastName = fields[2];

                decimal amount;
                if (decimal.TryParse(fields[3], out amount) == false) continue;

                DateTime date;
                if (DateTime.TryParse(fields[4], out date) == false) continue;

                try
                {
                    if (!employees.ContainsKey(employeeId))
                    {
                        result.Item1.Add(new Employee(new EmployeeValidator(), employeeId, firstName, lastName));
                    } else if (employees[employeeId] == firstName+lastName)
                    {

                    }

                    result.Item2.Add(new SalaryTransaction(new SalaryTransactionValidator(new EmployeeValidator()), amount, date, employeeId));
                }
                catch (Exception e)
                {
                    Log(e.Message);
                }
            }

            return result;
        }

        private void Log(string message)
        {
            if (_logger != null)
            {
                _logger.Log();
            }
        }
    }
}
