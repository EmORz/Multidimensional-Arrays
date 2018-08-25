using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Net;

namespace Snowmen
{
    class Program
    {
        static void Main(string[] args)
        {
          
            var input = Console.ReadLine();

        }
        
        public static void gotoSite(string url)
        {
            System.Diagnostics.Process.Start(url);
        }
    }
}