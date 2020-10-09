using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using MyBooks.Storage;

namespace MyBooks.Models
{
    public class ExtFunctions
    {
        public bool IsTextHasWrongSymbols(string _userInput)
        {
            bool _checker = true;
            foreach (char c in _userInput)
            {
                if (Char.IsNumber(c) || Char.IsPunctuation(c) || Char.IsWhiteSpace(c) || Char.IsSeparator(c) || Char.IsSurrogate(c) || Char.IsSymbol(c))
                {
                    _checker = false;
                }
            }
            return _checker;
        }
        public bool IsTextNumeric(string _userInput)
        {
            bool _checker = true;
            foreach (char c in _userInput)
            {
                if (!Char.IsNumber(c))
                {
                    _checker = false;
                }
            }
            return _checker;
        }

        public bool IsBookExist(string Name, string XmlPath)
        {
            List<Book> _items = new XMLStorage().ReturnAllItemsFromXml<Book>(XmlPath);
            return _items.Any(x => x.Name == Name);
        }

        public void CreateXmlFiles() //if xml files do not exist, create XML files
        {
            if (System.IO.File.Exists(Storages._xmlPathGenres) == false)
            {
                XDocument xDoc = new XDocument(new XElement("ArrayOfGenre"));
                xDoc.Element("ArrayOfGenre").Add(
                        new XElement("Genre",
                        new XElement("Id", Guid.NewGuid()),
                        new XElement("Name", "Science")));
                xDoc.Element("ArrayOfGenre").Add(
                        new XElement("Genre",
                        new XElement("Id", Guid.NewGuid()),
                        new XElement("Name", "Fantastic")));
                xDoc.Element("ArrayOfGenre").Add(
                       new XElement("Genre",
                       new XElement("Id", Guid.NewGuid()),
                       new XElement("Name", "Documentary")));
                xDoc.Element("ArrayOfGenre").Add(
                       new XElement("Genre",
                       new XElement("Id", Guid.NewGuid()),
                       new XElement("Name", "Detective")));
                xDoc.Element("ArrayOfGenre").Add(
                       new XElement("Genre",
                       new XElement("Id", Guid.NewGuid()),
                       new XElement("Name", "Drama")));
                xDoc.Save(Storages._xmlPathGenres);
            }

            if (System.IO.File.Exists(Storages._xmlPathBooks) == false)
            {
                XDocument xdoc = new XDocument(new XElement("ArrayOfBook"));
                xdoc.Save(Storages._xmlPathBooks);
            }
        }
    }
}