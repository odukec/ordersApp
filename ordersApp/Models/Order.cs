using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordersApp.Models
{
    public class Order
    {
        public enum StateVal
        {
            ONWAIT, ONTHERUN, PROCESSED 
        }

        public int IdOrder { get; set; }
        public DateTime DateOrder { get; set; }
        public int IdCustomer { get; set; }
        public String Description { get; set; }
        public StateVal? State { get; set; } = StateVal.ONWAIT;

        public virtual Customer Customer { get; set; }
    }
}
