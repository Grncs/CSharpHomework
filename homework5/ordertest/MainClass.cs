using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*为Order实现了Icomparable接口，实现了Compareto方法进行ID大小的比较。在OrderService中实现了两种排序，sort方法为将orderlist按
 默认比较方法排序，即按ID从小到大排序，而sortmoney则通过lambda表达式调用Order新增的getsum方法用总金额进行比较，并按从小到大的
 顺序排序*/

/*sort方法中添加lambda表达式作为参数时，lambda表达式的参数列表中不能标明类型*/

namespace ordertest {

    class MainClass {
        public static void Main() {
            try
            {
                Customer customer1 = new Customer(1, "Customer1");
                Customer customer2 = new Customer(2, "Customer2");

                Goods milk = new Goods(1, "Milk", 69.9);
                Goods eggs = new Goods(2, "eggs", 4.99);
                Goods apple = new Goods(3, "apple", 5.59);
                Goods computer = new Goods(4, "computer", 1599.9 );

                OrderDetail orderDetails1 = new OrderDetail(1, apple, 8);
                OrderDetail orderDetails1_2 = new OrderDetail(1, apple, 8);
                //检验contains方法能否检查非引用的相同对象

                OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);
                OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);

                OrderDetail orderDetails4 = new OrderDetail(4, computer, 2);
                OrderDetail orderDetails5 = new OrderDetail(5, apple, 6);
                OrderDetail orderDetails6 = new OrderDetail(6, apple, 1);
                /*用于排序的实例*/
                Order order1 = new Order(1, customer1);
                Order order2 = new Order(2, customer2);
                Order order3 = new Order(3, customer2);
                Order order4 = new Order(4, customer1);
                Order order5 = new Order(5, customer2);
                Order order6 = new Order(6, customer1);

                

                order1.AddDetails(orderDetails1);

                /*测试contain方法可检测的类型*/

                Console.WriteLine("try to add orderdetail again");

                try
                { 
                order1.AddDetails(orderDetails1);
                
            }catch(Exception e)
            {
                    Console.WriteLine(e.Message);
            }

                Console.WriteLine("try to add a orderdetail that has the same value to orderdetail1");

                try
                {
                    order1.AddDetails(orderDetails1_2);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                //使用contains方法能够检查出并非相同引用的相同对象，因为重写了equal方法

                

                order1.AddDetails(orderDetails2);
                order1.AddDetails(orderDetails3);

                //order1.AddOrderDetails(orderDetails3);

                order2.AddDetails(orderDetails2);
                order2.AddDetails(orderDetails3);
                order3.AddDetails(orderDetails3);

                order4.AddDetails(orderDetails5);
                order4.AddDetails(orderDetails2);

                order5.AddDetails(orderDetails4);
                order5.AddDetails(orderDetails5);

                order6.AddDetails(orderDetails6);

                OrderService os = new OrderService();
                os.AddOrder(order1);
                os.AddOrder(order5);
                os.AddOrder(order2);
                os.AddOrder(order4);
                os.AddOrder(order3);
                os.AddOrder(order6);
                

                Console.WriteLine("GetAllOrdersWithoutSorting");
                List<Order> orders = os.QueryAllOrders();
                foreach (Order order in orders)
                    Console.WriteLine(order.ToString());
                Console.WriteLine("\n\n\nSortingByOrderId");
                os.sort();
                orders = os.QueryAllOrders();
                foreach (Order order in orders)
                    Console.WriteLine(order.ToString());

                Console.WriteLine("\n\n\nSortingByTotalMoney");
                os.sortmoney();
                orders = os.QueryAllOrders();
                foreach (Order order in orders)
                    Console.WriteLine(order.ToString());

                /*Console.WriteLine("GetOrdersByCustomerName:'Customer2'");
                orders = os.QueryByCustomerName("Customer2");
                foreach (Order order in orders)
                    Console.WriteLine(order.ToString());

                Console.WriteLine("GetOrdersByGoodsName:'apple'");
                orders = os.QueryByGoodsName("apple");
                foreach (Order order in orders)
                    Console.WriteLine(order);
                
                Console.WriteLine("Remove order(id=2) and qurey all");
                os.RemoveOrder(2);
                os.QueryAllOrders().ForEach(
                    od => Console.WriteLine(od));*/

            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
