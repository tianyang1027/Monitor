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
            Thread thread = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    var fileLastWriteTime = File.GetLastWriteTime(@"C:\Users\v-yangtian\Desktop\FileTest.txt").ToString("G");
                    Console.WriteLine(DateTime.Now.ToString() + "_" + fileLastWriteTime);
                    if (fileLastWriteTime != lastWriteTime)
                    {
                        lastWriteTime = fileLastWriteTime;
                    }
                    Thread.CurrentThread.Join(1000);
                }
            }));
            thread.Start();
        }
    }
}
