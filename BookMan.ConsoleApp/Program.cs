﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp
{
    using Controllers;
    using DataServices;
    internal class Program
    {
        static void Main(string[] args)
        {
            SimpleDataAccess context = new SimpleDataAccess();
            BookController controller = new BookController(context);
            bool flag = true; 
            while (flag)
            {
                Console.Write("Request>  ");
                string request = Console.ReadLine();
                switch (request.ToLower())
                {
                    case "single":
                        controller.Single(1);
                        break;
                    case "create":
                        controller.Create();
                        break;
                    case "update":
                        controller.Update();
                        break;
                    case "list":
                        controller.List();
                        break;
                    default:
                        Console.WriteLine("Unknown command!!!");
                        flag = false;
                        break;
                }
            }
        }
    }
}
