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
                        new XElement("GenreId", _genre.GenreId),
                        new XElement("Name", _genre.Name)));
            xDoc.Save(_xmlPathGenres);
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