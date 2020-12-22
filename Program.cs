using System;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ThreadReturn
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int>[] th = new Task<int>[]
            {
                Task<int>.Run(() =>
                {
                    return summ(1, 100);
                }),
                Task<int>.Run(() =>
                {
                    return summ(1000, 5000);
                }),
                Task<int>.Run(() =>
                {
                    return summ(100, 1000);
                }),
                Task<int>.Run(() =>
                {
                    return summ(300, 42000);
                })
            };
            WaitTask(th);
            
        }

        public static int summ(int start, int end)
        {
            int sum = 0;
            for (int i = start; i < end; i++)
            {
                sum += i;
            }
            return sum;
        }

        public static void WaitTask(Task<int>[] tasks)
        {
            Task.WaitAll(tasks);
            Console.WriteLine("Summ");
            foreach(Task<int> t in tasks)
            {
                Console.WriteLine(t.Result);
            }
        }
    }
}
