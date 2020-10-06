using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBooks.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public int YearOfPublish { get; set; }
        public int GenreId { get; set; }
    }
}