using MyBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace MyBooks.Storage
{
    public class XMLStorage
    {


        public void AddGenre(Genre _genre, string _xmlPathGenres)
        {
            XDocument xDoc = XDocument.Load(_xmlPathGenres);
            xDoc.Element("ArrayOfGenre").Add(
                        new XElement("Genre",
                        new XElement("Id", _genre.Id),
                        new XElement("Name", _genre.Name)));
            xDoc.Save(_xmlPathGenres);
        }

        public void AddBook(Book _book, string _xmlPathBooks)
        {
            XDocument xDoc = XDocument.Load(_xmlPathBooks);
            xDoc.Element("ArrayOfBook").Add(
                new XElement("Book",
                new XElement("Id", Guid.NewGuid()),
                new XElement("Name", _book.Name),
                new XElement("AuthorName", _book.AuthorName),
                new XElement("AuthorSurname", _book.AuthorSurname),
                new XElement("YearOfPublish", _book.YearOfPublish),
                new XElement("GenreId", _book.Genre.Id),
                new XElement("Genre",
                    new XElement("Id", _book.Genre.Id),
                    new XElement("Name", _book.Genre.Name))));
            xDoc.Save(_xmlPathBooks);
        }

        public void DeleteBook(string bookName, string _xmlPath)
        {
            XDocument xDoc = XDocument.Load(_xmlPath);
            xDoc.Element("ArrayOfBook")
                .Elements("Book")
                .Where(x => (string)x.Element("Name") == bookName)
                .Remove();
            xDoc.Save(_xmlPath);
        }

        public List<T> ReturnAllItemsFromXml<T>(string _xmlPath) where T: class
        {
            Type[] _types = new Type[] { typeof(T) };
            List<T> _items = new List<T>();
            XmlSerializer reader = new XmlSerializer(_items.GetType(), _types);
            System.IO.StreamReader file = new System.IO.StreamReader(_xmlPath);
            _items = (List<T>)reader.Deserialize(file);
            file.Close();
            return _items;   
        }
    }
}