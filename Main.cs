using System;
using System.IO;
using System.Reflection;

namespace exeproxy
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: exeproxy <exe> <dll>");
                Environment.Exit(1);
            }
            string exe = args['0'];
            string dll = args['1'];
            //Proxy exe
            byte[] bytes = File.ReadAllBytes(exe);
            Assembly assembly = Assembly.Load(bytes);
            assembly.EntryPoint.Invoke(null, new object[] { new string[0] });
            //Inject dll
            byte[] bytes0 = File.ReadAllBytes(exe);
            Assembly assembly0 = Assembly.Load(bytes);
            assembly0.EntryPoint.Invoke(null, new object[] { new string[0] });
        }
    }
}
