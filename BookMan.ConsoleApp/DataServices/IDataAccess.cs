﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.DataServices
{
    using Models;
    public interface IDataAccess
    {
        List<Book> Books { get; set; }
        void Load();
        void SaveChanges();
    }
}
