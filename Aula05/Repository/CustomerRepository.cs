using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public class CustomerRepositorycs
    {
        public Customer Retrieve(int id)
        {
            foreach (Customer c in CustumerData.Costumers)
            {
                if (c.Id == id)
                {
                    return c;
                }

            }

            return null;
        }



        public List<Customer> RetrieveByName(string name)
        {
            List<Customer> ret = new List<Customer>();

            foreach(Customer c in CustumerData.Costumers)
            {
                if (c.Name.ToLower().Contains(name.ToLower()))
                  {
                    ret.Add(c);
                  }


            }
            return ret;
        }

        public List<Customer> RetrieveAll()
        {
            return CustumerData.Costumers;
        }


        public void Save(Customer customer)
        {
            customer.Id = GetCount() + 1;
            CustumerData.Costumers.Add(customer);
        }

        public void Delete(Customer customer)
        {
            CustumerData.Costumers.Remove(customer);    
        }

        public void DeleteById(int id)
        {
            Delete (Retrieve(id));
                
        }

        public void Update (Custo newCustomer)
        {
            Customer oldCustomer = Retrieve(newCustomer.Id);
            oldCustomer.Name = newCustomer.Name;
            oldCustomer.WorkAddres = newCustomer.WorkAddress;
            oldCustomer.HomeAddres = newCustomer.HomeAddress;
        }

        public int GetCount()
        {
            return CustumerData.Costumers.Count;
        }
    }
}
