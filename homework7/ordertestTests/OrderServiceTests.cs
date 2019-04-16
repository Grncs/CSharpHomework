using Microsoft.VisualStudio.TestTools.UnitTesting;
using ordertest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void OrderServiceAddTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");
            Goods milk = new Goods(1, "Milk", 69.9f);
            Goods eggs = new Goods(2, "eggs", 4.99f);
            Goods apple = new Goods(3, "apple", 5.59f);

            Order order1 = new Order(1, customer1);
            order1.AddDetails(new OrderDetail(apple, 8));
            order1.AddDetails(new OrderDetail(eggs, 10));

            order1.AddDetails(new OrderDetail(milk, 10));

            Order orderfail = new Order(3, customer1);
            orderfail.AddDetails(new OrderDetail(apple,20));

            OrderService orderService = new OrderService();
 
            orderService.AddOrder(order1);
            Assert.AreEqual(order1,orderService.QueryAll()[0]);
            try
            {
                orderService.AddOrder(orderfail);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            //Assert.Fail();
        }
        [TestMethod()]
        public void OrderServiceRemoveTest()
        {
            OrderServiceAddTest();
            Customer customer1 = new Customer(1, "Customer1");
            Goods eggs = new Goods(2, "eggs", 4.99f);
            Goods apple = new Goods(3, "apple", 5.59f);
            Order order1 = new Order(1, customer1);
            order1.AddDetails(new OrderDetail(apple, 8));
            order1.AddDetails(new OrderDetail(eggs, 10));
            OrderService orderService = new OrderService();
            orderService.AddOrder(order1);
            orderService.RemoveOrder(1);
            Assert.AreEqual(0, orderService.QueryAll().Count);
            try
            {
                orderService.RemoveOrder(1);
                Assert.Fail();
            }
            catch (Exception)
            {
                ;
            }
            try
            {
                orderService.RemoveOrder(2);
                Assert.Fail();
            }
            catch (Exception)
            {
                ;
            }
            orderService.AddOrder(order1);
            Assert.AreEqual(order1, orderService.QueryAll()[0]);
        }
        [TestMethod()]
        public void OrderServiceUpdateTest()
        {
            OrderServiceAddTest();
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");
            Goods milk = new Goods(1, "Milk", 69.9f);
            Goods eggs = new Goods(2, "eggs", 4.99f);
            Goods apple = new Goods(3, "apple", 5.59f);
            Order order1 = new Order(1, customer1);
            order1.AddDetails(new OrderDetail(apple, 8));
            order1.AddDetails(new OrderDetail(eggs, 10));
            order1.AddDetails(new OrderDetail(milk, 10));
            Order order1_1 = new Order(1, customer2);
            Order order2 = new Order(2, customer1);
            order2.AddDetails(new OrderDetail());
            order1_1.AddDetails(new OrderDetail());
            
            OrderService orderService = new OrderService();
            orderService.AddOrder(order1);
            orderService.Update(order1_1);
            Assert.AreEqual(order1_1, orderService.QueryAll()[0]);
            orderService.AddOrder(order2);
            Assert.AreEqual(order2, orderService.QueryAll()[1]);
        }
        [TestMethod()]
        public void OrderServiceGetByIdTest()
        {
            OrderServiceAddTest();
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");
            Goods milk = new Goods(1, "Milk", 69.9f);
            Goods eggs = new Goods(2, "eggs", 4.99f);
            Goods apple = new Goods(3, "apple", 5.59f);
            Order order1 = new Order(1, customer1);
            order1.AddDetails(new OrderDetail(apple, 8));
            order1.AddDetails(new OrderDetail(eggs, 10));
            order1.AddDetails(new OrderDetail(milk, 10));
            Order order2 = new Order(2, customer2);
            Order order3 = new Order(3, customer1);
            order2.AddDetails(new OrderDetail());
            order3.AddDetails(new OrderDetail());
            OrderService orderService = new OrderService();
            orderService.AddOrder(order2);
            orderService.AddOrder(order1);
            orderService.AddOrder(order3);
            Assert.AreEqual(order1, orderService.GetById(1));
            Assert.AreEqual(null, orderService.GetById(4));
            Assert.AreEqual(order2, orderService.GetById(2));
        }

        [TestMethod()]
        public void OrderServiceQueryByGoodsNameTest()
        {
            OrderServiceAddTest();
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");
            Goods milk = new Goods(1, "Milk", 69.9f);
            Goods eggs = new Goods(2, "eggs", 4.99f);
            Goods apple = new Goods(3, "apple", 5.59f);
            Order order1 = new Order(1, customer1);
            Order order1_1 = new Order(4, customer2);
            Order order2 = new Order(2, customer2);
            Order order3 = new Order(3, customer1);
            order1.AddDetails(new OrderDetail(apple,8));
            order1_1.AddDetails(new OrderDetail(apple, 15));
            order2.AddDetails(new OrderDetail(eggs,10));
            order3.AddDetails(new OrderDetail(milk,10));
            OrderService orderService = new OrderService();
            orderService.AddOrder(order2);
            orderService.AddOrder(order1);
            orderService.AddOrder(order1_1);
            orderService.AddOrder(order3);
            Assert.IsTrue(orderService.QueryByGoodsName("apple").Contains(order1));
            Assert.IsTrue(orderService.QueryByGoodsName("apple").Contains(order1_1));
            Assert.IsTrue(orderService.QueryByGoodsName("eggs").Contains(order2));
            Assert.AreEqual(order3, orderService.QueryByGoodsName("Milk")[0]);
            Assert.AreEqual(0, orderService.QueryByGoodsName("lipeizhang").Count);
        }

        [TestMethod()]
        public void OrderServiceQueryByCustomerNameTest()
        {
            OrderServiceAddTest();
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");
            Customer customer3 = new Customer(3, "Customer3");
            Customer customer4 = new Customer(4, "Customer4");
            Customer customer5 = new Customer(5, "Customer5");
            Goods milk = new Goods(1, "Milk", 69.9f);
            Goods eggs = new Goods(2, "eggs", 4.99f);
            Goods apple = new Goods(3, "apple", 5.59f);
            Order order1 = new Order(1, customer1);
            Order order1_1 = new Order(6, customer1);
            Order order2 = new Order(2, customer2);
            Order order3 = new Order(3, customer3);
            Order order4 = new Order(4, customer4);
            Order order5 = new Order(5, customer5);
            order1.AddDetails(new OrderDetail(apple, 8));
            order1_1.AddDetails(new OrderDetail(apple, 15));
            order2.AddDetails(new OrderDetail(eggs, 10));
            order3.AddDetails(new OrderDetail(milk, 10));
            order4.AddDetails(new OrderDetail());
            order5.AddDetails(new OrderDetail());
            OrderService orderService = new OrderService();
            orderService.AddOrder(order2);
            orderService.AddOrder(order1);
            orderService.AddOrder(order1_1);
            orderService.AddOrder(order3);
            orderService.AddOrder(order4);
            orderService.AddOrder(order5);
            Assert.IsTrue(orderService.QueryByCustomerName("Customer1").Contains(order1));
            Assert.IsTrue(orderService.QueryByCustomerName("Customer1").Contains(order1_1));
            Assert.IsTrue(orderService.QueryByCustomerName("Customer2").Contains(order2));
            Assert.AreEqual(order3, orderService.QueryByCustomerName("Customer3")[0]);
            Assert.AreEqual(0, orderService.QueryByCustomerName("lipeizhang").Count);
        }
        [TestMethod()]
        public void OrderServiceQueryByTotalAmountTest()
        {
            OrderServiceAddTest();
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");
            Goods milk = new Goods(1, "Milk", 69.9f);
            Goods eggs = new Goods(2, "eggs", 4.99f);
            Goods apple = new Goods(3, "apple", 5.59f);
            Order order1 = new Order(1, customer1);
            order1.AddDetails(new OrderDetail(milk, 10));
            Order order2 = new Order(2, customer2);
            order2.AddDetails(new OrderDetail(eggs, 10));
            order2.AddDetails(new OrderDetail(apple, 10));
            Order order3 = new Order(3, customer1);
            order3.AddDetails(new OrderDetail(apple,1));
            OrderService orderService = new OrderService();
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            orderService.AddOrder(order3);
            Assert.IsTrue(orderService.QueryByTotalAmount(699).Contains(order1));
            Assert.IsFalse(orderService.QueryByTotalAmount(699).Contains(order2));
            Assert.IsTrue(orderService.QueryByTotalAmount(5.59f).Contains(order1));
            Assert.IsTrue(orderService.QueryByTotalAmount(5.59f).Contains(order2));
            Assert.IsTrue(orderService.QueryByTotalAmount(5.59f).Contains(order3));
        }
    }
}