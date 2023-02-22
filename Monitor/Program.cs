using System;
using System.IO;
using System.Threading;

namespace Monitor
{
    internal class Program
    {
        private static string lastWriteTime { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString());
            Thread thread = new Thread(new ThreadStart(Monitor));
            thread.Start();
        }

        static void Monitor()
        {
            while (true)
            {
                var fileLastWriteTime = File.GetLastWriteTime(@"C:\Users\v-yangtian\Desktop\FileTest.txt");
                Console.WriteLine(DateTime.Now.ToString() + "_" + fileLastWriteTime.ToString());
                if (fileLastWriteTime.ToString() != lastWriteTime)
                {
                    lastWriteTime = fileLastWriteTime.ToString();
                }
                Thread.CurrentThread.Join(1000);
            }
        }
    }
}
