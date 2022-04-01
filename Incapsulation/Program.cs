using Incapsulation.Data.Entities;
using Incapsulation.Data.Specifications;
using Incapsulation.Data.Storages;

var customerStorage = new DataStorage<Customer>();
customerStorage.AddEntity(new Customer()
{
    Id = 1,
    Name = "Andrey",
    Age = 26
});

var cust = customerStorage.GetById(10);
if (cust != null)
{
    cust.Name = "new name";
    _ = customerStorage.UpdateCustomer(cust.Id, cust); 
}

var orderStorage = new OrderStorage();

var age10Spec = new CustomerByAgeSpecification(10);
var age10Customers = customerStorage.GetBySpecification(age10Spec);

var age26Spec = new CustomerByAgeSpecification(26);
var age26Customers = customerStorage.GetBySpecification(age26Spec);

var nameSpec = new CustomerByNameSpecification("andrey");
var customersByName = customerStorage.GetBySpecification(nameSpec);

Console.WriteLine(customersByName.Length);
