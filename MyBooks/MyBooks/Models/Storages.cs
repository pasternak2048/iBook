using MyBooks.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.EnterpriseServices;

namespace MyBooks.Models
{
    public static class Storages
    {
        public static string _xmlPathBooks = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//MyBooks.xml";
        public static string _xmlPathGenres = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//Genres.xml";
        public static List<Book> Books => new XMLStorage().ReturnAllItemsFromXml<Book>(_xmlPathBooks);
        public static List<Genre> Genres => new XMLStorage().ReturnAllItemsFromXml<Genre>(_xmlPathGenres);
        static Storages()
        {
            SynchronizeXMLAsync();
        }
        static void SynchronizeXML() // Backup data
        {
            bool i = false;
            while (i == false)
            {
                List<Book> _backupBooks = new XMLStorage().ReturnAllItemsFromXml<Book>(_xmlPathBooks);
                List<Genre> _backupGenres = new XMLStorage().ReturnAllItemsFromXml<Genre>(_xmlPathGenres);
                
                Thread.Sleep(50000);
            }
        }
        static async Task SynchronizeXMLAsync()
        {
            await Task.Run(() => SynchronizeXML());
        }
    }
}