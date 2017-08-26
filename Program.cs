using System;
using System.Net;
using System.IO;

namespace helloapp
{
    class Program
    {
        static void Main(string[] args)
        {
             Splider.GetArticlesTop10().ForEach(item=> Console.WriteLine(item));
        }
    }
}
