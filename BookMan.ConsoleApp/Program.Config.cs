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
            SimpleDataAccess dataAccess = new SimpleDataAccess();
            BookController controller = new BookController(dataAccess);

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

            // local function to convert parameter to book object
            Models.Book toBook(Parameter parameter)
            {
                var b = new Models.Book();
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