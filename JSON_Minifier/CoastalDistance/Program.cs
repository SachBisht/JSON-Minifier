using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

////Used Newtonsoft.JSON library for file reading!!
//31.0984679,-81.385627  ============Provided Ones
//33.8486573,-77.9752082
//1 mile = 5280 feet

namespace CoastalDistance
{
    class Program : GeoCoordinates
    {
        static void Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            
            GetCoordinates();
            Console.ReadKey();
        }

    }
}
