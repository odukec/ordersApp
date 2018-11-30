using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordersApp.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer Add(Customer item)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int customerID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();
            string query = string.Format("SELECT * FROM 'Customer'");

            
            return customers.ToArray();
        }

        public void Remove(string customerID)
        {
            throw new NotImplementedException();
        }

        public bool Update(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
