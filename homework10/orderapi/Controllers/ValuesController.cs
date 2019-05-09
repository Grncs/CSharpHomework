using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using orderapi.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;



using Microsoft.Extensions.DependencyInjection;




namespace orderapi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values/products
        [HttpPost("Products")]
        public void Products(OrderItem orderitem){
        
        using (var db = new OrderItemContext()) {
        db.Entry(orderitem).State = EntityState.Added;
        db.SaveChanges();
      
    }}

        //GET api/values/products/id
        [HttpGet("products/{id}")]
        public OrderItem GetProduct(string id)
        {
            using (var db = new OrderItemContext()) {
                
        return db.OrderItems.Where( o=>o.Id.Equals(id)).ToList()[0];
      }
        }

        //PUT: /api/values/products/id
        [HttpPut("products/{id}")]
        public void PutProduct(string id, OrderItem orderitem)
        {
            orderitem.Id = id;
            using(var db = new OrderItemContext()){
                var order = db.OrderItems.SingleOrDefault(o=>o.Id==id);
                db.Remove(order);
                db.Add(orderitem);
                db.SaveChanges();
            }
        }

        //Delete: /api/values/products/id
        [HttpDelete("products/{id}")]
        public void DeleteProduct(string id)
        {
            using(var db = new OrderItemContext()){
                var order = db.OrderItems.SingleOrDefault(o=>o.Id==id);
                db.Remove(order);

            }
        }



        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
