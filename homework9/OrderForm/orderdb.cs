using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ordertest;

namespace OrderForm
{
    public class OrderDB : DbContext
    {
        public OrderDB() : base("order")
        {
        }
        public DbSet<Order> Order { get; set; }

        public DbSet<OrderDetail> OrderItem { get; set; }

    }
}
