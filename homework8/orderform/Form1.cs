using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace orderform
{
    using ordertest;
    public partial class Form1 : Form
    {
        OrderService orderService;
        List<Goods> allgoods;
        List<Order> el = new List<Order>();
        public Form1()
        {
            InitializeComponent();
            try
            {
                Customer customer1 = new Customer(1, "Customer1");
                Customer customer2 = new Customer(2, "Customer2");

                Goods milk = new Goods(1, "Milk", 69.9f);
                Goods eggs = new Goods(2, "eggs", 4.99f);
                Goods apple = new Goods(3, "apple", 5.59f);

                allgoods = new List<Goods>();

                allgoods.Add(milk);
                allgoods.Add(eggs);
                allgoods.Add(apple);

                Order order1 = new Order(1, customer1);
                order1.AddDetails(new OrderDetail(apple, 8));
                order1.AddDetails(new OrderDetail(eggs, 10));
                // order1.AddDetails(new OrderDetail(eggs, 8));
                order1.AddDetails(new OrderDetail(milk, 10));

                Order order2 = new Order(2, customer2);
                order2.AddDetails(new OrderDetail(eggs, 10));
                order2.AddDetails(new OrderDetail(milk, 10));

                Order order3 = new Order(3, customer2);
                order3.AddDetails(new OrderDetail(milk, 100));

                orderService = new OrderService();
                orderService.AddOrder(order1);
                orderService.AddOrder(order2);
                orderService.AddOrder(order3);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            bindingSource1.DataSource = orderService.QueryAll();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
                if (e.Value != null) return;
                try
                {
                    var dgv = (DataGridView)sender;
                    object obj = null;
                    var source = dgv.DataSource as BindingSource;
                    if (source != null)
                    {
                        obj = ((IEnumerable<object>)source.DataSource).ElementAt(e.RowIndex);
                    }
                    else if (dgv.DataSource is IEnumerable<object>)
                    {
                        obj = ((IEnumerable<object>)dgv.DataSource).ElementAt(e.RowIndex);
                    }
                    var col = dgv.Columns[e.ColumnIndex];
                    var prop = col.DataPropertyName;
                    if (prop == "Detail")
                    {
                    if (obj == null) return;
                    var p1 = obj.GetType().GetProperty("Details");
                    if (p1 == null) return;
                    obj = p1.GetValue(obj, null);
                    string result = "";
                    int count;
                    var obj2 = obj as List<OrderDetail>;
                    count = obj2.Count();
                    
                   
                    foreach(OrderDetail od in obj2)
                    {
                        result += od.ToString();
                        result += "\n";
                    }
                    Console.WriteLine(result);
                    e.Value = result;
                    return;
                }
                    if (obj == null) return;
                    var p = obj.GetType().GetProperty(prop);
                    if (p == null) return;
                    obj = p.GetValue(obj, null);
                    e.Value = obj;
                }
                catch
                {
                    //ignore
                }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int key;
            try
            {
                key = Convert.ToInt16(textBox1.Text);
            }
            catch
            {
                key = -1;
            }
            Order res = orderService.GetById(key);
            List<Order> resp = new List<Order>();
            resp.Add(res);
            bindingSource1.DataSource = resp;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Order>res = orderService.QueryByCustomerName(this.textBox2.Text);
            bindingSource1.DataSource = res;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = "";
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            this.textBox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Order> res = orderService.QueryByGoodsName(textBox3.Text);
            bindingSource1.DataSource = res;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(allgoods);

            if (f2.ShowDialog() == DialogResult.OK)
            {
                bindingSource1.DataSource = el;
                try
                {
                    Order neworder = f2.neworder;
                    OrderDetail orderDetail = f2.orderDetail;
                    neworder.AddDetails(orderDetail);
                    if (orderService.QueryAll().Contains(neworder))
                    {
                        
                        orderService.GetById(neworder.Id).AddDetails(orderDetail);
                        MessageBox.Show("为" + neworder.Id + "号订单添加明细成功");
                        bindingSource1.DataSource = orderService.QueryAll();
                        return;
                    }
                    orderService.AddOrder(neworder);
                    MessageBox.Show("创建订单成功");
                     Console.WriteLine(neworder + " " + orderDetail);
                    bindingSource1.DataSource = orderService.QueryAll();
                }
                catch
                {
                    MessageBox.Show("创建订单或增加明细失败");
                    bindingSource1.DataSource = orderService.QueryAll();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = el;
            List<Order> res = orderService.QueryAll();
            bindingSource1.DataSource = res;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int key;
            try
            {
                key = Convert.ToInt16(textBox4.Text);
            }
            catch
            {
                key = -1;
                MessageBox.Show("删除失败");
                return;
            }
            bindingSource1.DataSource = el;
            orderService.RemoveOrder(key);
            MessageBox.Show("已尝试删除");
            bindingSource1.DataSource = orderService.QueryAll();
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int value;
            try
            {
                value = Convert.ToInt16(textBox5.Text);
                if(value <= 0)
                {
                    MessageBox.Show("商品价格必须大于0");
                    return;
                }
            }
            catch
            {
                value = -1;
                MessageBox.Show("删除失败");
                return;
            }
            string name;
            name = textBox6.Text;
            if(name == "")
            {
                MessageBox.Show("商品名不可为空");
                return;
            }
            Goods a = new Goods(1111, name, value);
            if (allgoods.Contains(a))
            {
                MessageBox.Show("已存在此商品");
                return;
            }
            allgoods.Add(a);
            MessageBox.Show("添加商品成功");
        }
    }
}
