namespace SalaryPaymentReport
{
    internal interface IEmployeeValidatable
    {
        bool IsValidEmployeeId(uint id);
        bool IsValidFirstName(string firstName);
        bool IsValidLastName(string lastName);
    }
}