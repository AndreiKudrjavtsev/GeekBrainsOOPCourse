using Incapsulation.Data.Entities;

namespace Incapsulation.Data.Specifications
{
    public class CustomerByAgeSpecification : SpecificationBase<Customer>
    {
        private int _age;

        public CustomerByAgeSpecification(int specAge)
        {
            _age = specAge;
        }

        protected sealed override bool CheckSpecification(Customer customer)
        {
            return customer.Age == _age;
        }
    }
}
