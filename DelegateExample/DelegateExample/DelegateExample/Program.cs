using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExample
{
    delegate void output(params object[] values);
    internal class Program
    {
        static void Main(string[] args)
        {
            output myPrint = (object[] _arr) => 
            {
                foreach (var item in _arr)
                {
                    Console.WriteLine(item);
                }
            };
            myPrint += (object[] _arr) =>
            {
                using (var sw = new StreamWriter("output.txt"))
                {
                    foreach (var item in _arr)
                    {
                        sw.WriteLine(item.ToString(), true);
                    }
                    
                }
            };
            myPrint(1, "два", 3);
        }
    }
}
