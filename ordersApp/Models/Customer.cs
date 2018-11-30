using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordersApp.Models
{
    public class Customer
    {
        public int IdCustomer { get; set; }
        public String NameCustomer { get; set; }
        public String SurnameCustomer { get; set; }
        public String PhoneNumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
