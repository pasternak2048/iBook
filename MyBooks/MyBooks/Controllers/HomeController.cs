using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBooks.Storage;
using System.Xml.Linq;

namespace MyBooks.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            StartUp();
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

        public void StartUp ()
        {
            string _xmlPathBooks = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Books/MyBooks.xml";
            string _xmlPathGenres = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Books/Genres.xml";
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
    }
}