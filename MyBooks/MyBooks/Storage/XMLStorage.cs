using MyBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Xml.Serialization;

namespace MyBooks.Storage
{
    public class XMLStorage
    {
        string _xmlPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//MyBooks.xml";

        public List<Book> ReturnAllBooksFromXml()
        {
            Type[] _types = new Type[] { typeof(Book) };
            List<Book> _books = new List<Book>();
            XmlSerializer reader = new XmlSerializer(_books.GetType(),_types);
            System.IO.StreamReader file = new System.IO.StreamReader(_xmlPath);
            _books = (List<Book>)reader.Deserialize(file);
            file.Close();
            return _books;
        }

    }
}