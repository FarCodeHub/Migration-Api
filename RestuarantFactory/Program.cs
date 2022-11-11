using System;
using System.Collections.Generic;

namespace RestuarantFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Menu["SP"] = new SteakPizza();
            // Menu[2] = new SteakPizza();

            var foodId = Console.ReadLine();
            var logType = Console.ReadLine();
            IOutputHandler handler= Handlers[logType];

            Menu[foodId].Cook(handler);
        }

        private static Dictionary<string, Food> Menu = new Dictionary<string, Food>();
        private static Dictionary<string, IOutputHandler> Handlers = new Dictionary<string, IOutputHandler>()
        {
            {"C",new ConsoleOutPut()},
            {"F",new FileOutPut(){Path = "C://"}},

        };
    }
}
