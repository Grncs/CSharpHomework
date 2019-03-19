using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService sv = new OrderService();
            OrderDetails dt = new OrderDetails();

            //"芒果", "苹果",  "西瓜", "香梨", "李子","番茄" , "香蕉" , "橘子" , "橙子"
            sv.AddOrder(100, "芒果", "刘启");
            dt.Rest[0] -= 100;
            sv.AddOrder(42, "苹果", "韩朵朵");
            dt.Rest[1] -= 42;
            sv.AddOrder(28, "西瓜", "李大壮");
            dt.Rest[2] -= 28;
            sv.AddOrder(79, "香梨", "莫斯");
            dt.Rest[3] -= 79;
            sv.AddOrder(174, "李子", "包租婆");
            dt.Rest[4] -= 174;
            
            int amount = 0;
            int choice = -1;
            int searchchoice = -1;
            int modifychoice = -1;
            int modifyno = -1;
            int producttype = -1;
            int deleteno = -1;
            string ordersearch = "";
            string customername = "";
            string[] s;

            sv.Show();
            while (true)
            {
                Menu();
                while (choice != 0 && choice != 1 && choice != 2 && choice != 3 && choice != 4)
                {
                    Console.Write("选择操作:");
                    try
                    { 
                        choice = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        choice = -1;
                        Console.WriteLine("请选择1、2、3、4或0\n");
                    }
                }
                if (choice == 0)
                    break;
                else
                    switch (choice)
                    {
                        case 1:
                            {
                                try
                                {
                                    dt.showalltype();
                                    Console.Write("请选择商品类型:");
                                    producttype = int.Parse(Console.ReadLine());
                                    if(producttype <0 || producttype > 8)
                                    {
                                        throw new Exception("无此商品类型\n");
                                    }
                                    Console.WriteLine(OrderDetails.ProductType[producttype] + ",请输入数目:");
                                    amount = int.Parse(Console.ReadLine());
                                    if (amount > dt.Rest[producttype])
                                        throw new Exception(OrderDetails.ProductType[producttype]+"的剩余数目不足!");
                                    if (amount < 0)
                                        throw new Exception("输入大于0的整数");
                                    Console.WriteLine(OrderDetails.ProductType[producttype] + amount + "个,请输入客户名称:");
                                    customername = Console.ReadLine();
                                    sv.AddOrder(amount, OrderDetails.ProductType[producttype], customername);
                                    dt.Rest[producttype] -= amount;
                                    Console.WriteLine("添加成功!");
                                }
                                catch (Exception e)
                                {
                                    Console.Write(e.Message);
                                } break; }
                        case 2: { sv.Show();
                                  Console.Write("选择要删除的订单号:");
                                try
                                {
                                    deleteno = int.Parse(Console.ReadLine());
                                    //"芒果", "苹果",  "西瓜", "香梨", "李子","番茄" , "香蕉" , "橘子" , "橙子"
                                    s = sv.Delete(deleteno);
                                    switch (s[0])
                                    {
                                        case "芒果":producttype = 0;break;
                                        case "苹果": producttype = 1; break;
                                        case "西瓜": producttype = 2; break;
                                        case "香梨": producttype = 3; break;
                                        case "李子": producttype = 4; break;
                                        case "番茄": producttype = 5; break;
                                        case "香蕉": producttype = 6; break;
                                        case "橘子": producttype = 7; break;
                                        case "橙子": producttype = 8; break;
                                    }
                                    dt.Rest[producttype] += int.Parse(s[1]);
                                    Console.WriteLine("删除成功!");
                                }
                                catch (SearchException e)
                                {
                                    Console.Write(e.Message);
                                }  
                                catch(Exception e) { Console.Write("输入错误！\n"); }

                                break; }
                        case 3:
                            {
                                Console.WriteLine("");
                                modifychoice = -1;
                                modifyno = -1;
                                sv.Show();
                                Console.Write("选择要修改的订单号:");
                                try
                                {
                                    modifyno = int.Parse(Console.ReadLine());
                                    sv.SearchByNo(Convert.ToString(modifyno));
                                }
                                catch (Exception)
                                {
                                    modifyno = -1;
                                    Console.WriteLine("无此订单号!");
                                    break;
                                }
                                while (modifychoice != 0 && modifychoice != 1 && modifychoice != 2 && modifychoice != 3 && modifychoice != 4)
                                {
                                    modifyMenu();
                                    Console.Write("选择操作:");
                                    try
                                    {
                                        modifychoice = int.Parse(Console.ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        modifychoice = -1;
                                        Console.WriteLine("请选择1、2、3或0\n");
                                    }
                                }
                                if (modifychoice == 0)
                                    break;
                                else
                                    switch (modifychoice)
                                    {
                                        case 1:
                                            {
                                                Console.Write("请输入新的客户姓名:");
                                                try
                                                {
                                                    customername = Console.ReadLine();
                                                    sv.ChangecName(modifyno, customername);
                                                    Console.WriteLine("修改成功！");
                                                }
                                                catch (Exception)
                                                {
                                                    Console.WriteLine("输入错误");
                                                    break;
                                                }
                                                break;
                                            }
                                        case 2:
                                            {
                                                dt.showalltype();
                                                Console.Write("请选择新的商品类型:");
                                                try
                                                { 
                                                    producttype = int.Parse(Console.ReadLine());
                                                    if (producttype < 0 || producttype > 8)
                                                    {
                                                        throw new Exception("无此商品类型\n");
                                                    }
                                                    sv.ChangepName(modifyno,OrderDetails.ProductType[producttype]);
                                                    Console.WriteLine("修改成功！");
                                                }
                                                catch (Exception)
                                                {
                                                    Console.WriteLine("输入错误");
                                                    break;
                                                }
                                                break;
                                            }
                                        case 3:
                                            {
                                                dt.showalltype();
                                                Console.Write("请输入新的商品数目:");
                                                try
                                                {
                                                    amount = int.Parse(Console.ReadLine());
                                                    producttype = sv.searchtype(modifyno);
                                                    if (producttype == -1)
                                                        throw new SearchException("could not trigger -_-");
                                                    if (amount < 0 || amount > dt.Rest[producttype]+sv.searchAmount(modifyno))
                                                    {
                                                        throw new Exception("数量错误！\n");
                                                    }
                                                    dt.Rest[producttype] = dt.Rest[producttype] + sv.searchAmount(modifyno) - amount;
                                                    sv.ChangeAmount (modifyno, amount);
                                                    Console.WriteLine("修改成功！");
                                                }
                                                catch (SearchException e)
                                                {
                                                    Console.WriteLine(e.Message);
                                                }
                                                catch (Exception e)
                                                {
                                                    Console.Write(e.Message);
                                                    break;
                                                }
                                                break;
                                            }
                                        default: break;
                                    }

                                break;
                            }


                        case 4: { Console.WriteLine("");
                                searchchoice = -1;
                                while (searchchoice != 0 && searchchoice != 1 && searchchoice != 2 && searchchoice != 3 && searchchoice != 4)
                                {
                                    searchMenu();
                                    Console.Write("选择操作:");
                                    try
                                    {
                                        searchchoice = int.Parse(Console.ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        searchchoice = -1;
                                        Console.WriteLine("请选择1、2、3、4或0\n");
                                    }
                                }
                                if (searchchoice == 0)
                                    break;
                                else
                                    switch (searchchoice)
                                    {
                                        case 1: { Console.WriteLine("请输入订单号");
                                                try
                                                {
                                                    ordersearch = Console.ReadLine();
                                                    sv.SearchByNo(ordersearch);
                                                    sv.ShowResult();
                                                }
                                                catch(SearchException e)
                                                {
                                                    Console.WriteLine(e.Message);
                                                }
                                                catch (Exception)
                                                {
                                                    Console.WriteLine("输入错误");
                                                    break;
                                                }
                                                break; }
                                        case 2:
                                            {
                                                Console.WriteLine("请输入商品名称");
                                                try
                                                {
                                                    ordersearch = Console.ReadLine();
                                                    sv.SearchBypName(ordersearch);
                                                    sv.ShowResult();
                                                }
                                                catch (SearchException e)
                                                {
                                                    Console.WriteLine(e.Message);
                                                }
                                                catch (Exception)
                                                {
                                                    Console.WriteLine("输入错误");
                                                    break;
                                                }
                                                break;
                                            }
                                        case 3:
                                            {
                                                Console.WriteLine("请输入客户名称");
                                                try
                                                {
                                                    ordersearch = Console.ReadLine();
                                                    sv.SearchBycName(ordersearch);
                                                    sv.ShowResult();
                                                }
                                                catch (SearchException e)
                                                {
                                                    Console.WriteLine(e.Message);
                                                }
                                                catch (Exception)
                                                {
                                                    Console.WriteLine("输入错误");
                                                    break;
                                                }
                                                break;
                                            }
                                        case 4: sv.Show(); break;
                                        default:break;
                                    }

                                break; }
                        default:break;
                    }
                choice = -1;
            }

            return;

        }
        static void Menu()
        {
                Console.Write("------------------------****-----------------------\n");
                Console.Write("1.添加订单\n");
                Console.Write("2.删除订单\n");
                Console.Write("3.修改订单\n");
                Console.Write("4.查询订单\n");
                Console.Write("0.退出\n");
                Console.Write("------------------------****-----------------------\n");

           
        }
        static void searchMenu()
        {
            Console.Write("------------------------****-----------------------\n");
            Console.Write("1.按订单号查询\n");
            Console.Write("2.按商品名称查询\n");
            Console.Write("3.按客户名字查询\n");
            Console.Write("4.全部显示\n");
            Console.Write("0.取消查询\n");
            Console.Write("------------------------****-----------------------\n");
        }
        static void modifyMenu()
        {
            Console.Write("------------------------****-----------------------\n");
            Console.Write("1.修改客户姓名\n");
            Console.Write("2.修改商品类型\n");
            Console.Write("3.修改商品数量\n");
            Console.Write("0.取消修改\n");
            Console.Write("------------------------****-----------------------\n");
        }

    }
        
}
