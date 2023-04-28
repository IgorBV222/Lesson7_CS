﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegateExample
{
    delegate void output(params object[] values);
    internal class Program
    {
        static void NamesOfObj(object[] _arr)
        {
            string output = string.Empty; //задали пустую строку, можно ""
            foreach (var item in _arr)
            {
                output += $"{item.GetType()}\n";
            }
            MessageBox.Show(output);
        }
        static void Main(string[] args)
        {
            output myPrint = (object[] _arr) =>
            {
                foreach (var item in _arr)
                {
                    Console.WriteLine(item);
                }
            };
            myPrint += NamesOfObj;
            myPrint += (object[] _arr) =>
            {
                using (var sw = new StreamWriter("output.txt", true))
                {
                    foreach (var item in _arr)
                    {
                        sw.WriteLine(item.ToString(), true);
                    }
                }
            };
            myPrint(1, "два", 3.5F, 'F');
            myPrint -= NamesOfObj;
            myPrint(1, 2d, (byte)25, true);
        }
    }
}
