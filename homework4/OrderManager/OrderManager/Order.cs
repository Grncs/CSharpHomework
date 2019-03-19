using System;

namespace OrderManager
{

    public class Order
    {
        int product_amount;
        string order_no;
        string product_name;
        string customer_name;

        public string Customer_name { get => customer_name; set => customer_name = value; }
        public string Product_name { get => product_name; set => product_name = value; }
        public string Order_no { get => order_no; set => order_no = value; }
        public int Product_amount { get => product_amount; set => product_amount = value; }

        public Order(string order_number, string pro_name, string cus_name, int amount)
        {
            product_amount = amount;
            Order_no = order_number;
            product_name = pro_name;
            Customer_name = cus_name;
        }
        public Order()
        {
            product_amount = 0;
            Order_no = null;
            product_name = null;
            Customer_name = null;
        }
    }
}