using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    
    class OrderDetails
    {
       static  string[] productType = { "芒果", "苹果",  "西瓜", "香梨", "李子","番茄" , "香蕉" , "橘子" , "橙子"};
       int[] rest = { 200, 200, 200, 200, 200, 200, 200, 200, 200 };

        public static string[] ProductType { get => productType; set => productType = value; }
        public int[] Rest { get => rest; set => rest = value; }


        public void showalltype()
        {
            Console.WriteLine("商品编号\t商品名称\t商品剩余数目");
            for (int i = 0; i < rest.Count(); i++)
            {
                Console.WriteLine(i + ".\t\t" + productType[i]+"\t\t" + rest[i]);
            }
            return;
        }
       
    }
}
