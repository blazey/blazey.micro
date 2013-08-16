namespace Blazey.Micro.Tests.doubles
{
    public class Employee
    {

        public Employee(string name, NationalInsuranceNumber nationalInsuranceNumber)
        {
            Name = name;
            NationalInsuranceNumber = nationalInsuranceNumber;
        }

        public Employee()
        {
        }

        public string Name { get; set; }
        public NationalInsuranceNumber NationalInsuranceNumber { get; set; }
    }
}