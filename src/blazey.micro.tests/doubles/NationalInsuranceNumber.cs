namespace Blazey.Micro.Tests.doubles
{
    public class NationalInsuranceNumber
    {
        public NationalInsuranceNumber(string value)
        {
            Value = value;
        }

        public NationalInsuranceNumber()
        {
            
        }

        public string Value { get; set; }
    }
}