

using Modelo; 
using System.Collections.Generic;
using System.Linq;

namespace Repository 
{
    public class CustomerRepository
    {
        public List<Customer> GetAllCustomers()
        {
            return CustomerData.Customers;
        }

        public Customer GetCustomerById(int id)
        {
            return CustomerData.Customers.FirstOrDefault(c => c.Id == id);
        }

        public void AddCustomer(Customer customer)
        {
            customer.Id = (CustomerData.Customers.Any() ? CustomerData.Customers.Max(c => c.Id) : 0) + 1;
            CustomerData.Customers.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            var existingCustomer = GetCustomerById(customer.Id);
            if (existingCustomer != null)
            {
                existingCustomer.Name = customer.Name;
                existingCustomer.HomeAddress = customer.HomeAddress;
                existingCustomer.WorkAddress = customer.WorkAddress;
            }
        }

        public void DeleteCustomer(int id)
        {
            var customerToRemove = GetCustomerById(id);
            if (customerToRemove != null)
            {
                CustomerData.Customers.Remove(customerToRemove);
            }
        }

        public List<Customer> RetrieveAll()
        {
            throw new NotImplementedException();
        }

        public void Save(Customer c)
        {
            throw new NotImplementedException();
        }

        public Customer Retrieve(int value)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int value)
        {
            throw new NotImplementedException();
        }
    }
}