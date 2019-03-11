using System;

public class Class1
{
	static void Main()
    {
        Console.Write("输入数组的大小,将产生对应数量的随机数\n");
        
        string s = Console.ReadLine();
        int num = int.Parse(s);
        int[] array = new int[num];
        Random r = new Random();
        for (int i = 0; i < num; i++)
            array[i] = r.Next();
        search(array);
        Console.ReadKey();
    }

    public static void search(int []a)
    {
        int max = a[0];
        int min = a[0];
        int sum = 0;
        Console.Write("数组的元素如下:\n");
        for(int i = 0; i < a.Length; i++)
        {
            Console.Write(a[i]+" ");
            if (i % 10 == 0 && i != 0)
                Console.WriteLine();
            if (a[i] > max)
                max = a[i];
            if (a[i] < min)
                min = a[i];
            sum += a[i];
        }
        Console.Write("\n\n数组最大值为" + max + "\n\n");
        Console.Write("数组最小值为" + min + "\n\n");
        Console.Write("数组元素总和为" + sum + "\n\n");
        Console.Write("数组平均值为" + sum / a.Length + "\n\n");

    }

}
