using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BookMan.ConsoleApp.Controllers
{
    using DataServices;
    using Models; //lưu ý cách dùng using với không gian tên con
    using Views;
    /// <summary>
    /// lớp điều khiển, giúp ghép nối dữ liệu sách với giao diện
    /// </summary>
    internal class BookController
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
            // khởi tạo view
            BookSingleView view = new BookSingleView(model);

            if (!string.IsNullOrEmpty(path)) { view.RenderToFile(path); return; }
            // gọi phương thức Render để thực sự hiển thị ra màn hình
            view.Render();
        }

        /// <summary>
        /// kích hoạt chức năng hiển thị danh sách
        /// </summary>
        public void List(string path = "")
        {
            var model = Repo.Select();         
            BookListView view = new BookListView(model);
            if (!string.IsNullOrEmpty(path)) { view.RenderToFile(path); return; }
            view.Render();
        }

        public void Create()
        {
            BookCreateView view = new BookCreateView();
            view.Render();
        }

        public void Update(int id)
        {
            var model = Repo.Select(id);
            var view = new BookUpdateView(model);
            view.Render();
        }
    }
}