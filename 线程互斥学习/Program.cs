using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程互斥学习
{
    class Program
    {
        public static void Main(string[] args)
        {
            MutexTest mu = new MutexTest();
            for (MutexTest.current = 0; MutexTest.current < 10000; ++MutexTest.current)
            {
                mu.StartThread();
                Console.WriteLine("C:\\java\\".TrimEnd('\\'));
            }
        }
    }

    public class MutexTest
    {
        static public int current = 0;
        public void StartThread()
        {
            Thread th = new Thread(TestThread);
            th.Start();
        }

        private bool flag = true;
        private object locker = new object();

        private List<string> _list = new List<string>();
        void Test()
        {
            lock (_list)
            {
                _list.Add("Item 1");
            }
        }
        public void TestThread()
        {
            lock (locker)
            {
                if (flag)
                {
                    flag = false;
                }
                else
                {
                    return;
                }
            }
            Console.WriteLine("线程 " + current + " ，获得运行权");
            Thread.Sleep(100);
            lock (locker)
            {
                flag = true;
            }
        }
    }
}
