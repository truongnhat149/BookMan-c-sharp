using System.IO;
using System.Diagnostics;

namespace BookMan.ConsoleApp.Controllers
{
    using DataServices;
    using Models;
    using Views;
    using Framework;
    internal class ShellController : ControllerBase
    {
        protected Repository Repo;
        public ShellController(BinaryDataAccess context)
        {
            Repo = new Repository(context);
        }

        public void Shell(string folder, string ext = "*.pdf")
        {
            if (!Directory.Exists(folder))
            {
                Error("Folder not found");
                return;
            }

            var files = Directory.GetFiles(folder, ext ?? "*.pdf", SearchOption.AllDirectories);

            foreach (var f in files)
            {
                Repo.Insert(new Book { Title = Path.GetFileNameWithoutExtension(f), File = f });
            }

            if (files.Length > 0)
            {
                Success($"{files.Length} item(s) found");
                return;
            }

            Inform("No item found!");
        }

        public void Read(int id)
        {
            var book = Repo.Select(id);
            if (book == null)
            {
                Error("Book not found");
                return;
            }

            if (!File.Exists(book.File))
            {
                Error("File not found");
                return;
            }
            Process.Start(book.File);
            Success($"You are reading book '{book.Title}'");
        }

        public void Save()
        {
            Repo.SaveChanges();
            Success("Data save!");
        }

        // clear data
        public void Clear(bool process = false)
        {
            if (!process)
            {
                Confirm("Do you really want to clear the shell?", "do clear");
                return;
            }
            Repo.Clear();
            Inform("The shell has been clear");
        }
    }
}