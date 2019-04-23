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
    public partial class Form2 : Form
    {
        public List<Goods> allgoods;
        public Order neworder;
        public OrderDetail orderDetail;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(List<Goods> gg)
        {
            allgoods = new List<Goods>();
            allgoods = gg;
            InitializeComponent();
            foreach (Goods g in allgoods)
                this.listBox1.Items.Add(g.Name);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(this.textBox1.Text);
                string name = this.textBox2.Text;
                uint quantity = Convert.ToUInt32(this.textBox4.Text);
                neworder = new Order(id, new Customer(1, name));
                orderDetail = new OrderDetail(allgoods[listBox1.SelectedIndex], quantity);
                Console.WriteLine(orderDetail);
            }
            catch
            {
               
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
