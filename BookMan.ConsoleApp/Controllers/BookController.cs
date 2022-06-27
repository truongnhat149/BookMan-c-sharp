using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BookMan.ConsoleApp.Controllers
{
    using Models;
    using Framework;
    using DataServices;
    using Views;
    /// <summary>
    /// lớp điều khiển, giúp ghép nối dữ liệu sách với giao diện
    /// </summary>
    internal class BookController : ControllerBase
    {
        protected Repository Repo;
        public BookController(SimpleDataAccess _context)
        {
            Repo = new Repository(_context);
        }
        /// <summary>
        /// ghép nối dữ liệu 1 cuốn sách với giao diện hiển thị 1 cuốn sách
        /// </summary>
        /// <param name="id">mã định danh của cuốn sách</param>
        public void Single(int id, string path = "")
        {
            // lấy dữ liệu qua repo
            var model = Repo.Select(id);

            Render(new BookSingleView(model), path);
        }

        /// <summary>
        /// kích hoạt chức năng hiển thị danh sách
        /// </summary>
        public void List(string path = "")
        {
            var model = Repo.Select();         
            Render(new BookListView(model), path);
        }

        public void Create(Book book = null)
        {
            if (book == null)
            {
                Render(new BookCreateView());
                return;
            }
            Repo.Insert(book);
            Success("Book created");
        }

        public void Update(int id, Book book = null)
        {
            if (book == null)
            {
                var model = Repo.Select(id);
                Render(new BookUpdateView(model));
                return;
            }
            Repo.Update(id, book);
            Success("Book Updated!");
        }
    }
}