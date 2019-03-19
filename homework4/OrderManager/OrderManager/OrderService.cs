using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    class OrderService
    {
        List<Order> allOrder = new List<Order>();
        List<Order> result;
        int serialnumber = 0;
        public List<Order> AllOrder { get => allOrder; set => allOrder = value; }
        public List<Order> Result { get => result; set => result = value; }

        public void AddOrder(int pro_amount, string pro_name, string cus_name)
        {
            allOrder.Add(new Order(Convert.ToString(serialnumber),pro_name,cus_name,pro_amount));
            serialnumber++;
        }
       
        public void SearchBypName(string pname)
        {
            Result = allOrder.Where(o=>o.Product_name==pname).ToList();
            if (Result.Count() == 0)
                throw new SearchException("没有找到结果");
        }

        public void SearchBycName(string cname)
        {
           
                Result = allOrder.Where(o => o.Customer_name == cname).ToList();
                if (Result.Count() == 0)
                    throw new SearchException("没有找到结果");
           

        }

        public void SearchByNo(string no)
        {
            Result = allOrder.Where(o => o.Order_no == no).ToList();
            if (Result.Count() == 0)
                throw new SearchException("没有找到结果");
        }

        public string[] Delete(int deleteno)
        {
            string []s = new string[2];
            for(int i = 0; i < AllOrder.Count(); i++)
            {
                if(int.Parse(AllOrder[i].Order_no) == deleteno)
                {
                    s[0] = AllOrder[i].Product_name;
                    s[1] = Convert.ToString(AllOrder[i].Product_amount);
                    AllOrder.RemoveAt(i);
                    break;
                }
                if (i == AllOrder.Count - 1)
                    throw new SearchException("不存在该订单号，删除失败!");
            }
            return s;
        }

        public void ChangecName(int modifyno, string newname)
        {
            for(int i = 0; i < AllOrder.Count; i++)
            {
                if(AllOrder[i].Order_no == Convert.ToString(modifyno))
                {
                    AllOrder[i].Customer_name = newname;
                    break;
                }
            }
            return;
        }

        public void ChangepName(int modifyno, string newname)
        {
            for (int i = 0; i < AllOrder.Count; i++)
            {
                if (AllOrder[i].Order_no == Convert.ToString(modifyno))
                {
                    AllOrder[i].Product_name = newname;
                    break;
                }
            }
            return;
        }

        public int searchtype(int modifyno)
        {
            int producttype = -1;
            for (int i = 0; i < AllOrder.Count; i++)
            {
                if (AllOrder[i].Order_no == Convert.ToString(modifyno))
                {
                    switch (AllOrder[i].Product_name)
                    {
                        case "芒果": producttype = 0; break;
                        case "苹果": producttype = 1; break;
                        case "西瓜": producttype = 2; break;
                        case "香梨": producttype = 3; break;
                        case "李子": producttype = 4; break;
                        case "番茄": producttype = 5; break;
                        case "香蕉": producttype = 6; break;
                        case "橘子": producttype = 7; break;
                        case "橙子": producttype = 8; break;
                    }
                }
            }
            return producttype;
        }

        public void ChangeAmount(int modifyno, int newamount)
        {
            for (int i = 0; i < AllOrder.Count; i++)
            {
                if (AllOrder[i].Order_no == Convert.ToString(modifyno))
                {
                    AllOrder[i].Product_amount = newamount;
                    break;
                }
            }
            return;
        }

        public int searchAmount(int modifyno)
        {
            for (int i = 0; i < AllOrder.Count; i++)
            {
                if (AllOrder[i].Order_no == Convert.ToString(modifyno))
                {
                    return AllOrder[i].Product_amount;
                }
            }
            return 0;
        }


        public void Show()
        {
            Console.WriteLine("订单号\t客户姓名\t商品名称\t商品数目");
            for (int i = 0; i < allOrder.Count(); i++)
            {
                Console.WriteLine(allOrder[i].Order_no + "\t" + allOrder[i].Customer_name + "\t\t" + allOrder[i].Product_name + "\t\t" + allOrder[i].Product_amount);
            }
            return;
        }
        public void ShowResult()
        {
            Console.WriteLine("搜索结果如下:");
            Console.WriteLine("订单号\t客户姓名\t商品名称\t商品数目");
            for (int i = 0; i < Result.Count(); i++)
            {
                Console.WriteLine(Result[i].Order_no + "\t" + Result[i].Customer_name + "\t\t" + Result[i].Product_name + "\t\t" + Result[i].Product_amount);
            }
            return;
        }


    }
}
