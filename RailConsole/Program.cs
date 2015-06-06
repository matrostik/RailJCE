using RailDomain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Rail application testing.......");
            //Console.OutputEncoding = System.Text.Encoding;


            RailDAL dal = new RailDAL();
            var list1 = dal.GetAllStations();
            var list2 = dal.GetAllRoutes();


            foreach (var item in list1)
            {
               Debug.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }
    }
}
