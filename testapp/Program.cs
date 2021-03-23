using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace testapp
{
    class Program
    {
        static void Main(string[] args)
        {
            string primera = "Test";
            string segundo = primera.ToString();
            segundo = "Tonto";
            Console.WriteLine("Primera: " + primera + " /Segunda: " + segundo);
            Console.ReadLine();
        }
    }
}
