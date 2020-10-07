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