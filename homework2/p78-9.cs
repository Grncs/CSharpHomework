/*埃拉托斯特尼筛法:要得到自然数n以内的全部素数，必须把不大于  的所有素数的倍数剔除，剩下的就是素数。 [1] 
给出要筛数值的范围n，找出以内的素数。先用2去筛，即把2留下，把2的倍数剔除掉；再用下一个质数，
也就是3筛，把3留下，把3的倍数剔除掉；接下去用下一个质数5筛，把5留下，把5的倍数剔除掉；不断重复下去......。
*/
using System;

public class Class1
{
	static void Main()
	{
        Boolean[] vs = new Boolean[101];
        Boolean flag;
        int count;
        for (int i = 2; i*i <= 100; i++)
        {
            flag = true;
            for (int j = 2; j < i; j++)
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
                count = 2;
                while(count*i <= 100)
                {
                    vs[count * i] = true;
                    count++;
                }
                Console.Write("去掉" + i + "的倍数后还剩:\n");
                for (int k = 1; k < 101; k++)
                {
                    if (vs[k] == false)
                        Console.Write(k + " ");
                }
                Console.Write("\n\n");
            }
        }
        Console.Write("即为最后结果\n");
        Console.ReadKey();
    }
}
