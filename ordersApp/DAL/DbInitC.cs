using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using ordersApp.Models;

namespace ordersApp.DAL
{
    public class DbInitC : System.Data.Entity. DropCreateDatabaseIfModelChanges<AppContext>
    {
        protected override void Seed(DAL.AppContext context)
        {
            var Customers = new List<Customer>
                {
                    new Customer { NameCustomer = "Pedro", SurnameCustomer = "Perez", PhoneNumber = "+57 342342323"},
                    new Customer { NameCustomer = "Andres", SurnameCustomer = "Gomez", PhoneNumber = "+57 3498345-3"},
                    new Customer { NameCustomer = "Pepe", SurnameCustomer = "Soto", PhoneNumber = "+57 349897544"},
                    new Customer { NameCustomer = "Rosa", SurnameCustomer = "Gomez", PhoneNumber = "+57 344356783"}
                };

            Customers.ForEach(c => context.Customer.Add(c));
            context.SaveChanges();

            var Orders = new List<Order>
                {
                    new Order { IdCustomer = Customers[0].IdCustomer, DateOrder = DateTime.Now.AddDays(-4), Description="Impresion 1000 Tarjetas" },
                    new Order { IdCustomer = Customers[2].IdCustomer, DateOrder = DateTime.Now.AddDays(-4), Description="Impresion 2000 Tarjetas" },
                    new Order { IdCustomer = Customers[1].IdCustomer, DateOrder = DateTime.Now.AddDays(-4), Description="Impresion 3000 Tarjetas" },
                    new Order { IdCustomer = Customers[0].IdCustomer, DateOrder = DateTime.Now.AddDays(-4), Description="Impresion 4000 Tarjetas" }
                };
            Orders.ForEach(o => context.Order.Add(o));
            context.SaveChanges();
        }
    }
}
