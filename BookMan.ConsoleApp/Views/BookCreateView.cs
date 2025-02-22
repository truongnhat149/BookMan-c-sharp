﻿using System;
using Framework;
namespace BookMan.ConsoleApp.Views
{
    using Framework;
    /// <summary>
    /// class để thêm một cuốn sách mới
    /// </summary>
    internal class BookCreateView : ViewBase
    {
        public BookCreateView()  { }

        /// <summary>
        /// yêu cầu người dùng nhập từng thông tin và lưu lại thông tin đó
        /// </summary>
        public override void Render()
        {
            ViewHelp.WriteLine("CREATE A NEW BOOK", ConsoleColor.Green);
            var title = ViewHelp.InputString("Title"); //đọc vào biến title            
            var authors = ViewHelp.InputString("Authors"); //đọc vào biến authors            
            var publisher = ViewHelp.InputString("Publisher"); //đọc vào biến publisher
            var isbn = ViewHelp.InputString("Isbn");
            var year = ViewHelp.InputInt("Year"); // nhập giá trị cho biến year
            var edition = ViewHelp.InputInt("Edition"); // nhập giá trị cho biến edition
            var tags = ViewHelp.InputString("Tags");
            var description = ViewHelp.InputString("Description");
            var rate = ViewHelp.InputInt("Rate");
            var file = ViewHelp.InputString("File");
            var reading = ViewHelp.InputBool("Reading");

            var request =
                "do create ? " +
                $"title = {title}" +
                $"authors = {authors}" +
                $"publisher = {publisher}" +
                $"isbn = {isbn}"+
                $"year = {year}" +
                $"edition = {edition}" +
                $"tags = {tags}" +
                $"description = {description}" +
                $"rate = {rate}" +
                $"reading = {reading}" +
                $"file = {file}";
            router.Forward(request);
        }
    }
}