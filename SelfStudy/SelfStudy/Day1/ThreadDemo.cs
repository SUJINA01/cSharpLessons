using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

namespace SelfStudy.Day1
{
    internal class ThreadDemo
    {
         static void  Test()
        {


            Thread t1 = Thread.CurrentThread;
            int id = t1.ManagedThreadId;
            Console.WriteLine(id);
            Console.WriteLine($"State of Thread:" + t1.IsAlive);
            Console.WriteLine($"Priority of Thread:" + t1.Priority);
            Console.WriteLine($"Language of Thread:" + t1.CurrentCulture);
            Console.WriteLine($"ThreadState:" + t1.ThreadState);
        }


    }
}
