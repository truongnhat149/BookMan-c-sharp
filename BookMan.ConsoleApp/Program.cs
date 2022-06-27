using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp
{
    using Framework;
    using Controllers;
    using DataServices;
    internal partial class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ConfigRouter();

            while (true)
            {
                ViewHelp.Write("# Request >>> ", ConsoleColor.Green);
                string request = Console.ReadLine();

                Router.Instance.Forward(request);
                Console.WriteLine();
            }
        }

        private static void About(Parameter parameter)
        {
            ViewHelp.WriteLine("BOOK MANAGER version 1.0", ConsoleColor.Green);
        }

        private static void Help(Parameter parameter)
        {
            if (parameter == null)
            {
                ViewHelp.WriteLine("SUPPRTED COMMANDS: ", ConsoleColor.Green);
                ViewHelp.WriteLine(Router.Instance.GetRoutes(), ConsoleColor.Yellow);
                ViewHelp.WriteLine("type: help ? cmd =<command> to get command details ", ConsoleColor.Cyan);

            }
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            var command = parameter["cmd"].ToLower();
            ViewHelp.WriteLine(Router.Instance.GetHelp(command));
        }
    }
}
