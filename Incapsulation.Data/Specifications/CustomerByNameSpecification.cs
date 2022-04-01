using Incapsulation.Data.Entities;

namespace Incapsulation.Data.Specifications
{
    public class CustomerByNameSpecification : SpecificationBase<Customer>
    {
        private string _name;

        public CustomerByNameSpecification(string specName)
        {
            _name = specName;
        }

        protected override bool CheckSpecification(Customer customer)
        {
            return string.Compare(customer.Name, _name, StringComparison.OrdinalIgnoreCase) == 0;
        }
    }
}
