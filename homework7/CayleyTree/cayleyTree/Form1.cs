using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cayleyTree
{
    public partial class CayleyTree : Form
    {
        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        int times = 10;
        int color = 0;
        public CayleyTree()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            graphics.Clear(Color.White);
            drawCayleyTree(times, 200, 310, 100, -Math.PI / 2);
        }

        void drawCayleyTree(int n, 
            double x0,double y0,double leng,double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }

        void drawLine(double x0, double y0, double x1, double y1)
        {
            switch (color) {
                case 0: graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);break;
                case 1: graphics.DrawLine(Pens.Red, (int)x0, (int)y0, (int)x1, (int)y1); break;
                case 2: graphics.DrawLine(Pens.Green, (int)x0, (int)y0, (int)x1, (int)y1); break;
                case 3: graphics.DrawLine(Pens.RoyalBlue, (int)x0, (int)y0, (int)x1, (int)y1); break;
                case 4: graphics.DrawLine(Pens.Purple, (int)x0, (int)y0, (int)x1, (int)y1); break;
                default: graphics.DrawLine(Pens.Red, (int)x0, (int)y0, (int)x1, (int)y1); break;
            }
        }

     

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }


        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                per1 = System.Convert.ToDouble(textBox1.Text);
                if (per1 > 2)
                    throw new Exception();
            }
            catch(Exception)
            {
                per1 = 0.6;
            }
            try
            {
                per2 = System.Convert.ToDouble(textBox2.Text);
                if (per2 > 2)
                    throw new Exception();
            }
            catch(Exception)
            {
                per2 = 0.7;
            }
            try
            {
                th1 = System.Convert.ToDouble(textBox3.Text);
                if (th1 >= 361)
                    throw new Exception();
                th1 = th1 * Math.PI / 180;
            }
            catch (Exception)
            {
                th1 = 30 * Math.PI / 180;
            }
            try
            {
                th2 = System.Convert.ToDouble(textBox3.Text);
                if (th2 >= 361)
                    throw new Exception();
                th2 = th2 * Math.PI / 180;
            }
            catch (Exception)
            {
                th2 = 20 * Math.PI / 180;
            }
            try
            {
                times = System.Convert.ToInt16(textBox5.Text);
                if (times >= 21)
                    throw new Exception();
            }
            catch (Exception)
            {
                times = 10;
            }
            try
            {
                string s = "";
                s = (string)listBox1.Text;
                switch(s){
                    case "blue":color = 0;break;
                    case "red": color = 1;break;
                    case "green":color = 2;break;
                    case "royalblue": color = 3; break;
                    case "purple": color = 4; break;
                    default:color = 1; break;
                }
            }
            catch (Exception)
            {
                color = 1;
            }
        }

        
    }
}
