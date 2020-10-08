using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBooks.Storage;
using System.Xml.Linq;
using MyBooks.Models;

namespace MyBooks.Controllers
{
    public class HomeController : Controller
    {
        string _xmlPathBooks = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Books/MyBooks.xml";
        string _xmlPathGenres = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Books/Genres.xml";
        public ActionResult Index()
        {
            StartUp();
            List<Book> _books = new XMLStorage().ReturnAllItemsFromXml<Book>(_xmlPathBooks);
            ViewBag.Books = _books;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            return PartialView();
        }

        [HttpPost]
        public string AddBook(Book _book)
        {
            
            if (_book.BookId==0)
            {
                return "Wrong value: BookID. (cannot have a value of 0 and must be a numeric)";
            }
            if (IsBookExist(_book.BookId))
            {
                ViewBag.Message = "Wrong value: BookID. (already exist).";
                return "Wrong value: BookID. (already exist).";
            }
 
            if (_book.AuthorName==null || !IsTextHasWrongSymbols(_book.AuthorName))
            {
                return "Wrong value: Author Name. (has wrong symbols).";
            }
            if (_book.AuthorSurname==null || !IsTextHasWrongSymbols(_book.AuthorSurname))
            {
                return "Wrong value: Author Surname. (has wrong symbols).";
            }
            if (_book.YearOfPublish < 1500 || _book.YearOfPublish > DateTime.Now.Year)
            {
                return $"Wrng year. Year must be > 1500 or < {DateTime.Now.Year}";
            }
            if (!IsGenreExist(_book.GenreId))
            {
                return "Wrong value: Genre does not exist.";
            }
            _book.Genre = new XMLStorage().ReturnAllItemsFromXml<Genre>(_xmlPathGenres).Find(i => i.GenreId == _book.GenreId);
            new XMLStorage().AddBook(_book, _xmlPathBooks);
            return "Saved";
        }
        public void StartUp ()
        {
            if (System.IO.File.Exists(_xmlPathGenres) == false)
            {
                XDocument xdoc = new XDocument(new XElement("ArrayOfGenre"));
                xdoc.Save(_xmlPathGenres);
            }

            if (System.IO.File.Exists(_xmlPathBooks) == false)
            {
                XDocument xdoc = new XDocument(new XElement("ArrayOfBook"));
                xdoc.Save(_xmlPathBooks);
            }
        }


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

        bool IsGenreExist(int _userChoise)
        {
            List<Genre> _genres = new XMLStorage().ReturnAllItemsFromXml<Genre>(_xmlPathGenres);
            bool _checkIsValueExist = false;
            foreach (Genre i in _genres)
            {
                if (i.GenreId == _userChoise)
                {
                    _checkIsValueExist = true;
                }
            }
            return _checkIsValueExist;
        }

        bool IsBookExist(int _userChoise)
        {
            List<Book> _books = new XMLStorage().ReturnAllItemsFromXml<Book>(_xmlPathBooks);
            bool _checkIsValueExist = false;
            foreach (Book i in _books)
            {
                if (i.BookId == _userChoise)
                {
                    _checkIsValueExist = true;
                }
            }
            return _checkIsValueExist;
        }
    }
}