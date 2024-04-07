using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfGoose.Print
{
    public class PrintInConsole : IPrint
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
