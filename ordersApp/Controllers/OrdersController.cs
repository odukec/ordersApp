using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ordersApp.Models;

using Microsoft.AspNetCore.Authorization;

namespace ordersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DAL.AppContext _context;

        public OrdersController(DAL.AppContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<Order>> GetAll()
        {
            return _context.Order.ToList();
        }

        [Authorize]
        [HttpGet("{id}", Name ="GetOrder")]
        public ActionResult<Order> GetById(int id)
        {
            var item = _context.Order.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            return item;
        }

        [Authorize]
        [HttpPost]
        public ActionResult<Order> CreateOrder(Order order)
        {
            if(_context.Order.Find(order.IdOrder) != null)
            {
                return Ok();
            }
            _context.Order.Add(order);
            _context.SaveChanges();

            return order;
        }

        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<Order> UpdateOrder(int id, Order order)
        {
            var item = _context.Order.Find(id);
            if( item == null)
            {
                return NotFound();
            }
            item.State = order.State;
            item.Description = order.Description;

            _context.Order.Update(item);
            _context.SaveChanges();

            return item;
        }

        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult<Order> DeleteOrder(int id)
        {
            var item = _context.Order.Find(id);
            if(item == null)
            {
                return NotFound();
            }

            _context.Order.Remove(item);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
