namespace BookMan.ConsoleApp
{
    using Models;
    using Framework;
    using DataServices;
    using Controllers;

    internal partial class Program
    {
        private static void ConfigRouter()
        {
            BinaryDataAccess dataAccess = new BinaryDataAccess();
            BookController controller = new BookController(dataAccess);
            ShellController shellController = new ShellController(dataAccess);

            Router route = Router.Instance;

            route.Register("about", About);
            route.Register("help", Help);

            route.Register(route: "create",
                  action: p => controller.Create(),
                  help: "[create]\r\n nhập sách mới");

            route.Register(route: "do create",
                  action: p => controller.Create(toBook(p)),
                  help: "this route should be used only in code");

            route.Register(route: "update",
                action: p => controller.Update(p["id"].ToInt()),
                help: "(update ? id = <value> \r\n tìm và cập nhật danh sách)");

            route.Register(route: "do update",
                action: p => controller.Update(p["id"].ToInt(), toBook(p)),
                help: "this router should be used only in code" );
            route.Register(route: "single",
                    action: p => controller.Single(p["id"].ToInt()),
                    help: "(single ? id = <value> \r\n hiển thị một cuốn sách theo id)"
                );

            route.Register(route: "list",
                    action: p => controller.List(),
                    help: "[list] \r hiển thị danh sách");

            route.Register(route: "list file",
                    action: p => controller.List(p["path"]),
                    help: "[list file ? path = <value> \r hiển thị tất cả sách]");

            route.Register(route: "single file",
                    action: p => controller.Single(p["id"].ToInt(), p["path"]),
                    help: "[single file ? id = <value> & path = <value>]");

            route.Register(route: "delete",
                    action: p => controller.Delete(p["id"].ToInt()),
                    help: "delete ? id = <value>");

            route.Register(route : "do delete",
                    action: p => controller.Delete(p["id"].ToInt(), true),
                    help: "this route should be used only in code");

            // filter key
            route.Register(route: "filter",
                    action: p => controller.Filter(p["key"]),
                    help: "[filter ? key = <value>] tìm sách theo từ khóa");

            // shell
            route.Register(route: "add shell",
                    action: p => shellController.Shell(p["path"], p["ext"]),
                    help: "[add shell ? path = <value>]");

            // save shell
            route.Register(route: "save shell",
                    action: p => shellController.Save(),
                    help: "[save shell]");

            // read file
            route.Register(route: "read",
                    action: p => shellController.Read(p["id"].ToInt()),
                    help:"[read ? id = <value>]");

            // book marked
            route.Register(route : "mark",
                    action: p => controller.Mark(p["id"].ToInt()),
                    help: "[mark ? id = <value>]");

            route.Register(route: "unmark",
                    action: p => controller.Mark(p["id"].ToInt(), false),
                    help: "[unmark ? id = <value>]");

            route.Register(route: "show mark",
                    action: p => controller.ShowMarks(),
                    help: "[show marks]");

            // clear data
            route.Register(route: "clear",
                     action: p => shellController.Clear(),
                     help: "[clear] Use with care");

            route.Register(route: "do clear",
                     action: p => shellController.Clear(true),
                     help: "[clear] Use with care");
            // local function to convert parameter to book object
            Book toBook(Parameter parameter)
            {
                var b = new Book();
                if (parameter.ContainsKey("id")) b.Id = parameter["id"].ToInt();
                if (parameter.ContainsKey("authors")) b.Authors = parameter["authors"];
                if (parameter.ContainsKey("title")) b.Title = parameter["title"];
                if (parameter.ContainsKey("publisher")) b.Publisher = parameter["publisher"];
                if (parameter.ContainsKey("year")) b.Year = parameter["year"].ToInt();
                if (parameter.ContainsKey("edition")) b.Edition = parameter["edition"].ToInt();
                if (parameter.ContainsKey("isbn")) b.Isbn = parameter["isbn"];
                if (parameter.ContainsKey("tags")) b.Tags = parameter["tags"];
                if (parameter.ContainsKey("description")) b.Description = parameter["description"];
                if (parameter.ContainsKey("file")) b.File = parameter["file"];
                if (parameter.ContainsKey("rate")) b.Rating = parameter["rate"].ToInt();
                if (parameter.ContainsKey("reading")) b.Reading = parameter["reading"].ToBool();
                return b;
            }
        }
    }
}