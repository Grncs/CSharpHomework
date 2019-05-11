using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace ordertest {

  /// <summary>
  /// Order class
  /// </summary>
  [Serializable]
  public class Order :IComparable<Order>{

        [Key]
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public float TotalAmount
        {
            get => details.Sum(d => d.Amount);
        }
        public List<OrderDetail> Details
        {
            get => this.details;
        }
        private List<OrderDetail> details = new List<OrderDetail>();

    /// <summary>
    ///  default constructor
    /// </summary>
    public Order() {
    }

    /// <summary>
    ///  constructor
    /// </summary>
    /// <param name="orderId">order id</param>
    /// <param name="customer">who orders goods</param>
    public Order(int orderId, Customer customer) {
      Id = orderId;
      Customer = customer;
    }

        
        
        

    
    

    
    

    /// <summary>
    /// add new orderDetail into the order
    /// </summary>
    /// <param name="orderDetail">the new orderDetail which will be added</param>
    public void AddDetails(OrderDetail orderDetail) {
      if (this.Details.Contains(orderDetail)) {
        throw new Exception($"orderDetail of the goods ({orderDetail.Goods.Name}) exists in order {Id}");
      }
      details.Add(orderDetail);
    }

    public int CompareTo(Order other) {
     if(other==null) return 1;
     return Id - other.Id;
    }

    public override bool Equals(object obj) {
      var order = obj as Order;
      return order != null &&
             Id == order.Id;
    }

    public override int GetHashCode() {
      return 2108858624 + Id.GetHashCode();
    }





    /// <summary>
    /// remove orderDetail by index num
    /// </summary>
    /// <param name="num">number of the orderDetail to be removed</param>
    public void RemoveDetails(int num) {
      details.RemoveAt(num);
    }

    public override string ToString() {
      String result = $"orderId:{Id}, customer:({Customer})";
      details.ForEach(detail => result += "\n\t" + detail);
      return result;
    }


  }
}
