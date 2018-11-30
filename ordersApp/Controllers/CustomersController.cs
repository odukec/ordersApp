using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ordersApp.Models;

using Microsoft.AspNetCore.Authorization;

namespace ordersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DAL.AppContext _context;

        public CustomersController(DAL.AppContext context)
        {
            _context = context;
            //if (_context.Customer.Count() == 0)
            //{
            //    var Customers = new List<Customer>
            //    {
            //        new Customer { NameCustomer = "Pedro", SurnameCustomer = "Perez", PhoneNumber = "+57 342342323"},
            //        new Customer { NameCustomer = "Andres", SurnameCustomer = "Gomez", PhoneNumber = "+57 3498345-3"},
            //        new Customer { NameCustomer = "Pepe", SurnameCustomer = "Soto", PhoneNumber = "+57 349897544"},
            //        new Customer { NameCustomer = "Rosa", SurnameCustomer = "Gomez", PhoneNumber = "+57 344356783"}
            //    };

            //    Customers.ForEach(c => context.Customer.Add(c));
            //    context.SaveChanges();

            //    var Orders = new List<Order>
            //    {
            //        new Order { IdCustomer = Customers[0].IdCustomer, DateOrder = DateTime.Now.AddDays(-4), Description="Impresion 1000 Tarjetas" },
            //        new Order { IdCustomer = Customers[2].IdCustomer, DateOrder = DateTime.Now.AddDays(1), Description="Impresion 2000 Tarjetas" },
            //        new Order { IdCustomer = Customers[1].IdCustomer, DateOrder = DateTime.Now.AddDays(-2), Description="Impresion 3000 Tarjetas" },
            //        new Order { IdCustomer = Customers[0].IdCustomer, DateOrder = DateTime.Now.AddDays(-8), Description="Impresion 4000 Tarjetas" }
            //    };
            //    Orders.ForEach(o => context.Order.Add(o));
            //    context.SaveChanges();
            //}
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<Customer>> GetAll()
        {
            return _context.Customer.ToList();
        }

        [Authorize]
        [HttpGet("{id}", Name = "GetCustomer")]
        public ActionResult<Customer> GetById(int id)
        {
            var item = _context.Customer.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [Authorize]
        [HttpPost]
        public ActionResult<Customer> CreateCustomer(Customer customer)
        {
            if(_context.Customer.Find(customer.IdCustomer) != null)
            {
                return Ok();
            }
            _context.Customer.Add(customer);
            _context.SaveChanges();

            return CreatedAtRoute("GetCustomer", new Customer { IdCustomer = customer.IdCustomer }, customer);
        }

        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<Customer> UpdateCustomer(int id, Customer customer)
        {
            var item = _context.Customer.Find(id);
            if( item == null)
            {
                return NotFound();
            }
            item.NameCustomer = customer.NameCustomer;
            item.PhoneNumber = customer.PhoneNumber;
            item.SurnameCustomer = customer.SurnameCustomer;

            _context.Customer.Update(item);
            _context.SaveChanges();

            return item;
        }

        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult<Customer> DeleteCustomer(int id)
        {
            var item = _context.Customer.Find(id);
            if( item == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(item);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
