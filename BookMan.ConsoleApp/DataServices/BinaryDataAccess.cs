﻿using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace BookMan.ConsoleApp.DataServices
{
    using Models;
    public class BinaryDataAccess : IDataAccess
    {
        // read write file binary
        public List<Book> Books { get; set; } = new List<Book>();
        private readonly string _file = Config.Instance.DataFile;
        //private readonly string _file = "data.dat";
        public void Load()
        {   
            if (!File.Exists(_file))
            {
                SaveChanges();
                return;
            }
            using (FileStream stream = File.OpenRead(_file))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Books = formatter.Deserialize(stream) as List<Book>;
            }
        }
        public void SaveChanges()
        {
            using (FileStream stream = File.OpenWrite(_file))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, Books);
            }
        }
    }
}