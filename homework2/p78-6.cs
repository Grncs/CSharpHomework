using System;


   class Class1
   {
    public static void Main(string[] args)
    {
        Boolean flag;
        int n = 0;
        Console.WriteLine("\n请输入一个数字，程序将输出它的所有素数因子\n");
        string s = Console.ReadLine();
        int input = int.Parse(s);
        Console.WriteLine();
        for(int i = 2; i <= input; i++)
        {
            flag = true;
            if (input % i != 0)
                continue;
            else
                for(int j = 2; j<i; j++)
                {
                    if (i % j == 0)
                    {
                        flag = false;
                        break;
                    }
                }
            if (flag == false)
                continue;
            else
            {
                if (n < 10)
                {
                    Console.Write(i + " ");
                    n++;
                }
                else
                {
                    Console.WriteLine();
                    Console.Write(i + " ");
                    n = 1;
                }
            }
        
        }
        Console.ReadKey();
       }
    }
