using Blazey.Micro.Tests.doubles;
using NUnit.Framework;
using blazey.micro;

namespace Blazey.Micro.Tests
{
    public class when_employee_is_created_from_complex_anermic_type : context_specification
    {
        private Employee _employee;
        private Employee _actual;

        protected override void Arrange()
        {
            _employee = new Employee
                {
                    Name = "Edward",
                    NationalInsuranceNumber = new NationalInsuranceNumber {Value = "NationalInsuranceNumber"}
                };
        }

        protected override void Act()
        {
            _actual = new ModelActivator().Activate<Employee>(_employee);
        }

        [Test]
        public void should_not_throw_exception()
        {
            Assert.That(Exception, Is.Null);
        }

        [Test]
        public void should_have_name()
        {
            Assert.That(_actual.Name, Is.EqualTo("Edward"));
        }

        [Test]
        public void should_have_national_insurance_number()
        {
            Assert.That(_actual.NationalInsuranceNumber.Value, Is.EqualTo("NationalInsuranceNumber"));
        }


    }
}