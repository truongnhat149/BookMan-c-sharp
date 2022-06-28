﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.DataServices
{
    using Models;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    public class XmlDataAccess
    {
        public List<Book> Books { get; set; } = new List<Book>();

        private readonly string _file = "data.xml";

        public void Load()
        {
            if (!File.Exists(_file))
            {
                SaveChanges();
                return;
            }
            var serializer = new XmlSerializer(typeof (List<Book>));
            using (var reader = XmlReader.Create(_file))
            {
                Books = (List<Book>)serializer.Deserialize(reader);
            }
        }
        public void SaveChanges()
        {
            var serializer = new XmlSerializer(typeof (List<Book>));
            using (var writer = XmlWriter.Create(_file))
            {
                serializer.Serialize(writer, Books);
            }   
        }
    }
}
