using System;
using Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Views
{
    using Models;
    class BookListView
    {
        protected Book[] Model;

        public BookListView(Book[] model)
        {
            Model = model;
        }

        public void Render()
        {
            if (Model.Length == 0)
            {
                ViewHelp.WriteLine("No book found", ConsoleColor.Yellow);
                return;
            }
            ViewHelp.WriteLine("THE BOOK LIST", ConsoleColor.Green);
            foreach (Book b in Model)
            {
                ViewHelp.Write($"[{b.Id}]", ConsoleColor.Yellow);
                ViewHelp.WriteLine($" {b.Title}", b.Reading ? ConsoleColor.Cyan : ConsoleColor.White);
            }
        }

        public void RenderToFile(string path)
        {
            ViewHelp.WriteLine($"Saving data to File '{path}'");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(Model);
            System.IO.File.WriteAllText(path, json);
            ViewHelp.WriteLine("Done!!!");
        }
    }
}
