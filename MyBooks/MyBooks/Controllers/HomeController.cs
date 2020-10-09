using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBooks.Storage;
using System.Xml.Linq;
using MyBooks.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace MyBooks.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            new ExtFunctions().CreateXmlFiles();
            List<Book> _books = new XMLStorage().ReturnAllItemsFromXml<Book>(Storages._xmlPathBooks); //load all books from xml file
            ViewBag.Books = _books;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Database for books.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Yurii Pasternak.";

            return View();
        }

        [HttpGet]
        public ActionResult AddBook() 
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult DeleteBook()
        {
            return PartialView();
        }

        [HttpPost]
        public string AddBook(Book book) //add book to xml file
        {
            
            if (new ExtFunctions().IsBookExist(book.Name, Storages._xmlPathBooks))
            {
                return "Wrong value: Name. (already exist).";
            }
 
            if (book.AuthorName==null || !new ExtFunctions().IsTextHasWrongSymbols(book.AuthorName))
            {
                return "Wrong value: Author Name. (has wrong symbols).";
            }
            if (book.AuthorSurname==null || !new ExtFunctions().IsTextHasWrongSymbols(book.AuthorSurname))
            {
                return"Wrong value: Author Surname. (has wrong symbols).";
            }
            if (book.YearOfPublish < 1500 || book.YearOfPublish > DateTime.Now.Year)
            {
                return  $"Wrng year. Year must be > 1500 or < {DateTime.Now.Year}";
            }
            book.Genre = new XMLStorage().ReturnAllItemsFromXml<Genre>(Storages._xmlPathGenres).Find(i => i.Id == book.GenreId);
            new XMLStorage().AddBook(book, Storages._xmlPathBooks);
            
            return "Saved";
        }

        
        public string DeleteBook(string Name) //delete book from xml file
        {
            if (!new ExtFunctions().IsBookExist(Name, Storages._xmlPathBooks))
            {
                ViewBag.Message = "Wrong value: BookID. (does not exist).";
                return "Wrong value: Name. (does not exist).";
            }
            new XMLStorage().DeleteBook(Name, Storages._xmlPathBooks);
            return "Done!";
        }
    }
}