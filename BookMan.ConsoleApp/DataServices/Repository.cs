﻿using System.Linq;
using System.Collections.Generic;
namespace BookMan.ConsoleApp.DataServices
{
    using Models;
    public class Repository
    {
        //protected readonly SimpleDataAccess _context;

        //protected readonly BinaryDataAccess _context;

        protected readonly IDataAccess _context;
        public Repository(IDataAccess context)
        {
            _context = context;
            _context.Load();
        }
        public void SaveChanges() => _context.SaveChanges();
        public List<Book> Books => _context.Books;
        public Book[] Select() => _context.Books.ToArray();
        public Book Select(int id)
        {
            //foreach (var b in _context.Books)
            //{
            //    if (b.Id == id) return b;
            //}
            //return null;
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }

        public Book[] Select(string key)
        {
            //var temp = new List<Book>();
            var k = key.ToLower();
            return _context.Books.Where(b => 
                    b.Title.ToLower().Contains(k) ||
                    b.Authors.ToLower().Contains(k) ||
                    b.Publisher.ToLower().Contains(k) ||
                    b.Tags.ToLower().Contains(k) ||
                    b.Description.ToLower().Contains(k)
                    ).ToArray();
            //foreach (var b in _context.Books)
            //{
            //    var logic =
            //        b.Title.ToLower().Contains(k) ||
            //        b.Authors.ToLower().Contains(k) ||
            //        b.Publisher.ToLower().Contains(k) ||
            //        b.Tags.ToLower().Contains(k) ||
            //        b.Description.ToLower().Contains(k)
            //        ;
            //    if (logic) temp.Add(b);
            //}
            //return temp.ToArray();
        }

        public void Insert(Book book)
        {
            //var lastIndex = _context.Books.Count - 1;
            //var id = lastIndex < 0 ? 1 : _context.Books[lastIndex].Id + 1;
            //book.Id = id;
            //_context.Books.Add(book);
            var id = _context.Books.Count == 0 ? 1 : _context.Books.Max(b => b.Id) + 1;
            book.Id = id;
            _context.Books.Add(book);
        }
        public bool Delete(int id)
        {
            var b = Select(id);
            if (b == null) return false;
            _context.Books.Remove(b);
            return true;
        }
        public bool Update(int id, Book book)
        {
            var b = Select(id);
            if (b == null) return false;
            b.Authors = book.Authors;
            b.Description = book.Description;
            b.Edition = book.Edition;
            b.File = book.File;
            b.Isbn = book.Isbn;
            b.Publisher = book.Publisher;
            b.Rating = book.Rating;
            b.Reading = book.Reading;
            b.Tags = book.Tags;
            b.Title = book.Title;
            b.Year = book.Year;
            return true;
        }

        // book marked
        public Book[] SelectMarked()
        {
            //var list = new List<Book>();
            //foreach(var b in Books)
            //{
            //    if (b.Reading) list.Add(b);
            //}
            //return list.ToArray();
            return _context.Books.Where(b => b.Reading == true).ToArray(    );
        }

        // clear data
        public void Clear()
        {
            _context.Books.Clear();
        }

        // thống kê
        public IEnumerable<IGrouping<string, Book>> Stats(string key = "folder")
        {
            return _context.Books.GroupBy(b => System.IO.Path.GetDirectoryName(b.File));
        }
    }
}