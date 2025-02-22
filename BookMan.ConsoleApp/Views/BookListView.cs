﻿using System;
using Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Views
{
    using Models;
    internal class BookListView : ViewBase<Book[]>
    {
        public BookListView(Book[] model) : base(model) { }
        
        public override void Render()
        {
            if (Model.Length == 0)
            {
                ViewHelp.WriteLine("No book found", ConsoleColor.Yellow);
                return;
            }

            ViewHelp.WriteLine("THE BOOK LIST", ConsoleColor.Green);

            foreach (Book b in Model )
            {
                ViewHelp.Write($"[{b.Id}]", ConsoleColor.Yellow);
                ViewHelp.WriteLine($" {b.Title}", b.Reading ? ConsoleColor.Cyan : ConsoleColor.White);
            }

            ViewHelp.WriteLine($"{Model.Length} items", ConsoleColor.Green);
        }

    }
}
