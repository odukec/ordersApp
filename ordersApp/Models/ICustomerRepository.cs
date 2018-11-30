using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordersApp.Models
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer Get(int customerID);
        Customer Add(Customer item);
        void Remove(string customerID);
        bool Update(Customer item);
    }
}
