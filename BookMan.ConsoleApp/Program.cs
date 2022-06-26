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
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var context = new SimpleDataAccess();
            BookController controller = new BookController(context);

            Router route = Router.Instance;

            route.Register("about", About);
            route.Register("help", Help);

            route.Register(route: "create",
                  action: p => controller.Create(),
                  help: "[create]\r\n nhập sách mới");

            route.Register(route: "update",
                action: p => controller.Update(p["id"].ToInt()),
                help: "(update ? id = <value> \r\n tìm và cập nhật danh sách)");

            route.Register(route: "single",
                    action: p => controller.Single(p["id"].ToInt()),
                    help: "(single ? id = <value> \r\n hiển thị một cuốn sách theo id)"
                );

            route.Register(route: "list",
                    action: p => controller.List(),
                    help: "[list] \r hiển thị danh sách");

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
