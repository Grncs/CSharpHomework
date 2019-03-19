using System;
using System.Timers;

namespace Timer1
{
    class Program
    {

        static Boolean flag = false;
        static void Main(string[] args)
        {
            Timer timer = new Timer();
            double time = 0;
 
            Console.WriteLine("请给闹钟定时(秒为单位)");
            try
            {
                time = double.Parse(Console.ReadLine());

                Console.Write("计时"+time+"秒\n");
            }
            catch (Exception e)
            {
                Console.Write(e.Message+"!!");
            }
            timer.Interval = time * 1000;
            timer.Enabled = true;
            timer.Start();
            timer.Elapsed += Timer_Elapsed;
            while (!flag) { }
            Console.ReadKey();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            flag = true;
            Console.WriteLine("time out");
           
        }
    }
}
