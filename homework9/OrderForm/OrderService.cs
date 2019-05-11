using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MySql.Data.MySqlClient;
using System.Data.Entity;
using ordertest;

namespace OrderForm {
  /// <summary>
  /// OrderService
  /// </summary>
  public class OrderService {

    //private List<Order> orderList;
    /// <summary>
    /// constructor
    /// </summary>
    public OrderService() {
            //orderList = new List<Order>();
            using (var odb = new OrderDB())
            {
                odb.Database.ExecuteSqlCommand("truncate table orderdetails");
                odb.Database.ExecuteSqlCommand("SET FOREIGN_KEY_CHECKS = 0");
                odb.Database.ExecuteSqlCommand("truncate table orders");
                odb.Database.ExecuteSqlCommand("SET FOREIGN_KEY_CHECKS = 1");
            }
    }
    
    private MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection("datasource=localhost;username=root");
            return connection;
        } 
    /// <summary>
    /// add new order
    /// </summary>
    /// <param name="order">the order to be added</param>
    public void AddOrder(Order order) {
       using(var odb = new OrderDB())
            {
                try
                {
                    odb.Entry(order).State = EntityState.Added;
                    odb.SaveChanges();
                }
                catch
                {
                    ;
                }
            }
      //if (orderList.Contains(order)) {
      //  throw new ApplicationException($"the orderList contains an order with ID {order.Id} !");
      //}
      //orderList.Add(order);
           // using (var db = new OrderDB()) { db.Order.Add(order); db.SaveChanges(); }
        }



    /// <summary>
    /// update the order
    /// </summary>
    /// <param name="order">the order to be updated</param>
    public void Update(Order order) {

            using (var db = new OrderDB())
            {
                Order oldOrder = db.Order.Include("Details").SingleOrDefault(o => o.Id == order.Id);
                db.OrderItem.RemoveRange(oldOrder.Details);
                db.SaveChanges();
            }

            using (var db = new OrderDB())
            {
                foreach (OrderDetail detail in order.Details)
                {
                    db.Entry(detail).State = EntityState.Added;
                }
                
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
            }


            //RemoveOrder(order.Id);
            //orderList.Add(order);
        }





    /// <summary>
    /// query by orderId
    /// </summary>
    /// <param name="orderId">id of the order to find</param>
    /// <returns>List<Order></returns> 
    public Order GetById(int orderId) {
            using(var odb = new OrderDB())
            {
                return odb.Order.FirstOrDefault(o => o.Id == orderId);
            }
      //return orderList.FirstOrDefault(o => o.Id == orderId);
    }

    /// <summary>
    /// remove order
    /// </summary>
    /// <param name="orderId">id of the order which will be removed</param> 
    public void RemoveOrder(int orderId) {
            using (var db = new OrderDB())
            {
                Order oldOrder = db.Order.Include("Details").SingleOrDefault(o => o.Id == orderId);
                db.OrderItem.RemoveRange(oldOrder.Details);
                db.SaveChanges();
            }
        }

    /// <summary>
    /// query all orders
    /// </summary>
    /// <returns>List<Order>:all the orders</returns> 
    public List<Order> QueryAll() {
            using (var odb = new OrderDB())
            {
                return odb.Order.Include("Details").ToList();
            }
    }


    /// <summary>
    /// query by goodsName
    /// </summary>
    /// <param name="goodsName">the name of goods in order's orderDetail</param>
    /// <returns></returns> 
    public List<Order> QueryByGoodsName(string goodsName) {
            using(var odb = new OrderDB())
            {
                return odb.Order.Include("Details").Where(o => o.Details.Where(d => d.Goods.Name.Equals(goodsName)).ToList().Count>0).ToList();
            }
      //var query = orderList.Where(
      //  o => o.Details.Exists(
      //    d => d.Goods.Name == goodsName));
      //return query.ToList();
    }

    /// <summary>
    /// query orders whose totalAmount >= totalAmount
    /// </summary>
    /// <param name="totalAmount">the minimum totalAmount</param>
    /// <returns></returns> 
    public List<Order> QueryByTotalAmount(float totalAmount) {
            using (var odb = new OrderDB())
            {
                return odb.Order.Where(o => o.TotalAmount >= totalAmount).ToList();
            }
      //          var query = orderList.Where(o => o.TotalAmount >= totalAmount);
      //return query.ToList();
    }

    /// <summary>
    /// query by customerName
    /// </summary>
    /// <param name="customerName">customer name</param>
    /// <returns></returns> 
    public List<Order> QueryByCustomerName(string customerName) {
            using (var odb = new OrderDB())
            {
                return odb.Order.Where(o => o.Customer.Equals(customerName)).ToList();
            }
      //      var query = orderList
      //    .Where(o => o.Customer.Name == customerName);
      //return query.ToList();
    }

        //public void Sort(Comparison<Order> comparison) {
        //  orderList.Sort(comparison);
        //}

        /// <summary>
        /// Exprot the orders to an xml file.
        /// </summary>
        public void Export(String fileName)
        {
            if (Path.GetExtension(fileName) != ".xml")
                throw new ArgumentException("the exported file must be a xml file!");
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                using(var odb = new OrderDB())
                {
                  xs.Serialize(fs, odb.Order.ToList());
                }
                
            }
        }

        /// <summary>
        /// import from an xml file
        /// </summary>
        public List<Order> Import(string path)
        {
     if (Path.GetExtension(path) != ".xml")
         throw new ArgumentException($"{path} isn't a xml file!");
         XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
         List<Order> result = new List<Order>();
         try
         {
           using (FileStream fs = new FileStream(path, FileMode.Open))
              {
                    using(var odb = new OrderDB())
                    {
                        odb.Order.AddRange((List<Order>)xs.Deserialize(fs)); 
                    }
               }
                return result;
         }
         catch (Exception e)
         {
           throw new ApplicationException("import error:" + e.Message);
         }

      }

    }
}
